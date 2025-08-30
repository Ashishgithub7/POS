using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Common.Constants;
using POS.Common.DTO.PurchaseBilling.Purchase;
using POS.Common.Enums;
using POS.Web.Utilities;
using System.Threading.Tasks;

namespace POS.Web.Controllers.PurchaseBilling
{
    public partial class PurchaseController 
    {
        public async Task<IActionResult> Index()
        {
            await LoadViewBagsAsync();
            return View();
        }

        [HttpGet("Product/List")]
        public async Task<IActionResult> GetAllProducts()
        {
            var result = await _productService.GetAllAsync();
            var products = result.Data;
            return Json(products);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save(PurchaseCreateDto request) 
        {
            var result = await _purchaseService.SaveAsync(request);
            return Json(result);
        }

        private async Task LoadViewBagsAsync() 
        {
            await LoadProductsViewBagAsync();
            await LoadSuppliersViewBagAsync();
        }

        private async Task LoadProductsViewBagAsync() 
        {
            var result = await _productService.GetAllAsync();
            if (result.Status == Status.Success) 
            {
                var products = result
                               .Data
                               .Select(x => new SelectListItem 
                               {
                                   Value = x.Id.ToString(),
                                   Text = x.Name
                               }).ToList();
                products.Insert(0, new SelectListItem 
                                { 
                                    Value = "0", 
                                    Text = "Please select a Product" 
                                });
                ViewBag.Products = products;
                return;
            }
            TempData[Others.ErrorMessage] = result.Error;
        }

        private async Task LoadSuppliersViewBagAsync() 
        {
            var result = await _supplierService.GetAllAsync();
            if (result.Status == Status.Success)
            {
                var suppliers = result
                               .Data
                               .Select(x => new SelectListItem
                               {
                                   Value = x.Id.ToString(),
                                   Text = x.Name
                               }).ToList();
                suppliers.Insert(0, new SelectListItem
                {
                    Value = "0",
                    Text = "Please select a Supplier"
                });
                ViewBag.Suppliers = suppliers;
                return;
            }
            TempData[Others.ErrorMessage] = result.Error;
        }
    }
}
