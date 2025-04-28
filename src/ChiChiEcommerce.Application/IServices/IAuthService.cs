using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs.Auth;

namespace ChiChiEcommerce.Application.Interface
{
    public interface IAuthService
    {
        string HashPassword(string inputPassword);
        bool VerifyPassword(string inputPass, string hashedPass);
    }
}

