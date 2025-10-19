using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI;
using HospitalManagerment.GUI.Login_Layout;
using HospitalManagerment.GUI.Main_Layout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetProcessDPIAware();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // Kích hoạt DPI aware
            SetProcessDPIAware();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Layout());
            //Application.Run(new Main_Layout());
        }
    }
}

