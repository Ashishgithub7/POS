using POS.Common.DTO.Common;
using POS.Common.Enums;
using POS.Data.Models;


namespace POS.Business.Services.Reporting.Sales
{
    public interface ISalesReportService
    {
        OutputDto<List<string>> GetReportType();
        Task<OutputDto<List<SalesReport>>> GetSalesReport(ReportType reportType);
    }
}
