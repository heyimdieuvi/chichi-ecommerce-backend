using System;
using ChiChiEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiChiEcommerce.Infrastructure.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("products");

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
                   .HasColumnName("productid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(p => p.Name)
                   .HasColumnName("name")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(p => p.Price)
                    .HasColumnName("price")
                    .HasColumnType("decimal(18,2)");  


            builder.Property(p => p.Description)
                   .HasColumnName("description");

            builder.Property(p => p.Stock)
                   .HasColumnName("stock")
                   .IsRequired();

            builder.Property(p => p.ShopId)
                   .HasColumnName("shopid");

            builder.Property(p => p.CategoryId)
                   .HasColumnName("categoryid");

            builder.HasOne(p => p.Shop)
                   .WithMany()
                   .HasForeignKey(p => p.ShopId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Category)
                   .WithMany()
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.SetNull);

            builder.Property(p => p.CreatedAt)
                   .HasColumnName("createdat")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(p => p.ModifiedAt)
                   .HasColumnName("modifiedat");

            builder.Property(p => p.IsDeleted)
                   .HasColumnName("isdeleted")
                   .HasDefaultValue(false);

            builder.HasQueryFilter(p => !p.IsDeleted);
        }
    }
}