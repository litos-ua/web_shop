using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface ICartService : IGenericService<Cart>
    {
        Task<IEnumerable<Cart>> GetCartsByProductIdAsync(int productId);
    }
}


