using Microsoft.AspNetCore.Mvc;
using POS.Common.Enums;

namespace POS.Web.Controllers.Report
{
    public partial class ReportController
    {
        [HttpGet("Revenue")]
        public IActionResult Revenue()
        {
            LoadReportTypes();
            return View();
        }

        [HttpGet("RevenueReport")]
        public async Task<IActionResult> GetRevenueReport(string request)
        {
            var reportType = Enum.Parse<ReportType>(request);
            var result = await _revenueReportService.GetRevenueReport(reportType);
            return Json(result.Data);
        }
    }
}
