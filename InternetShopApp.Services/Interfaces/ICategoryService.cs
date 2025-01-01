using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services.Interfaces
{
    public interface ICategoryService : IGenericService<Category>
    {
        Task<Category?> GetCategoryWithProductsByIdAsync(int categoryId);
    }
}





