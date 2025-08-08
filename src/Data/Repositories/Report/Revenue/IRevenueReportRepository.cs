using POS.Data.Entities.POS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Report.Revenue
{
    public interface IRevenueReportRepository
    {
        Task<List<Sales>> GetRevenueReport(DateTime startDate, DateTime endDate);

    }
}
