﻿
namespace InternetShopApp.Domain.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int ProductId { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;

        public Order? Order { get; set; }

        public Product? Product { get; set; }
    }
}
