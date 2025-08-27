using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.Inventory.SubCategories
{
    public class SubCategoryReadDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string CreatedDate { get; set; }
        public string LastModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string LastModifiedBy { get; set; }

    }
}
