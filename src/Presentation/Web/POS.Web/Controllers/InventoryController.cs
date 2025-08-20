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
    public class InventoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public InventoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("Category/List")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> CategoryList()
        {
            var result = await _categoryService.GetAllAsync();
            return View(result.Data);
        }

        [HttpGet("Category/Create")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public IActionResult CategoryCreate()
        {
            return View();
        }

        [HttpPost("Category/Create")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> CategoryCreate(CategoryCreateDto request)
        {
            request.CreatedBy = GetUserId();
            var result = await _categoryService.SaveAsync(request);
            if (result.Status == Status.Success)
            {
                TempData[Others.SuccessMessage] = result.Message;
                return RedirectToAction("CategoryList");
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result);
            return View(request);

        }

        [HttpGet("Category/Edit")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> CategoryEdit(int id)
        {
            var model = new CategoryUpdateDto();
            var result = await _categoryService.GetByIdAsync(id);

            if (result.Status == Status.Success)
            {
                model.Id = result.Data.Id;
                model.Name = result.Data.Name;
                return View(model);
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result);
            return View(model);
        }

        [HttpPost("Category/Edit")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> CategoryEdit(CategoryUpdateDto request)
        {
            request.CreatedBy = GetUserId();
            var result = await _categoryService.UpdateAsync(request);
            if (result.Status == Status.Success)
            {
                TempData[Others.SuccessMessage] = result.Message;
                return RedirectToAction("CategoryList");
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result);
            return View(request);

        }

        private int GetUserId()
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value, out int userId);
            return userId;
        }
    }
}
