using FluentValidation;
using POS.Business.Services.Inventory.Categories;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.PurchaseBilling.Suppliers;
using POS.Common.Utilities;
using POS.Data.Entities.PurchaseBilling;
using POS.Data.Repositories.Inventory.Categories;
using POS.Data.Repositories.PurchaseBilling.Suppliers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.PurchaseBilling.Suppliers
{
    public class SupplierService : ISupplierService
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IValidator<SupplierCreateDto> _supplierCreateDtoValidator;
        private readonly IValidator<SupplierUpdateDto> _supplierUpdateDtoValidator;
        private const string _module = "Supplier";

        public SupplierService(ISupplierRepository SupplierRepository, IValidator<SupplierCreateDto> SupplierCreateDtoValidator, IValidator<SupplierUpdateDto> SupplierUpdateDtoValidator)
        {
            _supplierRepository = SupplierRepository;
            _supplierCreateDtoValidator = SupplierCreateDtoValidator;
            _supplierUpdateDtoValidator = SupplierUpdateDtoValidator;
        }
        #region Read
        public async Task<OutputDto<List<SupplierReadDto>>> GetAllAsync()
        {
            try
            {
                var records = await _supplierRepository.GetAsync();
                var result = records.Select(x => new SupplierReadDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    ContactPerson = x.ContactPerson,
                    ContactNumber = x.ContactNumber,
                    EmailAddress = x.EmailAddress,
                    Address = x.Address,
                    CreatedBy = x.CreatedByUser.UserName,
                    CreatedDate = x.CreatedDate.FormatDate(),
                    LastModifiedBy = x.UpdatedByUser?.UserName,
                    LastModifiedDate = x.LastModifiedDate?.FormatDate()
                }).ToList();

                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<SupplierReadDto>());
            }


        }

        public async Task<OutputDto<SupplierReadDto>> GetByIdAsync(int id)
        {
            try
            {
                var records = await _supplierRepository.GetAsync((x => x.Id == id));
                var result = records
                             .Select(x => new SupplierReadDto
                             {
                                 Id = x.Id,
                                 Name = x.Name,
                                 ContactPerson = x.ContactPerson,
                                 ContactNumber = x.ContactNumber,
                                 EmailAddress = x.EmailAddress,
                                 Address = x.Address,
                                 CreatedBy = x.CreatedByUser.UserName,
                                 CreatedDate = x.CreatedDate.FormatDate(),
                                 LastModifiedBy = x.UpdatedByUser?.UserName,
                                 LastModifiedDate = x.LastModifiedDate?.FormatDate()
                             }).FirstOrDefault();

                return OutputDtoConverter.SetSuccess(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<SupplierReadDto>(ex.Message, null);
            }
        }

        #endregion Read

        #region Write
        public async Task<OutputDto> SaveAsync(SupplierCreateDto request)
        {
            try
            {
                var validationResult = await _supplierCreateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var supplier = new Supplier
                {
                    Name = request.Name,
                    ContactPerson = request.ContactPerson,
                    ContactNumber = request.ContactNumber,
                    EmailAddress = request.EmailAddress,
                    Address = request.Address,
                    CreatedBy = request.CreatedBy
                };
                await _supplierRepository.SaveAsync(supplier);
                return OutputDtoConverter.SetSuccess(_module, Operation.Save);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }

        }

        public async Task<OutputDto> UpdateAsync(SupplierUpdateDto request)
        {
            try
            {
                var validationResult = await _supplierUpdateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return OutputDtoConverter.SetFailed(validationResult);
                }

                var supplier = new Supplier
                {
                    Id = request.Id,
                    Name = request.Name,
                    ContactPerson = request.ContactPerson,
                    ContactNumber = request.ContactNumber,
                    EmailAddress = request.EmailAddress,
                    Address = request.Address,
                    LastModifiedBy = request.CreatedBy
                };
                await _supplierRepository.UpdateAsync(supplier);
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
                    return OutputDtoConverter.SetFailed("Supplier id is required");
                }
                await _supplierRepository.DeleteAsync(id);
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
