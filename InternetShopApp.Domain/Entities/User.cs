
using System.ComponentModel.DataAnnotations;


namespace InternetShopApp.Domain.Entities
{
    public class User
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string? Fullname { get; set; }

        public string? Address { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public ICollection<Cart> Carts { get; set; } = new List<Cart>(); 
        public ICollection<Order> Orders { get; set; } = new List<Order>(); 
    }
}
