using System;

using ChiChiEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiChiEcommerce.Infrastructure.Data.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("categories");

            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id)
                   .HasColumnName("categoryid")
                   .HasDefaultValueSql("gen_random_uuid()");

            builder.Property(c => c.Name)
                   .HasColumnName("name")
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasColumnName("description");

            builder.Property(c => c.CreatedAt)
                   .HasColumnName("createdat")
                   .HasDefaultValueSql("CURRENT_TIMESTAMP");

            builder.Property(c => c.ModifiedAt)
                   .HasColumnName("modifiedat");

            builder.Property(c => c.IsDeleted)
                   .HasColumnName("isdeleted")
                   .HasDefaultValue(false);

            builder.HasQueryFilter(c => !c.IsDeleted);
        }
    }
}
