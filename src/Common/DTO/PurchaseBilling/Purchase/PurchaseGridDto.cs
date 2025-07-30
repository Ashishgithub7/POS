using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.PurchaseBilling.Purchase
{
    public class PurchaseGridDto
    {
        public int SN { get; set; }
        public string Product { get; set; }
        public int Qty { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal SubTotal { get; set; }
    }
}
