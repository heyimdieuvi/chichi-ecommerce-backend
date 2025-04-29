using System;
using ChiChiEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiChiEcommerce.Infrastructure.Data.Configurations
{
    public class ShopConfiguration : IEntityTypeConfiguration<Shop>
    {
        public void Configure(EntityTypeBuilder<Shop> builder)
        {
            builder.ToTable("shops");

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id)
                   .HasColumnName("shopid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(s => s.Name)
                   .HasColumnName("name")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(s => s.Location)
                   .HasColumnName("location")
                   .IsRequired();

            builder.Property(s => s.OwnerId)
                   .HasColumnName("ownerid");

            builder.HasOne(s => s.Owner)
                   .WithMany()
                   .HasForeignKey(s => s.OwnerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(s => s.CreatedAt)
                   .HasColumnName("createdat")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(s => s.ModifiedAt)
                   .HasColumnName("modifiedat");

            builder.Property(s => s.IsDeleted)
                   .HasColumnName("isdeleted")
                   .HasDefaultValue(false);

            builder.HasQueryFilter(s => !s.IsDeleted);
        }
    }
}