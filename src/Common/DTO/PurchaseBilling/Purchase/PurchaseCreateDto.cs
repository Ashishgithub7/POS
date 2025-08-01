﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Common.DTO.PurchaseBilling.Purchase
{
    public class PurchaseCreateDto
    {
        public int SupplierId { get; set; }
        public int CreatedBy { get; set; }
        public List<PurchaseDetailCreateDto> PurchaseDetails { get; set; }
    }
}
