using FluentValidation;
using POS.Common.DTO.Inventory.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.Category
{
    public class CategoryUpdateDtoValidator : AbstractValidator<CategoryUpdateDto>
    {
        public CategoryUpdateDtoValidator()
        {
            Include(new CategoryCreateDtoValidator());

            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("Id is required.");

        }
    }
}
