
using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface ICartItemService : IGenericService<CartItem>
    {
        Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId);
    }
}




