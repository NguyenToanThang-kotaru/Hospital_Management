using System;
using System.Windows.Forms;

namespace Hospital_Management
{
    public partial class Main_Layout : Form
    {
        private bool isCollapsed = false;

        public Main_Layout()
        {
            InitializeComponent();
        }

        private void btnToggle_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                // mở rộng
                panelMenu.Width += 10;
                if (panelMenu.Width >= 200)
                {
                    timer1.Stop();
                    isCollapsed = false;
                }
            }
            else
            {
                // thu gọn
                panelMenu.Width -= 10;
                if (panelMenu.Width <= 60)
                {
                    timer1.Stop();
                    isCollapsed = true;
                }
            }
        }
    }
}
