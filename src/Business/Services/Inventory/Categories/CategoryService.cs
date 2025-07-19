using FluentValidation;
using POS.Business.Validators.Category;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.Utilities;
using POS.Data.Entities.Inventory;
using POS.Data.Repositories.Inventory.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Inventory.Categories
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<CategoryCreateDto> _categoryCreateDtoValidator;
        private readonly IValidator<CategoryUpdateDto> _categoryUpdateDtoValidator;
        private const string _module = "Category";

        public CategoryService(ICategoryRepository categoryRepository, IValidator<CategoryCreateDto> categoryCreateDtoValidator, IValidator<CategoryUpdateDto> categoryUpdateDtoValidator)
        {
            _categoryRepository = categoryRepository;
            _categoryCreateDtoValidator = categoryCreateDtoValidator;
            _categoryUpdateDtoValidator = categoryUpdateDtoValidator;
        }
        #region Read
        public async Task<OutputDto<List<CategoryReadDto>>> GetAllAsync()
        {
            try
            {
                var records = await _categoryRepository.GetAllAsync();
                var result = records.Select(x => new CategoryReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    CreatedBy = x.CreatedByUser.UserName,
                    CreatedDate = x.CreatedDate.FormatDate(),
                    LastModifiedBy = x.UpdatedByUser?.UserName,
                    LastModifiedDate = x.LastModifiedDate?.FormatDate()
                }).ToList();

                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<CategoryReadDto>());
            }


        }

        #endregion Read

        #region Write
        public async Task<OutputDto> SaveAsync(CategoryCreateDto request)
        {
            try
            {
                var validationResult = await _categoryCreateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var category = new Category
                {
                    Name = request.Name,
                    CreatedBy = request.CreatedBy
                };
                await _categoryRepository.SaveAsync(category);
                return OutputDtoConverter.SetSuccess(_module, Operation.Save);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }

        }

        public async Task<OutputDto> UpdateAsync(CategoryUpdateDto request)
        {
            try
            {
                var validationResult = await _categoryUpdateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var category = new Category
                {
                    Id = request.Id,
                    Name = request.Name,
                    LastModifiedBy = request.CreatedBy
                };
                await _categoryRepository.UpdateAsync(category);
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
                    return OutputDtoConverter.SetFailed("Category id is required");
                }
                await _categoryRepository.DeleteAsync(id);
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