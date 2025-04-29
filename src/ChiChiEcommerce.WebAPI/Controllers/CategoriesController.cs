using System.Threading.Tasks;
using ChiChiEcommerce.Application.DTOs;
using ChiChiEcommerce.Application.Usecases;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ChiChiEcommerce.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly GetAllCategoryUseCase _getAllCategoryUseCase;
        private readonly CreateCategoryUseCase _createCategoryUseCase;

        public CategoriesController(GetAllCategoryUseCase getAllCategoryUseCase, CreateCategoryUseCase createCategoryUseCase)
        {
            _getAllCategoryUseCase = getAllCategoryUseCase;
            _createCategoryUseCase = createCategoryUseCase;
        }
    
        [HttpPost]
        // [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryDto categoryDto)
        {
            if (!ModelState.IsValid || string.IsNullOrEmpty(categoryDto.Name))
            {
                return BadRequest("Category name is required.");
            }

            try
            {
                await _createCategoryUseCase.ExecuteAsync(categoryDto);
                return Ok("Category created successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error creating category: {ex.Message}");
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllCategories()
        {
            try
            {
                var categories = await _getAllCategoryUseCase.GetAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error retrieving categories: {ex.Message}");
            }
        }
    }
}