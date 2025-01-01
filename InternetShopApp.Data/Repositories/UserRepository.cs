using InternetShopApp.Data.Repositories.Interfaces;
//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly InternetShopContext _context;

        public UserRepository(InternetShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart?> GetCartByUserIdAsync(int userId)
        {
            return await _context.Carts
                .Include(c => c.CartItems) 
                .ThenInclude(ci => ci.Product) 
                .FirstOrDefaultAsync(c => c.UserId == userId);
        }

        public async Task<IEnumerable<Order>> GetOrdersByUserIdAsync(int userId)
        {
            return await _context.Orders
                .Where(o => o.UserId == userId)
                .Include(o => o.OrderItems) 
                .ToListAsync();
        }
    }
}

