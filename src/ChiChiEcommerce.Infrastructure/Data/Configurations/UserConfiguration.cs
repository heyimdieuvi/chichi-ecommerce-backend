using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        builder.HasKey(x => x.UserId);
        builder.Property(x => x.UserId)
               .HasColumnName("user_id")
               .HasDefaultValueSql("gen_random_uuid()");

        builder.Property(u => u.Name)
               .HasColumnName("name")
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(u => u.Email)
               .HasColumnName("email")
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(u => u.Phone)
        .HasColumnName("phone")
        .HasMaxLength(10)
        .IsRequired();       

        builder.HasIndex(u => u.Email).IsUnique();

        builder.HasIndex(u => u.Phone).IsUnique();

        builder.Property(u => u.PasswordHash)
               .HasColumnName("password_hash")
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(u => u.PasswordSalt)
               .HasColumnName("password_salt")
               .HasMaxLength(255)
               .IsRequired();

        builder.Property(u => u.Role)
               .HasColumnName("role")
               .HasMaxLength(50)
               .IsRequired();

        builder.Property(u => u.IsActive)
               .HasColumnName("is_active")
               .HasDefaultValue(true);

        builder.Property(u => u.CreatedAt)
               .HasColumnName("created_at")
               .HasDefaultValueSql("CURRENT_TIMESTAMP");
    }
  }
}