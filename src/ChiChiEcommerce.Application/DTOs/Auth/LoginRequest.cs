using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChiChiEcommerce.Application.DTOs.Auth
{
    public class LoginRequest
    {
        [Required]
        public string Email { get; set; } = string.Empty; //đảm bảo không null nha runtime
        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
