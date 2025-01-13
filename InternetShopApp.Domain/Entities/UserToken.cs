using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InternetShopApp.Domain.Entities
{
    public class UserToken
    {
        public int Id { get; set; }

        public int UserId { get; set; } // Связь с пользователем

        // Максимальная длина токена
        public string Token { get; set; } // Хранится RefreshToken

        public DateTime ExpiresAt { get; set; } = DateTime.UtcNow.AddDays(1); // Срок действия токена (по умолчанию 1 день)

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Дата создания токена (по умолчанию текущая)

        // Длина IP-адреса IPv4/IPv6
        public string? CreatedByIp { get; set; } // IP-адрес, с которого был создан токен (необязательное поле)

        public DateTime? RevokedAt { get; set; } // Дата отзыва токена (может быть null)

        // Длина IP-адреса IPv4/IPv6
        public string? RevokedByIp { get; set; } // IP-адрес, с которого токен был отозван (необязательное поле)

        // Это поле не будет сохранено в базе данных
        public bool IsActive => RevokedAt == null && DateTime.UtcNow < ExpiresAt; // Проверка активности токена

        // Навигационное свойство для связи с пользователем
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}

