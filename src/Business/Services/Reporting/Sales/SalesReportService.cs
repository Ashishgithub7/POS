using POS.Common.DTO.Common;
using POS.Common.Enums;
using POS.Common.Utilities;
using POS.Data.Models;
using POS.Data.Repositories.Report.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Business.Services.Reporting.Sales
{
    public class SalesReportService : ISalesReportService
    {
        public ISalesReportRepository _salesReportRepository;
        public SalesReportService(ISalesReportRepository salesReportRepository)
        {
            _salesReportRepository = salesReportRepository;
        }
        public OutputDto<List<string>> GetReportType()
        {
            try 
            {
                //var reportTypes = new List<String>
                //{
                //    ReportType.Daily.ToString(),
                //    ReportType.Weekly.ToString(),
                //    ReportType.Monthly.ToString(),
                //    ReportType.Yearly.ToString()
                //};

                var reportTypes = EnumUtility.GetNamesEnum<ReportType>();
                return OutputDtoConverter.SetSuccess(reportTypes);
            }
            catch (Exception ex)
            {
                return OutputDtoConverter.SetFailed(ex.Message, new List<string>());
            }
        }

        public async Task<OutputDto<List<SalesReport>>> GetSalesReport(ReportType reportType)
        {
            DateTime dateTime = DateTime.Now;
            DateTime startDate, endDate;
            try
            {
                CalculateStartEndDate(reportType, dateTime, out startDate, out endDate);
                var salesReport = await _salesReportRepository.GetSalesReport(startDate, endDate);
                var result = new List<SalesReport> { salesReport };
                return OutputDtoConverter.SetSuccess<List<SalesReport>>(result);
            }
            catch(Exception ex)
            {
                return OutputDtoConverter.SetFailed<List<SalesReport>>(ex.Message,new List<SalesReport>());
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
