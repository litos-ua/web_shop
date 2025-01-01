using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopApp.Services.Mapping
{
    public static class CartMapper
    {
        public static InternetShopApp.Domain.Entities.Cart MapToDomain(InternetShopApp.Data.Entities.Cart dataCart)
        {
            return new InternetShopApp.Domain.Entities.Cart
            {
                Id = dataCart.Id,
                UserId = dataCart.UserId,
                IsActive = dataCart.IsActive,
                CreatedAt = dataCart.CreatedAt,
                User = dataCart.User == null ? null : UserMapper.MapToDomain(dataCart.User),
                CartItems = dataCart.CartItems.Select(CartItemMapper.MapToDomain).ToList()
            };
        }

        public static InternetShopApp.Data.Entities.Cart MapToData(InternetShopApp.Domain.Entities.Cart domainCart)
        {
            return new InternetShopApp.Data.Entities.Cart
            {
                Id = domainCart.Id,
                UserId = domainCart.UserId,
                IsActive = domainCart.IsActive,
                CreatedAt = domainCart.CreatedAt,
                User = domainCart.User == null ? null : UserMapper.MapToData(domainCart.User),
                CartItems = domainCart.CartItems.Select(CartItemMapper.MapToData).ToList()
            };
        }
    }
}
