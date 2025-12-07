using HM.BUS;
using HM.GUI.Pages.BenhNhan;
using HM.GUI.Pages.DichVu;
using HM.GUI.Pages.HoSoBenhAn;
using HM.GUI.Pages.NhanVien;
using HM.GUI.Pages.Statistics;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HM.GUI.Main_Layout
{
    public partial class Main_Layout : Form
    {
        private string employeeId;
        private AccountBUS accountBUS;

        private StatisticPage statPage;
        private BenhNhanPage benhNhanPage;
        private HoSoBenhAnPage hoSoBenhAnPage;
        private DichVuPage dichVuPage;
        private NhanVienPage nhanVienPage;
        private QuyenPage quyenPage;

        public Main_Layout(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            accountBUS = new AccountBUS();
            ApplyViewPermissions(accountBUS.GetAccountByEmployeeId(employeeId).TenDangNhap);

        }

        private void LoadPage(UserControl page)
        {
            MainContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            MainContent.Controls.Add(page);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn đăng xuất?",
                "Đăng xuất",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                this.Hide();    
                Login_Layout.Login_Layout login = new Login_Layout.Login_Layout();
                login.ShowDialog();
                
            }
        }

        private void ApplyViewPermissions(string username)
        {
            try
            {
                List<string> allowedMaCN = accountBUS.GetFunctionsWithViewPermission(username);
                if (allowedMaCN == null) allowedMaCN = new List<string>();

                var mapping = new Dictionary<string, Control>(StringComparer.OrdinalIgnoreCase)
                {
                    { "CN0001", DashboardItem },
                    { "CN0002", BenhNhanItem },
                    { "CN0003", HoSoBenhAnItem },
                    { "CN0004", DichVuItem },
                    { "CN0005", NhanVienItem },
                    { "CN0006", QuyenItem }
                };

                foreach (var kv in mapping)
                    kv.Value.Visible = false;

                foreach (string ma in allowedMaCN)
                    if (mapping.TryGetValue(ma, out Control ctl))
                        ctl.Visible = true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi" + ex.Message);
            }
        }

        private void Dashboard_Click(object sender, EventArgs e)
        {
            if (statPage == null)
                statPage = new StatisticPage(employeeId);
            LoadPage(statPage);
        }

        private void BenhNhanItem_Click(object sender, EventArgs e)
        {
            if (benhNhanPage == null)
                benhNhanPage = new BenhNhanPage(employeeId);
            hoSoBenhAnPage = null;
            LoadPage(benhNhanPage);
        }

        private void HoSoBenhAnItem_Click(object sender, EventArgs e)
        {
            if (hoSoBenhAnPage == null)
                hoSoBenhAnPage = new HoSoBenhAnPage(employeeId);
            LoadPage(hoSoBenhAnPage);
        }

        private void DichVu_Click(object sender, EventArgs e)
        {
            if (dichVuPage == null)
                dichVuPage = new DichVuPage(employeeId);
            LoadPage(dichVuPage);
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            if (nhanVienPage == null)
                nhanVienPage = new NhanVienPage(employeeId);
            LoadPage(nhanVienPage);
        }

        private void Quyen_Click(object sender, EventArgs e)
        {
            if (quyenPage == null)
                quyenPage = new QuyenPage(employeeId);
            LoadPage(quyenPage);
        }
    }

}
