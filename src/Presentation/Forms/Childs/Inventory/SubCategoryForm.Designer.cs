namespace POS.Desktop.Forms.Childs.Inventory
{
    partial class SubCategoryForm
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
            lblSubCategoryHdr = new Label();
            exitBtn = new Button();
            cbxCategoryName = new ComboBox();
            lblCategoryName = new Label();
            lblSubCategoryName = new Label();
            txtBoxSubCategoryName = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            dgvSubCategory = new DataGridView();
            lblSearch = new Label();
            txtBoxSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSubCategory).BeginInit();
            SuspendLayout();
            // 
            // lblSubCategoryHdr
            // 
            lblSubCategoryHdr.Anchor = AnchorStyles.Top;
            lblSubCategoryHdr.AutoSize = true;
            lblSubCategoryHdr.Location = new Point(345, 14);
            lblSubCategoryHdr.Name = "lblSubCategoryHdr";
            lblSubCategoryHdr.Size = new Size(78, 15);
            lblSubCategoryHdr.TabIndex = 0;
            lblSubCategoryHdr.Text = "Sub Category";
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
            cbxCategoryName.Location = new Point(113, 45);
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
            lblSubCategoryName.Location = new Point(26, 80);
            lblSubCategoryName.Name = "lblSubCategoryName";
            lblSubCategoryName.Size = new Size(84, 15);
            lblSubCategoryName.TabIndex = 4;
            lblSubCategoryName.Text = "Sub Category :";
            // 
            // txtBoxSubCategoryName
            // 
            txtBoxSubCategoryName.Location = new Point(113, 77);
            txtBoxSubCategoryName.Name = "txtBoxSubCategoryName";
            txtBoxSubCategoryName.Size = new Size(144, 23);
            txtBoxSubCategoryName.TabIndex = 5;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(26, 125);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 6;
            btnSave.Text = "Save(F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(107, 125);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 7;
            btnUpdate.Text = "Update(F3)";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(188, 125);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 8;
            btnDelete.Text = "Delete(F4)";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(269, 125);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 9;
            btnCancel.Text = "Cancel(F5)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // dgvSubCategory
            // 
            dgvSubCategory.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSubCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSubCategory.Location = new Point(28, 173);
            dgvSubCategory.Name = "dgvSubCategory";
            dgvSubCategory.Size = new Size(748, 265);
            dgvSubCategory.TabIndex = 10;
            dgvSubCategory.CellDoubleClick += dgvSubCategory_CellDoubleClick;
            // 
            // lblSearch
            // 
            lblSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(578, 129);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(48, 15);
            lblSearch.TabIndex = 11;
            lblSearch.Text = "Search :";
            // 
            // txtBoxSearch
            // 
            txtBoxSearch.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtBoxSearch.Location = new Point(632, 126);
            txtBoxSearch.Name = "txtBoxSearch";
            txtBoxSearch.Size = new Size(144, 23);
            txtBoxSearch.TabIndex = 12;
            txtBoxSearch.TextChanged += txtBoxSearch_TextChanged;
            // 
            // SubCategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBoxSearch);
            Controls.Add(lblSearch);
            Controls.Add(dgvSubCategory);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtBoxSubCategoryName);
            Controls.Add(lblSubCategoryName);
            Controls.Add(lblCategoryName);
            Controls.Add(cbxCategoryName);
            Controls.Add(exitBtn);
            Controls.Add(lblSubCategoryHdr);
            Name = "SubCategoryForm";
            Text = "SubCategoryForm";
            Load += SubCategoryForm_Load;
            KeyDown += SubCategoryForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)dgvSubCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubCategoryHdr;
        private Button exitBtn;
        private ComboBox cbxCategoryName;
        private Label lblCategoryName;
        private Label lblSubCategoryName;
        private TextBox txtBoxSubCategoryName;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCancel;
        private DataGridView dgvSubCategory;
        private Label lblSearch;
        private TextBox txtBoxSearch;
    }
}