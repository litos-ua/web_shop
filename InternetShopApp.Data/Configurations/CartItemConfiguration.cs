//using InternetShopApp.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;


//namespace InternetShopApp.Data.Configurations
//{
//    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
//    {
//        public void Configure(EntityTypeBuilder<CartItem> builder)
//        {
//            builder.ToTable("CartItems");

//            builder.HasKey(ci => ci.Id); 

//            builder.HasOne(ci => ci.Cart) 
//                .WithMany(c => c.CartItems)
//                .HasForeignKey(ci => ci.CartId)
//                .OnDelete(DeleteBehavior.Cascade); 

//            builder.HasOne(ci => ci.Product) 
//                .WithMany()
//                .HasForeignKey(ci => ci.ProductId)
//                .OnDelete(DeleteBehavior.Restrict); //DeleteBehavior.Cascade

//            builder.Property(ci => ci.Quantity) 
//                .IsRequired()
//                .HasDefaultValue(1); 

//            builder.Property(ci => ci.CreatedAt)
//                .IsRequired()
//                .HasColumnType("datetime2");
//        }

//    }
//}

using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace InternetShopApp.Data.Configurations
{
    public class CartItemConfiguration : IEntityTypeConfiguration<CartItem>
    {
        public void Configure(EntityTypeBuilder<CartItem> builder)
        {
            builder.ToTable("CartItems");

            builder.HasKey(ci => ci.Id);

            builder.HasOne(ci => ci.Cart)
                   .WithMany(c => c.CartItems)
                   .HasForeignKey(ci => ci.CartId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(ci => ci.Product)
                   .WithMany()
                   .HasForeignKey(ci => ci.ProductId)
                   .OnDelete(DeleteBehavior.Restrict); 
                   //.OnDelete(DeleteBehavior.NoAction);

            builder.Property(ci => ci.Quantity)
                   .IsRequired()
                   .HasDefaultValue(1);

            builder.Property(ci => ci.CreatedAt)
                   .IsRequired()
                   .HasColumnType("datetime2");
        }
    }

}