using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface IProductService : IGenericService<Product>
    {    
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId);
        Task<IEnumerable<Product>> GetProductsByNameAsync(string name);
    }
}



