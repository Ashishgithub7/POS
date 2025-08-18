using FluentValidation;
using POS.Common.DTO.Common;
using POS.Common.DTO.User;
using POS.Common.Utilities;
using POS.Data.Entities.Login;
using POS.Data.Repositories.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IValidator<UserCreateDto> _userCreateValidator;
        public async Task<OutputDto<AppUser>> GetByEmailAsync(string email)
        {
            try 
            {
                var result = await _userRepository.GetByEmailAsync(email);
                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<AppUser>(ex.Message,null);
            }
        }

        public async Task<OutputDto> SaveAsync(UserCreateDto request)
        {
            try
            {
                var validationResult = _userCreateValidator.Validate(request);
                if (!validationResult.IsValid)
                {
                    var error = validationResult.Errors
                                                .Select(x => x.ErrorMessage)
                                                .ToList();
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var appUser = new AppUser
                {
                    UserName = request.Email,
                    Email = request.Email,
                    CreatedDate = DateTime.Now
                };
                var result = await _userRepository.SaveAsync(appUser, request.Password);
                return OutputDtoConverter.SetSuccess(result);

            }
            catch (Exception ex) 
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }
    }
}
