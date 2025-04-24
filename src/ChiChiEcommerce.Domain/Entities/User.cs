using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Domain.Entities
{
public class User : BaseEntity
{
    public string Name { get; set; } = null!;
    public string? Phone { get; set; }
    public string? AvatarUrl { get; set; }
    public Account? Account { get; set; }
}
}