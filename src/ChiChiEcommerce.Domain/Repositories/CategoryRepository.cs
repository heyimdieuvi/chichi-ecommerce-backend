using System.Collections.Generic;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Domain.Repositories
{
    public interface CategoryRepository
    {
        Task CreateCategoryAsync(Category category);
        Task<List<Category>> GetAllCategoriesAsync();
        Task<Category> GetCategoryByIdAsync(Guid categoryId);
    }
}