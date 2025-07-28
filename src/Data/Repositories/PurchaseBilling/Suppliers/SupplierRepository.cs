using Microsoft.EntityFrameworkCore;
using POS.Data.Data;
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
    public class SupplierRepository : ISupplierRepository
    {
        private readonly ApplicationDbContext _context;

        public SupplierRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        #region Read

        public async Task<List<Supplier>> GetAsync(Expression<Func<Supplier, bool>> predicate = null)
        {
            List<Supplier> records;
            if (predicate == null)
            {
                records = await _context
                                     .Suppliers
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
            else
            {
                records = await _context
                                     .Suppliers
                                     .Where(predicate)
                                     .Include(x => x.CreatedByUser)
                                     .Include(x => x.UpdatedByUser)
                                     .AsNoTracking() // Use AsNoTracking for read-only queries
                                     .OrderByDescending(x => x.CreatedDate)
                                     .ToListAsync();
            }
            return records;
        }

        #endregion Read

        #region Write
        public async Task SaveAsync(Supplier request)
        {
            await CheckIfExist(request.Name, request.ContactNumber);
            await _context
              .Suppliers
              .AddAsync(request);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Supplier request)
        {
            var existingRecord = await GetExistingRecordAsync(request.Id);

            if (request.Name != existingRecord.Name)
            {
                await CheckIfExist(request.Name,request.ContactNumber);
            }

            existingRecord.Name = request.Name;
            existingRecord.ContactPerson = request.ContactPerson;
            existingRecord.ContactNumber = request.ContactNumber;
            existingRecord.EmailAddress = request.EmailAddress;
            existingRecord.Address = request.Address;
            existingRecord.LastModifiedDate = DateTime.Now;
            existingRecord.LastModifiedBy = request.LastModifiedBy;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            Supplier existingRecord = await GetExistingRecordAsync(id);

            _context
           .Suppliers
           .Remove(existingRecord);

            await _context.SaveChangesAsync();

            #endregion Write
        }

        private async Task<Supplier> GetExistingRecordAsync(int id)
        {
            var existingRecord = await _context
                                       .Suppliers
                                       .FirstOrDefaultAsync(x => x.Id == id);
            if (existingRecord == null)
            {
                throw new NullReferenceException($"Invalid Supplier id: {id}");
            }

            return existingRecord;
        }

        private async Task CheckIfExist(string name, string contactNumber)
        {
            bool exists = await _context
                                 .Suppliers
                                 .AnyAsync(x => (x.Name.ToLower() == name.ToLower() && x.ContactPerson.ToLower() == contactNumber.ToLower()));
            if (exists)
            {
                throw new Exception($"Supplier '{name}' with Contact Number '{contactNumber}'already exists.");
            }
        }
    }
}

