using POS.Common.DTO.Common;
using POS.Common.Enums;
using POS.Common.Utilities;
using POS.Data.Entities.POS;
using POS.Data.Models;
using POS.Data.Repositories.Report.Revenue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Reporting.Revenue
{
    public class RevenueReportService : IRevenueReportService
    {
        public IRevenueReportRepository _revenueReportRepository;
        public RevenueReportService(IRevenueReportRepository revenueReportRepository)
        {
            _revenueReportRepository = revenueReportRepository;
        }
        public OutputDto<List<string>> GetReportType()
        {
            try
            {
                var reportTypes = EnumUtility.GetNamesEnum<ReportType>();
                return OutputDtoConverter.SetSuccess(reportTypes);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<string>());
            }
        }

        public async Task<OutputDto<List<RevenueReport>>> GetRevenueReport(ReportType reportType)
        {
            DateTime dateTime = DateTime.Now;
            DateTime startDate, endDate;
            try
            {
                CalculateStartEndDate(reportType, dateTime, out startDate, out endDate);
                var sales = await _revenueReportRepository.GetRevenueReport(startDate, endDate);
                decimal totalGrossAmount = 0;
                decimal totalNetAmount = 0;
                decimal totalPurchasePrice = 0;
                foreach (var sale in sales) 
                {
                    totalGrossAmount += sale.TotalAmount;
                    totalNetAmount += sale.NetTotal;

                    var salesDetails = sale.SalesDetails;
                    foreach (var salesDetail in salesDetails)
                    {
                        totalPurchasePrice += salesDetail.Product.PurchasePrice * salesDetail.Quantity;
                    }

                }
                var revenueReport = new RevenueReport
                                    {
                                      TotalGrossAmount = totalGrossAmount,
                                      TotalNetAmount = totalNetAmount,
                                      TotalRecords = sales.Count,
                                      TotalProfitAmount = totalNetAmount - totalPurchasePrice
                                    };
                var result = new List<RevenueReport> { revenueReport };
                return OutputDtoConverter.SetSuccess<List<RevenueReport>>(result);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed<List<RevenueReport>>(ex.Message, new List<RevenueReport>());
            }
            throw new NotImplementedException();
        }

        private static void CalculateStartEndDate(ReportType reportType, DateTime now, out DateTime startDate, out DateTime endDate)
        {
            switch (reportType)
            {
                case ReportType.Daily:
                    startDate = now.Date;
                    endDate = startDate.AddDays(1);
                    break;

                case ReportType.Weekly:
                    startDate = now.Date.AddDays(-(int)now.DayOfWeek);
                    endDate = startDate.AddDays(7);
                    break;

                case ReportType.Monthly:
                    startDate = new DateTime(now.Year, now.Month, 1);
                    endDate = startDate.AddMonths(1);
                    break;

                case ReportType.Yearly:
                    startDate = new DateTime(now.Year, 1, 1);
                    endDate = startDate.AddYears(1);
                    break;

                default:
                    throw new Exception($"Invalid Report Type {reportType.ToString()}");
            }
        }
    }
}
