using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.HoSoBenhAn
{
    public partial class QuyenPage : UserControl
    {
        private string employeeId;
        private TableDataGridView tableAccounts;
        private TableDataGridView tablePermission;
        private PermissionBUS permissionBUS;
        private PermissionDetailBUS permissionDetailBUS;
        private AccountBUS accountBUS;
        private EmployeeBUS employeeBUS;
        public QuyenPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableAccounts = new TableDataGridView();
            tablePermission = new TableDataGridView();
            accountBUS = new AccountBUS();
            permissionBUS = new PermissionBUS();
            permissionDetailBUS = new PermissionDetailBUS();
            employeeBUS = new EmployeeBUS();   
        }

        private void QuyenPage_Load(object sender, EventArgs e)
        {
            LoadAccountToTable();
            LoadPermissionToTable();

            txtMaQuyen.SetReadOnly(true);
            txtMaQuyen.TextValue = permissionBUS.GetNextPermissionId();
        }

        private void LoadAccountToTable()
        {
            tableAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableAccounts.DataSource = ToDataTable(accountBUS.GetAllAccount());
            taiKhoanPanel.Controls.Add(tableAccounts);
        }

        private void LoadPermissionToTable()
        {
            tablePermission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePermission.DataSource = ToDataTable(permissionBUS.GetAllPermissions());
            quyenPanel.Controls.Add(tablePermission);
        }

        private DataTable ToDataTable<T>(List<T> data)
        {
            DataTable table = new DataTable();
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        private void comboBoxNhanVienLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxNhanVien.GetComboBox();
            if (cb.DataSource == null)
            {
                cb.DataSource = employeeBUS.GetAllEmployees(); //doi thanh GetAllEmployeesDoNotHaveAccount
                cb.DisplayMember = "TenNV";
                cb.ValueMember = "MaNV";
                cb.SelectedIndex = -1;
                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;
                    string text = ((EmployeeDTO)cb.Items[ev.Index]).TenNV;
                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
            }
        }

        private void comboBoxQuyenLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxQuyen.GetComboBox();
            if (cb.DataSource == null)
            {
                cb.DataSource = permissionBUS.GetAllPermissions();
                cb.DisplayMember = "TenQuyen";
                cb.ValueMember = "MaQuyen";
                cb.SelectedIndex = -1;
                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;
                    string text = ((PermissionDTO)cb.Items[ev.Index]).TenQuyen;
                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
            }
        }

        // sự kiện tabPageTaiKhoan
        private void buttonHuyTaiKhoanClick(object sender, EventArgs e)
        {
            txtTenDangNhap.TextValue = "";
            txtMatKhau.TextValue = "";
            comboBoxNhanVien.GetComboBox().SelectedIndex = -1;
            comboBoxQuyen.GetComboBox().SelectedIndex = -1;
        }

        private void buttonXacNhanTaiKhoanClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDangNhap.TextValue) || string.IsNullOrEmpty(txtMatKhau.TextValue) || string.IsNullOrEmpty(comboBoxNhanVien.TextValue) || string.IsNullOrEmpty(comboBoxQuyen.TextValue))
            {
                MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin tài khoản!");
                return;
            }
            AccountDTO account = new AccountDTO()
            {
                TenDangNhap = txtTenDangNhap.TextValue.Trim(),
                MatKhau = txtMatKhau.TextValue.Trim(),
                MaNV = comboBoxNhanVien.GetComboBox().SelectedValue?.ToString(),
                MaQuyen = comboBoxQuyen?.GetComboBox().SelectedValue?.ToString(),
            };

            if (!accountBUS.ExistsAccountUsername(account.TenDangNhap))
            {
                accountBUS.AddAccount(account);
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                accountBUS.UpdateAccount(account);
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            buttonHuyTaiKhoanClick(null, null);
        }

        private void buttonThemTaiKhoanClick(object sender, EventArgs e)
        {
            txtTenDangNhap.TextValue = "";
            txtMatKhau.TextValue = "";
            comboBoxNhanVien.GetComboBox().SelectedIndex = -1;
            comboBoxQuyen.GetComboBox().SelectedIndex = -1;  
        }

        private void buttonSuaTaiKhoanClick(object sender, EventArgs e)
        {
            if (tableAccounts.SelectedRows.Count > 0)
            {
                var row = tableAccounts.SelectedRows[0];
                string username = row.Cells["TenDangNhap"].Value?.ToString();

                var taikhoan = accountBUS.GetAccountByUsername(username);
                if (accountBUS.GetAccountByUsername(username) != null)
                {
                    txtTenDangNhap.TextValue = taikhoan.TenDangNhap?.ToString();
                    txtMatKhau.TextValue = taikhoan.MatKhau?.ToString();
                    comboBoxNhanVien.GetComboBox().SelectedValue = taikhoan.MaNV;
                    comboBoxQuyen.GetComboBox().SelectedValue = taikhoan.MaQuyen;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với tài khoản!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn tài khoản cần sửa!");
            }
        }

        private void buttonXoaTaiKhoanClick(object sender, EventArgs e)
        {
            if (tableAccounts.SelectedRows.Count > 0)
            {
                string tenDangNhap = tableAccounts.SelectedRows[0].Cells["TenDangNhap"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa tai khoan này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    accountBUS.DeleteAccount(tenDangNhap);
                    MessageBox.Show("Xóa tai khoan thành công!");
                    buttonHuyTaiKhoanClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu chỉ định dịch vụ cần xóa!");
            }
        }

        // sự kiện tabPageQuyen
        private void buttonHuyQuyenClick(object sender, EventArgs e)
        {
            txtMaQuyen.TextValue = permissionBUS.GetNextPermissionId();
            txtTenQuyen.TextValue = "";
        }

        private void buttonXacNhanQuyenClick(object sender, EventArgs e)
        {

        }

        private void buttonThemQuyenClick(object sender, EventArgs e)
        {
            txtMaQuyen.TextValue = permissionBUS.GetNextPermissionId();
            txtTenQuyen.TextValue = "";
        }

        private void buttonSuaQuyenClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaQuyenClick(object sender, EventArgs e)
        {

        }
    }
}
