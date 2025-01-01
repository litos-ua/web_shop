//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;

namespace InternetShopApp.Data.Repositories.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<Cart?> GetCartByUserIdAsync(int userId);
        Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId);
    }
}

