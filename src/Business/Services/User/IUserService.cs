using POS.Common.DTO.Common;
using POS.Common.DTO.User;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.User
{
    public interface IUserService
    {
        Task<OutputDto> SaveAsync(UserCreateDto request);
        Task<OutputDto<AppUser>> GetByEmailAsync(string email);
    }
}
