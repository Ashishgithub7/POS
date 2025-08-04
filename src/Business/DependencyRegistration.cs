using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Inventory.Products;
using POS.Business.Services.Inventory.SubCategories;
using POS.Business.Services.Login;
using POS.Business.Services.POS;
using POS.Business.Services.PurchaseBilling.Purchases;
using POS.Business.Services.PurchaseBilling.Suppliers;
using POS.Common.DTO.Login;
using POS.Common.Validators.Login;

namespace POS.Business
{
    public static class DependencyRegistration
    {
        public static void AddBAL(this IServiceCollection services)
        {    
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ISubCategoryService, SubCategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<ISupplierService, SupplierService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            services.AddValidatorsFromAssemblyContaining<LoginRequestDtoValidator>();
            services.AddScoped<ISalesService, SalesService>();
           
        }
    }
}
