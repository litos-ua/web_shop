﻿//using Microsoft.EntityFrameworkCore;
//using System.ComponentModel.DataAnnotations;


//namespace InternetShopApp.Data.Entities
//{
//    public class User
//    {
//        public int Id { get; set; }

//        [Required]
//        [MaxLength(50)]
//        public string Username { get; set; }

//        [Required]
//        [MaxLength(100)]
//        [EmailAddress]
//        public string Email { get; set; }

//        [Required]
//        [MaxLength(100)]
//        public string? Fullname { get; set; }

//        [MaxLength(200)]
//        public string? Address { get; set; }

//        [Required]
//        [DataType(DataType.DateTime)]
//        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

//        public ICollection<Cart> Carts { get; set; } = new List<Cart>(); 
//        public ICollection<Order> Orders { get; set; } = new List<Order>(); 
//    }
//}


using System.ComponentModel.DataAnnotations;
using InternetShopApp.Domain.Entities.Enum;


namespace InternetShopApp.Data.Entities
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(100)]
        [EmailAddress]
        //[Index(IsUnique = true)]
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Fullname { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(15)]
        [Phone]
        public string? PhoneNumber { get; set; } 

        [Required]
        public UserRole Role { get; set; } = UserRole.User;

        public ICollection<Cart> Carts { get; set; } = new List<Cart>();
        public ICollection<Order> Orders { get; set; } = new List<Order>(); 
    }

}