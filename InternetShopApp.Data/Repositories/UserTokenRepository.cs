using InternetShopApp.Data.Entities;
using InternetShopApp.Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;


namespace InternetShopApp.Data.Repositories
{
    public class UserTokenRepository : GenericRepository<UserToken>, IUserTokenRepository
    {
        public UserTokenRepository(InternetShopContext context) : base(context) { }

        public async Task<UserToken?> FindByTokenAsync(string refreshToken)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Token == refreshToken);
        }

        public async Task<IEnumerable<UserToken>> FindByUserIdAsync(int userId)
        {
            return await _dbSet.Where(t => t.UserId == userId).ToListAsync();
        }
        public async Task<UserToken?> FindByEmailAsync(string email)
        {
            return await _dbSet
                .Include(t => t.User) 
                .FirstOrDefaultAsync(t => t.User.Email == email);
        }
    }
}

