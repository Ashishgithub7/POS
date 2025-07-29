using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Inventory.Products;
using POS.Business.Services.PurchaseBilling.Suppliers;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.Inventory.Products;
using POS.Common.DTO.PurchaseBilling.Suppliers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Desktop.Forms.Childs.PurchaseBilling
{
    public partial class PurchaseForm : Form
    {
        private readonly IProductService _productService;
        private readonly ISupplierService _supplierService;
        private List<ProductReadDto> _products = new List<ProductReadDto>();

        private int _userId;
        private int _id;
        public PurchaseForm(IProductService productService, ISupplierService supplierService)
        {
            InitializeComponent();
            InitializeFormComponents();
            _productService = productService;
            _supplierService = supplierService;
        }

        private void InitializeFormComponents()
        {
            this.AcceptButton = btnSave;
            txtProductName.TabIndex = 0;
            txtQuantity.TabIndex = 1;
            cbSupplier.TabIndex = 2;
            btnSave.TabIndex = 3;
            btnCancel.TabIndex = 4;
            KeyPreview = true;
        }

        private async Task LoadAllProductsAsync()
        {
            var result = await _productService.GetAllAsync();
            _products = result.Data;
        }

        private async void PurchaseForm_Load(object sender, EventArgs e)
        {
            if (MdiParent is MainForm mainForm)
            {
                _userId = mainForm.LoggedInUserId;
            }
            await LoadSupplierAsync();
            await LoadAllProductsAsync();

            var autoComplete = new AutoCompleteStringCollection();

            foreach (var product in _products)
            {
                autoComplete.Add(product.Name);
            }
            txtProductName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtProductName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            txtProductName.AutoCompleteCustomSource = autoComplete;
        }

        private async Task LoadSupplierAsync() 
        {
            var result = await _supplierService.GetAllAsync();
            var suppliers = result.Data;

            suppliers.Insert(0,new SupplierReadDto
            {
                Id = 0,
                Name = "Select a Supplier"
            });
            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = nameof(SupplierReadDto.Name);
            cbSupplier.ValueMember = nameof(SupplierReadDto.Id);
            cbSupplier.SelectedIndex = 0;

        }
    }
}
