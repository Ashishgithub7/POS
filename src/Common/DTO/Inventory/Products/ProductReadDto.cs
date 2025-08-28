using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.Inventory.Products
{
    public class ProductReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  decimal PurchasePrice { get; set; }
        public  decimal SellingPrice { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public string CategoryName { get; set; }
        public string SubCategoryName { get; set; }
        public string CreatedDate { get; set; }
        public string LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

    }
}
