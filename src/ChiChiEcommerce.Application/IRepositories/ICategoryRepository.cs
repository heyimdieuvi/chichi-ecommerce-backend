using System.Collections.Generic;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Application.IRepositories
{
    public interface ICategoryRepository
    {
        Task CreateCategoryAsync(Category category);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid categoryId);
    }
}