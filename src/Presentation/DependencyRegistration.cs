using Microsoft.Extensions.DependencyInjection;
using POS.Desktop.Forms;
using POS.Desktop.Forms.Childs.Inventory;
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
   
        }
    }
}
