using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Inventory.Products;
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
        private readonly IProductService _productService;

        public InventoryController(ICategoryService categoryService, ISubCategoryService subCategoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _productService = productService;
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
                categories.Insert(0, new SelectListItem { Value = "0", Text = "Please select a Category" });
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
