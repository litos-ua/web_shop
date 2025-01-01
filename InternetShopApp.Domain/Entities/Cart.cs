using System.ComponentModel.DataAnnotations;


namespace InternetShopApp.Domain.Entities
{
    public class Cart
    {
        public int Id { get; set; }

        public int UserId { get; set; } 

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow; 

        public bool IsActive { get; set; } = true; 

        public User? User { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>(); 
    }

}
