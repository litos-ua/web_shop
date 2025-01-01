using InternetShopApp.Data.Repositories.Interfaces;
//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data.Repositories
{
    public class OrderItemRepository : GenericRepository<OrderItem>, IOrderItemRepository
    {
        private readonly InternetShopContext _context;

        public OrderItemRepository(InternetShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<OrderItem> AddOrderItemAsync(OrderItem orderItem)
        {
            // Getting prise of Product
            var product = await _context.Products.FindAsync(orderItem.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {orderItem.ProductId} not found.");
            }

            orderItem.Price = product.Price;
            orderItem.Total = product.Price * orderItem.Quantity;

            _context.OrderItems.Add(orderItem);
            await _context.SaveChangesAsync();

            return orderItem;
        }

        public async Task<OrderItem> EditOrderItemAsync(OrderItem orderItem)
        {
            var existingOrderItem = await _context.OrderItems.FindAsync(orderItem.Id);
            if (existingOrderItem == null)
            {
                throw new KeyNotFoundException($"OrderItem with ID {orderItem.Id} not found.");
            }

            var product = await _context.Products.FindAsync(orderItem.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {orderItem.ProductId} not found.");
            }

            existingOrderItem.Price = product.Price;
            existingOrderItem.Total = product.Price * orderItem.Quantity;

            existingOrderItem.OrderId = orderItem.OrderId;
            existingOrderItem.Quantity = orderItem.Quantity;
            existingOrderItem.CreatedAt = orderItem.CreatedAt;

            _context.OrderItems.Update(existingOrderItem);
            await _context.SaveChangesAsync();

            return existingOrderItem;
        }
    }

}
