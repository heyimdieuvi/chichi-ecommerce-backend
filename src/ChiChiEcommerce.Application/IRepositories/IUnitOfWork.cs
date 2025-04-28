using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.IRepositories;

namespace ChiChiEcommerce.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        IUserRepository Users { get; }
        Task<int> CompleteAsync();
    }
}