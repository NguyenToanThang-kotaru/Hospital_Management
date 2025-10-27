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
        private TableDataGridView tableEmployee;
        private TableDataGridView tableDepartment;
        private EmployeeBUS employeeBUS;
        private DepartmentBUS departmentBUS;

        public NhanVienPage()
        {
            InitializeComponent();
            tableEmployee = new TableDataGridView();
            tableDepartment = new TableDataGridView();
            employeeBUS = new EmployeeBUS();
            departmentBUS = new DepartmentBUS();
        }

        private void NhanVienPage_Load(object sender, EventArgs e)
        {
            //LoadEmployeeToTable();
            LoadDepartmentToTable();

            txtMaNhanVien.SetReadOnly(true);
            txtMaKhoa.SetReadOnly(true);
        }

        //private void LoadEmployeeToTable()
        //{
        //    tableEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
        //    tableEmployee.DataSource = ToDataTable(employeeBUS.GetAllEmployees());

        //    nhanVienPanel.Controls.Add(tableEmployee);
        //}

        private void LoadDepartmentToTable ()
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

        }

        // sự kiện tabPageNhanVien
        private void buttonHuyNhanVienClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanNhanVienClick(object sender, EventArgs e)
        {

        }

        private void buttonThemNhanVienClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaNhanVienClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaNhanVienClick(object sender, EventArgs e)
        {

        }

        // sự kiện tabPageKhoa
        private void buttonHuyKhoaClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanKhoaClick(object sender, EventArgs e)
        {

        }

        private void buttnThemKhoaClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaKhoaClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaKhoaClick(object sender, EventArgs e)
        {

        }

        //

    }
}
