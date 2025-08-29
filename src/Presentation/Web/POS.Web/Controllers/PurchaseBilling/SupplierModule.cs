using Microsoft.AspNetCore.Mvc;
using POS.Common.Constants;
using POS.Common.DTO.PurchaseBilling.Suppliers;
using POS.Common.Enums;
using POS.Web.Utilities;

namespace POS.Web.Controllers.PurchaseBilling
{
    public partial class PurchaseController 
    {
        [HttpGet("Supplier/List")]
        public async Task<IActionResult> SupplierList()
        {
            var result = await _supplierService.GetAllAsync();
            var suppliers = result.Data;
            if (result.Status == Status.Failed) 
            {
                TempData[Others.ErrorMessage] = result.Error;
            }
            return View();
        }

        [HttpGet("Supplier/Create")]
        public IActionResult SupplierCreate()
        {
            return View();
        }

        [HttpPost("Supplier/Create")]
        public async Task<IActionResult> SupplierCreate(SupplierCreateDto request) 
        {
            request.CreatedBy = GetUserId();
            var result = await _supplierService.SaveAsync(request);
            if (result.Status == Status.Success)
            {
                TempData[Others.SuccessMessage] = result.Message;
                return RedirectToAction("SupplierList");
            }
            TempData[Others.ErrorMessage] = MessageAlert.FailureAlert(result, this.ModelState);
            return View(request);
        }
    }
}
