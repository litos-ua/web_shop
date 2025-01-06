using System.ComponentModel.DataAnnotations.Schema;



namespace InternetShopApp.Domain.Entities
{
    public class UserToken
    {
        public int Id { get; set; }

        public int UserId { get; set; } 

        public string Token { get; set; } 

        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(1); 

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; 

        public string? CreatedByIp { get; set; } 

        public DateTime? RevokedAt { get; set; } 

        public string? RevokedByIp { get; set; } 

        public bool IsActive => RevokedAt == null && DateTime.UtcNow < ExpiresAt; 

    
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
