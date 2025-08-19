using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POS.Common.Constants;

namespace POS.Data.Configurations.Login
{
    public class AppRoleConfiguration : IEntityTypeConfiguration<AppRole> // to seed roles in db 
    {
        public void Configure(EntityTypeBuilder<AppRole> builder)
        {
            builder
            .Property(e => e.CreatedDate)
            .HasDefaultValueSql("GETDATE()");

            builder
            .HasData(GetRoles()); //This seeds the database with initial role data (Admin, Manager, Inventory, Sales) when migrations are applied.
        }

        public List<AppRole> GetRoles() 
        {
            string admin = Role.Admin;
            string manager = Role.Manager;
            string inventory = Role.Inventory;
            string sales = Role.Sales;

            var roles = new List<AppRole>
                        {
                            new AppRole
                            {
                                Id = 1,
                                Name = admin,
                                NormalizedName = admin.ToUpper(),
                                ConcurrencyStamp = "1841fe7a-d7b5-4969-8a00-bed655ce5792"
                            },
                            new AppRole
                            {
                                Id = 2,
                                Name = manager,
                                NormalizedName = manager.ToUpper(),
                                ConcurrencyStamp = "90ea5401-4392-4fa8-939c-6dc9f1baafd1"
                            },
                            new AppRole
                            {
                                Id = 3,
                                Name = inventory,
                                NormalizedName = inventory.ToUpper(),
                                ConcurrencyStamp = "d39a2599-12fd-473b-b494-b3c36e2532d3"
                            },
                            new AppRole
                            {
                                Id = 4,
                                Name = sales,
                                NormalizedName = sales.ToUpper(),
                                ConcurrencyStamp = "e485278a-a70e-4a5b-b6b2-5838218a0302"
                            }
                        };
            return roles;
        }

    }
}
