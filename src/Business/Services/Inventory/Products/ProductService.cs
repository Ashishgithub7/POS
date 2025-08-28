using FluentValidation;
using POS.Business.Services.Inventory.SubCategories;
using POS.Business.Validators.Product;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Products;
using POS.Common.DTO.Inventory.SubCategories;
using POS.Common.Utilities;
using POS.Data.Entities.Inventory;
using POS.Data.Repositories.Inventory.Products;
using POS.Data.Repositories.Inventory.SubCategories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Inventory.Products
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IValidator<ProductCreateDto> _productCreateDtoValidator;
        private readonly IValidator<ProductUpdateDto> _productUpdateDtoValidator;
        private const string _module = "Product";

        public ProductService(IProductRepository ProductRepository, IValidator<ProductCreateDto> ProductCreateDtoValidator, IValidator<ProductUpdateDto> ProductUpdateDtoValidator)
        {
            _productRepository = ProductRepository;
            _productCreateDtoValidator = ProductCreateDtoValidator;
            _productUpdateDtoValidator = ProductUpdateDtoValidator;
        }
        #region Read
        public async Task<OutputDto<List<ProductReadDto>>> GetAllAsync()
        {
            try
            {
                var records = await _productRepository.GetAsync();
                var result = records.Select(x => new ProductReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    SubCategoryName = x.SubCategory.Name,
                    SubCategoryId = x.SubCategoryId,
                    CategoryName = x.SubCategory.Category.Name,
                    CategoryId = x.SubCategory.CategoryId,
                    PurchasePrice = x.PurchasePrice,
                    SellingPrice = x.SellingPrice,
                    Stock = x.Stock,
                    CreatedBy = x.CreatedByUser.UserName,
                    CreatedDate = x.CreatedDate.FormatDate(),
                    LastModifiedBy = x.UpdatedByUser?.UserName,
                    LastModifiedDate = x.LastModifiedDate?.FormatDate()
                }).ToList();

                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<ProductReadDto>());
            }


        }

        public async Task<OutputDto<ProductReadDto>> GetByIdAsync(int id)
        {
            try
            {
                var records = await _productRepository.GetAsync((x => x.Id == id));
                var result = records
                             .Select(x => new ProductReadDto
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 SubCategoryName = x.SubCategory.Name,
                                 CategoryName = x.SubCategory.Category.Name,
                                 PurchasePrice = x.PurchasePrice,
                                 SellingPrice = x.SellingPrice,
                                 Stock = x.Stock,
                                 CreatedBy = x.CreatedByUser.UserName,
                                 CreatedDate = x.CreatedDate.FormatDate(),
                                 LastModifiedBy = x.UpdatedByUser?.UserName,
                                 LastModifiedDate = x.LastModifiedDate?.FormatDate()
                             }).FirstOrDefault();

                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<ProductReadDto>(ex.Message, null);
            }
        }

        #endregion Read

        #region Write
        public async Task<OutputDto> SaveAsync(ProductCreateDto request)
        {
            try
            {
                var validationResult = await _productCreateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var product = new Product
                {
                    Name = request.Name,
                    SubCategoryId = request.SubCategoryId,
                    PurchasePrice = request.PurchasePrice,
                    SellingPrice = request.SellingPrice,
                    CreatedBy = request.CreatedBy
                };
                await _productRepository.SaveAsync(product);
                return OutputDtoConverter.SetSuccess(_module, Operation.Save);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }

        }

        public async Task<OutputDto> UpdateAsync(ProductUpdateDto request)
        {
            try
            {
                var validationResult = await _productUpdateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var product = new Product
                {
                    Id = request.Id,
                    Name = request.Name,
                    SubCategoryId = request.SubCategoryId,
                    PurchasePrice = request.PurchasePrice,
                    SellingPrice = request.SellingPrice,
                    LastModifiedBy = request.CreatedBy
                };
                await _productRepository.UpdateAsync(product);
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
                    return OutputDtoConverter.SetFailed("Product id is required");
                }
                await _productRepository.DeleteAsync(id);
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
