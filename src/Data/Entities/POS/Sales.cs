using POS.Data.Entities.Login;
using POS.Data.Entities.PurchaseBilling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Entities.POS
{
    public class Sales
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal DiscountPercentage { get; set; }
        public decimal DiscountAmount { get; set; }
        public decimal NetTotal { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public Supplier Supplier { get; set; }
        public AppUser CreatedUser { get; set; }
        public ICollection<SalesDetail> SalesDetails { get; set; }
    }
}
