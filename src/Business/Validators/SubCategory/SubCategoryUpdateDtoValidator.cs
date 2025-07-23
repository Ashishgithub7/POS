using FluentValidation;
using POS.Business.Validators.Category;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.Inventory.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.SubCategory
{
    public class SubCategoryUpdateDtoValidator : AbstractValidator<SubCategoryUpdateDto>
    {
        public SubCategoryUpdateDtoValidator()
        {
            Include(new SubCategoryCreateDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");

        }
    }
}
