using FluentValidation;
using POS.Common.DTO.PurchaseBilling.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.Purchase
{
    public class PurchaseDetailCreateDtoValidator : AbstractValidator<PurchaseDetailCreateDto>
    {
        public PurchaseDetailCreateDtoValidator()
        {
            RuleFor(x => x.ProductId)
            .NotEmpty()
            .WithMessage("Product ID is required.");

            RuleFor(x => x.UnitPrice)
                .NotEmpty()
                .WithMessage("Unit Price is required.");

            RuleFor(x => x.Quantity)
                .NotEmpty()
                .WithMessage("Quantity is required.");
                
        }

    }
}
