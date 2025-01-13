using InternetShopApp.Services.Interfaces.Auth;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

public class EmailService : IEmailService
{
    private readonly string _smtpHost = "smtp.wp.pl";
    private readonly int _smtpPort = 465; // Обычно 587 для TLS или 465 для SSL
    private readonly string _smtpUsername = "litos-ua@wp.pl";
    private readonly string _smtpPassword = "lll409";

    public async Task SendAsync(string to, string subject, string body)
    {
        using (var client = new SmtpClient(_smtpHost, _smtpPort))
        {
            client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            client.EnableSsl = true;

            var mailMessage = new MailMessage
            {
                From = new MailAddress(_smtpUsername),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mailMessage.To.Add(to);

            await client.SendMailAsync(mailMessage);
        }
    }
}

