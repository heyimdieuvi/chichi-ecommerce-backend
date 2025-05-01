using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Application.DTOs.Auth
{
    public class RegisterRequest
    {
        public string? UserName { get; set; }
        [Required]
        public string Email { get; set; } = null!; //đảm bảo không null nha runtime
        [Required]
        public string? Password { get; set; }
        public string? Name { get; set; }
    }
}