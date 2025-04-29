using System.Collections.Generic;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Application.IRepositories;
using ChiChiEcommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllCategoriesAsync()
        {
            return await _context.Categories
                .Where(c => !c.IsDeleted)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            return await _context.Categories
                .FirstOrDefaultAsync(c => c.Id == categoryId && !c.IsDeleted);
        }
    }
}