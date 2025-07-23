using Microsoft.AspNetCore.Identity;
using POS.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Entities.Login
{
    public class AppUser : IdentityUser<int>
    {
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public ICollection<Category> CreatedCategories{ get; set; }
        public ICollection<Category> UpdatedCategories{ get; set; }
        public ICollection<SubCategory> CreatedSubCategories { get; set; }
        public ICollection<SubCategory> UpdatedSubCategories { get; set; }

    }
}
