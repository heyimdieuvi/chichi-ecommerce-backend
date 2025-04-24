using ChiChiEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiChiEcommerce.Infrastructure.Data.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("users");

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id)
                   .HasColumnName("id")
                   .HasDefaultValueSql("gen_random_uuid()"); //auto generate

            builder.Property(u => u.Name)
                   .HasColumnName("name")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(u => u.Phone)
                   .HasColumnName("phone")
                   .HasMaxLength(20);

            builder.Property(u => u.AvatarUrl)
                   .HasColumnName("avatar_url")
                   .HasMaxLength(512);

            builder.HasOne(u => u.Account)
                   .WithOne(a => a.User)
                   .HasForeignKey<Account>(a => a.UserId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(u => u.CreatedAt)
                   .HasColumnName("created_at")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(u => u.ModifiedAt)
                   .HasColumnName("modified_at");

            builder.Property(u => u.IsDeleted)
                   .HasColumnName("is_deleted")
                   .HasDefaultValue(false);
        }
    }
}
