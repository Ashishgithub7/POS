using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Configurations.Roles
{
    public class IdentityUserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<int>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<int>> builder)
        {
            builder.HasData(GetUserRoles());
        }

        public List<IdentityUserRole<int>> GetUserRoles()
        {
            return new List<IdentityUserRole<int>>
            {
                new IdentityUserRole<int>
                {
                    UserId = 1,
                    RoleId = 1 // user with id 1 is assigned to role with id 1 (Admin role)
                },
                new IdentityUserRole<int>
                {
                    UserId = 2,
                    RoleId = 2 // user with id 2 is assigned to role with id 2 (Manager role)
                }
            };
        }
    }
}
