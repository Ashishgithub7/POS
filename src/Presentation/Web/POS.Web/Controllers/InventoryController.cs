using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Inventory.SubCategories;
using POS.Common.Constants;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.Enums;
using System.Security.Claims;

namespace POS.Web.Controllers
{
    [Route("[controller]")]
    public partial class InventoryController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;

        public InventoryController(ICategoryService categoryService, ISubCategoryService subCategoryService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
        }

        private async Task LoadCategoriesToViewBag() 
        {
            var result = await _categoryService.GetAllAsync();
            if (result.Status == Status.Success)
            {
                var categories = result
                                .Data
                                .Select(x =>  new SelectListItem 
                                {
                                    Value = x.Id.ToString(),
                                    Text = x.Name
                                }).ToList();
                categories.Insert(0, new SelectListItem { Value = "0", Text = "Select a Category" });
                ViewBag.Categories = categories;
                return;
            }
            else
            {
                TempData[Others.ErrorMessage] = result.Error;
            }
        }

        private int GetUserId()
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value, out int userId);
            return userId;
        }
    }
}
