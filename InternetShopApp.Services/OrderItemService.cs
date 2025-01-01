using InternetShopApp.Services.Interfaces;
using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Mapping;

namespace InternetShopApp.Services
{
    public class OrderItemService : GenericService<Domain.Entities.OrderItem, Data.Entities.OrderItem>, IOrderItemService
    {
        private readonly IOrderItemRepository _repository;
        private readonly IProductRepository _productRepository;

        public OrderItemService(
            IOrderItemRepository repository,
            IProductRepository productRepository) : base(repository)
        {
            _repository = repository;
            _productRepository = productRepository;
        }

        public async Task<Domain.Entities.OrderItem> AddOrderItemAsync(Domain.Entities.OrderItem orderItem)
        {
            var product = await _productRepository.GetByIdAsync(orderItem.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {orderItem.ProductId} not found.");
            }

            var dataOrderItem = OrderItemMapper.MapToData(orderItem);
            dataOrderItem.Price = product.Price;
            dataOrderItem.Total = product.Price * dataOrderItem.Quantity;

            var savedOrderItem = await _repository.AddAsync(dataOrderItem);
            return OrderItemMapper.MapToDomain(savedOrderItem);
        }

        public async Task<InternetShopApp.Domain.Entities.OrderItem> UpdateOrderItemAsync(Domain.Entities.OrderItem orderItem)
        {
            var existingOrderItem = await _repository.GetByIdAsync(orderItem.Id);
            if (existingOrderItem == null)
            {
                throw new KeyNotFoundException($"OrderItem with ID {orderItem.Id} not found.");
            }

            var product = await _productRepository.GetByIdAsync(orderItem.ProductId);
            if (product == null)
            {
                throw new KeyNotFoundException($"Product with ID {orderItem.ProductId} not found.");
            }

            existingOrderItem.Price = product.Price;
            existingOrderItem.Total = product.Price * orderItem.Quantity;
            existingOrderItem.Quantity = orderItem.Quantity;

            var updatedOrderItem = await _repository.EditOrderItemAsync(existingOrderItem);
            return OrderItemMapper.MapToDomain(updatedOrderItem);
        }

        protected override Domain.Entities.OrderItem MapToDomain(Data.Entities.OrderItem dataEntity)
        {
            return OrderItemMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.OrderItem MapToData(Domain.Entities.OrderItem domainEntity)
        {
            return OrderItemMapper.MapToData(domainEntity);
        }
    }
}

