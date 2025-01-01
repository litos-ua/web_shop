namespace InternetShopApp.Services.Mapping
{
    public static class OrderMapper
    {
        public static InternetShopApp.Domain.Entities.Order MapToDomain(InternetShopApp.Data.Entities.Order dataOrder)
        {
            return new InternetShopApp.Domain.Entities.Order
            {
                Id = dataOrder.Id,
                UserId = dataOrder.UserId,
                Amount = dataOrder.Amount,
                DeliveryRequirement = dataOrder.DeliveryRequirement,
                ReceivedStatus = dataOrder.ReceivedStatus,
                TypeOfPayment = dataOrder.TypeOfPayment,
                PaymentStatus = dataOrder.PaymentStatus,
                CreatedAt = dataOrder.CreatedAt,
                User = dataOrder.User == null ? null : UserMapper.MapToDomain(dataOrder.User),
                OrderItems = dataOrder.OrderItems.Select(OrderItemMapper.MapToDomain).ToList()
            };
        }

        public static InternetShopApp.Data.Entities.Order MapToData(InternetShopApp.Domain.Entities.Order domainOrder)
        {
            return new InternetShopApp.Data.Entities.Order
            {
                Id = domainOrder.Id,
                UserId = domainOrder.UserId,
                Amount = domainOrder.Amount,
                DeliveryRequirement = domainOrder.DeliveryRequirement,
                ReceivedStatus = domainOrder.ReceivedStatus,
                TypeOfPayment = domainOrder.TypeOfPayment,
                PaymentStatus = domainOrder.PaymentStatus,
                CreatedAt = domainOrder.CreatedAt,
                User = domainOrder.User == null ? null : UserMapper.MapToData(domainOrder.User),
                OrderItems = domainOrder.OrderItems.Select(OrderItemMapper.MapToData).ToList()
            };
        }
    }
}

