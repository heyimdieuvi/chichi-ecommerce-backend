using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Application.IRepositories;
using ChiChiEcommerce.Application.DTOs;

namespace ChiChiEcommerce.Application.Usecases
{
    public class GetProductUseCase
    {
        private readonly IProductRepository _productRepository;

        public GetProductUseCase(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<PagedResultDto<ProductDto>> GetProductsAsync(string? searchTerm, Guid? categoryId, int pageNumber, int pageSize)
        {
            var result = await _productRepository.GetProductsAsync(searchTerm, categoryId, pageNumber, pageSize);
            return new PagedResultDto<ProductDto>
            {
                Items = result.Items.Select(p => new ProductDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Description = p.Description,
                    Stock = p.Stock,
                    ShopId = p.ShopId,
                    CategoryId = p.CategoryId
                }).ToList(),
                TotalCount = result.TotalCount,
                PageNumber = result.PageNumber,
                PageSize = result.PageSize
            };
        }
    }
}