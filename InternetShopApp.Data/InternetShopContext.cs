//using InternetShopApp.Domain.Entities;
using InternetShopApp.Data.Entities;
using InternetShopApp.Data.Configurations;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data
{
    public class InternetShopContext : DbContext
    {
        public InternetShopContext(DbContextOptions<InternetShopContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Stock> Stocks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoryConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            //modelBuilder.ApplyConfiguration(new CartConfiguration());
            //modelBuilder.ApplyConfiguration(new CartItemConfiguration());
            //modelBuilder.ApplyConfiguration(new UserConfiguration());
            //modelBuilder.ApplyConfiguration(new StockConfiguration());
        }        
    }
}
