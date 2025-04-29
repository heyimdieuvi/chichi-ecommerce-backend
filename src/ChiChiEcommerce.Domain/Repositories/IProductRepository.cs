using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Domain.Repositories
{
    public interface IProductRepository
    {
        Task CreateProductAsync(Product product);
        Task<PagedResult<Product>> GetProductsAsync(string? searchTerm, Guid? categoryId, int pageNumber, int pageSize);
    }

    public class PagedResult<T>
    {
        public List<T> Items { get; set; } = new();
        public int TotalCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}