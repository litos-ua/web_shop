using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShopApp.Data.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");

            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.User)
                   .WithMany(u => u.Orders)
                   .HasForeignKey(o => o.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(o => o.Amount)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)")
                   .HasDefaultValue(0m);

            builder.Property(o => o.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");

            builder.Property(o => o.DeliveryRequirement) // boolean
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(o => o.ReceivedStatus) //boolean
                   .IsRequired()
                   .HasDefaultValue(false);

            builder.Property(o => o.TypeOfPayment)
                   .IsRequired()
                   .HasMaxLength(20)
                   .HasDefaultValue("Card");

            builder.Property(o => o.PaymentStatus)
                   .IsRequired()
                   .HasMaxLength(50)
                   .HasDefaultValue("not paid");

            builder.HasMany(o => o.OrderItems)
                   .WithOne(oi => oi.Order)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }

}

