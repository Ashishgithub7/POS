using Azure.Core;
using Microsoft.EntityFrameworkCore;
using POS.Data.Data;
using POS.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Inventory.SubCategories
{
    public class SubCategoryRepository : ISubCategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public SubCategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read

        public async Task<List<SubCategory>> GetAsync(Expression<Func<SubCategory,bool>> predicate = null)
        {
            List<SubCategory> records;
            if (predicate == null)
            {
                records = await _context
                                     .SubCategories
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .Include(x => x.Category)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
            else 
            {
                records = await _context
                                     .SubCategories
                                     .Where(predicate)
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .Include(x => x.Category)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
                return records;
        }

        #endregion Read

        #region Write
        public async Task SaveAsync(SubCategory request)
        {
            await CheckIfExist(request.Name);
            await _context
                  .SubCategories
                  .AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(SubCategory request)
        {
            var existingRecord = await GetExistingRecordAsync(request.Id);

            if(request.Name != existingRecord.Name)
            {
               await CheckIfExist(request.Name); 
            }

            existingRecord.Name = request.Name;
            existingRecord.LastModifiedDate = DateTime.Now;
            existingRecord.LastModifiedBy = request.LastModifiedBy;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            SubCategory existingRecord = await GetExistingRecordAsync(id);

            _context
           .SubCategories
           .Remove(existingRecord);

            await _context.SaveChangesAsync();

            #endregion Write
        }

        private async Task<SubCategory> GetExistingRecordAsync(int id)
        {
            var existingRecord = await _context
                                       .SubCategories
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (existingRecord == null)
            {
                throw new NullReferenceException($"Invalid SubCategory id: {id}");
            }

            return existingRecord;
        }

        private async Task CheckIfExist(string name)
        {
            bool exists = await _context
                                 .SubCategories
                                 .AnyAsync(x => x.Name == name);
            if (exists)
            {
                throw new Exception($"SubCategory '{name}' already exists.");
            }
        }
    }
}
