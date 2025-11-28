using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using HospitalManagerment.Utils;
using MySqlX.XDevAPI.Relational;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private ActionBUS actionBUS;
        private FunctionBUS functionBUS;

        private readonly dynamic[] hanhDongArr = new[]
        {
            new { MaHD = "add", TenHD = "Thêm" },
            new { MaHD = "delete", TenHD = "Xóa" },
            new { MaHD = "edit", TenHD = "Sửa" },
            new { MaHD = "view", TenHD = "Xem" }
        };

        private readonly dynamic[] chucNangArr = new[]
        {
            new { MaCN = "CN0001", TenCN = "Thống kê" },
            new { MaCN = "CN0002", TenCN = "Quản lý bệnh nhân" },
            new { MaCN = "CN0003", TenCN = "Quản lý hồ sơ bệnh án" },
            new { MaCN = "CN0004", TenCN = "Quản lý dịch vụ" },
            new { MaCN = "CN0005", TenCN = "Quản lý nhân viên" },
            new { MaCN = "CN0006", TenCN = "Quản lý phân quyền" }
        };

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
            {
                table.Rows.Add(account.TenDangNhap, account.MaQuyen, account.MaNV);
            }

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
            {
                table.Rows.Add(permission.MaQuyen, permission.TenQuyen);
            }

            tablePermission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePermission.DataSource = table;
            quyenPanel.Controls.Add(tablePermission);
        }


        private TableLayoutPanel CreatePermissionTable()
        {
            var table = new TableLayoutPanel
            {
                RowCount = chucNangArr.Length + 1,
                ColumnCount = hanhDongArr.Length + 1,
                Dock = DockStyle.Fill,
                AutoSize = true,
                CellBorderStyle = TableLayoutPanelCellBorderStyle.Single,
                BackColor = Color.White
            };

            table.ColumnStyles.Clear();
            table.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 250F));
            for (int j = 0; j < hanhDongArr.Length; j++)
                table.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / hanhDongArr.Length));

            table.RowStyles.Clear();
            table.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            for (int i = 0; i < chucNangArr.Length; i++)
                table.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            for (int j = 0; j < hanhDongArr.Length; j++)
            {
                table.Controls.Add(new Label
                {
                    Text = hanhDongArr[j].TenHD,
                    TextAlign = ContentAlignment.MiddleCenter,
                    Dock = DockStyle.Fill,
                    Font = new Font("Roboto", 11, FontStyle.Bold),
                    ForeColor = Consts.FontColorA
                }, j + 1, 0);
            }

            for (int i = 0; i < chucNangArr.Length; i++)
            {
                table.Controls.Add(new Label
                {
                    Text = chucNangArr[i].TenCN,
                    TextAlign = ContentAlignment.MiddleLeft,
                    Dock = DockStyle.Fill,
                    Font = new Font("Roboto", 11, FontStyle.Bold),
                    ForeColor = Consts.FontColorA
                }, 0, i + 1);

                // Các checkbox
                for (int j = 0; j < hanhDongArr.Length; j++)
                {
                    var panel = new Panel
                    {
                        Dock = DockStyle.Fill,
                    };

                    var ckb = new CheckBox
                    {
                        AutoSize = true,
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
        }

        private void buttonSuaTaiKhoanClick(object sender, EventArgs e)
        {
            if (tableAccounts.SelectedRows.Count > 0)
            {
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

                    // Kiểm tra nếu chưa có nhân viên này thì thêm
                    if (!list.Any(emp => emp.MaNV == taikhoan.MaNV))
                    {
                        var emp = employeeBUS.GetEmployeeById(taikhoan.MaNV);
                        if (emp != null)
                            list.Add(emp);
                    }

                    // Gán lại DataSource
                    cbNhanVien.DataSource = null;
                    cbNhanVien.DataSource = list;
                    cbNhanVien.DisplayMember = "TenNV";
                    cbNhanVien.ValueMember = "MaNV";

                    // Chọn nhân viên đang sửa
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

        // sự kiện tabPageQuyen
        private void buttonHuyQuyenClick(object sender, EventArgs e)
        {
            txtMaQuyen.TextValue = permissionBUS.GetNextPermissionId();
            txtTenQuyen.TextValue = "";
            TableLayoutPanel table = quyenPanelForCheckbox.Controls[0] as TableLayoutPanel;

            for (int i = 0; i < chucNangArr.Length; i++)
            {
                for (int j = 0; j < hanhDongArr.Length; j++)
                {
                    Panel panel = table.GetControlFromPosition(j + 1, i + 1) as Panel;
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

                    for (int i = 0; i < chucNangArr.Length; i++)
                    {
                        for (int j = 0; j < hanhDongArr.Length; j++)
                        {
                            Panel panel = table.GetControlFromPosition(j + 1, i + 1) as Panel;
                            if (panel != null && panel.Controls.Count > 0)
                            {
                                CheckBox ckb = panel.Controls[0] as CheckBox;
                                if (ckb != null && ckb.Checked)
                                {
                                    hasAnyPermission = true;
                                    PermissionDetailDTO permissionDetail = new PermissionDetailDTO()
                                    {
                                        MaCN = chucNangArr[i].MaCN,
                                        MaQuyen = permission.MaQuyen,
                                        MaHD = hanhDongArr[j].MaHD
                                    };

                                    permissionDetailBUS.AddPermissionDetail(permissionDetail);
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

                    for (int i = 0; i < chucNangArr.Length; i++)
                    {
                        for (int j = 0; j < hanhDongArr.Length; j++)
                        {
                            Panel panel = table.GetControlFromPosition(j + 1, i + 1) as Panel;
                            if (panel != null && panel.Controls.Count > 0)
                            {
                                CheckBox ckb = panel.Controls[0] as CheckBox;
                                if (ckb != null)
                                {
                                    string maCN = chucNangArr[i].MaCN;
                                    string maHD = hanhDongArr[j].MaHD;
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

            TableLayoutPanel table = quyenPanelForCheckbox.Controls[0] as TableLayoutPanel;

            for (int i = 0; i < chucNangArr.Length; i++)
            {
                for (int j = 0; j < hanhDongArr.Length; j++)
                {
                    Panel panel = table.GetControlFromPosition(j + 1, i + 1) as Panel;
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

                    TableLayoutPanel table = quyenPanelForCheckbox.Controls[0] as TableLayoutPanel;
                    for (int i = 0; i < chucNangArr.Length; i++)
                    {
                        for (int j = 0; j < hanhDongArr.Length; j++)
                        {
                            Panel panel = table.GetControlFromPosition(j + 1, i + 1) as Panel;
                            if (panel != null && panel.Controls.Count > 0)
                            {
                                CheckBox ckb = panel.Controls[0] as CheckBox;
                                if (ckb != null)
                                {
                                    string maCN = chucNangArr[i].MaCN;
                                    string maHD = hanhDongArr[j].MaHD;

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
    }
}
