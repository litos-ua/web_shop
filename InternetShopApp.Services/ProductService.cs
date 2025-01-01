using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Mapping;

namespace InternetShopApp.Services
{
    public class ProductService : GenericService<Domain.Entities.Product, Data.Entities.Product>, IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository) : base(productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Product>> GetProductsByCategoryAsync(int categoryId)
        {
            var dataProducts = await _productRepository.GetProductsByCategoryAsync(categoryId);
            return dataProducts.Select(ProductMapper.MapToDomain);
        }

        public async Task<IEnumerable<Domain.Entities.Product>> GetProductsByNameAsync(string name)
        {
            var dataProducts = await _productRepository.GetProductsByNameAsync(name);
            return dataProducts.Select(ProductMapper.MapToDomain);
        }

        protected override Domain.Entities.Product MapToDomain(Data.Entities.Product dataEntity)
        {
            return ProductMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.Product MapToData(Domain.Entities.Product domainEntity)
        {
            return ProductMapper.MapToData(domainEntity);
        }
    }
}


