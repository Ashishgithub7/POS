using POS.Data.Data;
using POS.Data.Entities.POS;
using POS.Data.Entities.PurchaseBilling;
using POS.Data.Repositories.PurchaseBilling.Purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.POS
{
    public class SalesRepository : ISalesRepository
    {
        private ApplicationDbContext _context;

        public SalesRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SaveAsync(Sales sales)
        {
            await _context.Sales.AddAsync(sales);
            await _context.SaveChangesAsync();
        }
    }
}

