using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Mapping;

namespace InternetShopApp.Services
{
    public class CartService : GenericService<Domain.Entities.Cart, Data.Entities.Cart>, ICartService
    {
        private readonly ICartRepository _cartRepository;

        public CartService(ICartRepository cartRepository) : base(cartRepository)
        {
            _cartRepository = cartRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Cart>> GetCartsByProductIdAsync(int productId)
        {
            var dataCarts = await _cartRepository.GetCartsByProductIdAsync(productId);
            return dataCarts.Select(CartMapper.MapToDomain);
        }

        protected override Domain.Entities.Cart MapToDomain(Data.Entities.Cart dataEntity)
        {
            return CartMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.Cart MapToData(Domain.Entities.Cart domainEntity)
        {
            return CartMapper.MapToData(domainEntity);
        }
    }
}



