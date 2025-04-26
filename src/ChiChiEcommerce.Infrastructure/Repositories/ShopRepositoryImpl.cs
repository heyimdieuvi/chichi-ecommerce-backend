using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;
using ChiChiEcommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data
{
    public class ShopRepositoryImpl : ShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepositoryImpl(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateShopAsync(Shop shop)
        {
            _context.Shops.Add(shop);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<Shop> GetShopByIdAsync(Guid shopId)
        {
            return await _context.Shops
                .Include(s => s.Owner)
                .FirstOrDefaultAsync(s => s.Id == shopId && !s.IsDeleted);
        }
    }
}