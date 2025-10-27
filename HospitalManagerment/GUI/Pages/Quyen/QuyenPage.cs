using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.HoSoBenhAn
{
    public partial class QuyenPage : UserControl
    {
        private DataGridView dgvAccounts;
        private DataGridView dgvPermission;
        private PermissionBUS permissionBUS;
        private AccountBUS accountBUS;
        public QuyenPage()
        {
            InitializeComponent();
            accountBUS = new AccountBUS();
            permissionBUS = new PermissionBUS();

        }

        private void QuyenPage_Load(object sender, EventArgs e)
        {
            LoadAccountsToGrid();
            LoadPermissionToGrid();
        }

        private void LoadAccountsToGrid()
        {
            // Khởi tạo DataGridView
            dgvAccounts = new DataGridView
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

            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            taiKhoanPanel.Controls.Clear();
            taiKhoanPanel.Controls.Add(dgvAccounts);

            // Gọi BUS để lấy dữ liệu dưới dạng List
            List<AccountDTO> list = accountBUS.GetAllAccount();
            // Chuyển List sang DataTable rồi bind lên DataGridView
            DataTable accountsTable = ToDataTable(list);
            dgvAccounts.DataSource = accountsTable;
        }

        private void LoadPermissionToGrid()
        {
            // Khởi tạo DataGridView
            dgvPermission = new DataGridView
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

            dgvPermission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            quyenPanel.Controls.Clear();
            quyenPanel.Controls.Add(dgvPermission);

            // Gọi BUS để lấy dữ liệu dưới dạng List
            List<PermissionDTO> list = permissionBUS.GetAllPermissions();
            // Chuyển List sang DataTable rồi bind lên DataGridView
            DataTable permissionTable = ToDataTable(list);
            dgvPermission.DataSource = permissionTable;
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
