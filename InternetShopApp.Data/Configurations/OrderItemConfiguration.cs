//using InternetShopApp.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace InternetShopApp.Data.Configurations
//{
//    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
//    {
//        public void Configure(EntityTypeBuilder<OrderItem> builder)
//        {
//            builder.ToTable("OrderItems");
//            builder.HasKey(oi => oi.Id);

//            builder.HasOne(oi => oi.Order)
//              .WithMany(o => o.OrderItems)
//              .HasForeignKey(oi => oi.OrderId);

//            builder.HasOne(oi => oi.Product)
//              .WithMany()
//              .HasForeignKey(oi => oi.ProductId);

//            builder.Property(oi => oi.CreatedAt)
//                .IsRequired()
//                .HasColumnType("datetime2");

//            builder.Property(oi => oi.Quantity)
//                .IsRequired()
//                .HasDefaultValue(0);

//        }
//    }
//}

using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShopApp.Data.Configurations
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.ToTable("OrderItems");

            builder.HasKey(oi => oi.Id);

            builder.HasOne(oi => oi.Order)
                   .WithMany(o => o.OrderItems)
                   .HasForeignKey(oi => oi.OrderId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(oi => oi.Product)
                   .WithMany()
                   .HasForeignKey(oi => oi.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
                   //.OnDelete(DeleteBehavior.NoAction);

            builder.Property(oi => oi.Price)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.Quantity)
                   .IsRequired();

            builder.Property(oi => oi.Total)
                   .IsRequired()
                   .HasColumnType("decimal(18,2)");

            builder.Property(oi => oi.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");
        }
    }

}