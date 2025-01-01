namespace InternetShopApp.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string? Description { get; set; }

        public decimal Price { get; set; }

        public string Image { get; set; } = "images/no-image.jpg";

        public int CategoryId { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public Category? Category { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
