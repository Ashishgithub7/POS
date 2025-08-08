using POS.Data.Models;
using POS.Data.Repositories.Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Report.Sale
{
    public class SalesReportRepository : ISalesReportRepository
    {
        private IDapperRepository _dapperRepository;    
        public SalesReportRepository(IDapperRepository dapperRepository) 
        {
            _dapperRepository = dapperRepository;
        }

        public async Task<SalesReport> GetSalesReport(DateTime startDate, DateTime endDate)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("@startDate", startDate);
            parameter.Add("@endDate", endDate);
            var result = await _dapperRepository.QueryFirstOrDefaultAsync<SalesReport>("usp_GetSalesReport", parameter);
            return result;
        }
    }
}
