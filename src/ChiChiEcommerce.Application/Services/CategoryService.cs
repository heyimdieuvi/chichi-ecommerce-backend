using System.Collections.Generic;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Usecases;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Application.Services
{
    public class CategoryService
    {
        private readonly CreateCategoryUseCase _createCategoryUseCase;
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(CreateCategoryUseCase createCategoryUseCase, ICategoryRepository categoryRepository)
        {
            _createCategoryUseCase = createCategoryUseCase;
            _categoryRepository = categoryRepository;
        }

        public async Task CreateCategoryAsync(CategoryDto categoryDto)
        {
            var category = new Category
            {
                Name = categoryDto.Name,
                Description = categoryDto.Description
            };
            await _createCategoryUseCase.ExecuteAsync(category);
        }

        public async Task<List<CategoryDto>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();
            return categories.Select(c => new CategoryDto
            {
                Id = c.Id,
                Name = c.Name,
                Description = c.Description
            }).ToList();
        }
    }
}