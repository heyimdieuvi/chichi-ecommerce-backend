using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Application.IRepositories;
using ChiChiEcommerce.Application.DTOs;

namespace ChiChiEcommerce.Application.Usecases
{
    public class GetShopUseCase
    {
        private readonly IShopRepository _shopRepository;

        public GetShopUseCase(IShopRepository shopRepository)
        {
            _shopRepository = shopRepository;
        }

        public async Task<ShopDto> ExecuteAsync(Guid shopId)
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