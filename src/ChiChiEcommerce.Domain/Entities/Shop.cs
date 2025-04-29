using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Domain.Entities
{
    public class Shop : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Location { get; set; } = null!;
        public Guid OwnerId { get; set; }
        public User Owner { get; set; } = null!;
    }
}