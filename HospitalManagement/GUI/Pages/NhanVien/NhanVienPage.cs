using HM.BUS;
using HM.DTO;
using HM.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HM.GUI.Pages.NhanVien
{
    public partial class NhanVienPage : UserControl
    {
        private string employeeId;
        private string functionId = "CN0005";
        private TableDataGridView tableEmployee;
        private TableDataGridView tableDepartment;
        private TableDataGridView tableEmployeeOfDepartment;
        private TableDataGridView tableRole;
        private EmployeeBUS employeeBUS;
        private DepartmentBUS departmentBUS;
        private RoleBUS roleBUS;
        private AccountBUS accountBUS;

        public NhanVienPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableEmployee = new TableDataGridView();
            tableEmployeeOfDepartment = new TableDataGridView();
            tableDepartment = new TableDataGridView();
            tableRole = new TableDataGridView();

            employeeBUS = new EmployeeBUS();
            departmentBUS = new DepartmentBUS();
            roleBUS = new RoleBUS();
            accountBUS = new AccountBUS();
        }

        private void NhanVienPage_Load(object sender, EventArgs e)
        {
            LoadEmployeeToTable();
            LoadDepartmentToTable();
            LoadEmployeeOfDepartmentToTable();
            LoadRoleToTable();

            txtMaNhanVien.SetReadOnly(true);
            txtMaKhoa.SetReadOnly(true);
            txtMaVaiTro.SetReadOnly(true);
            txtMaNhanVien.TextValue = employeeBUS.GetNextEmployeeId();
            txtMaKhoa.TextValue = departmentBUS.GetNextDepartmentId();
            txtMaVaiTro.TextValue = roleBUS.GetNextRoleId();

            applyPermissions(accountBUS.GetAccountByEmployeeId(employeeId).TenDangNhap, functionId);
        }
        private void applyPermissions(string username, string maCN)
        {
            if (!accountBUS.HasPermission(username, maCN, "add"))
            {
                tableToolBoxNhanVien.ColumnStyles[1].Width = 0;
                tableToolBoxNhanVien.ColumnStyles[2].Width = 0f;
                tableToolBoxKhoa.ColumnStyles[1].Width = 0;
                tableToolBoxKhoa.ColumnStyles[2].Width = 0f;
                tableToolBoxVaiTro.ColumnStyles[1].Width = 0;
                tableToolBoxVaiTro.ColumnStyles[2].Width = 0f;
            }
            if (!accountBUS.HasPermission(username, maCN, "edit"))
            {
                tableToolBoxNhanVien.ColumnStyles[3].Width = 0;
                tableToolBoxNhanVien.ColumnStyles[4].Width = 0f;
                tableToolBoxKhoa.ColumnStyles[3].Width = 0;
                tableToolBoxKhoa.ColumnStyles[4].Width = 0f;
                tableToolBoxVaiTro.ColumnStyles[3].Width = 0;
                tableToolBoxVaiTro.ColumnStyles[4].Width = 0f;
            }
            if (!accountBUS.HasPermission(username, maCN, "delete"))
            {
                tableToolBoxNhanVien.ColumnStyles[5].Width = 0;
                tableToolBoxNhanVien.ColumnStyles[6].Width = 0f;
                tableToolBoxKhoa.ColumnStyles[5].Width = 0;
                tableToolBoxKhoa.ColumnStyles[6].Width = 0f;
                tableToolBoxVaiTro.ColumnStyles[5].Width = 0;
                tableToolBoxVaiTro.ColumnStyles[6].Width = 0f;
            }
        }

        private bool CheckPermissionForXacNhan(bool isNewRecord)
        {
            string username = accountBUS.GetAccountByEmployeeId(employeeId).TenDangNhap;
            string action = isNewRecord ? "add" : "edit";

            if (!accountBUS.HasPermission(username, functionId, action))
            {
                string message = isNewRecord ? "thêm mới" : "sửa";
                MessageBox.Show($"Bạn không có quyền {message}!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void LoadEmployeeToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Nhân Viên", typeof(string));
            table.Columns.Add("Tên Nhân Viên", typeof(string));
            table.Columns.Add("Vai Trò", typeof(string));
            table.Columns.Add("Khoa", typeof(string));

            foreach (var employee in employeeBUS.GetAllEmployees())
                table.Rows.Add(employee.MaNV, employee.TenNV, roleBUS.GetRoleById(employee.VaiTro).TenVT, departmentBUS.GetDepartmentById(employee.MaKhoa).TenKhoa);

            tableEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableEmployee.DataSource = table;
            nhanVienPanel.Controls.Add(tableEmployee);
        }

        private void LoadDepartmentToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Khoa", typeof(string));
            table.Columns.Add("Tên Khoa", typeof(string));

            foreach (var department in departmentBUS.GetAllDepartment())
                table.Rows.Add(department.MaKhoa, department.TenKhoa);

            tableDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableDepartment.DataSource = table;
            khoaPanel.Controls.Add(tableDepartment);
        }

        private void LoadEmployeeOfDepartmentToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Tên Nhân viên", typeof(string));
            table.Columns.Add("Chức vụ", typeof(string));

            tableEmployeeOfDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableEmployeeOfDepartment.DataSource = table;
            nhanVienKhoaPanel.Controls.Add(tableEmployeeOfDepartment);
        }

        private void LoadRoleToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Vai Trò", typeof(string));
            table.Columns.Add("Tên Vai Trò", typeof(string));

            foreach (var role in roleBUS.GetAllRoles())
                table.Rows.Add(role.MaVT, role.TenVT);

            tableRole.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableRole.DataSource = table;
            vaiTroPanel.Controls.Add(tableRole);
        }
        private void comboBoxChucVuLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxChucVu.GetComboBox();
            if (cb.Items.Count == 0) 
            {
                cb.Items.Add("Trưởng khoa");
                cb.Items.Add("Phó khoa");
                cb.Items.Add("Điều trị");
                cb.Items.Add("Nội trú");
                cb.Items.Add("Thực tập");
            }
        }

        private void comboBoxVaiTroLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxVaiTro.GetComboBox();
            if (cb.DataSource == null)
            {
                cb.DataSource = roleBUS.GetAllRoles();
                cb.DisplayMember = "TenVT";
                cb.ValueMember = "MaVT";
                cb.SelectedIndex = -1;
            }
        }

        private void comboBoxKhoaLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxKhoa.GetComboBox();
            if (cb.DataSource == null)
            {
                cb.DataSource = departmentBUS.GetAllDepartment();
                cb.DisplayMember = "TenKhoa";  
                cb.ValueMember = "MaKhoa";     
                cb.SelectedIndex = -1;
            }
        }

        // sự kiện tabPageNhanVien ===================================================================================================================
        // sự kiện tabPageNhanVien ===================================================================================================================
        private void buttonHuyNhanVienClick(object sender, EventArgs e)
        {
            txtMaNhanVien.TextValue = employeeBUS.GetNextEmployeeId();
            txtTenNhanVien.TextValue = "";
            txtSoDienThoai.TextValue = "";
            comboBoxChucVu.GetComboBox().SelectedIndex = -1;
            comboBoxKhoa.GetComboBox().SelectedIndex = -1;
            comboBoxVaiTro.GetComboBox().SelectedIndex = -1;
            tableEmployee.ClearSelection();
        }

        private void buttonXacNhanNhanVienClick(object sender, EventArgs e)
        {
            bool isNewEmpolee = !employeeBUS.ExistsEmployeeId(txtMaNhanVien.TextValue.Trim());
            if (!CheckPermissionForXacNhan(isNewEmpolee))
            {
                return;
            }

            if (string.IsNullOrEmpty(txtTenNhanVien.TextValue) || string.IsNullOrEmpty(txtSoDienThoai.TextValue) || string.IsNullOrEmpty(comboBoxChucVu.TextValue) || string.IsNullOrEmpty(comboBoxKhoa.TextValue) || string.IsNullOrEmpty(comboBoxVaiTro.TextValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!");
                return;
            }

            if (!HM.Utils.Validators.IsName(txtTenNhanVien.TextValue.Trim()))
            {
                MessageBox.Show("Tên nhân viên không hợp lệ!");
                return;
            }

            if (!HM.Utils.Validators.IsValidPhone(txtSoDienThoai.TextValue.Trim()))
            {
                MessageBox.Show("Số điện thoại nhân viên không hợp lệ!");
                return;
            }

            EmployeeDTO employee = new EmployeeDTO()
            {
                MaNV = txtMaNhanVien.TextValue,
                TenNV = txtTenNhanVien.TextValue.Trim(),
                SdtNV = txtSoDienThoai.TextValue.Trim(),
                ChucVu = comboBoxChucVu.TextValue,
                VaiTro = comboBoxVaiTro.GetComboBox().SelectedValue?.ToString(),
                MaKhoa = comboBoxKhoa.GetComboBox().SelectedValue?.ToString(),
            };

            if (employee.ChucVu == "Trưởng khoa")
            {
                bool count = employeeBUS.CountHeadOfDepartment(employee.MaKhoa);

                if (!employeeBUS.ExistsEmployeeId(employee.MaNV))  
                {
                    if (count)
                    {
                        MessageBox.Show("Khoa này đã có Trưởng khoa. Không thể thêm mới!");
                        return;
                    }
                }
                else                                       
                {
                    var old = employeeBUS.GetEmployeeById(employee.MaNV);
                    bool isPromotingToHead = old.ChucVu != "Trưởng khoa";

                    if (isPromotingToHead && count)
                    {
                        MessageBox.Show("Khoa này đã có Trưởng khoa. Không thể cập nhật thành Trưởng khoa!");
                        return;
                    }
                }
            }

            if (!employeeBUS.ExistsEmployeeId(employee.MaNV))
            {
                employeeBUS.AddEmployee(employee);
                MessageBox.Show("Thêm nhân viên thành công!");
            }
            else
            {
                employeeBUS.UpdateEmployee(employee);
                MessageBox.Show("Cập nhật nhân viên thành công!");
            }
            LoadEmployeeToTable();
            buttonHuyNhanVienClick(null, null);
        }

        private void buttonThemNhanVienClick(object sender, EventArgs e)
        {
            txtMaNhanVien.TextValue = employeeBUS.GetNextEmployeeId();
            txtTenNhanVien.TextValue = "";
            txtSoDienThoai.TextValue = "";
            comboBoxChucVu.GetComboBox().SelectedIndex = -1;
            comboBoxKhoa.GetComboBox().SelectedIndex = -1;
            comboBoxVaiTro.GetComboBox().SelectedIndex = -1;
        }

        private void buttonSuaNhanVienClick(object sender, EventArgs e)
        {
            if (tableEmployee.SelectedRows.Count > 0)
            {
                var row = tableEmployee.SelectedRows[0];
                string maNV = row.Cells["Mã Nhân Viên"].Value?.ToString();

                var employee = employeeBUS.GetEmployeeById(maNV);
                if (employee != null)
                {
                    txtMaNhanVien.TextValue = employee.MaNV;
                    txtTenNhanVien.TextValue = employee.TenNV;
                    txtSoDienThoai.TextValue = employee.SdtNV;
                    comboBoxChucVu.GetComboBox().Text = employee.ChucVu;
                    comboBoxVaiTro.GetComboBox().SelectedValue = employee.VaiTro;
                    comboBoxKhoa.GetComboBox().SelectedValue = employee.MaKhoa;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy nhân viên với mã này!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần sửa!");
            }
        }

        private void buttonXoaNhanVienClick(object sender, EventArgs e)
        {
            if (tableEmployee.SelectedRows.Count > 0)
            {
                string maNV = tableEmployee.SelectedRows[0].Cells["Mã Nhân Viên"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa nhân viên này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    employeeBUS.DeleteEmployee(maNV);
                    MessageBox.Show("Xóa nhân viên thành công!");
                    LoadEmployeeToTable();
                    buttonHuyNhanVienClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa!");
            }
        }


        // sự kiện tabPageKhoa ============================================================================================================================================
        // sự kiện tabPageKhoa ============================================================================================================================================
        private void buttonHuyKhoaClick(object sender, EventArgs e)
        {
            txtMaKhoa.TextValue = departmentBUS.GetNextDepartmentId();
            txtTenKhoa.TextValue = "";
            LoadEmployeeOfDepartmentToTable();
        }

        private void buttonXacNhanKhoaClick(object sender, EventArgs e)
        {
            bool isNewDepartment = !departmentBUS.ExistsDepartmentId(txtMaKhoa.TextValue.Trim());
            if (!CheckPermissionForXacNhan(isNewDepartment))
            {
                return;
            }

            if (string.IsNullOrEmpty(txtTenKhoa.TextValue))
            {
                MessageBox.Show("Vui lòng nhập tên khoa!");
                return;
            }

            DepartmentDTO department = new DepartmentDTO()
            {
                MaKhoa = txtMaKhoa.TextValue,
                TenKhoa = txtTenKhoa.TextValue.Trim()
            };

            if (!departmentBUS.ExistsDepartmentId(department.MaKhoa))
            {
                departmentBUS.AddDepartment(department);
                MessageBox.Show("Thêm khoa thành công!");
            }
            else
            {
                departmentBUS.UpdateDepartment(department);
                MessageBox.Show("Cập nhật khoa thành công!");
            }
            comboBoxKhoa.GetComboBox().DataSource = null;
            comboBoxKhoaLoad(null, null);
            LoadDepartmentToTable();
            LoadEmployeeToTable();
            buttonHuyKhoaClick(null, null);
        }

        private void buttnThemKhoaClick(object sender, EventArgs e)
        {
            txtMaKhoa.TextValue = departmentBUS.GetNextDepartmentId();
            txtTenKhoa.TextValue = "";
            tableDepartment.ClearSelection();
            LoadEmployeeOfDepartmentToTable();
        }

        private void buttonSuaKhoaClick(object sender, EventArgs e)
        {
            if (tableDepartment.SelectedRows.Count > 0)
            {
                var row = tableDepartment.SelectedRows[0];
                string maKhoa = row.Cells["Mã Khoa"].Value?.ToString();

                var department = departmentBUS.GetDepartmentById(maKhoa);
                if (department != null)
                {
                    txtMaKhoa.TextValue = department.MaKhoa;
                    txtTenKhoa.TextValue = department.TenKhoa;

                    List<EmployeeDTO> employees = employeeBUS.GetAllEmployeesByDepartmentId(maKhoa);

                    nhanVienKhoaPanel.Controls.Clear();
                    tableEmployeeOfDepartment = new TableDataGridView();
                    tableEmployeeOfDepartment.Dock = DockStyle.Fill;
                    tableEmployeeOfDepartment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    tableEmployeeOfDepartment.ReadOnly = true;
                    tableEmployeeOfDepartment.AllowUserToAddRows = false;

                    DataTable dt = new DataTable();
                    dt.Columns.Add("Tên Nhân Viên");
                    dt.Columns.Add("Chức vụ");

                    foreach (var nv in employees)
                    {
                        dt.Rows.Add(nv.TenNV, nv.ChucVu);
                    }
                    tableEmployeeOfDepartment.DataSource = dt;
                    nhanVienKhoaPanel.Controls.Add(tableEmployeeOfDepartment);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy khoa với mã này!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khoa cần sửa!");
            }
        }

        private void buttonXoaKhoaClick(object sender, EventArgs e)
        {
            if (tableDepartment.SelectedRows.Count > 0)
            {
                string maKhoa = tableDepartment.SelectedRows[0].Cells["Mã Khoa"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa khoa này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    departmentBUS.DeleteDepartment(maKhoa);
                    MessageBox.Show("Xóa khoa thành công!");
                    LoadDepartmentToTable();
                    buttonHuyKhoaClick(null, null);
                    comboBoxKhoa.GetComboBox().DataSource = null;
                    comboBoxKhoaLoad(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khoa cần xóa!");
            }
        }

        // sự kiện tabPageVaiTro ============================================================================================================================================
        // sự kiện tabPageVaiTro ============================================================================================================================================
        private void buttonHuyVaiTroClick(object sender, EventArgs e)
        {
            txtMaVaiTro.TextValue = roleBUS.GetNextRoleId();
            txtTenVaiTro.TextValue = "";
        }

        private void buttonXacNhanVaiTroClick(object sender, EventArgs e)
        {
            bool isNewRole = !roleBUS.ExistsRoleId(txtMaVaiTro.TextValue.Trim());
            if (!CheckPermissionForXacNhan(isNewRole))
            {
                return;
            }

            if (string.IsNullOrEmpty(txtTenVaiTro.TextValue))
            {
                MessageBox.Show("Vui lòng nhập tên vai trò!");
                return;
            }

            RoleDTO role = new RoleDTO()
            {
                MaVT = txtMaVaiTro.TextValue,
                TenVT = txtTenVaiTro.TextValue.Trim(),
            };

            if (!roleBUS.ExistsRoleId(role.MaVT))
            {
                roleBUS.AddRole(role);
                MessageBox.Show("Thêm vai trò thành công!");
            }
            else
            {
                roleBUS.UpdateRole(role);
                MessageBox.Show("Cập nhật vai trò thành công!");
            }
            comboBoxVaiTro.GetComboBox().DataSource = null;
            comboBoxVaiTroLoad(null, null);
            LoadRoleToTable();
            LoadEmployeeToTable();
            buttonHuyVaiTroClick(null, null);
        }

        private void buttonThemVaiTroClick(object sender, EventArgs e)
        {
            txtMaVaiTro.TextValue = roleBUS.GetNextRoleId();
            txtTenVaiTro.TextValue = "";
        }

        private void buttonSuaVaiTroClick(object sender, EventArgs e)
        {
            if (tableRole.SelectedRows.Count > 0)
            {
                var row = tableRole.SelectedRows[0];
                string maVT = row.Cells["Mã Vai Trò"].Value?.ToString();

                var role = roleBUS.GetRoleById(maVT);
                if (role != null)
                {
                    txtMaVaiTro.TextValue = role.MaVT;
                    txtTenVaiTro.TextValue = role.TenVT;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy vai trò với mã này!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò cần sửa!");
            }
        }

        private void buttonXoaVaiTroClick(object sender, EventArgs e)
        {
            if (tableRole.SelectedRows.Count > 0)
            {
                string maVT = tableRole.SelectedRows[0].Cells["Mã Vai Trò"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa vai trò này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    roleBUS.DeleteRole(maVT);
                    MessageBox.Show("Xóa vai trò thành công!");
                    LoadRoleToTable();
                    buttonHuyVaiTroClick(null, null);
                    comboBoxVaiTro.GetComboBox().DataSource = null;
                    comboBoxVaiTroLoad(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn vai trò cần xóa!");
            }
        }



        // search Bar =======================================================================================================================================================
        private void searchBarNhanVienTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarNhanVien.Text.Trim();
            var employees = employeeBUS.SearchEmployee(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Mã Nhân Viên", typeof(string));
            table.Columns.Add("Tên Nhân Viên", typeof(string));
            table.Columns.Add("Vai Trò", typeof(string));
            table.Columns.Add("Khoa", typeof(string));

            foreach (var employee in employees)
            {
                table.Rows.Add(
                    employee.MaNV,
                    employee.TenNV,
                    employee.VaiTro,
                    departmentBUS.GetDepartmentById(employee.MaKhoa)?.TenKhoa
                );
            }

            tableEmployee.DataSource = table;
        }

        private void searchBarKhoaTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarKhoa.Text.Trim();
            var departments = departmentBUS.SearchDepartmentByName(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Mã Khoa", typeof(string));
            table.Columns.Add("Tên Khoa", typeof(string));

            foreach (var department in departments)
            {
                table.Rows.Add(department.MaKhoa, department.TenKhoa);
            }

            tableDepartment.DataSource = table;
        }

        private void searchBarVaiTroTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarVaiTro.Text.Trim();
            var roles = roleBUS.SearchRoleByName(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Mã Vai Trò", typeof(string));
            table.Columns.Add("Tên Vai Trò", typeof(string));

            foreach (var role in roles)
            {
                table.Rows.Add(role.MaVT, role.TenVT);
            }

            tableRole.DataSource = table;
        }
    }
}
