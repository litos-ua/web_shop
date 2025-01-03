//using System.Data;


//namespace InternetShopApp.Services.Mapping
//{
//    public static class UserMapper
//    {
//        public static Domain.Entities.User MapToDomain(Data.Entities.User dataUser)
//        {
//            return new InternetShopApp.Domain.Entities.User
//            {
//                Id = dataUser.Id,
//                Username = dataUser.Username,
//                Email = dataUser.Email,
//                Fullname = dataUser.Fullname,
//                Address = dataUser.Address,
//                CreatedAt = dataUser.CreatedAt,
//                Carts = dataUser.Carts.Select(CartMapper.MapToDomain).ToList(),
//                Orders = dataUser.Orders.Select(OrderMapper.MapToDomain).ToList()
//            };
//        }

//        public static Data.Entities.User MapToData(Domain.Entities.User domainUser)
//        {
//            return new Data.Entities.User
//            {
//                Id = domainUser.Id,
//                Username = domainUser.Username,
//                Email = domainUser.Email,
//                Fullname = domainUser.Fullname,
//                Address = domainUser.Address,
//                CreatedAt = domainUser.CreatedAt,
//                Carts = domainUser.Carts.Select(CartMapper.MapToData).ToList(),
//                Orders = domainUser.Orders.Select(OrderMapper.MapToData).ToList()
//            };
//        }
//    }
//}

using System.Data;

namespace InternetShopApp.Services.Mapping
{
    public static class UserMapper
    {
        public static Domain.Entities.User MapToDomain(Data.Entities.User dataUser)
        {
            return new Domain.Entities.User
            {
                Id = dataUser.Id,
                Username = dataUser.Username,
                Email = dataUser.Email,
                PasswordHash = dataUser.PasswordHash, 
                Fullname = dataUser.Fullname,
                Address = dataUser.Address,
                CreatedAt = dataUser.CreatedAt,
                PhoneNumber = dataUser.PhoneNumber, 
                Role = dataUser.Role, 
                Carts = dataUser.Carts.Select(CartMapper.MapToDomain).ToList(),
                Orders = dataUser.Orders.Select(OrderMapper.MapToDomain).ToList()
            };
        }

        public static Data.Entities.User MapToData(Domain.Entities.User domainUser)
        {
            return new Data.Entities.User
            {
                Id = domainUser.Id,
                Username = domainUser.Username,
                Email = domainUser.Email,
                PasswordHash = domainUser.PasswordHash, 
                Fullname = domainUser.Fullname,
                Address = domainUser.Address,
                CreatedAt = domainUser.CreatedAt,
                PhoneNumber = domainUser.PhoneNumber, 
                Role = domainUser.Role, 
                Carts = domainUser.Carts.Select(CartMapper.MapToData).ToList(),
                Orders = domainUser.Orders.Select(OrderMapper.MapToData).ToList()
            };
        }
    }
}

