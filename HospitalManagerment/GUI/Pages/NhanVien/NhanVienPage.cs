using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.NhanVien
{
    public partial class NhanVienPage : UserControl
    {
        private DataGridView dgvEmployee;
        private DataGridView dgvDepartment;
        private EmployeeBUS employeeBUS;
        private DepartmentBUS departmentBUS;

        public NhanVienPage()
        {
            InitializeComponent();
            employeeBUS = new EmployeeBUS();
            departmentBUS = new DepartmentBUS();
        }

        private void NhanVienPage_Load(object sender, EventArgs e)
        {
            //LoadEmployeeToGrid();
            LoadDepartmentToGrid();
        }

        //private void LoadEmployeeToGrid()
        //{
        //    // Khởi tạo DataGridView
        //    dgvEmployee = new DataGridView
        //    {
        //        Dock = DockStyle.Fill,
        //        AutoGenerateColumns = true, // Để DataTable tự sinh cột
        //        BackgroundColor = Color.White,
        //        AllowUserToAddRows = false,
        //        AllowUserToDeleteRows = false,
        //        ReadOnly = true,
        //        BorderStyle = BorderStyle.None,
        //        SelectionMode = DataGridViewSelectionMode.FullRowSelect,
        //        RowHeadersVisible = false,

        //        // Tăng chiều cao header + canh giữa đẹp hơn
        //        EnableHeadersVisualStyles = false,
        //        ColumnHeadersDefaultCellStyle = {
        //            BackColor = Color.FromArgb(247, 255, 254),
        //            ForeColor = Consts.FontColorA,
        //            Font = new Font("Roboto", 10, FontStyle.Bold),
        //            Alignment = DataGridViewContentAlignment.MiddleCenter,
        //            Padding = new Padding(0, 5, 0, 5),
        //            SelectionBackColor = Color.FromArgb(247, 255, 254)
        //        },
        //        DefaultCellStyle = {
        //            Font = new Font("Roboto", 10),
        //            ForeColor = Color.Black,
        //            BackColor = Color.White,
        //            SelectionForeColor = Color.Black
        //        },
        //        GridColor = Color.FromArgb(230, 230, 230),
        //        CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
        //        ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
        //        AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
        //        AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(247, 255, 254), },
        //        AllowUserToResizeColumns = false,
        //        AllowUserToResizeRows = false,
        //        RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing,
        //        ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
        //        ColumnHeadersHeight = 45,
        //        RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
        //    };

        //    dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

        //    nhanVienPanel.Controls.Clear();
        //    nhanVienPanel.Controls.Add(dgvEmployee);

        //    // Gọi BUS để lấy dữ liệu dưới dạng List
        //    List<EmployeeDTO> list = employeeBUS.GetAllEmployees();
        //    // Chuyển List sang DataTable rồi bind lên DataGridView
        //    DataTable accountsTable = ToDataTable(list);
        //    dgvEmployee.DataSource = accountsTable;
        //}

        private void LoadDepartmentToGrid()
        {
            // Khởi tạo DataGridView
            dgvDepartment = new DataGridView
            {
                Dock = DockStyle.Fill,
                AutoGenerateColumns = true, // Để DataTable tự sinh cột
                BackgroundColor = Color.White,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false,

                // Tăng chiều cao header + canh giữa đẹp hơn
                EnableHeadersVisualStyles = false,
                ColumnHeadersDefaultCellStyle = {
                    BackColor = Color.FromArgb(247, 255, 254),
                    ForeColor = Consts.FontColorA,
                    Font = new Font("Roboto", 10, FontStyle.Bold),
                    Alignment = DataGridViewContentAlignment.MiddleCenter,
                    Padding = new Padding(0, 5, 0, 5),
                    SelectionBackColor = Color.FromArgb(247, 255, 254)
                },
                DefaultCellStyle = {
                    Font = new Font("Roboto", 10),
                    ForeColor = Color.Black,
                    BackColor = Color.White,
                    SelectionForeColor = Color.Black
                },
                GridColor = Color.FromArgb(230, 230, 230),
                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
                ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AlternatingRowsDefaultCellStyle = { BackColor = Color.FromArgb(247, 255, 254), },
                AllowUserToResizeColumns = false,
                AllowUserToResizeRows = false,
                RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing,
                ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing,
                ColumnHeadersHeight = 45,
                RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None,
            };

            dgvDepartment.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            khoaPanel.Controls.Clear();
            khoaPanel.Controls.Add(dgvDepartment);

            // Gọi BUS để lấy dữ liệu dưới dạng List
            List<DepartmentDTO> list = departmentBUS.GetAllDepartment();
            // Chuyển List sang DataTable rồi bind lên DataGridView
            DataTable permissionTable = ToDataTable(list);
            dgvDepartment.DataSource = permissionTable;
        }

        // Hàm chuyển List sang DataTable
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
        private void lblCbcChucVu_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbcChucVu.GetComboBox();
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

        private void lblCbcVaiTro_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbcVaiTro.GetComboBox();
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

        private void lblCbcKhoa_Paint(object sender, PaintEventArgs e)
        {
            ComboBox cb = lblCbcKhoa.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Khoa hành chính");       // Vai trò khác bác sĩ
                cb.Items.Add("Khoa khám bệnh (ngoại trú)"); // Nơi tiếp nhận ban đầu
                cb.Items.Add("Khoa nội");              
                cb.Items.Add("Khoa ngoại");           
                cb.Items.Add("Khoa nhi");              
                cb.Items.Add("Khoa sản");            
                cb.Items.Add("Khoa truyền nhiễm");    
                cb.Items.Add("Khoa cận lâm sàng");  

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

        
    }
}
