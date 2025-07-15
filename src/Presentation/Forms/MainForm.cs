using Microsoft.Extensions.DependencyInjection;
using POS.Desktop.Forms.Childs.Inventory;
using POS.Presentation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Desktop.Forms
{
    public partial class MainForm : Form
    {

        public MainForm()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void supplierPurchaseToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void categoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<CategoryForm>();
        }

        

        private void subCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenChildForm<SubCategoryForm>();
        }

        private void productToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        private void OpenChildForm<T>() where T : Form
        {
            foreach (var child in MdiChildren)
            {
                child.Close();
            }
            var Form = Program.ServiceProvider.GetRequiredService<T>() as Form;
            Form.MdiParent = this;
            Form.Dock = DockStyle.Fill;
            Form.ControlBox = false;
            Form.FormBorderStyle = FormBorderStyle.None;
            Form.Show();
        }
    }
}
