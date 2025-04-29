using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.Services;
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Usecases;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Application.Services
{
    public class ShopService
    {
        private readonly CreateShopUseCase _createShopUseCase;
        private readonly IShopRepository _shopRepository; //????
        public ShopService(CreateShopUseCase createShopUseCase, IShopRepository shopRepository)
        {
            _createShopUseCase = createShopUseCase;
            _shopRepository = shopRepository;
        }

        public async Task CreateShopAsync(ShopDto shopDto)
        {
            var shop = new Shop
            {
                Name = shopDto.Name,
                Location = shopDto.Location,
                OwnerId = shopDto.OwnerId
            };
            await _createShopUseCase.ExecuteAsync(shop);
        }

        public async Task<ShopDto> GetShopByIdAsync(Guid shopId)
        {
            var shop = await _shopRepository.GetShopByIdAsync(shopId);
            if (shop == null)
            {
                throw new KeyNotFoundException($"Shop with ID {shopId} not found.");
            }

            return new ShopDto
            {
                Id = shop.Id,
                Name = shop.Name,
                Location = shop.Location,
                OwnerId = shop.OwnerId
            };
        }
    }
}
