using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Application.IRepositories;
using ChiChiEcommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data
{
    public class ShopRepository : IShopRepository
    {
        private readonly ApplicationDbContext _context;

        public ShopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateShopAsync(Shop shop)
        {
            await _context.Shops.AddAsync(shop);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            return await _context.Users
                                .Include(u => u.Account)  
                                .FirstOrDefaultAsync(u => u.Id == userId);
        }

        public async Task<Shop> GetShopByIdAsync(Guid shopId)
        {
            return await _context.Shops
                .Include(s => s.Owner)
                .FirstOrDefaultAsync(s => s.Id == shopId && !s.IsDeleted);
        }
    }
}