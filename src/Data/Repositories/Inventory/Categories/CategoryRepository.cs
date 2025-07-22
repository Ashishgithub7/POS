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

namespace POS.Data.Repositories.Inventory.Categories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read

        public async Task<List<Category>> GetAsync(Expression<Func<Category,bool>> predicate = null)
        {
            List<Category> records;
            if (predicate == null)
            {
                records = await _context
                                     .Categories
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
            else 
            {
                records = await _context
                                     .Categories
                                     .Where(predicate)
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
                return records;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var record = await _context
                                .Categories
                                .AsNoTracking()
                                .FirstOrDefaultAsync(x => x.Id == id);

            return record;
        }

        #endregion Read

        #region Write
        public async Task SaveAsync(Category request)
        {
            await CheckIfExist(request.Name);
            await _context
              .Categories
              .AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Category request)
        {
            await CheckIfExist(request.Name);
            var existingRecord = await GetExistingRecordAsync(request.Id);

            existingRecord.Name = request.Name;
            existingRecord.LastModifiedDate = DateTime.Now;
            existingRecord.LastModifiedBy = request.LastModifiedBy;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Category existingRecord = await GetExistingRecordAsync(id);

            _context
           .Categories
           .Remove(existingRecord);

            await _context.SaveChangesAsync();

            #endregion Write
        }

        private async Task<Category> GetExistingRecordAsync(int id)
        {
            var existingRecord = await _context
                                       .Categories
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (existingRecord == null)
            {
                throw new NullReferenceException($"Invalid category id: {id}");
            }

            return existingRecord;
        }

        private async Task CheckIfExist(string name)
        {
            bool exists = await _context
                                 .Categories
                                 .AnyAsync(x => x.Name == name);
            if (exists)
            {
                throw new Exception($"Category '{name}' already exists.");
            }
        }
    }
}
