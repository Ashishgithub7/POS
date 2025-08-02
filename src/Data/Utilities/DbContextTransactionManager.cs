using Microsoft.EntityFrameworkCore.Storage;
using POS.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Utilities
{
    public class DbContextTransactionManager : ITransactionManager
    {
        private readonly ApplicationDbContext _context;
        public DbContextTransactionManager(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IDbContextTransaction> BeginTransactionAsync()
        {
            return await _context.Database.BeginTransactionAsync();
        }
    }
}
