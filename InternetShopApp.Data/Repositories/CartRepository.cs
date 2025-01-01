using InternetShopApp.Data.Repositories.Interfaces;
//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data.Repositories
{
    public class CartRepository : GenericRepository<Cart>, ICartRepository
    {
        private readonly InternetShopContext _context;

        public CartRepository(InternetShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cart>> GetCartsByProductIdAsync(int productId)
        {
            return await _context.Carts
                .Include(c => c.CartItems) 
                .Where(c => c.CartItems.Any(ci => ci.ProductId == productId)) // Filter by ProductId
                .ToListAsync();
        }
    }
}

