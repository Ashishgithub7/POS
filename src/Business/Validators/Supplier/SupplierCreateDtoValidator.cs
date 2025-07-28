using FluentValidation;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.PurchaseBilling.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.Supplier
{
    public class SupplierCreateDtoValidator : AbstractValidator<SupplierCreateDto>
    {
        public SupplierCreateDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .MaximumLength(200)
            .WithMessage("Name can't exceed 200 characters");

            RuleFor(x => x.ContactNumber)
                .NotEmpty()
                .WithMessage("Contact number is required.")
                .Matches(@"^[9]\d{9}$")
                .WithMessage("Invalid Contact Number (e.g: 9876543210)");

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .WithMessage("Email address is required.")
                .EmailAddress()
                .WithMessage("A valid email address is required.");

            RuleFor(x => x.Address)
                .MaximumLength(500)
                .WithMessage("Address can't exceed 500 characters");

            RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Created by is required.");
        }
    }
}
