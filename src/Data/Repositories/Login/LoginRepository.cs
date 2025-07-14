using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        public Task<bool> LoginAsync(string userName, string password)
        {
            throw new NotImplementedException();
        }
    }
}
