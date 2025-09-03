using Microsoft.AspNetCore.Mvc;
using POS.Common.Enums;

namespace POS.Web.Controllers.Report
{
    public partial class ReportController
    {
        [HttpGet("Sales")]
        public IActionResult Sales()
        {
            LoadReportTypes();
            return View();
        }

        [HttpGet("SalesReport")]
        public async Task<IActionResult> GetSalesReport(string request)
        {
            var reportType = Enum.Parse<ReportType>(request);
            var result = await _salesReportService.GetSalesReport(reportType);
            return Json(result.Data);
        }
    }
}
