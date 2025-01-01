namespace InternetShopApp.Services.Mapping
{
    public static class OrderItemMapper
    {
        public static InternetShopApp.Domain.Entities.OrderItem MapToDomain(InternetShopApp.Data.Entities.OrderItem dataOrderItem)
        {
            return new InternetShopApp.Domain.Entities.OrderItem
            {
                Id = dataOrderItem.Id,
                OrderId = dataOrderItem.OrderId,
                ProductId = dataOrderItem.ProductId,
                Quantity = dataOrderItem.Quantity,
                Price = dataOrderItem.Price,
                Order = dataOrderItem.Order == null ? null : OrderMapper.MapToDomain(dataOrderItem.Order),
                Product = dataOrderItem.Product == null ? null : ProductMapper.MapToDomain(dataOrderItem.Product)
            };
        }

        public static InternetShopApp.Data.Entities.OrderItem MapToData(InternetShopApp.Domain.Entities.OrderItem domainOrderItem)
        {
            return new InternetShopApp.Data.Entities.OrderItem
            {
                Id = domainOrderItem.Id,
                OrderId = domainOrderItem.OrderId,
                ProductId = domainOrderItem.ProductId,
                Quantity = domainOrderItem.Quantity,
                Price = domainOrderItem.Price,
                Order = domainOrderItem.Order == null ? null : OrderMapper.MapToData(domainOrderItem.Order),
                Product = domainOrderItem.Product == null ? null : ProductMapper.MapToData(domainOrderItem.Product)
            };
        }
    }
}

