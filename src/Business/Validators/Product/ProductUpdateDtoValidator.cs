using FluentValidation;
using POS.Business.Validators.Category;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.Inventory.Products;
using POS.Common.DTO.Inventory.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.Product
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            Include(new ProductCreateDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");

        }
    }
}
