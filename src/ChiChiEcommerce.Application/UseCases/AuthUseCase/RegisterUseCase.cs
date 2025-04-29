using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs.Auth;
using ChiChiEcommerce.Domain.Entities;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Application.UseCases.AuthUseCase
{
    public class RegisterUseCase
    {
        //private readonly IAccountRepository _accountRepo;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterUseCase(IUnitOfWork unitOfWork)
        {
            //_accountRepo = accountRepo;
            _unitOfWork = unitOfWork;
        }
        public async Task<bool> RegisterAsync(RegisterRequest request)
        {
            if (await _unitOfWork.Accounts.CheckExistEmail(request.Email))
            {
                throw new Exception("Email already exists");
            }
            //     if(await _accountRepo.CheckExistUsername(request.UserName)) {
            //     throw new Exception("Email already exists");
            //   }
            var user = new User();
            await _unitOfWork.Users.AddUserAsync(user);

            var account = new Account
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Status = Domain.AccountStatus.Active,
                UserId = user.Id,
                User = user,
            };
            await _unitOfWork.Accounts.AddAccountAsync(account);
            var result = await _unitOfWork.CompleteAsync();
            
            return result > 0;
        }
    }
}