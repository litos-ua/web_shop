using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InternetShopApp.Services.Mapping
{
    public static class UserMapper
    {
        public static InternetShopApp.Domain.Entities.User MapToDomain(InternetShopApp.Data.Entities.User dataUser)
        {
            return new InternetShopApp.Domain.Entities.User
            {
                Id = dataUser.Id,
                Username = dataUser.Username,
                Email = dataUser.Email,
                Fullname = dataUser.Fullname,
                Address = dataUser.Address,
                CreatedAt = dataUser.CreatedAt,
                Carts = dataUser.Carts.Select(CartMapper.MapToDomain).ToList(),
                Orders = dataUser.Orders.Select(OrderMapper.MapToDomain).ToList()
            };
        }

        public static InternetShopApp.Data.Entities.User MapToData(InternetShopApp.Domain.Entities.User domainUser)
        {
            return new InternetShopApp.Data.Entities.User
            {
                Id = domainUser.Id,
                Username = domainUser.Username,
                Email = domainUser.Email,
                Fullname = domainUser.Fullname,
                Address = domainUser.Address,
                CreatedAt = domainUser.CreatedAt,
                Carts = domainUser.Carts.Select(CartMapper.MapToData).ToList(),
                Orders = domainUser.Orders.Select(OrderMapper.MapToData).ToList()
            };
        }
    }
}
