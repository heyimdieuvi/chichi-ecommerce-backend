using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Domain.Repositories
{
    public interface ShopRepository
    {
        Task CreateShopAsync(Shop shop);
        Task<User> GetUserByIdAsync(Guid userId);
        Task<Shop> GetShopByIdAsync(Guid shopId);
    }
}