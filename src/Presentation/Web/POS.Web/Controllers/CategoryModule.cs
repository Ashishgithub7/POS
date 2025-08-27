using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Common.Constants;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.Enums;
using POS.Web.Utilities;

namespace POS.Web.Controllers
{
    public partial class InventoryController
    {
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

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
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

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
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

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(request);

        }

        [HttpDelete("Category/Delete/{id}")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> CategoryDelete(int id)
        {
            var result = await _categoryService.DeleteAsync(id);
            return Json(result);
        }
    }
}
