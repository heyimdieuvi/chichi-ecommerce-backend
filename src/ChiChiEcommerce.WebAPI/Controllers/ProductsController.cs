using System;
using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Application.Usecases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChiChiEcommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly GetProductUseCase _getProductUseCase;
        private readonly CreateProductUseCase _createProductUseCase;

        public ProductsController(GetProductUseCase getProductUseCase, CreateProductUseCase createProductUseCase)
        {
            _getProductUseCase = getProductUseCase;
            _createProductUseCase = createProductUseCase;
        }

        [HttpPost]
        // [Authorize(Roles = "Seller,Admin")]
        public async Task<IActionResult> CreateProduct([FromBody] ProductDto productDto)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(productDto.Name))
            {
                return BadRequest("Product name is required.");
            }

            try
            {
                await _createProductUseCase.ExecuteAsync(productDto);
                return Ok("Product created successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating product: {ex.Message}");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetProducts([FromQuery] string? searchTerm, [FromQuery] Guid? categoryId, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            try
            {
                var result = await _getProductUseCase.GetProductsAsync(searchTerm, categoryId, pageNumber, pageSize);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving products: {ex.Message}");
            }
        }
    }
}