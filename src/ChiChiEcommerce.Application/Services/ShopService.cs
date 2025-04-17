using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Domain.Usecases;

namespace ChiChiEcommerce.Application.Services
{
    public class ShopService
    {
        private readonly CreateShopUseCase _createShopUseCase;

        public ShopService(CreateShopUseCase createShopUseCase)
        {
            _createShopUseCase = createShopUseCase;
        }

        public async Task CreateShopAsync(ShopDto shopDto)
        {
            var shop = new Domain.Entities.Shop
            {
                Name = shopDto.Name,
                Ownerid = shopDto.Ownerid
            };
            await _createShopUseCase.ExecuteAsync(shop);
        }
    }
}