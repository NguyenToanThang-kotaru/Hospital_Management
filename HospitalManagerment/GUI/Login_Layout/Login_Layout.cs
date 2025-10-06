using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HospitalManagerment.BUS;
using HospitalManagerment.DTO;

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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lableTextBox1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lableTextBox2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void lableTextBox1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountDTO account = new AccountDTO
            {
                TenDangNhap = lableTextBox1.TextValue,
                MatKhau = lableTextBox2.TextValue
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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
