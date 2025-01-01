//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;

namespace InternetShopApp.Data.Repositories.Interfaces
{
    public interface ICartRepository : IGenericRepository<Cart>
    {
        Task<IEnumerable<Cart>> GetCartsByProductIdAsync(int productId);
    }
}

