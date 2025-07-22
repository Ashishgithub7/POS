namespace POS.Desktop.Forms.Childs.Inventory
{
    partial class CategoryForm
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
            lblCategoryHdr = new Label();
            exitBtn = new Button();
            lblName = new Label();
            txtCategoryName = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            lblSearch = new Label();
            SearchTxtBox = new TextBox();
            dgvCategory = new DataGridView();
            btnExit = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCategory).BeginInit();
            SuspendLayout();
            // 
            // lblCategoryHdr
            // 
            lblCategoryHdr.Anchor = AnchorStyles.Top;
            lblCategoryHdr.AutoSize = true;
            lblCategoryHdr.Location = new Point(479, 20);
            lblCategoryHdr.Name = "lblCategoryHdr";
            lblCategoryHdr.Size = new Size(129, 15);
            lblCategoryHdr.TabIndex = 0;
            lblCategoryHdr.Text = "Category Management";
            // 
            // exitBtn
            // 
            exitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitBtn.Location = new Point(940, 20);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(75, 23);
            exitBtn.TabIndex = 1;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            // 
            // lblName
            // 
            lblName.AutoSize = true;
            lblName.Location = new Point(17, 57);
            lblName.Name = "lblName";
            lblName.Size = new Size(42, 15);
            lblName.TabIndex = 2;
            lblName.Text = "Name:";
            // 
            // txtCategoryName
            // 
            txtCategoryName.Location = new Point(65, 54);
            txtCategoryName.Name = "txtCategoryName";
            txtCategoryName.Size = new Size(156, 23);
            txtCategoryName.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(17, 97);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(98, 97);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(179, 97);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(260, 97);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel (F3)";
            btnCancel.UseVisualStyleBackColor = true;
            btnCancel.Click += btnCancel_Click;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(581, 120);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search:";
            // 
            // SearchTxtBox
            // 
            SearchTxtBox.Location = new Point(632, 117);
            SearchTxtBox.Name = "SearchTxtBox";
            SearchTxtBox.Size = new Size(156, 23);
            SearchTxtBox.TabIndex = 9;
            SearchTxtBox.TextChanged += SearchTxtBox_TextChanged;
            // 
            // dgvCategory
            // 
            dgvCategory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCategory.Location = new Point(17, 183);
            dgvCategory.Name = "dgvCategory";
            dgvCategory.Size = new Size(897, 255);
            dgvCategory.TabIndex = 10;
            dgvCategory.CellDoubleClick += dgvCategory_CellDoubleClick;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(839, 12);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 11;
            btnExit.Text = "Exit(F10)";
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1027, 530);
            Controls.Add(btnExit);
            Controls.Add(dgvCategory);
            Controls.Add(SearchTxtBox);
            Controls.Add(lblSearch);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(txtCategoryName);
            Controls.Add(lblName);
            Controls.Add(exitBtn);
            Controls.Add(lblCategoryHdr);
            Name = "CategoryForm";
            Text = "CategoryForm";
            Load += CategoryForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCategory).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategoryHdr;
        private Button exitBtn;
        private Label lblName;
        private TextBox txtCategoryName;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCancel;
        private Label lblSearch;
        private TextBox SearchTxtBox;
        private DataGridView dgvCategory;
        private Button btnExit;
    }
}