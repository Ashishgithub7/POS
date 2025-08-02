using FluentValidation;
using POS.Common.DTO.PurchaseBilling.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.Purchase
{
    public class PurchaseCreateDtoValidator : AbstractValidator<PurchaseCreateDto>
    {
        public PurchaseCreateDtoValidator()
        {
            RuleFor(x => x.SupplierId)
                .NotEmpty()
                .WithMessage("Supplier ID is required.");

            RuleFor(x => x.PurchaseDetails)
                .NotEmpty()
                .WithMessage("Purchase details are required.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty()
                .WithMessage("Created By is required.");

            RuleForEach(x => x.PurchaseDetails)
                .SetValidator(new PurchaseDetailCreateDtoValidator());
                


        }
    }
}
