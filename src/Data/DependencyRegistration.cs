using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using POS.Data.Data;
using POS.Data.Entities.Login;
using POS.Data.Repositories.Dapper;
using POS.Data.Repositories.Inventory.Categories;
using POS.Data.Repositories.Inventory.Products;
using POS.Data.Repositories.Inventory.SubCategories;
using POS.Data.Repositories.Login;
using POS.Data.Repositories.POS;
using POS.Data.Repositories.PurchaseBilling.Purchases;
using POS.Data.Repositories.PurchaseBilling.Suppliers;
using POS.Data.Repositories.Report.Revenue;
using POS.Data.Repositories.Report.Sales;
using POS.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data
{
    public static class DependencyRegistration
    {
        public static void AddDAL(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
            services.AddIdentity<AppUser, AppRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISubCategoryRepository, SubCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<ITransactionManager, DbContextTransactionManager>();
            services.AddScoped<ISalesRepository, SalesRepository>();
            services.AddScoped<IDapperRepository>(x => new DapperRepository(connectionString));
            services.AddScoped<ISalesReportRepository, SalesReportRepository>();
            services.AddScoped<IRevenueReportRepository, RevenueReportRepository>();
        }
    }
}

