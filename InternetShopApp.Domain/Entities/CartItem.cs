using System.ComponentModel.DataAnnotations;


namespace InternetShopApp.Domain.Entities
{
    public class CartItem
    {
        public int Id { get; set; }

        public int CartId { get; set; } 

        public int ProductId { get; set; } 

        public int Quantity { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public Cart? Cart { get; set; } 
        public Product? Product { get; set; } 
    }
}
