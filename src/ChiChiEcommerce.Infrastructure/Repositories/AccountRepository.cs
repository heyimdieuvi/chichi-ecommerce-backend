using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ChiChiEcommerce.Infrastructure.Repositories
{
  public class AccountRepository : IAccountRepository
  {
    private readonly ApplicationDbContext _context;
    public AccountRepository(ApplicationDbContext context) { //đki trong Program.cs, mỗi request 1 DB Transaction 
        _context = context;
    }
    public async Task AddAccountAsync(Account account)
    {
        await _context.Accounts.AddAsync(account); //ef core track the new row 
    }

    public async Task<bool> CheckExistEmail(string email) => await _context.Accounts.AnyAsync(a => a.Email == email);

    public async Task<bool> CheckExistUsername(string userName) => await _context.Accounts.AnyAsync(a => a.UserName == userName);
  }
}