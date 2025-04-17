using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Domain.Usecases
{
    public class CreateShopUseCase
    {
        private readonly ShopRepository _shopRepository;

        public CreateShopUseCase(ShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task ExecuteAsync(Shop shop)
        {
            if (string.IsNullOrEmpty(shop.Name))
            {
                throw new ArgumentException("Shop name is required.");
            }

            var owner = await _shopRepository.GetUserByIdAsync(shop.Ownerid);
            if (owner == null)
            {
                throw new ArgumentException($"User with ID {shop.Ownerid} does not exist.");
            }

            await _shopRepository.CreateShopAsync(shop);
        }
    }
}