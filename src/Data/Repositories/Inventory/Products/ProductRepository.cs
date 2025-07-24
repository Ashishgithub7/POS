using Microsoft.EntityFrameworkCore;
using POS.Data.Data;
using POS.Data.Entities.Inventory;
using POS.Data.Repositories.Inventory.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Inventory.Products
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read

        public async Task<List<Product>> GetAsync(Expression<Func<Product, bool>> predicate = null)
        {
            List<Product> records;
            if (predicate == null)
            {
                records = await _context
                                     .Products
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .Include(x => x.SubCategory)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
            else
            {
                records = await _context
                                     .Products
                                     .Where(predicate)
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .Include(x => x.SubCategory)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
            return records;
        }

        #endregion Read

        #region Write
        public async Task SaveAsync(Product request)
        {
            await CheckIfExist(request.Name);
            await _context
                  .Products
                  .AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Product request)
        {
            var existingRecord = await GetExistingRecordAsync(request.Id);

            if (request.Name != existingRecord.Name)
            {
                await CheckIfExist(request.Name);
            }

            existingRecord.Name = request.Name;
            existingRecord.SubCategoryId = request.SubCategoryId;
            existingRecord.PurchasePrice = request.PurchasePrice;
            existingRecord.SellingPrice = request.SellingPrice;
            existingRecord.LastModifiedDate = DateTime.Now;
            existingRecord.LastModifiedBy = request.LastModifiedBy;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Product existingRecord = await GetExistingRecordAsync(id);
               _context
               .Products
               .Remove(existingRecord);

            await _context.SaveChangesAsync();

            #endregion Write
        }

        private async Task<Product> GetExistingRecordAsync(int id)
        {
            var existingRecord = await _context
                                       .Products
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (existingRecord == null)
            {
                throw new NullReferenceException($"Invalid Product id: {id}");
            }

            return existingRecord;
        }

        private async Task CheckIfExist(string name)
        {
            bool exists = await _context
                                 .Products
                                 .AnyAsync(x => x.Name == name);
            if (exists)
            {
                throw new Exception($"Product '{name}' already exists.");
            }
        }
    }
}
