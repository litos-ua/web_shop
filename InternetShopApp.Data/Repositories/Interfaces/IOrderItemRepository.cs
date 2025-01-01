//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;

namespace InternetShopApp.Data.Repositories.Interfaces
{
    public interface IOrderItemRepository : IGenericRepository<OrderItem>
    {
        Task<OrderItem> AddOrderItemAsync(OrderItem orderItem);
        Task<OrderItem> EditOrderItemAsync(OrderItem orderItem);
    }

}
