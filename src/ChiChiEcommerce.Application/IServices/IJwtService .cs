using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Application.Interface
{
    public interface IJwtService 
    {
        string GenerateToken(Account account);
    }
}