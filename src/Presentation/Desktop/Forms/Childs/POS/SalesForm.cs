using POS.Business.Services.Inventory.Products;
using POS.Business.Services.POS;
using POS.Business.Services.PurchaseBilling.Purchases;
using POS.Business.Services.PurchaseBilling.Suppliers;
using POS.Common.DTO.Inventory.Products;
using POS.Common.DTO.POS;
using POS.Common.DTO.PurchaseBilling.Purchase;
using POS.Common.Enums;
using POS.Data.Entities.PurchaseBilling;
using POS.Desktop.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Desktop.Forms.Childs.POS
{
    public partial class SalesForm : Form
    {
        private readonly IProductService _productService;
        private readonly ISalesService _salesService;

        private List<ProductReadDto> _products;
        private List<SalesGridDto> _sales;
        private decimal _netTotal, _discountAmount, _discountPercentage;
        private const int _margin = 10; // Margin for the discount calculation

        private int _userId;
        private int _sn;
        private string _pattern = @"^\d+(-?)$"; // Regex pattern to allow only digits and an optional negative sign at the end
        public SalesForm(IProductService productService, ISalesService salesService)
        {
            _productService = productService;
            _salesService = salesService;
            InitializeComponent();
            InitializeFormComponents();
            LoadSalesGridColumn();
            _sales = new List<SalesGridDto>();
        }

        private void InitializeFormComponents()
        {
            txtProductName.TabIndex = 0;
            txtQuantity.TabIndex = 1;
            txtDiscount.TabIndex = 2;
            btnSave.TabIndex = 3;
            btnCancel.TabIndex = 4;
            txtProductName.Focus();
            KeyPreview = true;
        }

        private void LoadSalesGridColumn()
        {
            dgvSales.AutoGenerateColumns = false;
            dgvSales.ReadOnly = true;
            dgvSales.RowHeadersVisible = false;


            dgvSales.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesGridDto.SN),
                HeaderText = "SN",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesGridDto.SN),
            });
            dgvSales.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesGridDto.Product),
                HeaderText = "Product",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesGridDto.Product),
                Width = 200
            });
            dgvSales.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesGridDto.UnitPrice),
                HeaderText = "Unit Price",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesGridDto.UnitPrice),
            });
            dgvSales.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesGridDto.Qty),
                HeaderText = "Quantity",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesGridDto.Qty),
                Width = 100
            });
            dgvSales.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SalesGridDto.SubTotal),
                HeaderText = "SubTotal",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SalesGridDto.SubTotal),
                Width = 100
            });
            dgvSales.Columns.Add(new DataGridViewButtonColumn
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

        private async void SalesForm_Load(object sender, EventArgs e)
        {
            if (MdiParent is MainForm mainForm)
            {
                _userId = mainForm.LoggedInUserId;
            }

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
                LoadSalesGrid();
            }
        }
        private void LoadSalesGrid()
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
                var existingProduct = _sales
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
                bool exists = _sales
                             .Any(x => x.Product == productName);
                if (exists)
                {
                    DialogBox.FailureAlert($"Product '{productName}' already exists");
                    ResetControls();
                    return;
                }


                int sn = _sales
                         .Select(x => x.SN)
                         .LastOrDefault();
                _sales.Add(new SalesGridDto
                {
                    SN = sn + 1,
                    ProductId = productId,
                    Product = productName,
                    Qty = quantity,
                    UnitPrice = unitPrice,
                    SubTotal = unitPrice * quantity
                });

            }
            LoadSalesList();
            LoadGrandTotal();
            _sn = 0;
        }
        private (int, decimal) FindProductIdAndUnitPrice(string product)
        {
            decimal unitPrice = _products
                                .Where(x => x.Name.Equals(product))
                                .Select(x => x.SellingPrice)
                                .FirstOrDefault();

            int productId = _products
                                .Where(x => x.Name.Equals(product))
                                .Select(x => x.Id)
                                .FirstOrDefault();

            return (productId, unitPrice);
        }
        private void ResetControls()
        {
            txtProductName.Clear();
            txtQuantity.Clear();
            txtProductName.Focus();
        }
        private void LoadSalesList()
        {
            dgvSales.DataSource = null;
            dgvSales.DataSource = _sales;
            ResetControls();
        }
        private void LoadGrandTotal()
        {
            decimal grandTotal = _sales
                                 .Sum(x => x.SubTotal);
            txtGrandTotal.Text = grandTotal.ToString();
            txtNetTotal.Text = grandTotal.ToString();
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
                if (e.ColumnIndex != (int)dgvSales.CurrentRow.Cells["Action"].ColumnIndex)
                {
                    _sn = (int)dgvSales.CurrentRow.Cells[nameof(SalesGridDto.SN)].Value;
                    txtProductName.Text = dgvSales.CurrentRow.Cells[nameof(SalesGridDto.Product)].Value.ToString();
                    txtQuantity.Text = dgvSales.CurrentRow.Cells[nameof(SalesGridDto.Qty)].Value.ToString();
                }
                else
                {
                    ResetControls();
                }
            }
        }

        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if ((e.ColumnIndex == (int)dgvSales.CurrentRow.Cells["Action"].ColumnIndex) && _sales.Count > 0)
                {
                    var dialogResult = DialogBox.ConfirmDeleteAlert();

                    if (dialogResult == DialogResult.Yes)
                    {
                        //Delete and result
                        DeleteCurrentProduct();
                    }

                    ResetControls();
                }
            }
        }
        private void DeleteCurrentProduct()
        {
            int sn = (int)dgvSales.CurrentRow.Cells[nameof(PurchaseGridDto.SN)].Value;

            var item = _sales
                        .FirstOrDefault(x => x.SN == sn);

            _sales.Remove(item);
            UpdateSerialNumber();
            LoadSalesList();
            LoadGrandTotal();
        }
        private void UpdateSerialNumber()
        {
            for (int i = 0; i < _sales.Count; i++)
            {
                _sales[i].SN = i + 1;
            }
        }

        private void ResetAllControls()
        {
            _sales = new List<SalesGridDto>();
            LoadSalesList();
            txtGrandTotal.Text = "0";
            txtNetTotal.Text = "0";
            txtDiscount.Clear();
            ResetDiscount();
        }

        private void ResetDiscount() 
        {
            _discountAmount = 0;
            _discountPercentage = 0;
            _netTotal = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetAllControls();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await SaveAsync();
        }
        private async Task SaveAsync()
        {

            var salesDetails = _sales
                                  .Select(x => new SalesDetailCreateDto
                                  {
                                      ProductId = x.ProductId,
                                      Quantity = x.Qty,
                                      UnitPrice = x.UnitPrice
                                  }).ToList();

            var sales = new SalesCreateDto
            {
                DiscountAmount = _discountAmount,
                DiscountPercentage = _discountPercentage,
                CreatedBy = _userId,
                SalesDetails = salesDetails
            };

            var result = await _salesService.SaveAsync(sales);

            if (result.Status == Status.Success)
            {
                ResetAllControls();
                DialogBox.SuccessAlert("Sales saved successfully.");
            }
            else
            {
                DialogBox.FailureAlert(result);
            }
        }

        private async void SalesForm_KeyDown(object sender, KeyEventArgs e)
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

        private void txtDiscount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !(e.KeyChar == '-'))
            {
                e.Handled = true; // Prevent non-numeric input except '-'
            }
        }

        private void txtDiscount_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string discountText = txtDiscount.Text.Trim();
                if (!Regex.IsMatch(discountText, _pattern))
                {
                    DialogBox.FailureAlert("Please enter a valid discount [ex: 10 (for percentage OR 10- (for amount)]");
                    txtDiscount.Focus();
                    return;
                }
                decimal grandTotal = Convert.ToDecimal(txtGrandTotal.Text.Trim());
                if (discountText.EndsWith('-'))
                {
                    decimal grandTotalDiscount = (grandTotal * _margin) / 100;
                    _discountAmount = Convert.ToDecimal(discountText.TrimEnd('-'));
                    if (_discountAmount > grandTotalDiscount)
                    {
                        DialogBox.FailureAlert($"Discount amount cannot be greater than {grandTotalDiscount}");
                        txtDiscount.Focus();
                        return;
                    }
                }
                else
                {
                    _discountPercentage = Convert.ToDecimal(discountText);
                    if (_discountPercentage > _margin)
                    {
                        DialogBox.FailureAlert($"Discount percentage cannot be greater than 10%");
                        txtDiscount.Focus();
                        return;
                    }
                    _discountAmount = (grandTotal * _discountPercentage) / 100;
                }
                _netTotal = grandTotal - _discountAmount;
                txtNetTotal.Text = _netTotal.ToString();
                txtDiscount.Clear();
                txtProductName.Focus();
            }
           


        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
