using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Models
{
    public class SalesReport
    {
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalDiscountAmount { get; set; }
        public decimal TotalDiscountPercentage { get; set; }
        public int TotalRecords { get; set; }

    }
}
