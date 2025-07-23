using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.Inventory.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Inventory.SubCategories
{
    public interface ISubCategoryService
    {
        #region Read

        Task<OutputDto<List<SubCategoryReadDto>>> GetAllAsync();
        Task<OutputDto<SubCategoryReadDto>> GetByIdAsync(int id);

        #endregion Read

        #region Write
        Task<OutputDto> SaveAsync(SubCategoryCreateDto request);
        Task<OutputDto> UpdateAsync(SubCategoryUpdateDto request);
        Task<OutputDto> DeleteAsync(int id);

        #endregion Write
    }
}
