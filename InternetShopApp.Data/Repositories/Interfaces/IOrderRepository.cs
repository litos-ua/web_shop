//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;

namespace InternetShopApp.Data.Repositories.Interfaces
{
    public interface IOrderRepository : IGenericRepository<Order>
    {
        Task<IEnumerable<Order>> GetOrdersWithItemsAsync();
        Task<Order?> GetOrderWithItemsByIdAsync(int id);
    }
}

