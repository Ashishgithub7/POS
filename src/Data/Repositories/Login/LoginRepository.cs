using Microsoft.AspNetCore.Identity;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Repositories.Login
{
    public class LoginRepository : ILoginRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public LoginRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<AppUser> LoginAsync(string userName, string password)
        {
            var appUser = await _userManager
                                .FindByNameAsync(userName);
            if (appUser == null)
                return null;

            bool success = await _userManager
                                 .CheckPasswordAsync(appUser, password);
            return success ? appUser : null;
        }
    }
}
