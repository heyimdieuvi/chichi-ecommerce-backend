using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.IRepositories;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Infrastructure.Repositories
{
  public class UserRepository : IUserRepository
  {
    private readonly ApplicationDbContext _context;
    public UserRepository(ApplicationDbContext context)
    {
      _context = context;
    }
    
    public async Task AddUserAsync(User user) => await _context.Users.AddAsync(user);

  }
}