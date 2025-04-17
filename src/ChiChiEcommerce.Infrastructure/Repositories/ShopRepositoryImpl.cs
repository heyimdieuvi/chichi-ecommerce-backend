using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;
using ChiChiEcommerce.Infrastructure.Data.Entities;

namespace Infrastructure.Data
{
    public class ShopRepositoryImpl : ShopRepository
    {
        private readonly AppDbContext _context;

        public ShopRepositoryImpl(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateShopAsync(Shop shop)
        {
            var infraShop = new ChiChiEcommerce.Infrastructure.Data.Entities.shop
            {
                shopid = shop.Shopid,
                name = shop.Name,
                ownerid = shop.Ownerid
            };
            _context.shops.Add(infraShop);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(int userId)
        {
            var infraUser = await _context.users.FindAsync(userId);
            if (infraUser == null)
            {
                return null;
            }

            return new User
            {
                Userid = infraUser.userid,
                Name = infraUser.name,  
                Email = infraUser.email,        
                Password = infraUser.password,
                Role = infraUser.role
            };
        }
    }
}