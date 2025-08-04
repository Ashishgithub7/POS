using POS.Common.DTO.Common;
using POS.Common.DTO.POS;
using POS.Common.DTO.PurchaseBilling.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.POS
{
    public interface ISalesService
    {
        Task<OutputDto> SaveAsync(SalesCreateDto request);

    }
}
