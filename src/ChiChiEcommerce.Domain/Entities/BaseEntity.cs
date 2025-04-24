using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id {get; set; }
        public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTimeOffset? ModifiedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}