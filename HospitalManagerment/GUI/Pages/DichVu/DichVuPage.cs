using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.DichVu
{
    public partial class DichVuPage : UserControl
    {
        private DataGridView table;
        private ServiceBUS serviceBUS;
        public DichVuPage()
        {
            InitializeComponent();
            serviceBUS = new ServiceBUS();
        }

        private void DichVuPage_Load(object sender, EventArgs e)
        {
            LoadServicesToGrid();
        }

        private void LoadServicesToGrid()
        {
            // Khởi tạo DataGridView
            table = new DataGridView
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

            table.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            dichVuPanel.Controls.Clear();
            dichVuPanel.Controls.Add(table);

            // Gọi BUS để lấy dữ liệu dưới dạng List
            List<ServiceDTO> list = serviceBUS.GetAllService();
            // Chuyển List sang DataTable rồi bind lên DataGridView
            DataTable accountsTable = ToDataTable(list);
            table.DataSource = accountsTable;
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
    }
}
