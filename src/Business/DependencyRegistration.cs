using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Login;
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
            services.AddValidatorsFromAssemblyContaining<LoginRequestDtoValidator>();
           
        }
    }
}
