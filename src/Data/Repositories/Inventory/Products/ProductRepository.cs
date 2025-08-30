using Microsoft.EntityFrameworkCore;
using POS.Common.Enums;
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
                                     .ThenInclude(x => x.Category) // Include Category through SubCategory
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
                                     .ThenInclude(x => x.Category) // Include Category through SubCategory
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
        public async Task UpdateStockAsync(BillingType billingType, List<Product> products) 
        {
            var productIds = products
                             .Select(x => x.Id)
                             .ToList();

            var existingProducts = await _context
                                         .Products
                                         .Where(x => productIds.Contains(x.Id))
                                         .ToListAsync();
            DateTime currentTime = DateTime.Now;

            foreach (var existingProduct in existingProducts) 
            {
                var product = products
                              .FirstOrDefault(x => x.Id == existingProduct.Id);

                if(product != null) 
                {
                    if (billingType == BillingType.Purchase)
                    {
                        existingProduct.Stock += product.Stock;
                    }
                    else 
                    {
                        if (existingProduct.Stock >= product.Stock)
                        { 
                            existingProduct.Stock -= product.Stock;
                        }
                        else
                        {
                            throw new Exception("Atleast one product OUT OF STOCK");
                        }
                    }


                    existingProduct.LastModifiedDate = currentTime;
                    existingProduct.LastModifiedBy = product.LastModifiedBy;
                }
               await _context.SaveChangesAsync();
            }
        }
        #endregion Write
    }
}
