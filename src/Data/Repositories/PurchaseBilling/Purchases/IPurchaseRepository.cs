using POS.Data.Entities.PurchaseBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.PurchaseBilling.Purchases
{
    public interface IPurchaseRepository
    {
        Task SaveAsync(Purchase purchase);
    }
}
