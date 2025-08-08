using POS.Common.DTO.Common;
using POS.Common.Enums;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Reporting.Revenue
{
    public interface IRevenueReportService
    {
        OutputDto<List<string>> GetReportType();
        Task<OutputDto<List<RevenueReport>>> GetRevenueReport(ReportType reportType);
    }
}
