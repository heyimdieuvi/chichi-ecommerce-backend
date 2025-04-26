using System;

namespace ChiChiEcommerce.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; } = null!;
        public decimal Price { get; set; }
        public string Description { get; set; } = null!;
        public int Stock { get; set; }
        public Guid ShopId { get; set; }
        public Shop Shop { get; set; } = null!;
        public Guid? CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
