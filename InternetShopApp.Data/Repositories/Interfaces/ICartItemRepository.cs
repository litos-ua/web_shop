//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;

namespace InternetShopApp.Data.Repositories.Interfaces
{
    public interface ICartItemRepository : IGenericRepository<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
    }
}

