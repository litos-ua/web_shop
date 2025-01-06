
//using InternetShopApp.Data.Entities;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;


//namespace InternetShopApp.Data.Configurations
//{
//    public class UserConfiguration : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//            builder.ToTable("Users");

//            builder.HasKey(u => u.Id); 

//            builder.Property(u => u.Username)
//                .IsRequired()
//                .HasMaxLength(50); 

//            builder.Property(u => u.Email)
//                .IsRequired()
//                .HasMaxLength(100); 

//            builder.Property(u => u.Fullname)
//                .IsRequired()
//                .HasMaxLength(100); 

//            builder.Property(u => u.CreatedAt)
//                .IsRequired()
//                .HasColumnType("datetime2");

//            builder.HasMany(u => u.Carts)
//                .WithOne(c => c.User)
//                .HasForeignKey(c => c.UserId)
//                .OnDelete(DeleteBehavior.Cascade);
//        }
//    }
//}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InternetShopApp.Data.Entities; // Убедитесь, что путь к пространству имен корректен

namespace InternetShopApp.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Установка имени таблицы
            builder.ToTable("Users");

            // Установка первичного ключа
            builder.HasKey(u => u.Id);

            // Конфигурация Username
            builder.Property(u => u.Username)
                .IsRequired()
                .HasMaxLength(50);

            // Конфигурация Email с уникальным индексом
            builder.Property(u => u.Email)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(u => u.Email)
                .IsUnique(); // Уникальный индекс для Email

            // Конфигурация PasswordHash
            builder.Property(u => u.PasswordHash)
                .IsRequired()
                .HasMaxLength(100);

            // Конфигурация Fullname
            builder.Property(u => u.Fullname)
                .IsRequired()
                .HasMaxLength(100);

            // Конфигурация PhoneNumber
            builder.Property(u => u.PhoneNumber)
                .IsRequired()
                .HasMaxLength(15)
                .HasDefaultValue("");

            // Конфигурация CreatedAt
            builder.Property(u => u.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2");

            // Конфигурация Address
            builder.Property(u => u.Address)
                .HasMaxLength(200);

            // Конфигурация Role
            builder.Property(u => u.Role)
                .IsRequired();

            // Конфигурация связи с Carts
            builder.HasMany(u => u.Carts)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Конфигурация связи с Orders
            builder.HasMany(u => u.Orders)
                .WithOne(o => o.User)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}


//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using InternetShopApp.Data.Entities;

//namespace InternetShopApp.Data.Configurations
//{
//    public class UserConfiguration : IEntityTypeConfiguration<User>
//    {
//        public void Configure(EntityTypeBuilder<User> builder)
//        {
//            // Установка имени таблицы
//            builder.ToTable("Users");

//            // Установка первичного ключа
//            builder.HasKey(u => u.Id);

//            // Конфигурация Username
//            builder.Property(u => u.Username)
//                .IsRequired()
//                .HasMaxLength(50);

//            // Конфигурация Email с уникальным индексом
//            builder.Property(u => u.Email)
//                .IsRequired()
//                .HasMaxLength(100);

//            builder.HasIndex(u => u.Email)
//                .IsUnique(); // Уникальный индекс для Email

//            // Конфигурация PasswordHash
//            builder.Property(u => u.PasswordHash)
//                .IsRequired()
//                .HasMaxLength(100);

//            // Конфигурация Fullname
//            builder.Property(u => u.Fullname)
//                .IsRequired()
//                .HasMaxLength(100);

//            // Конфигурация PhoneNumber
//            builder.Property(u => u.PhoneNumber)
//                .IsRequired()
//                .HasMaxLength(15)
//                .HasDefaultValue("");

//            // Конфигурация CreatedAt
//            builder.Property(u => u.CreatedAt)
//                .IsRequired()
//                .HasColumnType("datetime2");

//            // Конфигурация Address
//            builder.Property(u => u.Address)
//                .HasMaxLength(200);

//            // Конфигурация Role
//            builder.Property(u => u.Role)
//                .IsRequired();

//            // Конфигурация полей для подтверждения по email
//            builder.Property(u => u.EmailVerificationToken)
//                .HasMaxLength(200);

//            builder.Property(u => u.EmailVerifiedAt)
//                .HasColumnType("datetime2");

//            // Конфигурация связи с Carts
//            builder.HasMany(u => u.Carts)
//                .WithOne(c => c.User)
//                .HasForeignKey(c => c.UserId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Конфигурация связи с Orders
//            builder.HasMany(u => u.Orders)
//                .WithOne(o => o.User)
//                .HasForeignKey(o => o.UserId)
//                .OnDelete(DeleteBehavior.Cascade);

//            // Конфигурация связи с UserTokens
//            builder.HasMany(u => u.UserTokens)
//                .WithOne(ut => ut.User)
//                .HasForeignKey(ut => ut.UserId)
//                .OnDelete(DeleteBehavior.Cascade); // Удаление токенов при удалении пользователя
//        }
//    }
//}
