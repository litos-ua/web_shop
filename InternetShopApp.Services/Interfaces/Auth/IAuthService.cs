using InternetShopApp.Domain.Entities.Enum;


namespace InternetShopApp.Services.Interfaces.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, UserRole role);
        string HashPassword(string password);
        bool VerifyPassword(string password, string passwordHash);
    }

}
