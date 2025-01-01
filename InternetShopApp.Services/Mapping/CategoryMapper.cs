using static System.Runtime.InteropServices.JavaScript.JSType;
//using InternetShopApp.Domain.Entities;

namespace InternetShopApp.Services.Mapping
{
    public static class CategoryMapper
    {
        public static InternetShopApp.Domain.Entities.Category MapToDomain(InternetShopApp.Data.Entities.Category dataCategory)
        {
            return new InternetShopApp.Domain.Entities.Category
            {
                Id = dataCategory.Id,
                Name = dataCategory.Name,
                Description = dataCategory.Description,
                CreatedAt = dataCategory.CreatedAt,
                Products = dataCategory.Products.Select(ProductMapper.MapToDomain).ToList()
            };
        }

        public static InternetShopApp.Data.Entities.Category MapToData(InternetShopApp.Domain.Entities.Category domainCategory)
        {
            return new InternetShopApp.Data.Entities.Category
            {
                Id = domainCategory.Id,
                Name = domainCategory.Name,
                Description = domainCategory.Description,
                CreatedAt = domainCategory.CreatedAt,
                Products = domainCategory.Products.Select(ProductMapper.MapToData).ToList()
            };
        }
    }
}

