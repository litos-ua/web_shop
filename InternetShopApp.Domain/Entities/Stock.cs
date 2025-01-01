
using System.ComponentModel.DataAnnotations;

namespace InternetShopApp.Domain.Entities
{
    public class Stock
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public Product? Product { get; set; }
    }

}
