using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace InternetShopApp.Data.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Cart>
    {
        public void Configure(EntityTypeBuilder<Cart> builder)
        {
            builder.ToTable("Carts");

            builder.HasKey(c => c.Id);

            builder.HasOne(c => c.User) // Связь с пользователем
                   .WithMany(u => u.Carts)
                   .HasForeignKey(c => c.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(c => c.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(c => c.IsActive)
                   .IsRequired()
                   .HasDefaultValue(true);
        }
    }
}
