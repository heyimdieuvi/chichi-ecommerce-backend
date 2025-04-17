using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Domain.Repositories
{
    public interface ShopRepository
    {
        Task CreateShopAsync(Shop shop);
        Task<User> GetUserByIdAsync(int userId);
    }
}