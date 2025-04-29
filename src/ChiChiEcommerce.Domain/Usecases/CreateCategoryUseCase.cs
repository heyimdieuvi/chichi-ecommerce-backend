using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Domain.Usecases
{
    public class CreateCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task ExecuteAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category), "Category cannot be null.");
            }

            if (string.IsNullOrEmpty(category.Name))
            {
                throw new ArgumentException("Category name is required.", nameof(category.Name));
            }

            await _categoryRepository.CreateCategoryAsync(category);
        }
    }
}
