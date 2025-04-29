using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        public string? UserName { get; set; }
        public string Email { get; set; } = null!; //đảm bảo không null nha runtime
        public string? Password { get; set; }
    }
}