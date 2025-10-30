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

        private void Dashboard_Click(object sender, EventArgs e)
        {
            LoadPage(new StatisticPage(employeeId));
        }

        private void BenhNhanItem_Click(object sender, EventArgs e)
        {
            LoadPage(new BenhNhanPage(employeeId));
        }

        private void HoSoBenhAnItem_Click(object sender, EventArgs e)
        {
            LoadPage(new HoSoBenhAnPage(employeeId));
        }

        private void DichVu_Click(object sender, EventArgs e)
        {
            LoadPage(new DichVuPage(employeeId));
        }

        private void NhanVien_Click(object sender, EventArgs e)
        {
            LoadPage(new NhanVienPage(employeeId));
        }

        private void Quyen_Click(object sender, EventArgs e)
        {
            LoadPage(new QuyenPage(employeeId));
        }
    }
}
