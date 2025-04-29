using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChiChiEcommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize(Roles = "Seller,Admin")]
    public class ShopsController : ControllerBase
    {
        private readonly ShopService _shopService;

        [HttpPost]
        public async Task<IActionResult> CreateShop([FromBody] ShopDto shopDto)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(shopDto.Name) || string.IsNullOrEmpty(shopDto.Location))
            {
                return BadRequest("Shop name and location are required.");
            }

            try
            {
                await _shopService.CreateShopAsync(shopDto);
                return Ok("Shop created successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating shop: {ex.Message}");
            }
        }

        [HttpGet("{shopId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetShop(Guid shopId)
        {
            try
            {
                var shop = await _shopService.GetShopByIdAsync(shopId);
                return Ok(shop);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving shop: {ex.Message}");
            }
        }
    }
}
