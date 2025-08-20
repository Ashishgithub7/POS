using FluentValidation;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Validators.Category
{
    public class CategoryCreateDtoValidator : AbstractValidator<CategoryCreateDto>
    {
        public CategoryCreateDtoValidator()
        {
            RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Category Name is required.");

            RuleFor(x => x.CreatedBy)
            .NotEmpty()
            .WithMessage("Created by is required.");
        }
    }
}
