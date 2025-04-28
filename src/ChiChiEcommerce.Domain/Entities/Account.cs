using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Domain.Entities
{
    public class Account : BaseEntity //phụ thuộc vào user -> mở rộng 1 user - n account
    {
    public string? UserName { get; set; }
    public string Email { get; set; } = null!; //đảm bảo không null nha runtime
    public string? Password { get; set; } //already hashed //if using other credential (GG/ Fb)
    public string Role { get; set; } = "Customer";
    public AccountStatus Status { get; set; }
    public string? Provider { get; set; }          // e.g., "Google", "Facebook", "Local"
    public string? ProviderUserId { get; set; }    // e.g., Google sub field (unique ID)
    public Guid? UserId { get; set; } // 1-1 relationship //foreign key
    public User? User { get; set; }
    }
}