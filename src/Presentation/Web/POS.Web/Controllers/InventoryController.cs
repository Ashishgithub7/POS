using Microsoft.AspNetCore.Mvc;
using POS.Business.Services.Inventory.Categories;
using System.Security.Claims;

namespace POS.Web.Controllers
{
    [Route("[controller]")]
    public partial class InventoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public InventoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        

        private int GetUserId()
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value, out int userId);
            return userId;
        }
    }
}
