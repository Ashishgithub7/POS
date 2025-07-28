using POS.Common.DTO.Inventory.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.PurchaseBilling.Suppliers
{
    public class SupplierReadDto : CategoryReadDto
    {
        public string ContactPerson { get; set; }
        public string ContactNumber { get; set; }
        public string EmailAddress { get; set; }
        public string Address { get; set; }

    }
}
