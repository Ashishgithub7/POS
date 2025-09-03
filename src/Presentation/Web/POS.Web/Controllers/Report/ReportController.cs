using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using POS.Business.Services.Reporting.Revenue;
using POS.Business.Services.Reporting.Sale;
using POS.Common.Constants;
using POS.Common.Enums;

namespace POS.Web.Controllers.Report
{
    [Route("[controller]")]
    [Authorize(Policy =Policy.SalesEntry)]
    public partial class ReportController : Controller
    {
        private readonly ISalesReportService _salesReportService;
        private readonly IRevenueReportService _revenueReportService;

        public ReportController(ISalesReportService salesReportService, IRevenueReportService revenueReportService)
        {
            _salesReportService = salesReportService;
            _revenueReportService = revenueReportService;
        }

        private void LoadReportTypes() 
        {
            var result = _salesReportService.GetReportType();
            if (result.Status == Status.Success)
            {
                var reportTypes = result
                               .Data
                               .Select(x => new SelectListItem
                               {
                                   Value = x,
                                   Text = x
                               }).ToList();
                reportTypes.Insert(0, new SelectListItem
                {
                    Value = "0",
                    Text = "Please select a Type"
                });
                ViewBag.ReportType = reportTypes;
                return;
            }
        }
    }
}
