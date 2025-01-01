

using InternetShopApp.Services.Mapping;

namespace InternetShopApp.Services.Mapping
{
    public static class ProductMapper
    {
        public static InternetShopApp.Domain.Entities.Product MapToDomain(InternetShopApp.Data.Entities.Product dataProduct)
        {
            return new InternetShopApp.Domain.Entities.Product
            {
                Id = dataProduct.Id,
                Name = dataProduct.Name,
                Description = dataProduct.Description,
                Price = dataProduct.Price,
                Image = dataProduct.Image,
                CategoryId = dataProduct.CategoryId,
                CreatedAt = dataProduct.CreatedAt,
                Category = dataProduct.Category == null ? null : CategoryMapper.MapToDomain(dataProduct.Category),
                CartItems = dataProduct.CartItems.Select(CartItemMapper.MapToDomain).ToList(),
                OrderItems = dataProduct.OrderItems.Select(OrderItemMapper.MapToDomain).ToList()
            };
        }

        public static InternetShopApp.Data.Entities.Product MapToData(InternetShopApp.Domain.Entities.Product domainProduct)
        {
            return new InternetShopApp.Data.Entities.Product
            {
                Id = domainProduct.Id,
                Name = domainProduct.Name,
                Description = domainProduct.Description,
                Price = domainProduct.Price,
                Image = domainProduct.Image,
                CategoryId = domainProduct.CategoryId,
                CreatedAt = domainProduct.CreatedAt,
                Category = domainProduct.Category == null ? null : CategoryMapper.MapToData(domainProduct.Category),
                CartItems = domainProduct.CartItems.Select(CartItemMapper.MapToData).ToList(),
                OrderItems = domainProduct.OrderItems.Select(OrderItemMapper.MapToData).ToList()
            };
        }
    }
}


