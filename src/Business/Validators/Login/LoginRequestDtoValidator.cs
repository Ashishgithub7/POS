using FluentValidation;
using POS.Common.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.Validators.Login
{
    public class LoginRequestDtoValidator : AbstractValidator<LoginRequestDto>
    {
        public LoginRequestDtoValidator()
        {
            RuleFor(x => x.UserName)
            .NotEmpty()
            .WithMessage("User name is required.");

            RuleFor(x => x.Password)
            .NotEmpty()
            .WithMessage("Password is required.");
        }
    }
}
