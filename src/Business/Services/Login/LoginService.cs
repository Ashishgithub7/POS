using FluentValidation;
using POS.Common.DTO.Common;
using POS.Common.DTO.Login;
using POS.Common.Utilities;
using POS.Data.Entities.Login;
using POS.Data.Repositories.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Login
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;
        private readonly IValidator<LoginRequestDto> _loginValidator;

        public LoginService(ILoginRepository loginRepository, IValidator<LoginRequestDto> loginValidator)
        {
            _loginRepository = loginRepository;
            _loginValidator = loginValidator;
        }

        public async Task<OutputDto<AppUser>> LoginAsync(LoginRequestDto request)
        {
            try
            {
                var validationResult = await _loginValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                    return OutputDtoConverter.SetFailed<AppUser>(validationResult,null);

                var appUser = await _loginRepository.LoginAsync(request.UserName, request.Password);
                if (appUser!= null)
                    return OutputDtoConverter.SetSuccess<AppUser>(appUser);

                return OutputDtoConverter.SetFailed<AppUser>("Invalid username or password", null);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<AppUser>(ex.Message,null);
            }
        }
    }
}
