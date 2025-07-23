using FluentValidation;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.SubCategories;
using POS.Common.Utilities;
using POS.Data.Entities.Inventory;
using POS.Data.Repositories.Inventory.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Inventory.SubCategories
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly IValidator<SubCategoryCreateDto> _subCategoryCreateDtoValidator;
        private readonly IValidator<SubCategoryUpdateDto> _subCategoryUpdateDtoValidator;
        private const string _module = "Sub Category";

        public SubCategoryService(ISubCategoryRepository subCategoryRepository, IValidator<SubCategoryCreateDto> subCategoryCreateDtoValidator, IValidator<SubCategoryUpdateDto> subCategoryUpdateDtoValidator)
        {
            _subCategoryRepository = subCategoryRepository;
            _subCategoryCreateDtoValidator = subCategoryCreateDtoValidator;
            _subCategoryUpdateDtoValidator = subCategoryUpdateDtoValidator;
        }
        #region Read
        public async Task<OutputDto<List<SubCategoryReadDto>>> GetAllAsync()
        {
            try
            {
                var records = await _subCategoryRepository.GetAsync();
                var result = records.Select(x => new SubCategoryReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CategoryName = x.Category.Name,
                    CreatedBy = x.CreatedByUser.UserName,
                    CreatedDate = x.CreatedDate.FormatDate(),
                    LastModifiedBy = x.UpdatedByUser?.UserName,
                    LastModifiedDate = x.LastModifiedDate?.FormatDate()
                }).ToList();

                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<SubCategoryReadDto>());
            }


        }

        public async Task<OutputDto<SubCategoryReadDto>> GetByIdAsync(int id)
        {
            try
            {
                var records = await _subCategoryRepository.GetAsync((x => x.Id == id));
                var result = records
                             .Select(x => new SubCategoryReadDto
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 CategoryName = x.Category.Name,
                                 CreatedBy = x.CreatedByUser.UserName,
                                 CreatedDate = x.CreatedDate.FormatDate(),
                                 LastModifiedBy = x.UpdatedByUser?.UserName,
                                 LastModifiedDate = x.LastModifiedDate?.FormatDate()
                             }).FirstOrDefault();

                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<SubCategoryReadDto>(ex.Message, null);
            }
        }

        #endregion Read

        #region Write
        public async Task<OutputDto> SaveAsync(SubCategoryCreateDto request)
        {
            try
            {
                var validationResult = await _subCategoryCreateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var subCategory = new SubCategory
                {
                    Name = request.Name,
                    CategoryId = request.CategoryId,
                    CreatedBy = request.CreatedBy
                };
                await _subCategoryRepository.SaveAsync(subCategory);
                return OutputDtoConverter.SetSuccess(_module, Operation.Save);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }

        }

        public async Task<OutputDto> UpdateAsync(SubCategoryUpdateDto request)
        {
            try
            {
                var validationResult = await _subCategoryUpdateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var subCategory = new SubCategory
                {
                    Id = request.Id,
                    Name = request.Name,
                    CategoryId = request.CategoryId,
                    LastModifiedBy = request.CreatedBy
                };
                await _subCategoryRepository.UpdateAsync(subCategory);
                return OutputDtoConverter.SetSuccess(_module, Operation.Update);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }

        public async Task<OutputDto> DeleteAsync(int id)
        {
            try
            {
                if (id <= 0)
                {
                    return OutputDtoConverter.SetFailed("SubCategory id is required");
                }
                await _subCategoryRepository.DeleteAsync(id);
                return OutputDtoConverter.SetSuccess(_module, Operation.Delete);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }

            #endregion Write
        }
    }
}
