using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Mapping;

namespace InternetShopApp.Services
{
    public class UserService : GenericService<Domain.Entities.User, Data.Entities.User>, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<Domain.Entities.Cart?> GetCartByUserIdAsync(int userId)
        {
            var cartData = await _userRepository.GetCartByUserIdAsync(userId);
            return cartData != null ? CartMapper.MapToDomain(cartData) : null;
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetOrdersByUserIdAsync(int userId)
        {
            var orderDataList = await _userRepository.GetOrdersByUserIdAsync(userId);
            return orderDataList.Select(OrderMapper.MapToDomain);
        }

        protected override Domain.Entities.User MapToDomain(Data.Entities.User dataEntity)
        {
            return UserMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.User MapToData(Domain.Entities.User domainEntity)
        {
            return UserMapper.MapToData(domainEntity);
        }
    }
}



