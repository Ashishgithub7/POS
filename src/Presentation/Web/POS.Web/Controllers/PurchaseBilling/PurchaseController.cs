using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Business.Services.Inventory.Products;
using POS.Business.Services.PurchaseBilling.Purchases;
using POS.Business.Services.PurchaseBilling.Suppliers;
using POS.Common.Constants;
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
    }
}
