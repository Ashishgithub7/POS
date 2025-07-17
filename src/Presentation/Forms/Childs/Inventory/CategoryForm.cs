using POS.Business.Services.Inventory.Categories;
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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace POS.Desktop.Forms.Childs.Inventory
{
    public partial class CategoryForm : Form
    {
        private readonly ICategoryService _categoryService;
        private List<CategoryReadDto> _categories = new List<CategoryReadDto>();
        public CategoryForm(ICategoryService categoryService)
        {
            InitializeComponent();
            InitializeFormComponents();
            _categoryService = categoryService;
        }

        private void InitializeFormComponents()
        {
            txtCategoryName.TabIndex = 0;
            btnSave.TabIndex = 1;
            btnUpdate.TabIndex = 2;
            btnDelete.TabIndex = 3;
        }

        private async Task btnSave_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text.Trim();
            var request = new CategoryCreateDto
            {
                Name = name,
                CreatedBy = 0
            };
            var result = await _categoryService.SaveAsync(request);
            if (result.Status == Status.Success)
            {
                ResetControls();
                await LoadCategoryAsync();
                DialogBox.SuccessAlert(result.Message);
                return;
            }
            DialogBox.FailureAlert(result);
        }

        private void ResetControls()
        {
            txtCategoryName.Clear();
            txtCategoryName.Focus();
        }

        private void SearchTxtBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void grdView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void CategoryForm_Load(object sender, EventArgs e)
        {
            await LoadCategoryGridAsync();
        }

        private async Task LoadCategoryGridAsync()
        {
            dgvCategory.AutoGenerateColumns = false;
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
            });
            dgvCategory.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(CategoryReadDto.LastModifiedDate),
                HeaderText = "Last Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(CategoryReadDto.LastModifiedDate),
            });
            await LoadCategoryAsync();
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
                }
            }
        }

      
    }
}
