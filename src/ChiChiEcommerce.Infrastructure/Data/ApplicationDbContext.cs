using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

        public DbSet<User> Users => Set<User>();
        public DbSet<Account> Accounts => Set<Account>();
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //do not get is delete rows
            modelBuilder.Entity<User>().HasQueryFilter(u => !u.IsDeleted);
            modelBuilder.Entity<Account>().HasQueryFilter(a => !a.IsDeleted);
        }
    }
}