using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configuration
{
    internal class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder
            .Property(e => e.CreatedDate)
            .HasDefaultValueSql("GETDATE()");
            builder
            .HasData(GetUsers());

        }

        private List<AppUser> GetUsers() 
        {
            //var passwordHasher = new PasswordHasher<IdentityUser<int>>();
            //string password = passwordHasher.HashPassword(null, "Sumit1@3");

            var users = new List<AppUser>
            {
                new AppUser
                {
                     Id = 1,
                    ConcurrencyStamp = "6858faa1-e1aa-4b9e-8c1e-a2d0399756d9",
                    SecurityStamp = "c8f7a81e-b758-4057-a9d6-cdbae674095f",
                    UserName = "ashish",
                    NormalizedUserName = "ASHISH",
                    Email = "aBhandari@gmail.com",
                    NormalizedEmail = "ABHANDARI@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = "AQAAAAIAAYagAAAAEIjnW4sg9477bONJfkG9qaHSmx9of9VtfQ+leAx4JABl0Z3eHhUusdqf0J50GjRjAQ=="

                }
            };
            return users;
        }
    }
}
