using FluentValidation;
using POS.Business.Validators.Category;
using POS.Business.Validators.SubCategory;
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
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {

            RuleFor(x => x.SubCategoryId)
            .NotEmpty()
            .WithMessage("SubCategory is required.");
            
            RuleFor(x => x.PurchasePrice)
            .NotEmpty()
            .WithMessage("Purchase Price is required."); 
            
            RuleFor(x => x.SellingPrice)
            .NotEmpty()
            .WithMessage("Selling Price is required.")
            .GreaterThanOrEqualTo(x => (x.PurchasePrice + (x.PurchasePrice * 10) / 100));
           
            Include(new CategoryCreateDtoValidator());
        }
    }
}
