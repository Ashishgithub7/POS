using POS.Data.Entities.Common;
using POS.Data.Entities.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Data.Entities.PurchaseBilling
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int SuplierId { get; set; }
        public decimal TotalAmount { get; set; }
        public Supplier Supplier { get; set; }
        public AppUser CreatedUser { get; set; }
        public ICollection<PurchaseDetail> PurchaseDetails { get; set; }
    }
}
