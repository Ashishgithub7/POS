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
    public class SubCategoryCreateDtoValidator : AbstractValidator<SubCategoryCreateDto>
    {
        public SubCategoryCreateDtoValidator()
        {
           Include(new CategoryCreateDtoValidator());

            RuleFor(x => x.CategoryId)
            .NotEmpty()
            .WithMessage("Category is required.");
        }
    }
}
