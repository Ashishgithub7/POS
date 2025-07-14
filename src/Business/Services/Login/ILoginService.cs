using POS.Common.DTO.Common;
using POS.Common.DTO.Login;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Login
{
    public interface ILoginService
    {
        Task<OutputDto<AppUser>> LoginAsync(LoginRequestDto request);
    }
}
