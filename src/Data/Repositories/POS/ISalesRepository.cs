using POS.Data.Entities.POS;
using POS.Data.Entities.PurchaseBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.POS
{
    public interface ISalesRepository
    {
        Task SaveAsync(Sales sales);

    }
}
