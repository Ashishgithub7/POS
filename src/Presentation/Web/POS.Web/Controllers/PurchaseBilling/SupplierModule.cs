using Microsoft.AspNetCore.Mvc;

namespace POS.Web.Controllers.PurchaseBilling
{
    public partial class PurchaseController 
    {
        public IActionResult SupplierList()
        {
            return View();
        }
    }
}
