using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.IRepositories;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Accounts = new AccountRepository(context);
            Users = new UserRepository(context);
        }
        public IAccountRepository Accounts { get; private set; } //services or usecase can access through UoW
        public IUserRepository Users { get; private set; }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose() //automatic call when request end
        {
            _context.Dispose();
        }
    }
}