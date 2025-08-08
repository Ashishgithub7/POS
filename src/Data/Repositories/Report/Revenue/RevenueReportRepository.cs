using POS.Data.Models;
using POS.Data.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Report.Revenue
{
    public class RevenueReportRepository : IRevenueReportRepository
    {
        private IDapperRepository _dapperRepository;
        public RevenueReportRepository(IDapperRepository dapperRepository)
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<RevenueReport> GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("@startDate", startDate);
            parameter.Add("@endDate", endDate);
            var result = await _dapperRepository.QueryFirstOrDefaultAsync<RevenueReport>("usp_GetRevenueReport", parameter);
            return result;
        }
    }
}
