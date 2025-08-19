using FluentValidation;
using POS.Common.DTO.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.User
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.Email)
                    .NotEmpty()
                    .WithMessage("Email is required.")
                    .EmailAddress()
                    .WithMessage("Invalid email format.");

            RuleFor(x => x.Password)
                    .NotEmpty()
                    .WithMessage("Password is required.")
                    .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
                    .MaximumLength(16).WithMessage("Password length must not exceed 16")
                    .Matches(@"[A-Z]+").WithMessage("Password must contain atleast one uppercase letter")
                    .Matches(@"[a-z]+").WithMessage("Password must contain atleast one lowercase letter")
                    .Matches(@"[0-9]+").WithMessage("Password must contain atleast one number")
                    .Matches(@"[^a-zA-Z0-9]").WithMessage("Password must contain atleast one special character");

            RuleFor(x => x.ConfirmPassword)
                   .NotEmpty()
                   .WithMessage("Confirm Password is required.")
                   .Equal(x => x.Password)
                   .WithMessage("Confirm Password must match the Password.");
        }
    }
}
