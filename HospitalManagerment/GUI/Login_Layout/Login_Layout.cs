using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using LayoutTest.GUIComponents;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Login_Layout
{
    public partial class Login_Layout : Form
    {
        private AccountBUS accountBUS = new AccountBUS();
        public Login_Layout()
        {
            InitializeComponent();
        }

        private void Login_Layout_Load(object sender, EventArgs e)
        {
            lblTxtTaiKhoan.TextValue = "admin"; 
            lblTxtMatKhau.TextValue = "123456"; 
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            AccountDTO account = new AccountDTO
            {
                TenDangNhap = lblTxtTaiKhoan.TextValue,
                MatKhau = lblTxtMatKhau.TextValue
            };
            string errMsg;
            bool loginSuccess = accountBUS.Login(account, out errMsg);
            if (loginSuccess)
            {
                this.Hide();
                Main_Layout.Main_Layout mainLayout = new Main_Layout.Main_Layout();
                mainLayout.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show(errMsg);
            }
        }
    }
}
