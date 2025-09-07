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
            // Test connection
            if (DatabaseConnection.TestConnection())
            {
                MessageBox.Show("✅ Kết nối MySQL thành công!");
            }
            else
            {
                MessageBox.Show("❌ Kết nối MySQL thất bại!");
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1()); // hoặc Form1
        }
    }
}
