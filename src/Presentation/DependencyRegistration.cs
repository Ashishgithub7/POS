using Microsoft.Extensions.DependencyInjection;
using POS.Desktop.Forms;
using POS.Desktop.Forms.Childs.Inventory;
using POS.Desktop.Forms.Childs.POS;
using POS.Desktop.Forms.Childs.PurchaseBilling;
using POS.Desktop.Forms.Childs.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Desktop
{
    public static class DependencyRegistration
    {
        public static void AddDestopLayer(this IServiceCollection services)
        {
            services.AddScoped<LoginForm>();
            services.AddScoped<MainForm>();
            services.AddScoped<CategoryForm>();
            services.AddScoped<SubCategoryForm>();
            services.AddScoped<ProductForm>();
            services.AddScoped<SupplierForm>();
            services.AddScoped<PurchaseForm>();
            services.AddScoped<SalesForm>();
            services.AddScoped<SalesReportForm>();
   
        }
    }
}
