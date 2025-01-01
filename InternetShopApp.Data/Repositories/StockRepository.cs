//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;
using InternetShopApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data.Repositories
{
    public class StockRepository : GenericRepository<Stock>, IStockRepository
    {
        private readonly InternetShopContext _context;
        public StockRepository(InternetShopContext context) : base(context)
        {
            _context = context;
        }
    }
}


