
using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Domain.Entities;
using InternetShopApp.Domain.Entities.DTOs;
using InternetShopApp.Domain.Entities.Enum;
using InternetShopApp.Data.Entities;
using InternetShopApp.Services.Interfaces.Auth;
using InternetShopApp.Services.Mapping;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using InternetShopApp.Data.Repositories;

namespace InternetShopApp.Services.Auth
{
    public class AuthService : GenericService<Domain.Entities.UserToken, Data.Entities.UserToken>, IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(
            IConfiguration configuration,
            IUserTokenRepository userTokenRepository,
            IHttpContextAccessor httpContextAccessor) : base(userTokenRepository)
        {
            _configuration = configuration;
            _userTokenRepository = userTokenRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public string GenerateJwtToken(string email, UserRole role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Role, role.ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                Issuer = _configuration["Jwt:Issuer"], 
                Audience = _configuration["Jwt:Audience"], 
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }

        public async Task SaveRefreshTokenAsync(int userId, string refreshToken)
        {
            var userTokenDomain = new Domain.Entities.UserToken
            {
                UserId = userId,
                Token = refreshToken,
                CreatedAt = DateTime.UtcNow,
                ExpiresAt = DateTime.UtcNow.AddDays(7) // Задайте срок действия токена
            };

            var userTokenData = MapToData(userTokenDomain);
            await _userTokenRepository.AddAsync(userTokenData);
        }

        public ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Secret"]);

            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,
                ValidateIssuer = false,
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateLifetime = false
            };

            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out var securityToken);

            if (securityToken is not JwtSecurityToken jwtSecurityToken ||
                !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new SecurityTokenException("Invalid token");
            }

            return principal;
        }

        //public bool RevokeRefreshToken(string accessToken, string refreshToken)
        //{
        //    var principal = GetPrincipalFromExpiredToken(accessToken);
        //    var email = principal.FindFirstValue(ClaimTypes.Email);

        //    if (string.IsNullOrEmpty(email)) return false;

        //    var userToken = _userTokenRepository.FindByTokenAsync(refreshToken).Result;

        //    if (userToken == null || userToken.User.Email != email || !userToken.IsActive) return false;

        //    userToken.RevokedAt = DateTime.UtcNow;
        //    _userTokenRepository.UpdateAsync(userToken);
        //    return true;
        //}

        public bool RevokeRefreshToken(string accessToken)
        {
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var email = principal?.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email)) return false;

            // Ищем refreshToken в репозитории
            var userToken = _userTokenRepository.FindByEmailAsync(email).Result;

            if (userToken == null || !userToken.IsActive) return false;

            // Проверяем, связан ли refreshToken с пользователем
            if (userToken.User.Email != email) return false;

            // Помечаем refreshToken как отозванный
            userToken.RevokedAt = DateTime.UtcNow;
            _userTokenRepository.UpdateAsync(userToken);
            return true;
        }


        public TokenApiResponse? RefreshTokens(string accessToken, string refreshToken)
        {
            var principal = GetPrincipalFromExpiredToken(accessToken);
            var email = principal.FindFirstValue(ClaimTypes.Email);

            if (string.IsNullOrEmpty(email)) return null;

            var userToken = _userTokenRepository.FindByTokenAsync(refreshToken).Result;

            if (userToken == null || userToken.User.Email != email || !userToken.IsActive) return null;

            var newAccessToken = GenerateJwtToken(email, UserRole.User); // Role can be adjusted
            var newRefreshToken = GenerateRefreshToken();

            userToken.Token = newRefreshToken;
            userToken.CreatedAt = DateTime.UtcNow;
            userToken.ExpiresAt = DateTime.UtcNow.AddDays(1);

            _userTokenRepository.UpdateAsync(userToken);

            return new TokenApiResponse
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return HashPassword(password) == hashedPassword;
        }

        public string GenerateVerificationToken(string email)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Email, email) }),
                Expires = DateTime.UtcNow.AddHours(24),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        private string GetClientIp()
        {
            return _httpContextAccessor.HttpContext?.Connection?.RemoteIpAddress?.ToString() ?? "Unknown";
        }

        protected override Domain.Entities.UserToken MapToDomain(Data.Entities.UserToken dataEntity)
        {
            return UserTokenMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.UserToken MapToData(Domain.Entities.UserToken domainEntity)
        {
            return UserTokenMapper.MapToData(domainEntity);
        }
    }
}









