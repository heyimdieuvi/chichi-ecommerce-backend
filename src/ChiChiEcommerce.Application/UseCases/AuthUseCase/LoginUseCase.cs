using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs.Auth;
using ChiChiEcommerce.Application.Interface;
using ChiChiEcommerce.Domain.Repositories;

namespace ChiChiEcommerce.Application.UseCases.AuthUseCase
{
    public class LoginUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtService _jwtService;
        public LoginUseCase(IUnitOfWork unitOfWork, IJwtService jwtService) 
        {
            _unitOfWork = unitOfWork;
            _jwtService = jwtService;
        }
        public async Task<LoginResponse?> LoginAsync(LoginRequest request) 
        {
            //viec check required email voi password check o annotaion rui
            //get account tu email lieu co ton tai ko
            var account = await _unitOfWork.Accounts.GetAccountByEmail(request.Email);
            if (account is null) return null;
            //check xong roi lay password ra
            var password = account.Password;
            var inputPass = request.Password;
            var result = BCrypt.Net.BCrypt.Verify(inputPass, password);
            if (result is false) return null;
            var token = _jwtService.GenerateToken(account);
            return new LoginResponse{
                Email = account.Email,
                Role = account.Role,
                Token = token
            };
        }
        
    }
}