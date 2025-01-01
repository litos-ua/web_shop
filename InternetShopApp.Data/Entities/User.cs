using System.ComponentModel.DataAnnotations;


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
        public string Email { get; set; }

        [Required]
        [MaxLength(100)]
        public string? Fullname { get; set; }

        [MaxLength(200)]
        public string? Address { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Cart> Carts { get; set; } = new List<Cart>(); 
        public ICollection<Order> Orders { get; set; } = new List<Order>(); 
    }
}
