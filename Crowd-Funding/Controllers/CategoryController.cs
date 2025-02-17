using Crowd_Funding.DTO.Category;
using Crowd_Funding.Services;
using Microsoft.AspNetCore.Mvc;

namespace Crowd_Funding.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryService CategoryService;

        public CategoryController(CategoryService categoryService)
        {
            this.CategoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await CategoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await CategoryService.GetCategoryByIdAsync(id);
            if (category == null)
            {
                return NotFound($"Category with ID {id} not found.");
            }
            return Ok(category);

        }
        [HttpPost]
        public async Task<IActionResult> AddCategory(AddCategoryDTO categoryFromRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var category = await CategoryService.AddCategoryAsync(categoryFromRequest);
            return Created();

        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(GetCategoryDTO categoryFromRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await CategoryService.UpdateCategoryAsync(categoryFromRequest);
            return Ok(new { message = "Category Updated" });

        }
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {

            bool isDeleted = await CategoryService.DeleteCategoryAsync(id);
            if (!isDeleted)
                return NotFound(new { message = $"Category with ID {id} not found." });

            return Ok(new { message = "Category Deleted" });

        }
    }
}

