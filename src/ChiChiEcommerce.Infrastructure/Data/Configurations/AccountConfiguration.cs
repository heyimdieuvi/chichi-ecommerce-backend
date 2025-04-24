using ChiChiEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChiChiEcommerce.Infrastructure.Data.Configurations
{
       public class AccountConfiguration : IEntityTypeConfiguration<Account>
       {
              public void Configure(EntityTypeBuilder<Account> builder)
              {
                     builder.ToTable("accounts");

                     builder.HasKey(a => a.Id);
                     builder.Property(a => a.Id)
                         .HasColumnName("id")
                         .HasDefaultValueSql("gen_random_uuid()");

                     builder.Property(a => a.UserName)
                          .HasColumnName("username")
                          .HasMaxLength(100);

                     builder.Property(a => a.Email)
                          .HasColumnName("email")
                          .HasMaxLength(255)
                          .IsRequired();

                     builder.HasIndex(a => a.Email).IsUnique();

                     builder.Property(a => a.Password)
                          .HasColumnName("password");

                     builder.Property(a => a.Role)
                          .HasColumnName("role")
                          .HasMaxLength(50)
                          .IsRequired();

                     builder.Property(a => a.Status)
                          .HasColumnName("status")
                          .HasConversion<string>() // stores enum as string
                          .HasMaxLength(50);

                     builder.Property(a => a.Provider)
                     .HasColumnName("provider")
                     .HasMaxLength(50)
                     .IsRequired(false);

                     builder.Property(a => a.ProviderUserId)
                            .HasColumnName("provider_user_id")
                            .HasMaxLength(128)
                            .IsRequired(false);

                     builder.Property(a => a.UserId)
                     .HasColumnName("user_id");

                     builder.HasOne(a => a.User)
                      .WithOne(u => u.Account)
                      .HasForeignKey<Account>(a => a.UserId)
                      .OnDelete(DeleteBehavior.Cascade);

                     builder.Property(a => a.CreatedAt)
                      .HasColumnName("created_at")
                      .HasDefaultValueSql("CURRENT_TIMESTAMP");

                     builder.Property(a => a.ModifiedAt)
                        .HasColumnName("modified_at");

                     builder.Property(a => a.IsDeleted)
                       .HasColumnName("is_deleted")
                       .HasDefaultValue(false);
              }
       }
}
