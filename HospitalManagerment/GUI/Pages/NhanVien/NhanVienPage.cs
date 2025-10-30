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
        private EmployeeBUS employeeBUS;
        private DepartmentBUS departmentBUS;

        public NhanVienPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableEmployee = new TableDataGridView();
            tableDepartment = new TableDataGridView();
            employeeBUS = new EmployeeBUS();
            departmentBUS = new DepartmentBUS();
        }

        private void NhanVienPage_Load(object sender, EventArgs e)
        {
            LoadEmployeeToTable();
            LoadDepartmentToTable();

            txtMaNhanVien.SetReadOnly(true);
            txtMaKhoa.SetReadOnly(true);

            txtMaNhanVien.TextValue = employeeBUS.GetNextEmployeeId();
            txtMaKhoa.TextValue = departmentBUS.GetNextDepartmentId();
        }

        private void LoadEmployeeToTable()
        {
            tableEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableEmployee.DataSource = ToDataTable(employeeBUS.GetAllEmployees());
            nhanVienPanel.Controls.Add(tableEmployee);
        }

        private void LoadDepartmentToTable()
        {
            tableDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableDepartment.DataSource = ToDataTable(departmentBUS.GetAllDepartment());
            khoaPanel.Controls.Add(tableDepartment);
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

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;

                    string text = cb.Items[ev.Index].ToString();

                    Color textColor = Color.FromArgb(125,125,125); 
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
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

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;

                    string text = cb.Items[ev.Index].ToString();

                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
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

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;
                    string text = ((DepartmentDTO)cb.Items[ev.Index]).TenKhoa;
                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
            }
        }

        // sự kiện tabPageNhanVien
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
                string maNV = row.Cells["MaNV"].Value?.ToString();

                var employee = employeeBUS.GetEmployeeByID(maNV);
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
                string maNV = tableEmployee.SelectedRows[0].Cells["MaNV"].Value?.ToString();
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
            tableDepartment.ClearSelection();
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
                string maKhoa = row.Cells["MaKhoa"].Value?.ToString();

                var department = departmentBUS.GetDepartmentById(maKhoa);
                if (department != null)
                {
                    txtMaKhoa.TextValue = department.MaKhoa;
                    txtTenKhoa.TextValue = department.TenKhoa;
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
                string maKhoa = tableDepartment.SelectedRows[0].Cells["MaKhoa"].Value?.ToString();
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


        //

    }
}
