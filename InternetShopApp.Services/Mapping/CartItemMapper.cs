
namespace InternetShopApp.Services.Mapping
{
    public static class CartItemMapper
    {
        public static InternetShopApp.Domain.Entities.CartItem MapToDomain(InternetShopApp.Data.Entities.CartItem dataCartItem)
        {
            return new InternetShopApp.Domain.Entities.CartItem
            {
                Id = dataCartItem.Id,
                CartId = dataCartItem.CartId,
                ProductId = dataCartItem.ProductId,
                Quantity = dataCartItem.Quantity,
                CreatedAt = dataCartItem.CreatedAt,
                Cart = dataCartItem.Cart == null ? null : CartMapper.MapToDomain(dataCartItem.Cart),
                Product = dataCartItem.Product == null ? null : ProductMapper.MapToDomain(dataCartItem.Product)
            };
        }

        public static InternetShopApp.Data.Entities.CartItem MapToData(InternetShopApp.Domain.Entities.CartItem domainCartItem)
        {
            return new InternetShopApp.Data.Entities.CartItem
            {
                Id = domainCartItem.Id,
                CartId = domainCartItem.CartId,
                ProductId = domainCartItem.ProductId,
                Quantity = domainCartItem.Quantity,
                CreatedAt = domainCartItem.CreatedAt,
                Cart = domainCartItem.Cart == null ? null : CartMapper.MapToData(domainCartItem.Cart),
                Product = domainCartItem.Product == null ? null : ProductMapper.MapToData(domainCartItem.Product)
            };
        }
    }
}
