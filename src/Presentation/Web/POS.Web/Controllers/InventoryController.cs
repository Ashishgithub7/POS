using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Business.Services.Inventory.Categories;
using POS.Common.Constants;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.Enums;
using POS.Web.Utilities;
using System.Security.Claims;
using System.Threading.Tasks;

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
