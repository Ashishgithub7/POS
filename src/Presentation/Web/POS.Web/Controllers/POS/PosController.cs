using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Business.Services.Inventory.Products;
using POS.Business.Services.POS;
using POS.Business.Services.Reporting.Sale;
using POS.Common.Constants;
using POS.Common.DTO.POS;
using POS.Common.DTO.PurchaseBilling.Purchase;
using POS.Common.Enums;
using POS.Web.Utilities;
using System.Security.Claims;
using System.Threading.Tasks;

namespace POS.Web.Controllers.POS
{
    [Route("[controller]")]
    [Authorize(Policy = Policy.SalesEntry)]
    public class PosController : Controller
    {
        private readonly ISalesService _salesService;
        private readonly IProductService _productService;

        public PosController(ISalesService salesService, IProductService productService)
        {
            _salesService = salesService;
            _productService = productService;
        }

        public async Task<IActionResult> Sales()
        {
            await LoadProductsViewBagAsync();
            return View();
        }

        [HttpGet("Product/List")]
        public async Task<IActionResult> GetAllProducts() 
        {
            var result = await _productService.GetAllAsync();
            var products = result.Data;
            return Json(products);
        }

        [HttpPost("Sales/Save")]
        public async Task<IActionResult> Save(SalesCreateDto request)
        {
            request.CreatedBy = GetUserId();
            var result = await _salesService.SaveAsync(request);
            if (result.Status == Status.Failed)
            {
                var errors = MessageAlert.FailureAlert(result);
                result.Error = errors;
            }
            else
                TempData[Others.SuccessMessage] = result.Message;

            return Json(result);
        }

        private int GetUserId()
        {
            int.TryParse(User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value, out int userId);
            return userId;
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
    }
}
