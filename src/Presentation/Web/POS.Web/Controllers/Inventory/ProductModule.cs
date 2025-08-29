using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Common.Constants;
using POS.Common.Enums;
using POS.Web.Utilities;
using POS.Common.DTO.Inventory.Categories;
using POS.Business.Services.Inventory.SubCategories;
using POS.Common.DTO.Inventory.SubCategories;
using System.Threading.Tasks;
using POS.Common.DTO.Inventory.Products;

namespace POS.Web.Controllers
{
    public partial class InventoryController
    {

        [HttpGet("Product/List")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> ProductList()
        {
            var result = await _productService.GetAllAsync();
            var products = result.Data;
            if (result.Status == Status.Failed) 
            {
                TempData[Others.ErrorMessage] = result.Error;
                //return View(new List<ProductReadDto>());
            }
            return View(products);
        }

        [HttpGet("Product/Create")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> ProductCreate()
        {
            await LoadCategoriesToViewBag();
            ProductCreateDto request = new ProductCreateDto();
            return View(request);
        }

        [HttpPost("Product/Create")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> ProductCreate(ProductCreateDto request)
        {
            await LoadCategoriesToViewBag();
            request.CreatedBy = GetUserId();
            var result = await _productService.SaveAsync(request);
            if (result.Status == Status.Success)
            {
                TempData[Others.SuccessMessage] = result.Message;
                return RedirectToAction("ProductList");
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(request);

        }

        [HttpGet("Product/Edit")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> ProductEdit(int id)
        {
            await LoadCategoriesToViewBag();
            var model = new ProductUpdateDto();
            var result = await _productService.GetByIdAsync(id);

            if (result.Status == Status.Success)
            {
                model.Id = result.Data.Id;
                model.CategoryId = result.Data.CategoryId;
                model.SubCategoryId = result.Data.SubCategoryId;
                model.Name = result.Data.Name;
                model.PurchasePrice = result.Data.PurchasePrice;
                model.SellingPrice = result.Data.SellingPrice;
                return View(model);
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(model);
        }

        [HttpPost("Product/Edit")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> ProductEdit(ProductUpdateDto request)
        {
            request.CreatedBy = GetUserId();
            var result = await _productService.UpdateAsync(request);
            if (result.Status == Status.Success)
            {
                TempData[Others.SuccessMessage] = result.Message;
                return RedirectToAction("ProductList");
            }

            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(request);

        }

        [HttpDelete("Product/Delete/{id}")]
        [Authorize(Policy = Policy.InventoryEditOrDelete)]
        public async Task<IActionResult> ProductDelete(int id)
        {
            var result = await _productService.DeleteAsync(id);
            return Json(result);
        }

        [HttpGet("SubCategory/Category/{categoryId}")]
        [Authorize(Policy = Policy.InventoryCreateOrList)]
        public async Task<IActionResult> GetSubCategoriesByCategoryId(int categoryId)
        {
            var result = await _subCategoryService.GetByCategoryIdAsync(categoryId);
            var subCategories = result
                                .Data
                                .Select(x => new 
                                {
                                    Id = x.Id,
                                    Name = x.Name
                                }).ToList();
            return Json(subCategories);
        }
    }
}
