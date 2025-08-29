using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using POS.Business.Services.PurchaseBilling.Purchases;
using POS.Business.Services.PurchaseBilling.Suppliers;
using System.Security.Claims;

namespace POS.Web.Controllers.PurchaseBilling
{
    [Route("[controller]")]
    public partial class PurchaseController : Controller
    {
        private readonly ISupplierService _supplierService;
        private readonly IPurchaseService _purchaseService;

        public PurchaseController(ISupplierService supplierService, IPurchaseService purchaseService)
        {
            _supplierService = supplierService;
            _purchaseService = purchaseService;
        }

        public IActionResult Index()
        {
            return View();
        }

        private int GetUserId()
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value, out int userId);
            return userId;
        }
    }
}
