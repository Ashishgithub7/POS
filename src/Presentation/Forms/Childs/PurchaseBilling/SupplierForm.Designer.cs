namespace POS.Desktop.Forms.Childs.PurchaseBilling
{
    partial class SupplierForm
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
            lblSupplierName = new Label();
            lblContactPerson = new Label();
            lblContactNumber = new Label();
            lblEmailAddress = new Label();
            lblAddress = new Label();
            txtSupplierName = new TextBox();
            textBox2 = new TextBox();
            txtContactNumber = new TextBox();
            txtEmailAddress = new TextBox();
            txtAddress = new TextBox();
            btnExit = new Button();
            btnSave = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnCancel = new Button();
            dgvSupplier = new DataGridView();
            lblSearch = new Label();
            txtSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).BeginInit();
            SuspendLayout();
            // 
            // lblHdr
            // 
            lblHdr.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            lblHdr.AutoSize = true;
            lblHdr.Location = new Point(361, 9);
            lblHdr.Name = "lblHdr";
            lblHdr.Size = new Size(124, 15);
            lblHdr.TabIndex = 0;
            lblHdr.Text = "Supplier Management";
            // 
            // lblSupplierName
            // 
            lblSupplierName.AutoSize = true;
            lblSupplierName.Location = new Point(17, 55);
            lblSupplierName.Name = "lblSupplierName";
            lblSupplierName.Size = new Size(94, 15);
            lblSupplierName.TabIndex = 1;
            lblSupplierName.Text = "Supplier Name  :";
            // 
            // lblContactPerson
            // 
            lblContactPerson.AutoSize = true;
            lblContactPerson.Location = new Point(17, 89);
            lblContactPerson.Name = "lblContactPerson";
            lblContactPerson.Size = new Size(94, 15);
            lblContactPerson.TabIndex = 2;
            lblContactPerson.Text = "Contact Person :";
            // 
            // lblContactNumber
            // 
            lblContactNumber.AutoSize = true;
            lblContactNumber.Location = new Point(17, 123);
            lblContactNumber.Name = "lblContactNumber";
            lblContactNumber.Size = new Size(102, 15);
            lblContactNumber.TabIndex = 3;
            lblContactNumber.Text = "Contact Number :";
            // 
            // lblEmailAddress
            // 
            lblEmailAddress.AutoSize = true;
            lblEmailAddress.Location = new Point(17, 158);
            lblEmailAddress.Name = "lblEmailAddress";
            lblEmailAddress.Size = new Size(87, 15);
            lblEmailAddress.TabIndex = 4;
            lblEmailAddress.Text = "Email Address :";
            // 
            // lblAddress
            // 
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(17, 193);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(55, 15);
            lblAddress.TabIndex = 5;
            lblAddress.Text = "Address :";
            // 
            // txtSupplierName
            // 
            txtSupplierName.Location = new Point(125, 52);
            txtSupplierName.Name = "txtSupplierName";
            txtSupplierName.Size = new Size(130, 23);
            txtSupplierName.TabIndex = 6;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(125, 86);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(130, 23);
            textBox2.TabIndex = 7;
            // 
            // txtContactNumber
            // 
            txtContactNumber.Location = new Point(125, 120);
            txtContactNumber.Name = "txtContactNumber";
            txtContactNumber.Size = new Size(130, 23);
            txtContactNumber.TabIndex = 8;
            // 
            // txtEmailAddress
            // 
            txtEmailAddress.Location = new Point(125, 155);
            txtEmailAddress.Name = "txtEmailAddress";
            txtEmailAddress.Size = new Size(130, 23);
            txtEmailAddress.TabIndex = 9;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(125, 190);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(130, 23);
            txtAddress.TabIndex = 10;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.Location = new Point(632, 28);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(75, 23);
            btnExit.TabIndex = 11;
            btnExit.Text = "Exit (F10)";
            btnExit.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(17, 254);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(75, 23);
            btnSave.TabIndex = 12;
            btnSave.Text = "Save (F2)";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            btnUpdate.Location = new Point(98, 254);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(77, 23);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update (F3)";
            btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            btnDelete.Location = new Point(181, 254);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(75, 23);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete (F4)";
            btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(262, 254);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(75, 23);
            btnCancel.TabIndex = 15;
            btnCancel.Text = "Cancel (F5)";
            btnCancel.UseVisualStyleBackColor = true;
            // 
            // dgvSupplier
            // 
            dgvSupplier.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSupplier.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSupplier.Location = new Point(17, 291);
            dgvSupplier.Name = "dgvSupplier";
            dgvSupplier.Size = new Size(690, 248);
            dgvSupplier.TabIndex = 16;
            // 
            // lblSearch
            // 
            lblSearch.AutoSize = true;
            lblSearch.Location = new Point(522, 258);
            lblSearch.Name = "lblSearch";
            lblSearch.Size = new Size(48, 15);
            lblSearch.TabIndex = 17;
            lblSearch.Text = "Search :";
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(576, 254);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(131, 23);
            txtSearch.TabIndex = 18;
            // 
            // SupplierForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(719, 551);
            Controls.Add(txtSearch);
            Controls.Add(lblSearch);
            Controls.Add(dgvSupplier);
            Controls.Add(btnCancel);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSave);
            Controls.Add(btnExit);
            Controls.Add(txtAddress);
            Controls.Add(txtEmailAddress);
            Controls.Add(txtContactNumber);
            Controls.Add(textBox2);
            Controls.Add(txtSupplierName);
            Controls.Add(lblAddress);
            Controls.Add(lblEmailAddress);
            Controls.Add(lblContactNumber);
            Controls.Add(lblContactPerson);
            Controls.Add(lblSupplierName);
            Controls.Add(lblHdr);
            Name = "SupplierForm";
            Text = "SupplierForm";
            ((System.ComponentModel.ISupportInitialize)dgvSupplier).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblHdr;
        private Label lblSupplierName;
        private Label lblContactPerson;
        private Label lblContactNumber;
        private Label lblEmailAddress;
        private Label lblAddress;
        private TextBox txtSupplierName;
        private TextBox textBox2;
        private TextBox txtContactNumber;
        private TextBox txtEmailAddress;
        private TextBox txtAddress;
        private Button btnExit;
        private Button btnSave;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnCancel;
        private DataGridView dgvSupplier;
        private Label lblSearch;
        private TextBox txtSearch;
    }
}