using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Common.Constants;
using POS.Common.Enums;
using POS.Web.Utilities;
using POS.Common.DTO.Inventory.Categories;
using POS.Business.Services.Inventory.SubCategories;
using POS.Common.DTO.Inventory.SubCategories;
using System.Threading.Tasks;

namespace POS.Web.Controllers
{
    public partial class InventoryController
    {

        [HttpGet("SubCategory/List")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> SubCategoryList()
        {
            var result = await _subCategoryService.GetAllAsync();
            var subCategories = result.Data;
            if (result.Status == Status.Failed) 
            {
                TempData[Others.ErrorMessage] = result.Error;
                //return View(new List<SubCategoryReadDto>());
            }
            return View(subCategories);
        }

        [HttpGet("SubCategory/Create")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> SubCategoryCreate()
        {
            await LoadCategoriesToViewBag();
            return View();
        }

        [HttpPost("SubCategory/Create")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> SubCategoryCreate(SubCategoryCreateDto request)
        {
            await LoadCategoriesToViewBag();
            request.CreatedBy = GetUserId();
            var result = await _subCategoryService.SaveAsync(request);
            if (result.Status == Status.Success)
            {
                TempData[Others.SuccessMessage] = result.Message;
                return RedirectToAction("SubCategoryList");
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(request);

        }

        [HttpGet("SubCategory/Edit")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SubCategoryEdit(int id)
        {
            await LoadCategoriesToViewBag();
            var model = new SubCategoryUpdateDto();
            var result = await _subCategoryService.GetByIdAsync(id);

            if (result.Status == Status.Success)
            {
                model.Id = result.Data.Id;
                model.CategoryId = result.Data.CategoryId;
                model.Name = result.Data.Name;
                return View(model);
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(model);
        }

        [HttpPost("SubCategory/Edit")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SubCategoryEdit(SubCategoryUpdateDto request)
        {
            request.CreatedBy = GetUserId();
            var result = await _subCategoryService.UpdateAsync(request);
            if (result.Status == Status.Success)
            {
                TempData[Others.SuccessMessage] = result.Message;
                return RedirectToAction("SubCategoryList");
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(request);

        }

        [HttpDelete("SubCategory/Delete/{id}")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> SubCategoryDelete(int id)
        {
            var result = await _subCategoryService.DeleteAsync(id);
            return Json(result);
        }
    }
}
