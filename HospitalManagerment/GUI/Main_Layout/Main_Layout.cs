using System;
using System.Windows.Forms;
using HospitalManagerment.GUI.Pages.Statistics;
using HospitalManagerment.GUI.Pages.BenhNhan;
using HospitalManagerment.GUI.Pages.DichVu;
using HospitalManagerment.GUI.Pages.HoSoBenhAn;
using HospitalManagerment.GUI.Pages.NhanVien;
using HospitalManagerment.GUI.Pages.BacSi;

namespace HospitalManagerment.GUI.Main_Layout
{
    public partial class Main_Layout : Form
    {
        public Main_Layout()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            LoadPage(new StatisticPage());
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SideBar_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainContent_Paint(object sender, PaintEventArgs e)
        {

        }
        private void LoadPage(UserControl page)
        {
            MainContent.Controls.Clear();      // Xóa nội dung cũ
            page.Dock = DockStyle.Fill;             // Cho nội dung lấp đầy panel
            MainContent.Controls.Add(page);    // Thêm trang mới vào
        }

        //private void LoadSidebar()
        //{
        //    ChucNangDAO dao = new ChucNangDAO();
        //    DataTable dt = dao.GetAll();

        //    // Xóa các control cũ nếu có
        //    SideBar.Controls.Clear();

        //    int y = 10; // vị trí bắt đầu

        //    foreach (DataRow row in dt.Rows)
        //    {
        //        Button btn = new Button();
        //        btn.Text = row["TenChucNang"].ToString();
        //        btn.Tag = row["FormLienKet"].ToString(); // gắn tên form hoặc id
        //        btn.Size = new Size(SideBar.Width - 20, 40);
        //        btn.Location = new Point(10, y);
        //        btn.BackColor = Color.LightSteelBlue;
        //        btn.FlatStyle = FlatStyle.Flat;
        //        btn.Font = new Font("Segoe UI", 10, FontStyle.Bold);
        //        btn.TextAlign = ContentAlignment.MiddleLeft;
        //        btn.Click += SidebarButton_Click;

        //        SideBar.Controls.Add(btn);
        //        y += 45; // cách giữa các nút
        //    }
        //}

        private void BenhNhan_Click(object sender, EventArgs e)
        {
            LoadPage(new BenhNhanPage());
        }

        private void DichVuLB_Click(object sender, EventArgs e)
        {
            LoadPage(new DichVuPage());
        }

        private void HoSoBenhAnLB_Click(object sender, EventArgs e)
        {
            LoadPage(new HoSoBenhAnPage());
        }

        private void NhanVienLB_Click(object sender, EventArgs e)
        {
            LoadPage(new NhanVienPage());
        }

        private void QuyenLB_Click(object sender, EventArgs e)
        {
            LoadPage(new QuyenPage());
        }

        private void BacSi_LB(object sender, EventArgs e)
        {
            LoadPage(new BacSiPage());
        }

        private void sidebarItem1_Click(object sender, EventArgs e)
        {

        }

        private void sidebarItem1_Click_1(object sender, EventArgs e)
        {

        }

        private void sidebarItem4_Click(object sender, EventArgs e)
        {

        }

        private void sidebarItem1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
