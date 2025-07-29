using POS.Business.Services.Inventory.Categories;
using POS.Business.Services.PurchaseBilling.Suppliers;
using POS.Common.Constants;
using POS.Common.DTO.Common;
using POS.Common.DTO.Inventory.Categories;
using POS.Common.DTO.PurchaseBilling.Suppliers;
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

namespace POS.Desktop.Forms.Childs.PurchaseBilling
{
    public partial class SupplierForm : Form
    {
        private readonly ISupplierService _supplierService;
        private List<SupplierReadDto> _suppliers = new List<SupplierReadDto>();

        private int _userId;
        private int _id;
        public SupplierForm(ISupplierService supplierService)
        {
            InitializeComponent();
            InitializeFormComponents();
            _supplierService = supplierService;
        }

        private void InitializeFormComponents()
        {
            this.AcceptButton = btnSave;
            txtSupplierName.TabIndex = 0;
            txtContactPerson.TabIndex = 1;
            txtContactNumber.TabIndex = 2;
            txtEmailAddress.TabIndex = 3;
            txtAddress.TabIndex = 4;
            btnSave.TabIndex = 5;
            btnUpdate.TabIndex = 6;
            btnDelete.TabIndex = 7;
            btnCancel.TabIndex = 8;
            KeyPreview = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetControls()
        {
            btnSave.Enabled = true;
            _id = 0;
            txtSupplierName.Clear();
            txtContactPerson.Clear();
            txtContactNumber.Clear();
            txtEmailAddress.Clear();
            txtAddress.Clear();
            txtSupplierName.Focus();
        }

        private async void SupplierForm_Load(object sender, EventArgs e)
        {
            if (MdiParent is MainForm mainForm)
            {
                _userId = mainForm.LoggedInUserId;
            }
            await LoadSupplierGridAsync();
        }

        private async Task LoadSupplierGridAsync()
        {
            dgvSupplier.AutoGenerateColumns = false;
            dgvSupplier.ReadOnly = true;
            dgvSupplier.RowHeadersVisible = false;

            dgvSupplier.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = Others.Sn,
                HeaderText = "S.N",

            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.Id),
                HeaderText = "ID",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.Id),
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.Name),
                HeaderText = "Name",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.Name),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.ContactPerson),
                HeaderText = "Contact Person",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.ContactPerson),
                Width = 200
            }); dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.ContactNumber),
                HeaderText = "Contact Number",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.ContactNumber),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.EmailAddress),
                HeaderText = "Email Address",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.EmailAddress),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.Address),
                HeaderText = "Address",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.Address),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.CreatedBy),
                HeaderText = "Created By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.CreatedBy),
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.CreatedDate),
                HeaderText = "Created Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.CreatedDate),
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.LastModifiedBy),
                HeaderText = "Last Modified By",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.LastModifiedBy),
                Width = 200
            });
            dgvSupplier.Columns.Add(new DataGridViewColumn
            {
                Name = nameof(SupplierReadDto.LastModifiedDate),
                HeaderText = "Last Modified Date",
                CellTemplate = new DataGridViewTextBoxCell(),
                DataPropertyName = nameof(SupplierReadDto.LastModifiedDate),
                Width = 200

            });
            await LoadSupplierAsync();
        }

        private async Task LoadSupplierAsync()
        {
            dgvSupplier.DataSource = null;
            var result = await _supplierService.GetAllAsync();
            if (result.Status == Status.Success)
            {
                _suppliers = result.Data;
                if (_suppliers.Count > 0)
                {
                    dgvSupplier.DataSource = _suppliers;
                    UpdateSerialNumbers();
                }
            }
        }
        private void UpdateSerialNumbers()
        {
            for (int i = 0; i < dgvSupplier.Rows.Count; i++)
            {
                dgvSupplier.Rows[i].Cells[Others.Sn].Value = i + 1;
            }
        }

        private async Task UpsertAsync(bool isUpdate = false)
        {
            string name = txtSupplierName.Text.Trim();
            string contactPerson = txtContactPerson.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            string emailAddress = txtEmailAddress.Text.Trim();
            string address = txtAddress.Text.Trim();
            OutputDto result;
            if (isUpdate)
            {
                var request = new SupplierUpdateDto
                {
                    Id = _id,
                    Name = name,
                    ContactPerson = contactPerson,
                    ContactNumber = contactNumber,
                    EmailAddress = emailAddress,
                    Address = address,
                    CreatedBy = _userId
                };
                result = await _supplierService.UpdateAsync(request);
            }
            else
            {
                var request = new SupplierCreateDto
                {
                    Name = name,
                    ContactPerson = contactPerson,
                    ContactNumber = contactNumber,
                    EmailAddress = emailAddress,
                    Address = address,
                    CreatedBy = _userId
                };
                result = await _supplierService.SaveAsync(request);
            }

            await OnSuccessAsync(result);

        }
        private async Task OnSuccessAsync(OutputDto result)
        {
            if (result.Status == Status.Success)
            {
                await LoadSupplierAsync();
                DialogBox.SuccessAlert(result.Message);

            }
            else DialogBox.FailureAlert(result);

            ResetControls();

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            await UpsertAsync();
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            await UpsertAsync(true);
        }

        private async Task DeleteAsync()
        {
            if (_id > 0)
            {
                var dialogResult = DialogBox.ConfirmDeleteAlert();

                if (dialogResult == DialogResult.Yes)
                {
                    var result = await _supplierService.DeleteAsync(_id);

                    if (result.Status == Status.Success)
                    {
                        await LoadSupplierAsync();
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

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            await DeleteAsync();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            ResetControls();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string searchedText = txtSearch.Text.Trim();

            if (String.IsNullOrEmpty(searchedText))
            {
                dgvSupplier.DataSource = _suppliers;
                return;
            }
            else
            {
                var filteredCategories = _suppliers
                                               .Where(x => x.Name.Contains(searchedText, StringComparison.OrdinalIgnoreCase) ||
                                                           x.ContactPerson.Contains(searchedText, StringComparison.OrdinalIgnoreCase)||
                                                           x.ContactNumber.Contains(searchedText)||
                                                           x.EmailAddress.Contains(searchedText, StringComparison.OrdinalIgnoreCase)||
                                                           x.Address.Contains(searchedText, StringComparison.OrdinalIgnoreCase))
                                               .ToList();
                dgvSupplier.DataSource = filteredCategories;
            }
        }

        private async void dgvSupplier_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnSave.Enabled = false;
            _id = (int)dgvSupplier.Rows[e.RowIndex].Cells[nameof(SupplierReadDto.Id)].Value;
            if (_id > 0)
            {
                var result = await _supplierService.GetByIdAsync(_id);
                if (result.Status == Status.Success)
                {
                    txtSupplierName.Text = result.Data.Name;
                    txtContactPerson.Text = result.Data.ContactPerson;
                    txtContactNumber.Text = result.Data.ContactNumber;
                    txtEmailAddress.Text = result.Data.EmailAddress;
                    txtAddress.Text = result.Data.Address;
                }
                else
                {
                    DialogBox.FailureAlert(result);
                }
            }
            txtSupplierName.Focus();
        }

        private async void SupplierForm_KeyDown(object sender, KeyEventArgs e)
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
