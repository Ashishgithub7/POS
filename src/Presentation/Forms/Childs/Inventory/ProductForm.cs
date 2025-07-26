using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Inventory.Products;
using POS.Business.Services.Inventory.SubCategories;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.Inventory.Products;
using POS.Common.DTO.Inventory.SubCategories;
using POS.Common.Enums;
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
using Message = POS.Common.Constants.Message;

namespace POS.Desktop.Forms.Childs.Inventory
{
    public partial class ProductForm : Form
    {
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly IProductService _productService;

        private List<ProductReadDto> _products = new List<ProductReadDto>();

        private int _userId;
        private int _id;
        private int _selectedCategoryId;

        public ProductForm(ICategoryService categoryService, ISubCategoryService subCategoryService, IProductService productService)
        {
            InitializeComponent();
            InitializeFormComponents();
            _categoryService = categoryService;
            _subCategoryService = subCategoryService;
            _productService = productService;
        }

        private void InitializeFormComponents()
        {
            this.AcceptButton = btnSave;
            cbxCategoryName.TabIndex = 0;
            cbxSubCategoryName.TabIndex = 1;
            txtProductName.TabIndex = 2;
            txtPurchasePrice.TabIndex = 3;
            txtSellingPrice.TabIndex = 4;
            btnSave.TabIndex = 5;
            btnUpdate.TabIndex = 6;
            btnDelete.TabIndex = 7;
            btnCancel.TabIndex = 8;
            txtSearch.TabIndex = 9;
            KeyPreview = true;
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetControls()
        {
            btnSave.Enabled = true;
            _id = 0;
            cbxCategoryName.SelectedIndex = 0;
            cbxSubCategoryName.SelectedIndex = 0;
            txtProductName.Clear();
            txtPurchasePrice.Clear();
            txtSellingPrice.Clear();
            cbxCategoryName.Focus();
        }

        private async void ProductForm_Load(object sender, EventArgs e)
        {
            if (MdiParent is MainForm mainForm)
            {
                _userId = mainForm.LoggedInUserId;
            }
            await LoadCategoryComboBoxAsync();
            await LoadProductGridAsync();
        }

        private async Task LoadCategoryComboBoxAsync()
        {
            List<CategoryReadDto> categories;
            var result = await _categoryService.GetAllAsync();
            if (result.Status == Status.Success)
            {
                categories = result.Data;
                categories.Insert(0, new()
                {
                    Id = 0,
                    Name = "Select a Category"
                }
                );
            }
            else
            {
                categories =
                [
                    new CategoryReadDto
                    {
                        Id = 0,
                        Name = "No Categories Available"
                    }
                ];
            }
            cbxCategoryName.DataSource = categories;
            cbxCategoryName.DisplayMember = nameof(CategoryReadDto.Name);
            cbxCategoryName.ValueMember = nameof(CategoryReadDto.Id);
            cbxCategoryName.SelectedIndex = 0; // Set default selection to the first item
        }
        private async Task LoadSubCategoryComboBoxAsync(int selectedCategoryId)
        {
            List<SubCategoryReadDto> subCategories;
            var result = await _subCategoryService.GetByCategoryIdAsync(selectedCategoryId);
            if (result.Status == Status.Success)
            {
                subCategories = result.Data;
                subCategories.Insert(0, new()
                {
                    Id = 0,
                    Name = "Select a Sub Category"
                }
                );
            }
            else
            {
                subCategories =
                [
                    new SubCategoryReadDto
                    {
                        Id = 0,
                        Name = "No Sub Categories Available"
                    }
                ];
            }
            cbxSubCategoryName.DataSource = subCategories;
            cbxSubCategoryName.DisplayMember = nameof(SubCategoryReadDto.Name);
            cbxSubCategoryName.ValueMember = nameof(SubCategoryReadDto.Id);
            cbxSubCategoryName.SelectedIndex = 0; // Set default selection to the first item
        }

        public async Task LoadProductGridAsync()
        {
            dgvProduct.AutoGenerateColumns = false;
            dgvProduct.ReadOnly = true;
            dgvProduct.RowHeadersVisible = false;

            dgvProduct.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = Others.Sn,
                HeaderText = "S.N",

            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.Id),
                HeaderText = "ID",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.Id)
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.CategoryName),
                HeaderText = "Category",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.CategoryName),
                Width = 200
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.Name),
                HeaderText = "Sub Category",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.Name),
                Width = 200

            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.Name),
                HeaderText = "Product",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.Name),
                Width = 200

            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.PurchasePrice),
                HeaderText = "Purchase Price",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.PurchasePrice),
                Width = 200

            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.SellingPrice),
                HeaderText = "Selling Price",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.SellingPrice),
                Width = 200

            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.Stock),
                HeaderText = "Stock",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.Stock),
                Width = 200

            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.CreatedBy),
                Width = 200
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.CreatedDate),
                Width = 150
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.LastModifiedBy),
                HeaderText = "Last Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.LastModifiedBy),
                Width = 200
            });
            dgvProduct.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(ProductReadDto.LastModifiedDate),
                HeaderText = "Last Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(ProductReadDto.LastModifiedDate),
                Width = 150
            });
            await LoadProductsAsync();
        }

        private async Task LoadProductsAsync()
        {
            dgvProduct.DataSource = null;
            var result = await _productService.GetAllAsync();
            if (result.Status == Status.Success)
            {
                _products = result.Data;
                if (_products.Count > 0)
                {
                    dgvProduct.DataSource = _products;
                    UpdateSerialNumbers();
                }
            }
        }
        private void UpdateSerialNumbers()
        {
            for (int i = 0; i < dgvProduct.Rows.Count; i++)
            {
                dgvProduct.Rows[i].Cells[Others.Sn].Value = i + 1;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await UpsertAsync();
        }

        private async Task UpsertAsync(bool isUpdate = false)
        {
            int subCategoryId = (int)cbxSubCategoryName.SelectedValue;
            string name = txtProductName.Text.Trim();
            decimal purchasePrice = Convert.ToDecimal(txtPurchasePrice.Text.Trim());
            decimal sellingPrice = Convert.ToDecimal(txtSellingPrice.Text.Trim());
            OutputDto result;
            if (isUpdate)
            {
                var request = new ProductUpdateDto
                {
                    Id = _id,
                    SubCategoryId = subCategoryId,
                    Name = name,
                    PurchasePrice = purchasePrice,
                    SellingPrice = sellingPrice,
                    CreatedBy = _userId
                };
                result = await _productService.UpdateAsync(request);
            }
            else
            {
                var request = new ProductUpdateDto
                {
                    SubCategoryId = subCategoryId,
                    Name = name,
                    PurchasePrice = purchasePrice,
                    SellingPrice = sellingPrice,
                    CreatedBy = _userId
                };
                result = await _productService.SaveAsync(request);
            }

            await OnSuccessAsync(result);
        }
        private async Task OnSuccessAsync(OutputDto result)
        {
            if (result.Status == Status.Success)
            {
                await LoadProductsAsync();
                DialogBox.SuccessAlert(result.Message);

            }
            else DialogBox.FailureAlert(result);

            ResetControls();

        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await UpsertAsync(true);
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DeleteAsync();
        }

        private async Task DeleteAsync()
        {
            if (_id > 0)
            {
                var dialogResult = DialogBox.ConfirmDeleteAlert();

                if (dialogResult == DialogResult.Yes)
                {
                    var result = await _productService.DeleteAsync(_id);

                    if (result.Status == Status.Success)
                    {
                        await LoadProductsAsync();
                        DialogBox.SuccessAlert(result.Message);
                        ResetControls();
                    }
                    else
                    {
                        DialogBox.FailureAlert(result);
                    }
                }
            }
            else
            {
                DialogBox.FailureAlert(Message.SelectionRequiredMessage);
            }
            ResetControls();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private async void dgvProduct_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            _id = (int)dgvProduct.Rows[e.RowIndex].Cells[nameof(ProductReadDto.Id)].Value;
            if (_id > 0)
            {
                var result = await _productService.GetByIdAsync(_id);
                if (result.Status == Status.Success)
                {
                    var product = result.Data;
                    cbxCategoryName.SelectedValue = product.CategoryName;
                    cbxSubCategoryName.SelectedValue = product.SubCategoryName;
                    txtProductName.Text = product.Name;
                    txtPurchasePrice.Text = product.PurchasePrice.ToString();
                    txtSellingPrice.Text = product.SellingPrice.ToString();
                }
                else
                {
                    DialogBox.FailureAlert(result);
                }
            }
            cbxCategoryName.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchedText = txtSearch.Text.Trim();

            if (String.IsNullOrEmpty(searchedText))
            {
                dgvProduct.DataSource = _products;
                return;
            }
            else
            {
                var filteredProducts = _products
                                               .Where(x =>
                                                          x.Name.Contains(searchedText, StringComparison.OrdinalIgnoreCase) ||
                                                          x.CategoryName.Contains(searchedText, StringComparison.OrdinalIgnoreCase)
                                                      )
                                               .ToList();
                dgvProduct.DataSource = filteredProducts;
            }
        }

        private async void ProductForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                await UpsertAsync();
            }
            else if (e.KeyCode == Keys.F3)
            {
                await UpsertAsync(true);
            }
            else if (e.KeyCode == Keys.F4)
            {
                await DeleteAsync();
            }
            else if (e.KeyCode == Keys.F5)
            {
                ResetControls();
            }
            else if (e.KeyCode == Keys.F10)
            {
                this.Close();
            }
        }

        private async void cbxCategoryName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxCategoryName.SelectedItem is CategoryReadDto category) // Cast the selected item to the correct type
            {
                _selectedCategoryId = category.Id;

                if (_selectedCategoryId >= 0)
                {
                    await LoadSubCategoryComboBoxAsync(_selectedCategoryId);
                }
                else
                {
                    throw new Exception("Invalid Category ID");
                }
            }
        }
    }
}
