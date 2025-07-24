using POS.Common.DTO.Inventory.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.Inventory.Products
{
    public class ProductCreateDto : CategoryCreateDto
    {
        public int SubCategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
    }
}
