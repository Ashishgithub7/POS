using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Inventory.Products
{
    public interface IProductService
    {
        #region Read

        Task<OutputDto<List<ProductReadDto>>> GetAllAsync();
        Task<OutputDto<ProductReadDto>> GetByIdAsync(int id);

        #endregion Read

        #region Write
        Task<OutputDto> SaveAsync(ProductCreateDto request);
        Task<OutputDto> UpdateAsync(ProductUpdateDto request);
        Task<OutputDto> DeleteAsync(int id);

        #endregion Write
    }
}
