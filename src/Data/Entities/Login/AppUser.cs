using Microsoft.AspNetCore.Identity;
using POS.Data.Entities.Inventory;
using POS.Data.Entities.PurchaseBilling;
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
        public ICollection<Product> CreatedProducts { get; set; }
        public ICollection<Product> UpdatedProducts { get; set; }
        public ICollection<Supplier> CreatedSuppliers { get; set; }
        public ICollection<Supplier> UpdatedSuppliers { get; set; }
        public ICollection<Purchase> CreatedPurchases { get; set; }
        public ICollection<Purchase> UpdatedPurchase { get; set; }

    }
}
