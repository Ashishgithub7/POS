using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Utilities
{
    public interface ITransactionManager
    {
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
