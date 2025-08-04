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
    public class SalesDetailCreateDtoValidator : AbstractValidator<SalesDetailCreateDto>
    {
        public SalesDetailCreateDtoValidator()
        {

            Include(new PurchaseDetailCreateDtoValidator());

        }

    }
}
