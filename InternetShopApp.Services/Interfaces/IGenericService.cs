using System.Linq.Expressions;

namespace InternetShopApp.Services.Interfaces
{
    public interface IGenericService<TDomain> where TDomain : class
    {
        Task<IEnumerable<TDomain>> GetAllAsync();
        Task<TDomain?> GetByIdAsync(int id);
        Task AddAsync(TDomain entity);
        Task UpdateAsync(TDomain entity);
        Task DeleteAsync(int id);
        Task<IEnumerable<TDomain>> FindAsync(Expression<Func<TDomain, bool>> predicate);
    }
}





