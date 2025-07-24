namespace POS.Desktop.Forms.Childs.Inventory
{
    partial class ProductForm
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
            lblProductManagementHdr = new Label();
            exitBtn = new Button();
            cbxCategoryName = new ComboBox();
            lblCategoryName = new Label();
            lblSubCategoryName = new Label();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            dgvSubCategory = new DataGridView();
            lblSearch = new Label();
            txtBoxSearch = new TextBox();
            comboBox1 = new ComboBox();
            lblProductName = new Label();
            lblPurchasePrice = new Label();
            lblSellingPrice = new Label();
            txtProductName = new TextBox();
            txtPurchasePrice = new TextBox();
            txtSellingPrice = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSubCategory).BeginInit();
            SuspendLayout();
            // 
            // lblProductManagementHdr
            // 
            lblProductManagementHdr.Anchor = AnchorStyles.Top;
            lblProductManagementHdr.AutoSize = true;
            lblProductManagementHdr.Location = new Point(348, 14);
            lblProductManagementHdr.Name = "lblProductManagementHdr";
            lblProductManagementHdr.Size = new Size(123, 15);
            lblProductManagementHdr.TabIndex = 0;
            lblProductManagementHdr.Text = "Product Management";
            // 
            // exitBtn
            // 
            exitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitBtn.Location = new Point(701, 14);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(75, 23);
            exitBtn.TabIndex = 1;
            exitBtn.Text = "Exit(F10)";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // cbxCategoryName
            // 
            cbxCategoryName.FormattingEnabled = true;
            cbxCategoryName.Location = new Point(122, 45);
            cbxCategoryName.Name = "cbxCategoryName";
            cbxCategoryName.Size = new Size(144, 23);
            cbxCategoryName.TabIndex = 2;
            // 
            // lblCategoryName
            // 
            lblCategoryName.AutoSize = true;
            lblCategoryName.Location = new Point(26, 48);
            lblCategoryName.Name = "lblCategoryName";
            lblCategoryName.Size = new Size(61, 15);
            lblCategoryName.TabIndex = 3;
            lblCategoryName.Text = "Category :";
            // 
            // lblSubCategoryName
            // 
            lblSubCategoryName.AutoSize = true;
            lblSubCategoryName.Location = new Point(26, 83);
            lblSubCategoryName.Name = "lblSubCategoryName";
            lblSubCategoryName.Size = new Size(84, 15);
            lblSubCategoryName.TabIndex = 4;
            lblSubCategoryName.Text = "Sub Category :";
            // 
            // btnSave
            // 
            btnSave.Location = new Point(26, 247);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save(F2)";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(107, 247);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update(F3)";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(188, 247);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete(F4)";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(269, 247);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel(F5)";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvSubCategory
            // 
            dgvSubCategory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSubCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubCategory.Location = new Point(26, 291);
            dgvSubCategory.Name = "dgvSubCategory";
            dgvSubCategory.Size = new Size(750, 229);
            dgvSubCategory.TabIndex = 10;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(578, 251);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(48, 15);
            lblSearch.TabIndex = 11;
            lblSearch.Text = "Search :";
            // 
            // txtBoxSearch
            // 
            txtBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBoxSearch.Location = new Point(632, 247);
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.Size = new Size(144, 23);
            txtBoxSearch.TabIndex = 12;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(122, 80);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(144, 23);
            comboBox1.TabIndex = 13;
            // 
            // lblProductName
            // 
            lblProductName.AutoSize = true;
            lblProductName.Location = new Point(26, 116);
            lblProductName.Name = "lblProductName";
            lblProductName.Size = new Size(48, 15);
            lblProductName.TabIndex = 14;
            lblProductName.Text = "Name  :";
            // 
            // lblPurchasePrice
            // 
            lblPurchasePrice.AutoSize = true;
            lblPurchasePrice.Location = new Point(26, 151);
            lblPurchasePrice.Name = "lblPurchasePrice";
            lblPurchasePrice.Size = new Size(90, 15);
            lblPurchasePrice.TabIndex = 15;
            lblPurchasePrice.Text = "Purchase Price :";
            // 
            // lblSellingPrice
            // 
            lblSellingPrice.AutoSize = true;
            lblSellingPrice.Location = new Point(26, 188);
            lblSellingPrice.Name = "lblSellingPrice";
            lblSellingPrice.Size = new Size(77, 15);
            lblSellingPrice.TabIndex = 16;
            lblSellingPrice.Text = "Selling Price :";
            // 
            // txtProductName
            // 
            txtProductName.Location = new Point(122, 113);
            txtProductName.Name = "txtProductName";
            txtProductName.Size = new Size(144, 23);
            txtProductName.TabIndex = 17;
            // 
            // txtPurchasePrice
            // 
            txtPurchasePrice.Location = new Point(122, 148);
            txtPurchasePrice.Name = "txtPurchasePrice";
            txtPurchasePrice.Size = new Size(144, 23);
            txtPurchasePrice.TabIndex = 18;
            // 
            // txtSellingPrice
            // 
            txtSellingPrice.Location = new Point(122, 185);
            txtSellingPrice.Name = "txtSellingPrice";
            txtSellingPrice.Size = new Size(144, 23);
            txtSellingPrice.TabIndex = 19;
            // 
            // ProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 532);
            Controls.Add(txtSellingPrice);
            Controls.Add(txtPurchasePrice);
            Controls.Add(txtProductName);
            Controls.Add(lblSellingPrice);
            Controls.Add(lblPurchasePrice);
            Controls.Add(lblProductName);
            Controls.Add(comboBox1);
            Controls.Add(txtBoxSearch);
            Controls.Add(lblSearch);
            Controls.Add(dgvSubCategory);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(lblSubCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(cbxCategoryName);
            Controls.Add(exitBtn);
            Controls.Add(lblProductManagementHdr);
            Name = "ProductForm";
            Text = "SubCategoryForm";
            ((System.ComponentModel.ISupportInitialize)dgvSubCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblProductManagementHdr;
        private Button exitBtn;
        private ComboBox cbxCategoryName;
        private Label lblCategoryName;
        private Label lblSubCategoryName;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCancel;
        private DataGridView dgvSubCategory;
        private Label lblSearch;
        private TextBox txtBoxSearch;
        private ComboBox comboBox1;
        private Label lblProductName;
        private Label lblPurchasePrice;
        private Label lblSellingPrice;
        private TextBox txtProductName;
        private TextBox txtPurchasePrice;
        private TextBox txtSellingPrice;
    }
}