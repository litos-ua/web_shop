using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Mapping;


namespace InternetShopApp.Services
{
    public class CategoryService : GenericService<Domain.Entities.Category, Data.Entities.Category>, ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository) : base(categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Domain.Entities.Category?> GetCategoryWithProductsByIdAsync(int categoryId)
        {
            var dataCategory = await _categoryRepository.GetCategoryWithProductsByIdAsync(categoryId);
            return dataCategory == null ? null : CategoryMapper.MapToDomain(dataCategory);
        }

        protected override Domain.Entities.Category MapToDomain(Data.Entities.Category dataEntity)
        {
            return CategoryMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.Category MapToData(Domain.Entities.Category domainEntity)
        {
            return CategoryMapper.MapToData(domainEntity);
        }
    }
}





