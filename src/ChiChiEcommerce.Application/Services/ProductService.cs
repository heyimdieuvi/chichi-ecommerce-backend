using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Usecases;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Application.Services
{
    public class ProductService
    {
        private readonly CreateProductUseCase _createProductUseCase;
        private readonly ProductRepository _productRepository;

        public ProductService(CreateProductUseCase createProductUseCase, ProductRepository productRepository)
        {
            _createProductUseCase = createProductUseCase;
            _productRepository = productRepository;
        }

        public async Task CreateProductAsync(ProductDto productDto)
        {
            var product = new Product
            {
                Name = productDto.Name,
                Price = productDto.Price,
                Description = productDto.Description,
                Stock = productDto.Stock,
                ShopId = productDto.ShopId,
                CategoryId = productDto.CategoryId
            };
            await _createProductUseCase.ExecuteAsync(product);
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