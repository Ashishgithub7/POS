namespace POS.Desktop.Forms.Childs.Report
{
    partial class SalesReportForm
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
            dgvSalesReport = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).BeginInit();
            SuspendLayout();
            // 
            // lblHdr
            // 
            lblHdr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHdr.AutoSize = true;
            lblHdr.Location = new Point(381, 23);
            lblHdr.Name = "lblHdr";
            lblHdr.Size = new Size(71, 15);
            lblHdr.TabIndex = 0;
            lblHdr.Text = "Sales Report";
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
            btnExit.Click += btnExit_Click;
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
            // dgvSalesReport
            // 
            dgvSalesReport.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            dgvSalesReport.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalesReport.Location = new Point(11, 113);
            dgvSalesReport.Name = "dgvSalesReport";
            dgvSalesReport.Size = new Size(702, 325);
            dgvSalesReport.TabIndex = 4;
            // 
            // SalesReportForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dgvSalesReport);
            Controls.Add(cbFilter);
            Controls.Add(lblFilter);
            Controls.Add(btnExit);
            Controls.Add(lblHdr);
            Name = "SalesReportForm";
            Text = "SalesReportForm";
            ((System.ComponentModel.ISupportInitialize)dgvSalesReport).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHdr;
        private Button btnExit;
        private Label lblFilter;
        private ComboBox cbFilter;
        private DataGridView dgvSalesReport;


    }
}