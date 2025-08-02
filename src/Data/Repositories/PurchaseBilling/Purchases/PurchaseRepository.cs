using POS.Data.Data;
using POS.Data.Entities.PurchaseBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.PurchaseBilling.Purchases
{
    public class PurchaseRepository : IPurchaseRepository
    {
        private ApplicationDbContext _context;

        public PurchaseRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task SaveAsync(Purchase purchase) 
        {
            await _context.Purchases.AddAsync(purchase);
            await _context.SaveChangesAsync();
        }
    }
}
