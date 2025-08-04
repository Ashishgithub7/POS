using FluentValidation;
using POS.Business.Validators.Purchase;
using POS.Common.DTO.POS;
using POS.Common.DTO.PurchaseBilling.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.POS
{
    public class SalesCreateDtoValidator : AbstractValidator<SalesCreateDto>
    {
        public SalesCreateDtoValidator()
        {

            RuleFor(x => x.SalesDetails)
                .NotEmpty()
                .WithMessage("Sales details are required.");

            RuleFor(x => x.CreatedBy)
                .NotEmpty()
                .WithMessage("Created By is required.");

            RuleForEach(x => x.SalesDetails)
                .SetValidator(new SalesDetailCreateDtoValidator());



        }
    }
}
