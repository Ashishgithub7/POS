using Microsoft.EntityFrameworkCore;
using POS.Data.Data;
using POS.Data.Entities.POS;
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
        private readonly ApplicationDbContext _context;
        public RevenueReportRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Sales>> GetRevenueReport(DateTime startDate, DateTime endDate)
        {
            var parameter = new Dictionary<string, object>();
            parameter.Add("@startDate", startDate);
            parameter.Add("@endDate", endDate);

            var result = await _context
                               .Sales
                               .Where(x => x.CreatedDate >= startDate &&  x.CreatedDate < endDate)
                               .Include(x => x.SalesDetails)
                               .ThenInclude(x => x.Product)
                               .AsNoTracking() // Use AsNoTracking for read-only queries
                               .OrderByDescending(x => x.CreatedDate)
                               .ToListAsync();

            return result;
        }
    }
}
