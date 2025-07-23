using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.Inventory.SubCategories;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
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
    public partial class SubCategoryForm : Form
    {
        private readonly ISubCategoryService _subCategoryService;
        private readonly ICategoryService _categoryService;
        private List<SubCategoryReadDto> _subCategories = new List<SubCategoryReadDto>();

        private int _userId;
        private int _id;

        public SubCategoryForm(ISubCategoryService subCategoryService, ICategoryService categoryService)
        {
            InitializeComponent();
            InitializeFormComponents();
            _subCategoryService = subCategoryService;
            _categoryService = categoryService;
            
        }
        private void InitializeFormComponents()
        {
            this.AcceptButton = btnSave;
            cbxCategoryName.TabIndex = 0;
            txtBoxSubCategoryName.TabIndex = 1;
            btnSave.TabIndex = 2;
            btnUpdate.TabIndex = 3;
            btnDelete.TabIndex = 4;
            btnCancel.TabIndex = 5;
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
            txtBoxSubCategoryName.Clear();
            cbxCategoryName.Focus();
        }

        private async void SubCategoryForm_Load(object sender, EventArgs e)
        {
            if (MdiParent is MainForm mainForm)
            {
                _userId = mainForm.LoggedInUserId;
            }
            await LoadCategoryComboBoxAsync();
            await LoadSubCategoryGridAsync();
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

        public async Task LoadSubCategoryGridAsync()
        {
            dgvSubCategory.AutoGenerateColumns = false;
            dgvSubCategory.ReadOnly = true;
            dgvSubCategory.RowHeadersVisible = false;

            dgvSubCategory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = Others.Sn,
                HeaderText = "S.N",

            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.Id),
                HeaderText = "ID",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.Id)
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.CategoryName),
                HeaderText = "Category",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.CategoryName),
                Width = 200
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.Name),
                HeaderText = "Sub Category",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.Name),
                Width = 200

            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.CreatedBy),
                Width = 200
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.CreatedDate),
                Width = 150
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.LastModifiedBy),
                HeaderText = "Last Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.LastModifiedBy),
                Width = 200
            });
            dgvSubCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SubCategoryReadDto.LastModifiedDate),
                HeaderText = "Last Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SubCategoryReadDto.LastModifiedDate),
                Width = 150
            });
            await LoadSubCategoryAsync();
        }
        private async Task LoadSubCategoryAsync()
        {
            dgvSubCategory.DataSource = null;
            var result = await _subCategoryService.GetAllAsync();
            if (result.Status == Status.Success)
            {
                _subCategories = result.Data;
                if (_subCategories.Count > 0)
                {
                    dgvSubCategory.DataSource = _subCategories;
                    UpdateSerialNumbers();
                }
            }
        }
        private void UpdateSerialNumbers()
        {
            for (int i = 0; i < dgvSubCategory.Rows.Count; i++)
            {
                dgvSubCategory.Rows[i].Cells[Others.Sn].Value = i + 1;
            }
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await UpsertAsync();
        }
        private async Task UpsertAsync(bool isUpdate = false)
        {
            int categoryId = (int)cbxCategoryName.SelectedValue;
            string name = txtBoxSubCategoryName.Text.Trim();
            OutputDto result;
            if (isUpdate)
            {
                var request = new SubCategoryUpdateDto
                {
                    Id = _id,
                    CategoryId = categoryId,
                    Name = name,
                    CreatedBy = _userId
                };
                result = await _subCategoryService.UpdateAsync(request);
            }
            else
            {
                var request = new SubCategoryCreateDto
                {
                    CategoryId = categoryId,
                    Name = name,
                    CreatedBy = _userId
                };
                result = await _subCategoryService.SaveAsync(request);
            }

            await OnSuccessAsync(result);

        }
        private async Task OnSuccessAsync(OutputDto result)
        {
            if (result.Status == Status.Success)
            {
                await LoadSubCategoryAsync();
                DialogBox.SuccessAlert(result.Message);

            }
            else DialogBox.FailureAlert(result);

            ResetControls();

        }

        private async void dgvSubCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            _id = (int)dgvSubCategory.Rows[e.RowIndex].Cells[nameof(CategoryReadDto.Id)].Value;
            if (_id > 0)
            {
                var result = await _subCategoryService.GetByIdAsync(_id);
                if (result.Status == Status.Success)
                {
                    cbxCategoryName.SelectedValue = result.Data.CategoryName;
                    txtBoxSubCategoryName.Text = result.Data.Name;
                }
                else
                {
                    DialogBox.FailureAlert(result);
                }
            }
            cbxCategoryName.Focus();
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
                    var result = await _subCategoryService.DeleteAsync(_id);

                    if (result.Status == Status.Success)
                    {
                        await LoadSubCategoryAsync();
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

        private void txtBoxSearch_TextChanged(object sender, EventArgs e)
        {
            string searchedText = txtBoxSearch.Text.Trim();

            if (String.IsNullOrEmpty(searchedText))
            {
                dgvSubCategory.DataSource = _subCategories;
                return;
            }
            else
            {
                var filteredCategories = _subCategories
                                               .Where(x => x.Name.Contains(searchedText, StringComparison.OrdinalIgnoreCase))
                                               .ToList();
                dgvSubCategory.DataSource = filteredCategories;
            }
        }

        private async void SubCategoryForm_KeyDown(object sender, KeyEventArgs e)
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
    }
}
