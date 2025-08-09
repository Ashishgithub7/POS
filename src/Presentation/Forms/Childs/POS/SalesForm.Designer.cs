using POS.Data.Entities.PurchaseBilling;

namespace POS.Desktop.Forms.Childs.POS
{
    partial class SalesForm
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
            dgvSales = new DataGridView();
            lblProductName = new Label();
            lblGrandTotal = new Label();
            txtProductName = new TextBox();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            lblSupplier = new Label();
            btnSave = new Button();
            btnCancel = new Button();
            txtGrandTotal = new Label();
            txtDiscount = new TextBox();
            lblNetTotal = new Label();
            txtNetTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // lblHdr
            // 
            lblHdr.Anchor = AnchorStyles.Top;
            lblHdr.AutoSize = true;
            lblHdr.Location = new Point(443, 18);
            lblHdr.Name = "lblHdr";
            lblHdr.Size = new Size(107, 15);
            lblHdr.TabIndex = 0;
            lblHdr.Text = "Sales Management";
            lblHdr.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(845, 30);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 1;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // dgvSales
            // 
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Location = new Point(16, 75);
            dgvSales.Name = "dgvSales";
            dgvSales.Size = new Size(640, 300);
            dgvSales.TabIndex = 2;
            dgvSales.CellContentClick += dgvSales_CellContentClick;
            dgvSales.CellDoubleClick += dgvPurchase_CellDoubleClick;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(18, 403);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(55, 15);
            lblProductName.TabIndex = 3;
            lblProductName.Text = "Product :";
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.AutoSize = true;
            lblGrandTotal.Location = new Point(240, 403);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(70, 15);
            lblGrandTotal.TabIndex = 4;
            lblGrandTotal.Text = "GrandTotal :";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(79, 400);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(131, 23);
            txtProductName.TabIndex = 5;
            txtProductName.KeyDown += txtProductName_KeyDown;
            // 
            // txtQuantity
            // 
            txtQuantity.Location = new Point(79, 441);
            txtQuantity.Name = "txtQuantity";
            txtQuantity.Size = new Size(131, 23);
            txtQuantity.TabIndex = 6;
            txtQuantity.KeyDown += txtQuantity_KeyDown;
            txtQuantity.KeyPress += txtQuantity_KeyPress;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(16, 444);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(59, 15);
            lblQuantity.TabIndex = 7;
            lblQuantity.Text = "Quantity :";
            // 
            // lblSupplier
            // 
            lblSupplier.AutoSize = true;
            lblSupplier.Location = new Point(240, 441);
            lblSupplier.Name = "lblSupplier";
            lblSupplier.Size = new Size(60, 15);
            lblSupplier.TabIndex = 8;
            lblSupplier.Text = "Discount :";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(497, 400);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 10;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(497, 441);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 11;
            btnCancel.Text = "Cancel (F3)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // txtGrandTotal
            // 
            txtGrandTotal.AutoSize = true;
            txtGrandTotal.Location = new Point(316, 404);
            txtGrandTotal.Name = "txtGrandTotal";
            txtGrandTotal.Size = new Size(13, 15);
            txtGrandTotal.TabIndex = 12;
            txtGrandTotal.Text = "0";
            // 
            // txtDiscount
            // 
            txtDiscount.Location = new Point(316, 438);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(131, 23);
            txtDiscount.TabIndex = 13;
            txtDiscount.KeyDown += txtDiscount_KeyDown;
            txtDiscount.KeyPress += txtDiscount_KeyPress;
            // 
            // lblNetTotal
            // 
            lblNetTotal.AutoSize = true;
            lblNetTotal.Location = new Point(243, 476);
            lblNetTotal.Name = "lblNetTotal";
            lblNetTotal.Size = new Size(57, 15);
            lblNetTotal.TabIndex = 14;
            lblNetTotal.Text = "NetTotal :";
            // 
            // txtNetTotal
            // 
            txtNetTotal.AutoSize = true;
            txtNetTotal.Location = new Point(316, 476);
            txtNetTotal.Name = "txtNetTotal";
            txtNetTotal.Size = new Size(13, 15);
            txtNetTotal.TabIndex = 15;
            txtNetTotal.Text = "0";
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 552);
            Controls.Add(txtNetTotal);
            Controls.Add(lblNetTotal);
            Controls.Add(txtDiscount);
            Controls.Add(txtGrandTotal);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(lblSupplier);
            Controls.Add(lblQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(txtProductName);
            Controls.Add(lblGrandTotal);
            Controls.Add(lblProductName);
            Controls.Add(dgvSales);
            Controls.Add(btnExit);
            Controls.Add(lblHdr);
            Name = "SalesForm";
            Text = "PurchaseForm";
            Load += SalesForm_Load;
            KeyDown += SalesForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHdr;
        private Button btnExit;
        private DataGridView dgvSales;
        private Label lblProductName;
        private Label lblGrandTotal;
        private TextBox txtProductName;
        private TextBox txtQuantity;
        private Label lblQuantity;
        private Label lblSupplier;
        private Button btnSave;
        private Button btnCancel;
        private Label txtGrandTotal;
        private TextBox txtDiscount;
        private Label lblNetTotal;
        private Label txtNetTotal;
    }
}