using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Domain.Usecases
{
    public class CreateProductUseCase
    {
        private readonly ProductRepository _productRepository;
        private readonly ShopRepository _shopRepository;
        private readonly CategoryRepository _categoryRepository;

        public CreateProductUseCase(ProductRepository productRepository, ShopRepository shopRepository, CategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _shopRepository = shopRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException(nameof(product), "Product cannot be null.");
            }

            if (string.IsNullOrEmpty(product.Name))
            {
                throw new ArgumentException("Product name is required.", nameof(product.Name));
            }

            if (product.Price <= 0)
            {
                throw new ArgumentException("Price must be greater than zero.", nameof(product.Price));
            }

            if (product.Stock < 0)
            {
                throw new ArgumentException("Stock cannot be negative.", nameof(product.Stock));
            }

            var shop = await _shopRepository.GetShopByIdAsync(product.ShopId);
            if (shop == null)
            {
                throw new ArgumentException($"Shop with ID {product.ShopId} does not exist.", nameof(product.ShopId));
            }

            if (product.CategoryId.HasValue)
            {
                var category = await _categoryRepository.GetCategoryByIdAsync(product.CategoryId.Value);
                if (category is null)
                {
                    throw new ArgumentException($"Category with ID {product.CategoryId} does not exist.", nameof(product.CategoryId));
                }
            }

            await _productRepository.CreateProductAsync(product);
        }
    }
}