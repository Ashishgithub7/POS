using POS.Business.Services.Reporting.Sales;
using POS.Common.Constants;
using POS.Common.DTO.PurchaseBilling.Purchase;
using POS.Common.Enums;
using POS.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Desktop.Forms.Childs.Report
{
    public partial class SalesReportForm : Form
    {
        private readonly ISalesReportService _salesReportService;
        public SalesReportForm(ISalesReportService salesReportService)
        {
            _salesReportService = salesReportService;
            InitializeComponent();
            LoadSalesReportTypes();
        }

        private void LoadSalesReportTypes()
        {
            var result = _salesReportService.GetReportType();
            if (result.Status == Status.Success)
            {
                var reportTypes = result.Data.ToArray();
                cbFilter.Items.AddRange(reportTypes);
                cbFilter.SelectedIndex = 0;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = cbFilter.Text;
            var reportType = Enum.Parse<ReportType>(selected);
            var result = await _salesReportService.GetSalesReport(reportType);
            dgvSalesReport.DataSource = null; // Clear previous data

            if (result.Status == Status.Success)
            {
                dgvSalesReport.DataSource = result.Data;
                UpdateSerialNumber();
            }
        }
        private void UpdateSerialNumber()
        {
            for (int i = 0; i < dgvSalesReport.Rows.Count; i++)
            {
                dgvSalesReport.Rows[i].Cells[Others.Sn].Value = i + 1;
            }
        }

        private void SalesReportForm_Load(object sender, EventArgs e)
        {
            LoadSalesReportGrid();
        }
        private void LoadSalesReportGrid() 
        {
            dgvSalesReport.AutoGenerateColumns = false;
            dgvSalesReport.ReadOnly = true;
            dgvSalesReport.RowHeadersVisible = false;


            dgvSalesReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = Others.Sn,
                HeaderText = "SN",
                Width = 50,
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalGrossAmount),
                HeaderText = "Total Gross Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalGrossAmount),
                Width = 130
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalDiscountAmount),
                HeaderText = "Total Discount Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalDiscountAmount),
                Width = 145
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalDiscountPercentage),
                HeaderText = "Total Discount Percentage",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalDiscountPercentage),
                Width = 150
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalRecords),
                HeaderText = "Total Records",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalRecords),
                Width = 100
            });
            dgvSalesReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesReport.TotalNetAmount),
                HeaderText = "Total Net Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesReport.TotalNetAmount),
                Width = 130
            });
            
        }
    }
}
