using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace POS.Web.Controllers.PurchaseBilling
{
    [Route("[controller]")]
    public partial class PurchaseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
