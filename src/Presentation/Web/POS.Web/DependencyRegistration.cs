using System.Runtime.CompilerServices;

namespace POS.Web
{
    public static class DependencyRegistration
    {
        public static void AddWebLayer(this IServiceCollection services) 
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Account/Login";
                options.LogoutPath = "/Account/Logout";
                options.AccessDeniedPath = "/Account/AccessDenied";

                //Secure Cookie Setting
                options.Cookie.HttpOnly = true; //Prevent JavaScript access to the cookie
                options.Cookie.SecurePolicy = CookieSecurePolicy.Always; //Requires Https for the cookie
                options.Cookie.SameSite = SameSiteMode.Strict; //Prevent CSRF attacks
                options.ExpireTimeSpan = TimeSpan.FromMinutes(15); //Set cookie expiration time
                options.SlidingExpiration = true; //Refresh cookie expiration on each request
            });
        }
    }
}
