
using Microsoft.AspNetCore.Http.HttpResults;
using POS.Business;
using POS.Data;

namespace POS.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            //Creates builder to build application with custom configuration and services.

            // Add services to the container.

            builder.Services.AddControllers();
            //Registers controller support in application for handling HTTP requests.
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string connectionString = builder.Configuration["ConnectionStrings:DefaultConnection"];
            //to get connection string from app.json

            builder.Services.AddDAL(connectionString);
            builder.Services.AddBAL();
            builder.Services.AddAPILayer();
            //to register services one after another to be able to call each service or method on depends upon

            var app = builder.Build();
            //Creates application instance with configured services and middleware.

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            //Redirects HTTP requests to HTTPS for secure communication.

            app.UseAuthorization();
            //Enables authorization middleware to enforce access control policies like roles and policies.


            app.MapControllers();
            //Maps controller routes to handle incoming HTTP requests.

            app.Run();
        }
    }
}
