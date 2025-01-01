using InternetShopApp.Data.Repositories.Interfaces;
//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data.Repositories
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        private readonly InternetShopContext _context;

        public ProductRepository(InternetShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(int categoryId)
        {
            var categoryExists = await _context.Categories.AnyAsync(c => c.Id == categoryId);
            if (!categoryExists)
            {
                return Enumerable.Empty<Product>(); // Empty list if there is no category
            }

            return await _context.Products
                .AsNoTracking()
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByNameAsync(string name)
        {
            return await _context.Products
                .AsNoTracking()
                .Where(p => p.Name == name)
                .ToListAsync();
        }
    }
}

