using System;
using System.Windows.Forms;
using Hospital_Management.DAL;

namespace Hospital_Management.UI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Main_Layout form = new Main_Layout();
            form.WindowState = FormWindowState.Maximized;
            Application.Run(form); // hoặc Form1

            // Test connection
            // if (DatabaseConnection.TestConnection())
            // {
            //     MessageBox.Show("✅ Kết nối MySQL thành công!");
            // }
            // else
            // {
            //     MessageBox.Show("❌ Kết nối MySQL thất bại!");
            // }
        }
    }
}
