using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Application.IRepositories
{
    public interface IShopRepository
    {
        Task CreateShopAsync(Shop shop);
        Task<User> GetUserByIdAsync(Guid userId);
        Task<Shop> GetShopByIdAsync(Guid shopId);
    }
}