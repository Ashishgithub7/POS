using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Login
{
    public interface ILoginRepository
    {
        Task<AppUser> LoginAsync(string userName, string password);
    }
}
