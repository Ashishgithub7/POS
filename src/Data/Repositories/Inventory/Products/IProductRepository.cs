using POS.Common.Enums;
using POS.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Inventory.Products
{
    public interface IProductRepository
    {
        #region Read
        Task<List<Product>> GetAsync(Expression<Func<Product, bool>> predicate = null);

        #endregion Read

        #region Write

        Task SaveAsync(Product request);
        Task UpdateAsync(Product request);
        Task DeleteAsync(int id);
        Task UpdateStockAsync(BillingType billingType, List<Product> products);

        #endregion Write
    }
}
