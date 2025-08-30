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
            request.CreatedBy = GetUserId();
            var result = await _purchaseService.SaveAsync(request);
            if (result.Status == Status.Failed)
            {
                var errors = MessageAlert.FailureAlert(result);
                result.Error = errors;
            }
            else
                TempData[Others.SuccessMessage] = "Purchase saved successfully";

            return Json(result);
        }
    }
}
