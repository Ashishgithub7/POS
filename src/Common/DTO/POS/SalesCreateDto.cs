using POS.Common.DTO.PurchaseBilling.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.POS
{
    public class SalesCreateDto 
    {
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public int CreatedBy { get; set; }
        public List<SalesDetailCreateDto> SalesDetails { get; set; }
    }
}
