
namespace InternetShopApp.Services.Interfaces.Auth
{
    public interface IEmailService
    {
        Task SendAsync(string to, string subject, string body);
    }

}
