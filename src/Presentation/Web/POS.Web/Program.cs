using Microsoft.AspNetCore.Identity;
using POS.Business;
using POS.Data;
using POS.Data.Entities.Login;

namespace POS.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddScoped<SignInManager<AppUser>>(); // Fixed CS0119 error by registering SignInManager<AppUser> as a scoped service.

            string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];

            builder.Services.AddDAL(connectionString);
            builder.Services.AddBAL();
            builder.Services.AddWebLayer(); // Registering the web layer services

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
