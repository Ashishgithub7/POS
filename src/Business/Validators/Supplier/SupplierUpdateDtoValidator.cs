using FluentValidation;
using POS.Common.Constants;
using POS.Common.DTO.PurchaseBilling.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.Supplier
{
    public class SupplierUpdateDtoValidator : AbstractValidator<SupplierUpdateDto>
    {
        public SupplierUpdateDtoValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage(Message.IdRequiredMessage);

            Include(new SupplierCreateDtoValidator());
        }
    }
}
