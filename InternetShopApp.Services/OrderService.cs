using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Mapping;
using InternetShopApp.Data.Repositories.Interfaces;

namespace InternetShopApp.Services
{
    public class OrderService : GenericService<Domain.Entities.Order, Data.Entities.Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository) : base(orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Domain.Entities.Order>> GetOrdersWithItemsAsync()
        {
            var dataOrders = await _orderRepository.GetOrdersWithItemsAsync();
            return dataOrders.Select(OrderMapper.MapToDomain);
        }

        public async Task<Domain.Entities.Order?> GetOrderWithItemsByIdAsync(int id)
        {
            var dataOrder = await _orderRepository.GetOrderWithItemsByIdAsync(id);
            return dataOrder == null ? null : OrderMapper.MapToDomain(dataOrder);
        }

        protected override Domain.Entities.Order MapToDomain(Data.Entities.Order dataEntity)
        {
            return OrderMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.Order MapToData(Domain.Entities.Order domainEntity)
        {
            return OrderMapper.MapToData(domainEntity);
        }
    }
}


