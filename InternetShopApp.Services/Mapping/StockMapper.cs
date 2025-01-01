namespace InternetShopApp.Services.Mapping
{
    public static class StockMapper
    {
        public static InternetShopApp.Domain.Entities.Stock MapToDomain(InternetShopApp.Data.Entities.Stock dataStock)
        {
            return new InternetShopApp.Domain.Entities.Stock
            {
                Id = dataStock.Id,
                ProductId = dataStock.ProductId,
                Quantity = dataStock.Quantity,
                CreatedAt = dataStock.CreatedAt,
                Product = dataStock.Product == null ? null : ProductMapper.MapToDomain(dataStock.Product)
            };
        }

        public static InternetShopApp.Data.Entities.Stock MapToData(InternetShopApp.Domain.Entities.Stock domainStock)
        {
            return new InternetShopApp.Data.Entities.Stock
            {
                Id = domainStock.Id,
                ProductId = domainStock.ProductId,
                Quantity = domainStock.Quantity,
                CreatedAt = domainStock.CreatedAt,
                Product = domainStock.Product == null ? null : ProductMapper.MapToData(domainStock.Product)
            };
        }
    }
}

