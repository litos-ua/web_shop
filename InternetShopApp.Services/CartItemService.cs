using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Mapping;

namespace InternetShopApp.Services
{
    public class CartItemService : GenericService<InternetShopApp.Domain.Entities.CartItem, InternetShopApp.Data.Entities.CartItem>, ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository) : base(cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<IEnumerable<Domain.Entities.CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            var dataCartItems = await _cartItemRepository.GetCartItemsByCartIdAsync(cartId);
            return dataCartItems.Select(CartItemMapper.MapToDomain);
        }

        protected override Domain.Entities.CartItem MapToDomain(Data.Entities.CartItem dataEntity)
        {
            return CartItemMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.CartItem MapToData(Domain.Entities.CartItem domainEntity)
        {
            return CartItemMapper.MapToData(domainEntity);
        }
    }
}
