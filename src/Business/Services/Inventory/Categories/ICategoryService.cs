using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
using POS.Data.Entities.Inventory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Inventory.Categories
{
    public interface ICategoryService
    {
        #region Read

        Task<OutputDto<List<CategoryReadDto>>> GetAllAsync();
        Task<OutputDto<CategoryReadDto>> GetByIdAsync(int id);

        #endregion Read

        #region Write
        Task<OutputDto> SaveAsync(CategoryCreateDto request);
        Task<OutputDto> UpdateAsync(CategoryUpdateDto request);
        Task<OutputDto> DeleteAsync(int id);

        #endregion Write
    }
}
