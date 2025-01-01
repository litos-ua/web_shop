using System.Linq.Expressions;
using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;

namespace InternetShopApp.Services
{
    public abstract class GenericService<TDomain, TData> : IGenericService<TDomain>
        where TDomain : class
        where TData : class
    {
        private readonly IGenericRepository<TData> _repository;

        protected GenericService(IGenericRepository<TData> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<TDomain>> GetAllAsync()
        {
            var dataEntities = await _repository.GetAllAsync();
            return dataEntities.Select(MapToDomain);
        }

        public async Task<TDomain?> GetByIdAsync(int id)
        {
            var dataEntity = await _repository.GetByIdAsync(id);
            return dataEntity == null ? null : MapToDomain(dataEntity);
        }

        public async Task AddAsync(TDomain entity)
        {
            var dataEntity = MapToData(entity);
            await _repository.AddAsync(dataEntity);
        }

        public async Task UpdateAsync(TDomain entity)
        {
            var dataEntity = MapToData(entity);
            await _repository.UpdateAsync(dataEntity);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }

        public async Task<IEnumerable<TDomain>> FindAsync(Expression<Func<TDomain, bool>> predicate)
        {
            throw new NotImplementedException("Mapping predicates between domain and data is not supported.");
        }

        
        protected abstract TDomain MapToDomain(TData dataEntity);

        
        protected abstract TData MapToData(TDomain domainEntity);
    }
}





