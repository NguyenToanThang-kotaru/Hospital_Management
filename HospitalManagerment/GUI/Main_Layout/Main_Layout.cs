using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Pages.BenhNhan;
using HospitalManagerment.GUI.Pages.DichVu;
using HospitalManagerment.GUI.Pages.HoSoBenhAn;
using HospitalManagerment.GUI.Pages.NhanVien;
using HospitalManagerment.GUI.Pages.Statistics;
using System;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Main_Layout
{
    public partial class Main_Layout : Form
    {
        private string employeeId;

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
        }

        private void LoadPage(UserControl page)
        {
            MainContent.Controls.Clear();
            page.Dock = DockStyle.Fill;
            MainContent.Controls.Add(page);
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {

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
