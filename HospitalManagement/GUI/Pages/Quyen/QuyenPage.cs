using HM.BUS;
using HM.DTO;
using HM.GUI.Component.TableDataGridView;
using HM.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HM.GUI.Pages.HoSoBenhAn
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
        private ActionBUS actionBUS;
        private FunctionBUS functionBUS;
        
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
            actionBUS = new ActionBUS();
            functionBUS = new FunctionBUS();

            quyenPanelForCheckbox.Controls.Add(CreatePermissionTable());
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
            DataTable table = new DataTable();
            table.Columns.Add("Tên Đăng Nhập", typeof(string));
            table.Columns.Add("Quyền", typeof(string));
            table.Columns.Add("Nhân Viên", typeof(string));

            foreach (var account in accountBUS.GetAllAccount())
                table.Rows.Add(account.TenDangNhap, permissionBUS.GetPermissionById(account.MaQuyen).TenQuyen, employeeBUS.GetEmployeeById(account.MaNV).TenNV);

            tableAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableAccounts.DataSource = table;
            taiKhoanPanel.Controls.Add(tableAccounts);
        }


        private void LoadPermissionToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Quyền", typeof(string));
            table.Columns.Add("Tên Quyền", typeof(string));

            foreach (var permission in permissionBUS.GetAllPermissions())
                table.Rows.Add(permission.MaQuyen, permission.TenQuyen);

            tablePermission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePermission.DataSource = table;
            quyenPanel.Controls.Add(tablePermission);
        }


        private TableLayoutPanel CreatePermissionTable()
        {
            // Lấy danh sách hành động và chức năng từ database
            var hanhDongList = actionBUS.GetAllAction();
            var chucNangList = functionBUS.GetAllFunction();

            var table = new TableLayoutPanel
            {
                RowCount = chucNangList.Count + 1,
                ColumnCount = hanhDongList.Count + 1,
                Dock = DockStyle.Fill,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White
            };

            table.ColumnStyles.Clear();
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            for (int j = 0; j < hanhDongList.Count; j++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / hanhDongList.Count));

            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            for (int i = 0; i < chucNangList.Count; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            // Header cho các hành động
            for (int j = 0; j < hanhDongList.Count; j++)
            {
                table.Controls.Add(new Label
                {
                    Text = hanhDongList[j].TenHD,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Roboto", 11, FontStyle.Bold),
                    ForeColor = Consts.FontColorA
                }, j + 1, 0);
            }

            // Các chức năng và checkbox tương ứng
            for (int i = 0; i < chucNangList.Count; i++)
            {
                // Label tên chức năng
                table.Controls.Add(new Label
                {
                    Text = chucNangList[i].TenCN,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Font = new Font("Roboto", 11, FontStyle.Bold),
                    ForeColor = Consts.FontColorA
                }, 0, i + 1);

                // Checkbox cho từng hành động
                for (int j = 0; j < hanhDongList.Count; j++)
                {
                    var panel = new Panel
                    {
                        Dock = DockStyle.Fill,
                        Tag = new { MaCN = chucNangList[i].MaCN, MaHD = hanhDongList[j].MaHD }
                    };

                    var ckb = new CheckBox
                    {
                        AutoSize = true,
                        Tag = new { MaCN = chucNangList[i].MaCN, MaHD = hanhDongList[j].MaHD }
                    };

                    panel.Controls.Add(ckb);
                    panel.Resize += (s, e) =>
                    {
                        ckb.Location = new Point(
                            (panel.Width - ckb.Width) / 2,
                            (panel.Height - ckb.Height) / 2
                        );
                    };

                    table.Controls.Add(panel, j + 1, i + 1);
                }
            }
            return table;
        }

        private void comboBoxNhanVienLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxNhanVien.GetComboBox();
            if (cb.DataSource == null)
            {
                cb.DataSource = employeeBUS.GetAllEmployeesDoNotHaveAccount(); //doi thanh GetAllEmployeesDoNotHaveAccount
                cb.DisplayMember = "TenNV";
                cb.ValueMember = "MaNV";
                cb.SelectedIndex = -1;
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
            }
        }

        // sự kiện tabPageTaiKhoan =========================================================================================================
        // sự kiện tabPageTaiKhoan =========================================================================================================
        private void buttonHuyTaiKhoanClick(object sender, EventArgs e)
        {
            txtTenDangNhap.TextValue = "";
            txtMatKhau.TextValue = "";
            buttonXacNhanTaiKhoan.Text = "Xác nhận";
            comboBoxNhanVien.GetComboBox().DataSource = null;
            comboBoxNhanVienLoad(null,null);
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

            if (buttonXacNhanTaiKhoan.Text == "Xác nhận")
            {
                accountBUS.AddAccount(account);
                MessageBox.Show("Thêm tài khoản thành công!");
            }
            else
            {
                accountBUS.UpdateAccount(account);
                MessageBox.Show("Cập nhật tài khoản thành công!");
            }
            LoadAccountToTable();
            comboBoxNhanVien.GetComboBox().DataSource = null;
            comboBoxNhanVienLoad(null, null);
            buttonHuyTaiKhoanClick(null, null);
        }

        private void buttonThemTaiKhoanClick(object sender, EventArgs e)
        {
            txtTenDangNhap.TextValue = "";
            txtMatKhau.TextValue = "";
            comboBoxNhanVien.GetComboBox().SelectedIndex = -1;
            comboBoxQuyen.GetComboBox().SelectedIndex = -1;
            buttonXacNhanTaiKhoan.Text = "Xác nhận";
        }

        private void buttonSuaTaiKhoanClick(object sender, EventArgs e)
        {
            if (tableAccounts.SelectedRows.Count > 0)
            {
                buttonXacNhanTaiKhoan.Text = "Lưu";
                var row = tableAccounts.SelectedRows[0];
                string username = row.Cells["Tên Đăng Nhập"].Value?.ToString();

                var taikhoan = accountBUS.GetAccountByUsername(username);
                if (taikhoan != null)
                {
                    txtTenDangNhap.TextValue = taikhoan.TenDangNhap?.ToString();
                    txtMatKhau.TextValue = taikhoan.MatKhau?.ToString();

                    ComboBox cbNhanVien = comboBoxNhanVien.GetComboBox();
                    // Lấy danh sách nhân viên hiện tại từ DataSource
                    var list = ((List<EmployeeDTO>)cbNhanVien.DataSource).ToList();

                    if (!list.Any(emp => emp.MaNV == taikhoan.MaNV))
                    {
                        var emp = employeeBUS.GetEmployeeById(taikhoan.MaNV);
                        if (emp != null)
                            list.Add(emp);
                    }

                    cbNhanVien.DataSource = null;
                    cbNhanVien.DataSource = list;
                    cbNhanVien.DisplayMember = "TenNV";
                    cbNhanVien.ValueMember = "MaNV";

                    cbNhanVien.SelectedValue = taikhoan.MaNV;
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
                string tenDangNhap = tableAccounts.SelectedRows[0].Cells["Tên Đăng Nhập"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa tài khoản này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    accountBUS.DeleteAccount(tenDangNhap);
                    MessageBox.Show("Xóa tài khoản thành công!");
                    LoadAccountToTable();
                    comboBoxNhanVien.GetComboBox().DataSource = null;
                    comboBoxNhanVienLoad(null, null);
                    buttonHuyTaiKhoanClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu chỉ định dịch vụ cần xóa!");
            }
        }

        // sự kiện tabPageQuyen =================================================================================================================
        // sự kiện tabPageQuyen =================================================================================================================
        private void buttonHuyQuyenClick(object sender, EventArgs e)
        {
            txtMaQuyen.TextValue = permissionBUS.GetNextPermissionId();
            txtTenQuyen.TextValue = "";
            
            if (quyenPanelForCheckbox.Controls.Count > 0 && quyenPanelForCheckbox.Controls[0] is TableLayoutPanel table)
            {
                var hanhDongList = actionBUS.GetAllAction();
                var chucNangList = functionBUS.GetAllFunction();
                
               
                for (int i = 1; i < table.RowCount; i++) 
                {
                    for (int j = 1; j < table.ColumnCount; j++) 
                    {
                        Panel panel = table.GetControlFromPosition(j, i) as Panel;
                        if (panel != null && panel.Controls.Count > 0)
                        {
                            CheckBox ckb = panel.Controls[0] as CheckBox;
                            if (ckb != null)
                            {
                                ckb.Checked = false;
                            }
                        }
                    }
                }
            }
        }

        private void buttonXacNhanQuyenClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenQuyen.TextValue))
            {
                MessageBox.Show("Vui long nhap day du thong tin quyen");
                return;
            }

            PermissionDTO permission = new PermissionDTO()
            {
                MaQuyen = txtMaQuyen.TextValue.Trim(),
                TenQuyen = txtTenQuyen.TextValue.Trim()
            };

            if (!permissionBUS.ExistsPermissionId(permission.MaQuyen))
            {
                if (permissionBUS.AddPermission(permission))
                {
                    TableLayoutPanel table = quyenPanelForCheckbox.Controls[0] as TableLayoutPanel;
                    bool hasAnyPermission = false;

                    var hanhDongList = actionBUS.GetAllAction();
                    var chucNangList = functionBUS.GetAllFunction();

                    for (int i = 1; i < table.RowCount; i++) 
                    {
                        for (int j = 1; j < table.ColumnCount; j++) 
                        {
                            Panel panel = table.GetControlFromPosition(j, i) as Panel;
                            if (panel != null && panel.Controls.Count > 0)
                            {
                                CheckBox ckb = panel.Controls[0] as CheckBox;
                                if (ckb != null && ckb.Checked)
                                {
                                    var tag = ckb.Tag as dynamic;
                                    if (tag != null)
                                    {
                                        hasAnyPermission = true;
                                        PermissionDetailDTO permissionDetail = new PermissionDetailDTO()
                                        {
                                            MaCN = tag.MaCN,
                                            MaQuyen = permission.MaQuyen,
                                            MaHD = tag.MaHD
                                        };

                                        permissionDetailBUS.AddPermissionDetail(permissionDetail);
                                    }
                                }
                            }
                        }
                    }

                    if (hasAnyPermission)
                    {
                        MessageBox.Show("Phân quyền thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Thêm quyền thành công nhưng chưa phân quyền chức năng nào!");
                    }
                }
                else
                {
                    MessageBox.Show("Lỗi khi thêm quyền!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                if (permissionBUS.UpdatePermission(permission))
                {
                    TableLayoutPanel table = quyenPanelForCheckbox.Controls[0] as TableLayoutPanel;

                    for (int i = 1; i < table.RowCount; i++)
                    {
                        for (int j = 1; j < table.ColumnCount; j++)
                        {
                            Panel panel = table.GetControlFromPosition(j, i) as Panel;
                            if (panel != null && panel.Controls.Count > 0)
                            {
                                CheckBox ckb = panel.Controls[0] as CheckBox;
                                if (ckb != null)
                                {
                                    var tag = ckb.Tag as dynamic;
                                    if (tag != null)
                                    {
                                        string maCN = tag.MaCN;
                                        string maHD = tag.MaHD;
                                        string maQuyen = permission.MaQuyen;
                                        bool isChecked = ckb.Checked;

                                        bool exists = permissionDetailBUS.ExistsPermissionDetail(maQuyen, maHD, maCN);

                                        if (isChecked && exists)
                                            permissionDetailBUS.ActivePermissionDetail(maQuyen, maHD, maCN);
                                        else if (isChecked && !exists)
                                            permissionDetailBUS.AddPermissionDetail(new PermissionDetailDTO()
                                            {
                                                MaCN = maCN,
                                                MaQuyen = maQuyen,
                                                MaHD = maHD
                                            });
                                        else if (!isChecked && exists)
                                            permissionDetailBUS.DeletePermissionDetail(maQuyen, maHD, maCN);
                                    }
                                }
                            }
                        }
                    }
                    MessageBox.Show("Cập nhật quyền thành công!");
                }
                else
                {
                    MessageBox.Show("Cập nhật quyền thất bại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            LoadPermissionToTable();
            comboBoxQuyen.GetComboBox().DataSource = null;
            comboBoxQuyenLoad(null, null);
            buttonHuyQuyenClick(null, null);
        }

        private void buttonThemQuyenClick(object sender, EventArgs e)
        {
            txtMaQuyen.TextValue = permissionBUS.GetNextPermissionId();
            txtTenQuyen.TextValue = "";

            if (quyenPanelForCheckbox.Controls.Count > 0 && quyenPanelForCheckbox.Controls[0] is TableLayoutPanel table)
            {
                for (int i = 1; i < table.RowCount; i++)
                {
                    for (int j = 1; j < table.ColumnCount; j++)
                    {
                        Panel panel = table.GetControlFromPosition(j, i) as Panel;
                        if (panel != null && panel.Controls.Count > 0)
                        {
                            CheckBox ckb = panel.Controls[0] as CheckBox;
                            if (ckb != null)
                            {
                                ckb.Checked = false;
                            }
                        }
                    }
                }
            }
        }

        private void buttonSuaQuyenClick(object sender, EventArgs e)
        {
            if (tablePermission.SelectedRows.Count > 0)
            {
                var row = tablePermission.SelectedRows[0];
                string maQuyen = row.Cells["Mã Quyền"].Value?.ToString();

                var quyen = permissionBUS.GetPermissionById(maQuyen);
                if (quyen != null)
                {
                    txtMaQuyen.TextValue = quyen.MaQuyen?.ToString();
                    txtTenQuyen.TextValue = quyen.TenQuyen?.ToString();
                    List<PermissionDetailDTO> list = permissionDetailBUS.GetPermissionDetailsByPermissionId(maQuyen);

                    if (quyenPanelForCheckbox.Controls.Count > 0 && quyenPanelForCheckbox.Controls[0] is TableLayoutPanel table)
                    {
                        for (int i = 1; i < table.RowCount; i++)
                        {
                            for (int j = 1; j < table.ColumnCount; j++)
                            {
                                Panel panel = table.GetControlFromPosition(j, i) as Panel;
                                if (panel != null && panel.Controls.Count > 0)
                                {
                                    CheckBox ckb = panel.Controls[0] as CheckBox;
                                    if (ckb != null)
                                    {
                                        var tag = ckb.Tag as dynamic;
                                        if (tag != null)
                                        {
                                            string maCN = tag.MaCN;
                                            string maHD = tag.MaHD;

                                            bool exists = list.Any(pd =>
                                                pd.MaCN == maCN &&
                                                pd.MaHD == maHD &&
                                                pd.MaQuyen == maQuyen);

                                            ckb.Checked = exists;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy quyền với mã này!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn quyền cần sửa!");
            }
        }

        private void buttonXoaQuyenClick(object sender, EventArgs e)
        {
            if (tablePermission.SelectedRows.Count > 0)
            {
                string maQuyen = tablePermission.SelectedRows[0].Cells["Mã Quyền"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa quyền này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    permissionBUS.DeletePermission(maQuyen);
                    MessageBox.Show("Xóa quyền thành công!");
                    comboBoxQuyen.GetComboBox().DataSource = null;
                    LoadPermissionToTable();
                    buttonHuyQuyenClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn quyền cần xóa!");
            }
        }

        private void searchBarTaiKhoanTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarTaiKhoan.Text.Trim();
            var accounts = accountBUS.SearchAccount(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Tên Đăng Nhập", typeof(string));
            table.Columns.Add("Quyền", typeof(string));
            table.Columns.Add("Nhân Viên", typeof(string));

            foreach (var account in accounts)
            {
                table.Rows.Add(
                    account.TenDangNhap,
                    permissionBUS.GetPermissionById(account.MaQuyen)?.TenQuyen,
                    employeeBUS.GetEmployeeById(account.MaNV)?.TenNV
                );
            }

            tableAccounts.DataSource = table;
        }

    }
}
