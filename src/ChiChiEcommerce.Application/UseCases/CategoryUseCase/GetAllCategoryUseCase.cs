using System;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Application.IRepositories;
using ChiChiEcommerce.Application.DTOs;

namespace ChiChiEcommerce.Application.Usecases
{
    public class GetAllCategoryUseCase
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetAllCategoryUseCase(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
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
