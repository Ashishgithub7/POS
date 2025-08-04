using FluentValidation;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.POS;
using POS.Common.Enums;
using POS.Common.Utilities;
using POS.Data.Entities.Inventory;
using POS.Data.Entities.POS;
using POS.Data.Repositories.Inventory.Products;
using POS.Data.Repositories.POS;
using POS.Data.Utilities;

namespace POS.Business.Services.POS
{
    public class SalesService : ISalesService
    {
        private readonly IProductRepository _productRepository;
        private readonly ISalesRepository _salesRepository;
        private readonly IValidator<SalesCreateDto> _salesCreateDtoValidator;
        private readonly ITransactionManager _transactionManager;

        public SalesService(IProductRepository productRepository, ISalesRepository SalesRepository, IValidator<SalesCreateDto> SalesCreateDtoValidator, ITransactionManager transactionManager)
        {
            _productRepository = productRepository;
            _salesRepository = SalesRepository;
            _salesCreateDtoValidator = SalesCreateDtoValidator;
            _transactionManager = transactionManager;
        }
        public async Task<OutputDto> SaveAsync(SalesCreateDto request)
        {
            try
            {
                var validationResult = await _salesCreateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                    return OutputDtoConverter.SetFailed(validationResult);

                decimal totalAmount = request
                                  .SalesDetails
                                  .Sum(x => (x.Quantity * x.UnitPrice));

                var SalesDetails = request
                                      .SalesDetails
                                      .Select(x => new SalesDetail
                                      {
                                          ProductId = x.ProductId,
                                          UnitPrice = x.UnitPrice,
                                          Quantity = x.Quantity,
                                          SubTotal = x.UnitPrice * x.Quantity
                                      }).ToList();

                var sales = new Sales
                {
                    TotalAmount = totalAmount,
                    DiscountAmount = request.DiscountAmount,
                    DiscountPercentage = request.DiscountPercentage,
                    NetTotal = totalAmount - request.DiscountAmount,
                    CreatedBy = request.CreatedBy,
                    SalesDetails = SalesDetails
                };

                using (var transaction = await _transactionManager.BeginTransactionAsync())
                {
                    try
                    {
                        await _salesRepository.SaveAsync(sales);

                        var products = SalesDetails
                                       .Select(x => new Product
                                       {
                                           Id = x.ProductId,
                                           Stock = x.Quantity,
                                           LastModifiedBy = request.CreatedBy
                                       }).ToList();  /* Creates list of products from SalesDetails(list of SalesDetail) */
                        await _productRepository.UpdateStockAsync(BillingType.Sales, products);
                        await transaction.CommitAsync();
                        return OutputDtoConverter.SetSuccess("Sales", Operation.Save);
                    }

                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        return OutputDtoConverter.SetFailed(ex.Message);
                    }
                }

            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message);
            }
        }
    }
}
