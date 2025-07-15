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
            NameTxtBox = new TextBox();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            lblSearch = new Label();
            SearchTxtBox = new TextBox();
            grdView = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)grdView).BeginInit();
            SuspendLayout();
            // 
            // lblCategoryHdr
            // 
            lblCategoryHdr.Anchor = AnchorStyles.Top;
            lblCategoryHdr.AutoSize = true;
            lblCategoryHdr.Location = new Point(366, 20);
            lblCategoryHdr.Name = "lblCategoryHdr";
            lblCategoryHdr.Size = new Size(129, 15);
            lblCategoryHdr.TabIndex = 0;
            lblCategoryHdr.Text = "Category Management";
            // 
            // exitBtn
            // 
            exitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitBtn.Location = new Point(713, 20);
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
            // NameTxtBox
            // 
            NameTxtBox.Location = new Point(65, 54);
            NameTxtBox.Name = "NameTxtBox";
            NameTxtBox.Size = new Size(156, 23);
            NameTxtBox.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(17, 97);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 4;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(98, 97);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(75, 23);
            btnUpdate.TabIndex = 5;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(179, 97);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 6;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(260, 97);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel (F3)";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(581, 120);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(45, 15);
            lblSearch.TabIndex = 8;
            lblSearch.Text = "Search:";
            lblSearch.Click += SearchLbl_Click;
            // 
            // SearchTxtBox
            // 
            SearchTxtBox.Location = new Point(632, 117);
            SearchTxtBox.Name = "SearchTxtBox";
            SearchTxtBox.Size = new Size(156, 23);
            SearchTxtBox.TabIndex = 9;
            SearchTxtBox.TextChanged += SearchTxtBox_TextChanged;
            // 
            // grdView
            // 
            grdView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            grdView.Location = new Point(17, 183);
            grdView.Name = "grdView";
            grdView.Size = new Size(771, 255);
            grdView.TabIndex = 10;
            // 
            // CategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grdView);
            Controls.Add(SearchTxtBox);
            Controls.Add(lblSearch);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(NameTxtBox);
            Controls.Add(lblName);
            Controls.Add(exitBtn);
            Controls.Add(lblCategoryHdr);
            Name = "CategoryForm";
            Text = "CategoryForm";
            ((System.ComponentModel.ISupportInitialize)grdView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCategoryHdr;
        private Button exitBtn;
        private Label lblName;
        private TextBox NameTxtBox;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCancel;
        private Label lblSearch;
        private TextBox SearchTxtBox;
        private DataGridView grdView;
    }
}