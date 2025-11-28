using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.NhanVien
{
    public partial class NhanVienPage : UserControl
    {
        private string employeeId; 
        private TableDataGridView tableEmployee;
        private TableDataGridView tableDepartment;
        private TableDataGridView tableEmployeeOfDepartment;
        private EmployeeBUS employeeBUS;
        private DepartmentBUS departmentBUS;

        public NhanVienPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableEmployee = new TableDataGridView();
            tableEmployeeOfDepartment = new TableDataGridView();
            tableDepartment = new TableDataGridView();
            employeeBUS = new EmployeeBUS();
            departmentBUS = new DepartmentBUS();
        }

        private void NhanVienPage_Load(object sender, EventArgs e)
        {
            LoadEmployeeToTable();
            LoadDepartmentToTable();
            LoadEmployeeOfDepartmentToTable();

            txtMaNhanVien.SetReadOnly(true);
            txtMaKhoa.SetReadOnly(true);
            txtMaNhanVien.TextValue = employeeBUS.GetNextEmployeeId();
            txtMaKhoa.TextValue = departmentBUS.GetNextDepartmentId();
        }

        private void LoadEmployeeToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Nhân Viên", typeof(string));
            table.Columns.Add("Tên Nhân Viên", typeof(string));
            table.Columns.Add("Vai Trò", typeof(string));
            table.Columns.Add("Khoa", typeof(string));

            foreach (var employee in employeeBUS.GetAllEmployees())
            {
                table.Rows.Add(employee.MaNV, employee.TenNV, employee.VaiTro, employee.MaKhoa);
            }
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
            {
                table.Rows.Add(department.MaKhoa, department.TenKhoa);
            }

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
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Quản trị viên");
                cb.Items.Add("Kế toán");
                cb.Items.Add("Quản lý");
                cb.Items.Add("Nhân viên quầy");
                cb.Items.Add("Bác sĩ");
                cb.Items.Add("Điều dưỡng");
                cb.Items.Add("Bảo vệ");
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

        // sự kiện tabPageNhanVien ======================================================================================
        // sự kiện tabPageNhanVien ======================================================================================
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
            if (string.IsNullOrEmpty(txtTenNhanVien.TextValue) || string.IsNullOrEmpty(txtSoDienThoai.TextValue) || string.IsNullOrEmpty(comboBoxChucVu.TextValue) || string.IsNullOrEmpty(comboBoxKhoa.TextValue) || string.IsNullOrEmpty(comboBoxVaiTro.TextValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin nhân viên!");
                return;
            }

            EmployeeDTO employee = new EmployeeDTO()
            {
                MaNV = txtMaNhanVien.TextValue,
                TenNV = txtTenNhanVien.TextValue.Trim(),
                SdtNV = txtSoDienThoai.TextValue.Trim(),
                ChucVu = comboBoxChucVu.TextValue,
                VaiTro = comboBoxVaiTro.TextValue,
                MaKhoa = comboBoxKhoa.GetComboBox().SelectedValue?.ToString(),
            };

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
                    comboBoxVaiTro.GetComboBox().Text = employee.VaiTro;
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


        // sự kiện tabPageKhoa
        private void buttonHuyKhoaClick(object sender, EventArgs e)
        {
            txtMaKhoa.TextValue = departmentBUS.GetNextDepartmentId();
            txtTenKhoa.TextValue = "";
        }


        private void buttonXacNhanKhoaClick(object sender, EventArgs e)
        {
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
            buttonHuyKhoaClick(null, null);
        }

        private void buttnThemKhoaClick(object sender, EventArgs e)
        {
            txtMaKhoa.TextValue = departmentBUS.GetNextDepartmentId();
            txtTenKhoa.TextValue = "";
            tableDepartment.ClearSelection();
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
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khoa cần xóa!");
            }
        }

    }
}
