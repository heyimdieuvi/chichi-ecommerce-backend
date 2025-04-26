using System.Collections.Generic;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;
using ChiChiEcommerce.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Data
{
    public class CategoryRepositoryImpl : CategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepositoryImpl(ApplicationDbContext context)
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