using POS.Data.Entities.Inventory;
using POS.Data.Entities.PurchaseBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.PurchaseBilling.Suppliers
{
    public interface ISupplierRepository
    {
        #region Read
        Task<List<Supplier>> GetAsync(Expression<Func<Supplier, bool>> predicate = null);

        #endregion Read

        #region Write

        Task SaveAsync(Supplier Supplier);
        Task DeleteAsync(int id);
        Task UpdateAsync(Supplier Supplier);

        #endregion Write
    }
}
