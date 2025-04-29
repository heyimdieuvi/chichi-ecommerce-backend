using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Domain.Usecases
{
    public class CreateShopUseCase
    {
        private readonly IShopRepository _shopRepository;

        public CreateShopUseCase(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task ExecuteAsync(Shop shop)
        {
            if (shop == null)
            {
                throw new ArgumentNullException(nameof(shop), "Shop cannot be null.");
            }

            if (string.IsNullOrEmpty(shop.Name))
            {
                throw new ArgumentException("Shop name is required.", nameof(shop.Name));
            }

            if (string.IsNullOrEmpty(shop.Location))
            {
                throw new ArgumentException("Shop location is required.", nameof(shop.Location));
            }

            var owner = await _shopRepository.GetUserByIdAsync(shop.OwnerId);
            if (owner == null)
            {
                throw new ArgumentException($"User with ID {shop.OwnerId} does not exist.", nameof(shop.OwnerId));
            }

            if (owner.Account.Role != "Seller")
            {
                throw new ArgumentException("Owner must have Seller role.", nameof(shop.OwnerId));
            }
        }
    }
}