
using InternetShopApp.Data.Repositories.Interfaces;
//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace InternetShopApp.Data.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        private readonly InternetShopContext _context;

        public CategoryRepository(InternetShopContext context) : base(context)
        {
            _context = context;
        }

        //public async Task<IEnumerable<Category>> GetCategoriesWithProductsAsync()
        //{
        //    return await _context.Categories
        //        .Include(c => c.Products)
        //        .ToListAsync();
        //}

        public async Task<Category?> GetCategoryWithProductsByIdAsync(int categoryId)
        {
            return await _context.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(c => c.Id == categoryId);
        }
    }
}

