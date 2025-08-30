using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Business.Services.Inventory.Products;
using POS.Business.Services.PurchaseBilling.Purchases;
using POS.Business.Services.PurchaseBilling.Suppliers;
using POS.Common.Constants;
using POS.Common.Enums;
using System.Security.Claims;

namespace POS.Web.Controllers.PurchaseBilling
{
    [Route("[controller]")]
    [Authorize(Policy = Policy.PurchaseEntry)]
    public partial class PurchaseController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IPurchaseService _purchaseService;
        private readonly IProductService _productService;

        public PurchaseController(ISupplierService supplierService, IPurchaseService purchaseService, IProductService productService)
        {
            _supplierService = supplierService;
            _purchaseService = purchaseService;
            _productService = productService;
        }

        private int GetUserId()
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value, out int userId);
            return userId;
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
