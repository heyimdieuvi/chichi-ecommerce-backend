using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Application.IRepositories
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user);
    }
}