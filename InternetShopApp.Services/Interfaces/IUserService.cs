using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface IUserService : IGenericService<Domain.Entities.User>
    {

        Task<Domain.Entities.User?> GetByEmailAsync(string email);
        Task<Domain.Entities.Cart?> GetCartByUserIdAsync(int userId);
        Task<IEnumerable<Domain.Entities.Order>> GetOrdersByUserIdAsync(int userId);
    }
}



