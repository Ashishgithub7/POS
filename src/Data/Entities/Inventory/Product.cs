using POS.Data.Entities.Common;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Entities.Inventory
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int SubCategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public int Stock { get; set; }
        public AppUser CreatedByUser { get; set; }
        public AppUser UpdatedByUser { get; set; }
        public SubCategory SubCategory { get; set; }
    }
}
