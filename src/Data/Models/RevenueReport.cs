using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Models
{
    public class RevenueReport
    {
        public decimal TotalGrossAmount { get; set; }
        public decimal TotalNetAmount { get; set; }
        public decimal TotalProfitAmount { get; set; }
        public int TotalRecords { get; set; }
    }
}
