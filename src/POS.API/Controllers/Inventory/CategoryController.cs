using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using POS.Business.Services.Inventory.Categories;

namespace POS.API.Controllers.Inventory
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController( ICategoryService categoryService) 
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
           var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }
    }
}
