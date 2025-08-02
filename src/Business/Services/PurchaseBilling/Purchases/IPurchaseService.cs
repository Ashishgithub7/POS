using Microsoft.EntityFrameworkCore.Diagnostics;
using POS.Common.DTO.Common;
using POS.Common.DTO.PurchaseBilling.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.PurchaseBilling.Purchases
{
    public interface IPurchaseService
    {
        Task<OutputDto> SaveAsync(PurchaseCreateDto request);
    }
}
