using POS.Common.DTO.Common;
using POS.Common.DTO.PurchaseBilling.Suppliers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.PurchaseBilling.Suppliers
{
    public interface ISupplierService
    {
        #region Read

        Task<OutputDto<List<SupplierReadDto>>> GetAllAsync();
        Task<OutputDto<SupplierReadDto>> GetByIdAsync(int id);

        #endregion Read

        #region Write
        Task<OutputDto> SaveAsync(SupplierCreateDto request);
        Task<OutputDto> UpdateAsync(SupplierUpdateDto request);
        Task<OutputDto> DeleteAsync(int id);

        #endregion Write
    }
}
