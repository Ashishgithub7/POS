using POS.Business.Services.Reporting.Revenue;
using POS.Business.Services.Reporting.Sales;
using POS.Common.Constants;
using POS.Common.Enums;
using POS.Data.Models;
using POS.Data.Repositories.Report.Sales;
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
    public partial class RevenueReportForm : Form
    {
        private IRevenueReportService _revenueReportService;
        private IRevenueReportService _salesReportService;
        public RevenueReportForm(IRevenueReportService revenueReportService, IRevenueReportService salesReportService)
        {
            InitializeComponent();
            _revenueReportService = revenueReportService;
            _salesReportService = salesReportService;
            LoadReportTypesComboBox();
        }
        private void LoadReportTypesComboBox()
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
            var result = await _revenueReportService.GetRevenueReport(reportType);
            dgvRevenueReport.DataSource = null; // Clear previous data

            if (result.Status == Status.Success)
            {
                dgvRevenueReport.DataSource = result.Data;
                UpdateSerialNumber();
            }
        }
        private void UpdateSerialNumber()
        {
            for (int i = 0; i < dgvRevenueReport.Rows.Count; i++)
            {
                dgvRevenueReport.Rows[i].Cells[Others.Sn].Value = i + 1;
            }
        }

        private void RevenueReportForm_Load(object sender, EventArgs e)
        {
            LoadRevenueReportGrid();
        }
        private void LoadRevenueReportGrid()
        {
            dgvRevenueReport.AutoGenerateColumns = false;
            dgvRevenueReport.ReadOnly = true;
            dgvRevenueReport.RowHeadersVisible = false;


            dgvRevenueReport.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = Others.Sn,
                HeaderText = "SN",
                Width = 50,
            });
            dgvRevenueReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(RevenueReport.TotalRecords),
                HeaderText = "Total Records",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(RevenueReport.TotalRecords),
                Width = 100
            });
            dgvRevenueReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(RevenueReport.TotalGrossAmount),
                HeaderText = "Total Gross Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(RevenueReport.TotalGrossAmount),
                Width = 130
            });
            dgvRevenueReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(RevenueReport.TotalNetAmount),
                HeaderText = "Total Net Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(RevenueReport.TotalNetAmount),
                Width = 130
            });
            dgvRevenueReport.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(RevenueReport.TotalProfitAmount),
                HeaderText = "Total Profit Amount",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(RevenueReport.TotalProfitAmount),
                Width = 130
            });

        }
    }
}
