using Microsoft.IdentityModel.Tokens;
using Microsoft.VisualBasic;
using POS.Business.Services.Inventory.Categories;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.Enums;
using POS.Desktop.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Message = POS.Common.Constants.Message;

namespace POS.Desktop.Forms.Childs.Inventory
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private List<CategoryReadDto> _categories = new List<CategoryReadDto>();

        private int _userId;
        private int _id;
        public CategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();
            InitializeFormComponents();
            _categoryService = categoryService;
        }

        private void InitializeFormComponents()
        {
            this.AcceptButton = btnSave;
            txtCategoryName.TabIndex = 0;
            btnSave.TabIndex = 1;
            btnUpdate.TabIndex = 2;
            btnDelete.TabIndex = 3;
            KeyPreview = true;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await UpsertAsync();
        }
        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await UpsertAsync(true);
        }
        private async Task UpsertAsync(bool isUpdate = false)
        {
            string name = txtCategoryName.Text.Trim();
            OutputDto result;
            if (isUpdate)
            {
                var request = new CategoryUpdateDto
                {
                    Id = _id,
                    Name = name,
                    CreatedBy = _userId
                };
                result = await _categoryService.UpdateAsync(request);
            }
            else
            {
                var request = new CategoryCreateDto
                {
                    Name = name,
                    CreatedBy = _userId
                };
                result = await _categoryService.SaveAsync(request);
            }

            await OnSuccessAsync(result);

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
                    var result = await _categoryService.DeleteAsync(_id);

                    if (result.Status == Status.Success)
                    {
                        await LoadCategoryAsync();
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

        private void ResetControls()
        {
            btnSave.Enabled = true;
            _id = 0;
            txtCategoryName.Clear();
            txtCategoryName.Focus();
        }
        

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {
            string searchedText = SearchTxtBox.Text.Trim();

            if (String.IsNullOrEmpty(searchedText))
            {
                dgvCategory.DataSource = _categories;
                return;
            }
            else
            {
                var filteredCategories = _categories
                                               .Where(x => x.Name.Contains(searchedText, StringComparison.OrdinalIgnoreCase))
                                               .ToList();
                dgvCategory.DataSource = filteredCategories;
            }
        }

        private async void CategoryForm_Load(object sender, EventArgs e)
        {
            if (MdiParent is MainForm mainForm)
            {
                _userId = mainForm.LoggedInUserId;
            }
            await LoadCategoryGridAsync();
        }

        private async Task LoadCategoryGridAsync()
        {
            dgvCategory.AutoGenerateColumns = false;
            dgvCategory.ReadOnly = true;
            dgvCategory.RowHeadersVisible = false;

            dgvCategory.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = Others.Sn,
                HeaderText = "S.N",

            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryReadDto.Id),
                HeaderText = "ID",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryReadDto.Id),
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryReadDto.Name),
                HeaderText = "Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryReadDto.Name),
                Width = 200
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryReadDto.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryReadDto.CreatedBy),
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryReadDto.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryReadDto.CreatedDate),
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryReadDto.LastModifiedBy),
                HeaderText = "Last Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryReadDto.LastModifiedBy),
                Width = 200
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryReadDto.LastModifiedDate),
                HeaderText = "Last Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryReadDto.LastModifiedDate),
                Width = 200

            });
            await LoadCategoryAsync();
        }

        private void UpdateSerialNumbers()
        {
            for (int i = 0; i < dgvCategory.Rows.Count; i++)
            {
                dgvCategory.Rows[i].Cells[Others.Sn].Value = i + 1;
            }
        }
        private async Task LoadCategoryAsync()
        {
            dgvCategory.DataSource = null;
            var result = await _categoryService.GetAllAsync();
            if (result.Status == Status.Success)
            {
                _categories = result.Data;
                if (_categories.Count > 0)
                {
                    dgvCategory.DataSource = _categories;
                    UpdateSerialNumbers();
                }
            }
        }

        private async void dgvCategory_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            _id = (int)dgvCategory.Rows[e.RowIndex].Cells[nameof(CategoryReadDto.Id)].Value;
            if (_id > 0)
            {
                var result = await _categoryService.GetByIdAsync(_id);
                if (result.Status == Status.Success)
                {
                    txtCategoryName.Text = result.Data.Name;
                }
                else
                {
                    DialogBox.FailureAlert(result);
                }
            }
            txtCategoryName.Focus();
        }



        private async Task OnSuccessAsync(OutputDto result)
        {
            if (result.Status == Status.Success)
            {
                await LoadCategoryAsync();
                DialogBox.SuccessAlert(result.Message);

            }
            else DialogBox.FailureAlert(result);

            ResetControls();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private async void CategoryForm_KeyDown(object sender, KeyEventArgs e)
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
