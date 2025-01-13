//using InternetShopApp.Domain.Entities.Enum;


//namespace InternetShopApp.Services.Interfaces.Auth
//{
//    public interface IAuthService
//    {
//        string GenerateJwtToken(string email, UserRole role);
//        string GenerateVerificationToken(string email);
//        string HashPassword(string password);
//        bool VerifyPassword(string password, string passwordHash);
//    }

//}

//using InternetShopApp.Domain.Entities.DTOs;
//using InternetShopApp.Domain.Entities.Enum;
//using System.Security.Claims;

//namespace InternetShopApp.Services.Interfaces.Auth
//{
//    public interface IAuthService
//    {
//        string GenerateJwtToken(string email, UserRole role);
//        string GenerateRefreshToken();
//        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
//        (string AccessToken, string RefreshToken) RefreshTokens(string accessToken, string refreshToken);

//        bool RevokeRefreshToken(string email);

//        string HashPassword(string password);
//        bool VerifyPassword(string password, string hashedPassword);
//        string GenerateVerificationToken(string email);
//    }
//}

//using InternetShopApp.Domain.Entities.DTOs;
//using InternetShopApp.Domain.Entities.Enum;
//using System.Security.Claims;

//namespace InternetShopApp.Services.Interfaces.Auth
//{
//    public interface IAuthService
//    {
//        string GenerateJwtToken(string email, UserRole role);
//        string GenerateRefreshToken();
//        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
//        public TokenApiResponse? RefreshTokens(string accessToken, string refreshToken);

//        public bool RevokeRefreshToken(string accessToken, string refreshToken);

//        string HashPassword(string password);
//        bool VerifyPassword(string password, string hashedPassword);
//        string GenerateVerificationToken(string email);
//    }
//}


using InternetShopApp.Domain.Entities.DTOs;
using InternetShopApp.Domain.Entities.Enum;
using System.Security.Claims;

namespace InternetShopApp.Services.Interfaces.Auth
{
    public interface IAuthService : IGenericService<Domain.Entities.UserToken>
    {
        string GenerateJwtToken(string email, UserRole role);
        string GenerateRefreshToken();
        Task SaveRefreshTokenAsync(int userId, string refreshToken);

        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
        public TokenApiResponse? RefreshTokens(string accessToken, string refreshToken);

        //public bool RevokeRefreshToken(string accessToken, string refreshToken);
        public bool RevokeRefreshToken(string accessToken);

        string HashPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
        string GenerateVerificationToken(string email);
    }
}