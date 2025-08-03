using FluentValidation;
using Microsoft.IdentityModel.Tokens;
using POS.Business.Validators.Category;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.PurchaseBilling.Purchase;
using POS.Common.Enums;
using POS.Common.Utilities;
using POS.Data.Entities.Inventory;
using POS.Data.Entities.PurchaseBilling;
using POS.Data.Repositories.Inventory.Products;
using POS.Data.Repositories.PurchaseBilling.Purchases;
using POS.Data.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.PurchaseBilling.Purchases
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IProductRepository _productRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IValidator<PurchaseCreateDto> _purchaseCreateDtoValidator;
        private readonly ITransactionManager _transactionManager;

        public PurchaseService(IProductRepository productRepository, IPurchaseRepository purchaseRepository, IValidator<PurchaseCreateDto> purchaseCreateDtoValidator, ITransactionManager transactionManager)
        {
            _productRepository = productRepository;
            _purchaseRepository = purchaseRepository;
            _purchaseCreateDtoValidator = purchaseCreateDtoValidator;
            _transactionManager = transactionManager;
        }
        public async Task<OutputDto> SaveAsync(PurchaseCreateDto request)
        {
            try
            {
                var validationResult = await _purchaseCreateDtoValidator.ValidateAsync(request);
                if (!validationResult.IsValid)
                   return OutputDtoConverter.SetFailed(validationResult);

                decimal totalAmount = request
                                  .PurchaseDetails
                                  .Sum(x => (x.Quantity * x.UnitPrice));

                var purchaseDetails = request
                                      .PurchaseDetails
                                      .Select(x => new PurchaseDetail
                                      {
                                          ProductId = x.ProductId,
                                          UnitPrice = x.UnitPrice,
                                          Quantity = x.Quantity,
                                          SubTotal = x.UnitPrice * x.Quantity
                                      }).ToList();

                var purchase = new Purchase
                {
                    SuplierId = request.SupplierId,
                    TotalAmount = totalAmount,
                    CreatedBy = request.CreatedBy,
                    PurchaseDetails = purchaseDetails
                };

                using (var transaction = await _transactionManager.BeginTransactionAsync())
                {
                    try
                    {
                        await _purchaseRepository.SaveAsync(purchase);

                        var products = purchaseDetails
                                       .Select(x => new Product
                                       {
                                           Id = x.ProductId,
                                           Stock = x.Quantity,
                                           LastModifiedBy = request.CreatedBy
                                       }).ToList();  /* Creates list of products from purchaseDetails(list of purchaseDetail) */
                        await _productRepository.UpdateStockAsync(BillingType.Purchase, products);
                        await transaction.CommitAsync();
                        return OutputDtoConverter.SetSuccess("Purchase",Operation.Save);
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
