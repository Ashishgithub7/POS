namespace POS.Desktop.Forms.Childs.Report
{
    partial class RevenueReportForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblHdr = new Label();
            btnExit = new Button();
            lblFilter = new Label();
            cbFilter = new ComboBox();
            dgvRevenueReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvRevenueReport).BeginInit();
            SuspendLayout();
            // 
            // lblHdr
            // 
            lblHdr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHdr.AutoSize = true;
            lblHdr.Location = new Point(353, 19);
            lblHdr.Name = "lblHdr";
            lblHdr.Size = new Size(90, 15);
            lblHdr.TabIndex = 0;
            lblHdr.Text = "Revenue Report";
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(713, 48);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit(F10)";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // lblFilter
            // 
            lblFilter.AutoSize = true;
            lblFilter.Location = new Point(27, 56);
            lblFilter.Name = "lblFilter";
            lblFilter.Size = new Size(39, 15);
            lblFilter.TabIndex = 2;
            lblFilter.Text = "Filter :";
            // 
            // cbFilter
            // 
            cbFilter.FormattingEnabled = true;
            cbFilter.Location = new Point(86, 53);
            cbFilter.Name = "cbFilter";
            cbFilter.Size = new Size(147, 23);
            cbFilter.TabIndex = 3;
            // 
            // dgvRevenueReport
            // 
            dgvRevenueReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvRevenueReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRevenueReport.Location = new Point(11, 113);
            dgvRevenueReport.Name = "dgvRevenueReport";
            dgvRevenueReport.Size = new Size(702, 325);
            dgvRevenueReport.TabIndex = 4;
            // 
            // RevenueReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvRevenueReport);
            Controls.Add(cbFilter);
            Controls.Add(lblFilter);
            Controls.Add(btnExit);
            Controls.Add(lblHdr);
            Name = "RevenueReportForm";
            Text = "SalesReportForm";
            ((System.ComponentModel.ISupportInitialize)dgvRevenueReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHdr;
        private Button btnExit;
        private Label lblFilter;
        private ComboBox cbFilter;
        private DataGridView dgvRevenueReport;
    }
}