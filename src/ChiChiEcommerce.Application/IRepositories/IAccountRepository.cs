using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Domain.Entities;

namespace ChiChiEcommerce.Domain.Repositories
{
    public interface IAccountRepository
    {
        Task<bool> CheckExistEmail (string email);
        Task AddAccountAsync(Account account);
        Task<bool> CheckExistUsername (string userName);
        Task<Account?> GetAccountByEmail (string email);
    }
}