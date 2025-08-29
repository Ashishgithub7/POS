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

        public int CategoryId { get; set; }
        public int SubCategoryId { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SellingPrice { get; set; }
        public ProductCreateDto()
        {
            PurchasePrice = 0;
            SellingPrice = 0;
        }
    }

    
}
