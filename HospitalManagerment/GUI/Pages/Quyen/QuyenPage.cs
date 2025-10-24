using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.HoSoBenhAn
{
    public partial class QuyenPage : UserControl
    {
        private DataGridView dgvAccounts;
        private AccountBUS accountBUS;
        public QuyenPage()
        {
            InitializeComponent();
            accountBUS = new AccountBUS();
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void QuyenPage_Load(object sender, EventArgs e)
        {
            LoadAccountsToGrid();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tabPageTaiKhoan_Click(object sender, EventArgs e)
        {

        }

        private void roundedPanel6_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadAccountsToGrid()
        {
            // Khởi tạo DataGridView
            dgvAccounts = new DataGridView
            {
                Dock = DockStyle.Fill,                
                AutoGenerateColumns = false,
                BackgroundColor = Color.White,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                BorderStyle = BorderStyle.None,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                RowHeadersVisible = false
            };

            // --- Tùy chỉnh giao diện cơ bản ---
            dgvAccounts.EnableHeadersVisualStyles = false;
            dgvAccounts.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(45, 85, 155);
            dgvAccounts.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgvAccounts.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvAccounts.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvAccounts.DefaultCellStyle.ForeColor = Color.Black;
            dgvAccounts.DefaultCellStyle.BackColor = Color.White;
            dgvAccounts.DefaultCellStyle.SelectionBackColor = Color.FromArgb(200, 220, 255);
            dgvAccounts.DefaultCellStyle.SelectionForeColor = Color.Black;
            dgvAccounts.GridColor = Color.FromArgb(230, 230, 230);
            dgvAccounts.BorderStyle = BorderStyle.FixedSingle;
            dgvAccounts.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAccounts.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAccounts.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAccounts.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 245, 245);

            
            dgvAccounts.AllowUserToResizeColumns = false;
            dgvAccounts.AllowUserToResizeRows = false;
            dgvAccounts.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // ✅ Tăng chiều cao header
            dgvAccounts.ColumnHeadersHeight = 40;
            dgvAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            // Định nghĩa cột
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TenDangNhap",
                HeaderText = "Tên đăng nhập",
                Width = 200
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MatKhau",
                HeaderText = "Mật khẩu",
                Width = 200
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaQuyen",
                HeaderText = "Mã quyền",
                Width = 150
            });
            dgvAccounts.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "MaNV",
                HeaderText = "Mã nhân viên",
                Width = 150
            });

            // Gắn vào panel
            taiKhoanPanel.Controls.Clear();
            taiKhoanPanel.Controls.Add(dgvAccounts);

            // Gọi BUS để lấy dữ liệu
            List<AccountDTO> accounts = accountBUS.GetAllAccount();
            dgvAccounts.DataSource = accounts;
        }
    }
}
