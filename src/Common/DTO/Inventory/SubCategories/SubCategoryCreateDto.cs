using POS.Common.DTO.Inventory.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.Inventory.SubCategories
{
    public class SubCategoryCreateDto : CategoryCreateDto
    {
        public int CategoryId { get; set; }
    }
}
