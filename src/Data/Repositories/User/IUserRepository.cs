using Microsoft.AspNetCore.Identity;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.User
{
    public interface IUserRepository
    {
        Task<IdentityResult> SaveAsync(AppUser user, string password);
        Task<AppUser> GetByEmailAsync(string email);
    }
}
