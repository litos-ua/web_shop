using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using InternetShopApp.Data.Entities; // Замените на актуальное пространство имен

namespace YourNamespace.Data.Configurations
{
    public class UserTokenConfiguration : IEntityTypeConfiguration<UserToken>
    {
        public void Configure(EntityTypeBuilder<UserToken> builder)
        {
            // Установка имени таблицы
            builder.ToTable("UserTokens");

            // Установка первичного ключа
            builder.HasKey(ut => ut.Id);

            // Конфигурация связи с пользователем
            builder.HasOne(ut => ut.User)
                .WithMany(u => u.UserTokens) // Убедитесь, что в User есть коллекция UserTokens
                .HasForeignKey(ut => ut.UserId)
                .OnDelete(DeleteBehavior.Cascade); // Удаление токенов при удалении пользователя

            // Конфигурация Token
            builder.Property(ut => ut.Token)
                .IsRequired()
                .HasMaxLength(500);

            // Конфигурация ExpiresAt
            builder.Property(ut => ut.ExpiresAt)
                .IsRequired()
                .HasColumnType("datetime2"); // Для точного хранения даты и времени

            // Конфигурация CreatedAt
            builder.Property(ut => ut.CreatedAt)
                .IsRequired()
                .HasColumnType("datetime2");

            // Конфигурация CreatedByIp
            builder.Property(ut => ut.CreatedByIp)
                .HasMaxLength(45) // Для IPv6
                .HasDefaultValue(null); // По умолчанию null

            // Конфигурация RevokedAt
            builder.Property(ut => ut.RevokedAt)
                .HasColumnType("datetime2")
                .HasDefaultValue(null); // По умолчанию null

            // Конфигурация RevokedByIp
            builder.Property(ut => ut.RevokedByIp)
                .HasMaxLength(45)
                .HasDefaultValue(null); // По умолчанию null
        }
    }
}

