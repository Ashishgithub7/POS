using POS.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Inventory.Categories
{
    public interface ICategoryRepository
    {
        #region Read
        Task<List<Category>> GetAsync(Expression<Func<Category, bool>> predicate = null);
       
        #endregion Read

        #region Write

        Task SaveAsync(Category category);
        Task DeleteAsync(int id);
        Task UpdateAsync(Category category);

        #endregion Write
    }
}
