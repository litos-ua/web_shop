using InternetShopApp.Domain.Entities.Enum;
using InternetShopApp.Services.Interfaces.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace InternetShopApp.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;

        public AuthService(IConfiguration configuration)
        {
            _configuration = configuration;
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
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
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
            var hashedInput = HashPassword(password);
            return hashedInput == hashedPassword;
        }
    }

}


//private string GenerateJwtToken(string email, UserRole role)
//{
//    var claims = new List<Claim>
//    {
//        new Claim(ClaimTypes.Email, email),
//        new Claim(ClaimTypes.Role, role.ToString()) // Добавляем роль как строку
//    };

//    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
//    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

//    var token = new JwtSecurityToken(
//        issuer: _configuration["Jwt:Issuer"],
//        audience: _configuration["Jwt:Audience"],
//        claims: claims,
//        expires: DateTime.UtcNow.AddHours(1),
//        signingCredentials: creds
//    );

//    return new JwtSecurityTokenHandler().WriteToken(token);
//}
