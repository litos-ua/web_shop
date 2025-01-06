
//using System.ComponentModel.DataAnnotations;


//namespace InternetShopApp.Domain.Entities
//{
//public class User
//{
//    public int Id { get; set; }

//    public string Username { get; set; }

//    public string Email { get; set; }

//    public string? Fullname { get; set; }

//    public string? Address { get; set; }

//    public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

//    public ICollection<Cart> Carts { get; set; } = new List<Cart>();
//    public ICollection<Order> Orders { get; set; } = new List<Order>();
//}
//}


//using InternetShopApp.Domain.Entities.Enum;


//namespace InternetShopApp.Domain.Entities
//{
//    public class User
//    {
//        public int Id { get; set; }

//        public string Username { get; set; }

//        public string Email { get; set; }

//        public string PasswordHash { get; set; }

//        public string? Fullname { get; set; }

//        public string? Address { get; set; }

//        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

//        public string? PhoneNumber { get; set; } = string.Empty;

//        public UserRole Role { get; set; } = UserRole.User;

//        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
//        public ICollection<Order> Orders { get; set; } = new List<Order>();
//    }
//}

using InternetShopApp.Domain.Entities.Enum;

namespace InternetShopApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string? Fullname { get; set; }

        public string? Address { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public string? PhoneNumber { get; set; } = string.Empty;

        public UserRole Role { get; set; } = UserRole.User;

        // Поля для email-аутентификации
        //public string? EmailVerificationToken { get; set; } // Токен для подтверждения email

        //public DateTime? EmailVerifiedAt { get; set; } // Дата и время подтверждения email (null, если не подтвержден)

        // Связь с токенами
        public ICollection<UserToken> UserTokens { get; set; } = new List<UserToken>();

        // Навигационные свойства для связанных сущностей
        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
