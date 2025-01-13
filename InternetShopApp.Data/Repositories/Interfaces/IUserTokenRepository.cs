using InternetShopApp.Data.Entities;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace InternetShopApp.Data.Repositories.Interfaces
{
    public interface IUserTokenRepository : IGenericRepository<UserToken>
    {
        Task<UserToken?> FindByTokenAsync(string refreshToken);
        Task<IEnumerable<UserToken>> FindByUserIdAsync(int userId);
        public  Task<UserToken?> FindByEmailAsync(string email);
    }
}

