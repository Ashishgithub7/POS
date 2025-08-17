using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Inventory.Products;
using POS.Business.Services.PurchaseBilling.Purchases;
using POS.Business.Services.PurchaseBilling.Suppliers;
using POS.Common.Constants;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.Inventory.Products;
using POS.Common.DTO.PurchaseBilling.Purchase;
using POS.Common.DTO.PurchaseBilling.Suppliers;
using POS.Desktop.Utilities;
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
        private readonly IPurchaseService _purchaseService;
        private List<ProductReadDto> _products = new List<ProductReadDto>();
        private List<PurchaseGridDto> _purchase;

        private int _userId;
        private int _id;
        private int _sn;
        public PurchaseForm(IProductService productService, ISupplierService supplierService, IPurchaseService purchaseService)
        {
            InitializeComponent();
            InitializeFormComponents();
            _productService = productService;
            _supplierService = supplierService;
            _purchaseService = purchaseService;
            LoadPurchaseGridColumn();
            _purchase = new List<PurchaseGridDto>();
        }

        private void InitializeFormComponents()
        {
            txtProductName.TabIndex = 0;
            txtQuantity.TabIndex = 1;
            cbSupplier.TabIndex = 2;
            btnSave.TabIndex = 3;
            btnCancel.TabIndex = 4;
            KeyPreview = true;
        }

        private void LoadPurchaseGridColumn()
        {
            dgvPurchase.AutoGenerateColumns = false;
            dgvPurchase.ReadOnly = true;
            dgvPurchase.RowHeadersVisible = false;


            dgvPurchase.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(PurchaseGridDto.SN),
                HeaderText = "SN",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(PurchaseGridDto.SN),
            });
            dgvPurchase.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(PurchaseGridDto.Product),
                HeaderText = "Product",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(PurchaseGridDto.Product),
                Width = 200
            });
            dgvPurchase.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(PurchaseGridDto.UnitPrice),
                HeaderText = "Unit Price",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(PurchaseGridDto.UnitPrice),
            });
            dgvPurchase.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(PurchaseGridDto.Qty),
                HeaderText = "Quantity",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(PurchaseGridDto.Qty),
                Width = 100
            });
            dgvPurchase.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(PurchaseGridDto.SubTotal),
                HeaderText = "SubTotal",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(PurchaseGridDto.SubTotal),
                Width = 100
            });
            dgvPurchase.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "Action",
                CellTemplate = new DataGridViewButtonCell(),
                HeaderText = "Action",
                Text = "Delete",
                UseColumnTextForButtonValue = true,
                Width = 50
            });
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

            suppliers.Insert(0, new SupplierReadDto
            {
                Id = 0,
                Name = "Select a Supplier"
            });
            cbSupplier.DataSource = suppliers;
            cbSupplier.DisplayMember = nameof(SupplierReadDto.Name);
            cbSupplier.ValueMember = nameof(SupplierReadDto.Id);
            cbSupplier.SelectedIndex = 0;

        }

        private void txtProductName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                bool valid = ValidateProduct();
                if (!valid) return;

                txtQuantity.Focus();
            }

        }

        private bool ValidateProduct()
        {
            string productName = txtProductName.Text.Trim();
            if (String.IsNullOrEmpty(productName))
            {
                DialogBox.FailureAlert("Please select a product");
                txtProductName.Focus();

            }

            bool exists = _products
                           .Any(x => x.Name == productName);
            if (!exists)
            {
                DialogBox.FailureAlert("Please select a valid product.");
                txtProductName.Focus();

            }
            return !String.IsNullOrEmpty(productName) && exists;
        }

        private void txtQuantity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                LoadPurchaseGrid();
            }
        }

        private void LoadPurchaseGrid()
        {
            bool valid = ValidateProduct();
            if (!valid) return;

            string productName = txtProductName.Text.Trim();

            int.TryParse(txtQuantity.Text.Trim(), out int quantity);
            if (quantity <= 0)
                quantity = 1;
            (int productId, decimal unitPrice) = FindProductIdAndUnitPrice(productName);

            if (_sn > 0)
            {
                var existingProduct = _purchase
                                      .FirstOrDefault(x => x.SN == _sn);
                if (existingProduct != null)
                {
                    existingProduct.ProductId = productId;
                    existingProduct.Product = productName;
                    existingProduct.Qty = quantity; ;
                    existingProduct.UnitPrice = unitPrice;
                    existingProduct.SubTotal = unitPrice * quantity;
                }
            }
            else
            {
                bool exists = _purchase
                             .Any(x => x.Product == productName);
                if (exists)
                {
                    DialogBox.FailureAlert($"Product '{productName}' already exists");
                    ResetControls();
                    return;
                }


                int sn = _purchase
                         .Select(x => x.SN)
                         .LastOrDefault();
                _purchase.Add(new PurchaseGridDto
                {
                    SN = sn + 1,
                    ProductId = productId,
                    Product = productName,
                    Qty = quantity,
                    UnitPrice = unitPrice,
                    SubTotal = unitPrice * quantity
                });

            }
            LoadPurchaseList();
            LoadGrandTotal();
            _sn = 0;
        }

        private void LoadPurchaseList()
        {
            dgvPurchase.DataSource = null;
            dgvPurchase.DataSource = _purchase;
            ResetControls();
        }

        private void LoadGrandTotal()
        {
            decimal grandTotal = _purchase
                                 .Sum(x => x.SubTotal);
            txtGrandTotal.Text = grandTotal.ToString();
        }

        private void ResetControls()
        {
            txtProductName.Clear();
            txtQuantity.Clear();
            txtProductName.Focus();
        }

        private void ResetAllControls()
        {
            _purchase = new List<PurchaseGridDto>();
            LoadPurchaseList();
            txtGrandTotal.Text = "0";
            cbSupplier.SelectedIndex = 0;
        }

        private (int, decimal) FindProductIdAndUnitPrice(string product)
        {
            decimal unitPrice = _products
                                .Where(x => x.Name.Equals(product))
                                .Select(x => x.PurchasePrice)
                                .FirstOrDefault();

            int productId = _products
                                .Where(x => x.Name.Equals(product))
                                .Select(x => x.Id)
                                .FirstOrDefault();

            return (productId, unitPrice);
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Prevent non-numeric input
            }
        }

        private void dgvPurchase_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex != (int)dgvPurchase.CurrentRow.Cells["Action"].ColumnIndex)
                {
                    _sn = (int)dgvPurchase.CurrentRow.Cells[nameof(PurchaseGridDto.SN)].Value;
                    txtProductName.Text = dgvPurchase.CurrentRow.Cells[nameof(PurchaseGridDto.Product)].Value.ToString();
                    txtQuantity.Text = dgvPurchase.CurrentRow.Cells[nameof(PurchaseGridDto.Qty)].Value.ToString();
                }
                else
                {
                    ResetControls();
                }
            }

        }

        private void dgvPurchase_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == (int)dgvPurchase.CurrentRow.Cells["Action"].ColumnIndex)
                {

                    if (_purchase.Count > 0)
                    {

                        var dialogResult = DialogBox.ConfirmDeleteAlert();

                        if (dialogResult == DialogResult.Yes)
                        {
                            //Delete and result
                            RemoveItem();
                        }

                        ResetControls();
                    }

                }
            }
        }

        private void RemoveItem()
        {
            int sn = (int)dgvPurchase.CurrentRow.Cells[nameof(PurchaseGridDto.SN)].Value;

            var item = _purchase
                        .FirstOrDefault(x => x.SN == sn);

            _purchase.Remove(item);
            UpdateSerialNumber();
            LoadPurchaseList();
            LoadGrandTotal();
        }

        private void UpdateSerialNumber()
        {
            for (int i = 0; i < _purchase.Count; i++)
            {
                _purchase[i].SN = i + 1;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveAsync();
        }

        private async Task SaveAsync()
        {
            var supplierId = (int)cbSupplier.SelectedValue;

            var purchaseDetails = _purchase
                                  .Select(x => new PurchaseDetailCreateDto
                                  {
                                      ProductId = x.ProductId,
                                      Quantity = x.Qty,
                                      UnitPrice = x.UnitPrice
                                  }).ToList();

            var purchase = new PurchaseCreateDto
            {
                SupplierId = supplierId,
                CreatedBy = _userId,
                PurchaseDetails = purchaseDetails
            };

            var result = await _purchaseService.SaveAsync(purchase);

            if (result.Status == Common.Enums.Status.Success)
            {
                DialogBox.SuccessAlert("Purchase saved successfully.");
                ResetAllControls();
            }
            else
            {
                DialogBox.FailureAlert(result);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAllControls();
        }

        private async void PurchaseForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                await SaveAsync();
            }
            else if (e.KeyCode == Keys.F3)
            {
                ResetAllControls();
            }
            else if (e.KeyCode == Keys.F10)
            {
                this.Close();
            }
        }
    }
}
