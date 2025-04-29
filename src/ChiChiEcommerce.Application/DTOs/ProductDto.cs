using System;

namespace ChiChiEcommerce.Application.DTOs
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public Guid ShopId { get; set; }
        public Guid? CategoryId { get; set; }
    }
}
