using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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

        public List<AccountDTO> GetAllAccount()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM tai_khoan WHERE TrangThaiXoa = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accounts.Add(new AccountDTO
                            {
                                TenDangNhap = reader["TenDangNhap"].ToString(),
                                MatKhau = reader["MatKhau"].ToString(),
                                MaQuyen = reader["MaQuyen"].ToString(),
                                MaNV = reader["MaNV"].ToString(),
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách tài khoản: " + ex.Message);
            }

            return accounts;
        }


    }
}
