using InternetShopApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;



namespace InternetShopApp.Data.Repositories
{
    public class CartItemRepository : GenericRepository<CartItem>, ICartItemRepository
    {
        private readonly InternetShopContext _context;

        public CartItemRepository(InternetShopContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByCartIdAsync(int cartId)
        {
            return await _context.CartItems
                .Where(ci => ci.CartId == cartId)
                .Include(ci => ci.Product) // Loading related data (Products)
                .ToListAsync();
        }
    }

}
