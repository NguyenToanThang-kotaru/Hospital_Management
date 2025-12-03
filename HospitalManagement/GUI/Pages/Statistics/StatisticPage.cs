using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HM.GUI.Pages.Statistics
{
    public partial class StatisticPage : UserControl
    {
        private string employeeId;
        public StatisticPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
        }

        private void buttonThongKeClick(object sender, EventArgs e)
        {

        }
    }
}
