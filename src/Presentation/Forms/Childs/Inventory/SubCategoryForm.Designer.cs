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
            lblSubCategoryHdr.Click += label1_Click;
            // 
            // exitBtn
            // 
            exitBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            exitBtn.Location = new Point(713, 14);
            exitBtn.Name = "exitBtn";
            exitBtn.Size = new Size(75, 23);
            exitBtn.TabIndex = 1;
            exitBtn.Text = "Exit";
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += exitBtn_Click;
            // 
            // SubCategoryForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(exitBtn);
            Controls.Add(lblSubCategoryHdr);
            Name = "SubCategoryForm";
            Text = "SubCategoryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblSubCategoryHdr;
        private Button exitBtn;
    }
}