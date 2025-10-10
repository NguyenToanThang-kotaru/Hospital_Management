using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HospitalManagerment.DAO
{
    internal class AccountDAO
    {
        public bool login(AccountDTO account, out String errorMessage)
        {
            bool result = false;
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM tai_khoan WHERE TenDangNhap=@username AND MatKhau=@password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", account.TenDangNhap);
                    cmd.Parameters.AddWithValue("@password", account.MatKhau); 
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            errorMessage = "Đăng nhập thành công!";
                            return true;
                            
                        }
                    }
                }
            }
            errorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return result;
        }

        public bool getAllAccount(out String errorMessage)
        {
            bool result = false;
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM tai_khoan WHERE TenDangNhap=@username AND MatKhau=@password";
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", account.TenDangNhap);
                    cmd.Parameters.AddWithValue("@password", account.MatKhau);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            errorMessage = "Đăng nhập thành công!";
                            return true;

                        }
                    }
                }
            }
            errorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return result;
        }
    }
}
