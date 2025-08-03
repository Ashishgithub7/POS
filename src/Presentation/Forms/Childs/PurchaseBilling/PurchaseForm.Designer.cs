namespace POS.Desktop.Forms.Childs.PurchaseBilling
{
    partial class PurchaseForm
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
            dgvPurchase = new DataGridView();
            lblProductName = new Label();
            lblGrandTotal = new Label();
            txtProductName = new TextBox();
            txtQuantity = new TextBox();
            lblQuantity = new Label();
            lblSupplier = new Label();
            cbSupplier = new ComboBox();
            btnSave = new Button();
            btnCancel = new Button();
            txtGrandTotal = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvPurchase).BeginInit();
            SuspendLayout();
            // 
            // lblHdr
            // 
            lblHdr.AutoSize = true;
            lblHdr.Location = new Point(443, 9);
            lblHdr.Name = "lblHdr";
            lblHdr.Size = new Size(129, 15);
            lblHdr.TabIndex = 0;
            lblHdr.Text = "Purchase Management";
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
            // 
            // dgvPurchase
            // 
            dgvPurchase.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPurchase.Location = new Point(16, 75);
            dgvPurchase.Name = "dgvPurchase";
            dgvPurchase.Size = new Size(640, 300);
            dgvPurchase.TabIndex = 2;
            dgvPurchase.CellContentClick += dgvPurchase_CellContentClick;
            dgvPurchase.CellDoubleClick += dgvPurchase_CellDoubleClick;
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
            lblSupplier.Size = new Size(56, 15);
            lblSupplier.TabIndex = 8;
            lblSupplier.Text = "Supplier :";
            // 
            // cbSupplier
            // 
            cbSupplier.FormattingEnabled = true;
            cbSupplier.Location = new Point(316, 440);
            cbSupplier.Name = "cbSupplier";
            cbSupplier.Size = new Size(131, 23);
            cbSupplier.TabIndex = 9;
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
            // PurchaseForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(932, 552);
            Controls.Add(txtGrandTotal);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            Controls.Add(cbSupplier);
            Controls.Add(lblSupplier);
            Controls.Add(lblQuantity);
            Controls.Add(txtQuantity);
            Controls.Add(txtProductName);
            Controls.Add(lblGrandTotal);
            Controls.Add(lblProductName);
            Controls.Add(dgvPurchase);
            Controls.Add(btnExit);
            Controls.Add(lblHdr);
            Name = "PurchaseForm";
            Text = "PurchaseForm";
            Load += PurchaseForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPurchase).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHdr;
        private Button btnExit;
        private DataGridView dgvPurchase;
        private Label lblProductName;
        private Label lblGrandTotal;
        private TextBox txtProductName;
        private TextBox txtQuantity;
        private Label lblQuantity;
        private Label lblSupplier;
        private ComboBox cbSupplier;
        private Button btnSave;
        private Button btnCancel;
        private Label txtGrandTotal;
    }
}