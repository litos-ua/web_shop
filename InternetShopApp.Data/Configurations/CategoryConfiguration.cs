using InternetShopApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InternetShopApp.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
                builder.ToTable("Categories");

                builder.HasKey(c => c.Id);

                builder.Property(c => c.Name)
                        .IsRequired()
                        .HasMaxLength(50);

                builder.Property(c => c.CreatedAt)
                       .IsRequired()
                       .HasColumnType("datetime2");
        }
    }
}
