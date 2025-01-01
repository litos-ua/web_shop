using InternetShopApp.Data.Repositories.Interfaces;
using InternetShopApp.Services.Interfaces;
using InternetShopApp.Services.Mapping;

namespace InternetShopApp.Services
{
    public class StockService : GenericService<Domain.Entities.Stock, Data.Entities.Stock>, IStockService
    {
        private readonly IStockRepository _stockRepository;

        public StockService(IStockRepository stockRepository) : base(stockRepository)
        {
            _stockRepository = stockRepository;
        }

        protected override Domain.Entities.Stock MapToDomain(Data.Entities.Stock dataEntity)
        {
            return StockMapper.MapToDomain(dataEntity);
        }

        protected override Data.Entities.Stock MapToData(Domain.Entities.Stock domainEntity)
        {
            return StockMapper.MapToData(domainEntity);
        }
    }
}


