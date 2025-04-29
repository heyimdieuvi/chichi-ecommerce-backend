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
        public AuthController(RegisterUseCase registerUseCase)
        {
            _registerUseCase = registerUseCase;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register (RegisterRequest register) 
        {
            var result = await _registerUseCase.RegisterAsync(register);
            //if (result is false) return  
            return Created();
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login (LoginRequest request)
        {
            return Ok();
        } 
    }
}