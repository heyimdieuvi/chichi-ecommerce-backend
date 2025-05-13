using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs.Auth;
using ChiChiEcommerce.Application.Interface;
using ChiChiEcommerce.Application.UseCases.AuthUseCase;
using Microsoft.AspNetCore.Mvc;

namespace ChiChiEcommerce.WebAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly RegisterUseCase _registerUseCase;
        private readonly LoginUseCase _loginUseCase;
        public AuthController(RegisterUseCase registerUseCase, LoginUseCase loginUseCase)
        {
            _registerUseCase = registerUseCase;
            _loginUseCase = loginUseCase;

        }
        [HttpPost("register")]
        public async Task<IActionResult> Register ([FromBody] RegisterRequest register) 
        {
            var result = await _registerUseCase.RegisterAsync(register);
            if (result is false) return Conflict("Email is existed.");
            return Created();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] LoginRequest request)
        {
            var response = await _loginUseCase.LoginAsync(request);
            return response is null ? Unauthorized(new { Message = "Wrong Email or Password!"}) : Ok(new{response});
        } 
    }
}