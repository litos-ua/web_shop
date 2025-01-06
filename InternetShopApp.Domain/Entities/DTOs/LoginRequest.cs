
using System.ComponentModel.DataAnnotations;

namespace InternetShopApp.Domain.Entities.DTOs
{
    public class LoginRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(8)]
        public string PasswordHash { get; set; }
    }
}
