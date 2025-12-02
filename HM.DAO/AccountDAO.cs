using HM.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace HM.DAO
{
    public class AccountDAO
    {
        public bool Login(AccountDTO account, out string errorMessage)
        {
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                string query = "SELECT * FROM taikhoan WHERE TenDangNhap=@username AND MatKhau=@password";
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
            return false;
        }

        public List<AccountDTO> GetAllAccount()
        {
            List<AccountDTO> accounts = new List<AccountDTO>();

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM taikhoan WHERE TrangThaiXoa = 0";

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

        public List<AccountDTO> SearchAccountBy(string keyword)
        {
            List<AccountDTO> accounts = new List<AccountDTO>();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM taikhoan 
                                     WHERE (TenDangNhap LIKE @keyword OR MaNV LIKE @keyword) 
                                     AND TrangThaiXoa = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
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
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi tìm kiếm tài khoản: " + ex.Message);
            }
            return accounts;
        }

        public bool AddAccount(AccountDTO account)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();

                    string query = @"INSERT INTO taikhoan 
                            (TenDangNhap, MatKhau, MaQuyen, MaNV, TrangThaiXoa)
                             VALUES (@TenDangNhap, @MatKhau, @MaQuyen, @MaNV, @TrangThaiXoa)";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", account.TenDangNhap);
                        cmd.Parameters.AddWithValue("@MatKhau", account.MatKhau);
                        cmd.Parameters.AddWithValue("@MaQuyen", account.MaQuyen);
                        cmd.Parameters.AddWithValue("@MaNV", account.MaNV);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", "0");

                        int rows = cmd.ExecuteNonQuery();

                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm tài khoản: " + ex.Message);
                return false;
            }
        }

        public bool UpdateAccount(AccountDTO account)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE taikhoan 
                                     SET MatKhau = @MatKhau, MaQuyen = @MaQuyen, MaNV = @MaNV
                                     WHERE TenDangNhap = @TenDangNhap AND TrangThaiXoa = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MatKhau", account.MatKhau);
                        cmd.Parameters.AddWithValue("@MaQuyen", account.MaQuyen);
                        cmd.Parameters.AddWithValue("@MaNV", account.MaNV);
                        cmd.Parameters.AddWithValue("@TenDangNhap", account.TenDangNhap);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật tài khoản: " + ex.Message);
                return false;
            }
        }

        public bool DeleteAccount(string username)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"UPDATE taikhoan 
                                     SET TrangThaiXoa = 1
                                     WHERE TenDangNhap = @TenDangNhap AND TrangThaiXoa = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDangNhap", username);
                        int rows = cmd.ExecuteNonQuery();
                        return rows > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa tài khoản: " + ex.Message);
                return false;
            }
        }

        public AccountDTO GetAccountByUsername(string username)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM taikhoan WHERE TenDangNhap=@username AND TrangThaiXoa = 0";
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AccountDTO
                                {
                                    TenDangNhap = reader["TenDangNhap"].ToString(),
                                    MatKhau = reader["MatKhau"].ToString(),
                                    MaQuyen = reader["MaQuyen"].ToString(),
                                    MaNV = reader["MaNV"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tài khoản theo tên đăng nhập: " + ex.Message);
            }
            return null;
        }

        public AccountDTO GetAccountByEmployeeId(string employeeId)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT * FROM taikhoan WHERE MaNV = @MaNV AND TrangThaiXoa = 0";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaNV", employeeId);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new AccountDTO
                                {
                                    TenDangNhap = reader["TenDangNhap"].ToString(),
                                    MatKhau = reader["MatKhau"].ToString(),
                                    MaQuyen = reader["MaQuyen"].ToString(),
                                    MaNV = reader["MaNV"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi lấy tài khoản theo mã nhân viên: " + ex.Message);
            }
            return null;
        }

        public List<string> getFunctionsWithViewPermission(string username)
        {
            List<string> listMaCN = new List<string>();
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT ctq.MaCN
                             FROM taikhoan tk
                             JOIN quyen q ON tk.MaQuyen = q.MaQuyen
                             JOIN chitietquyen ctq ON q.MaQuyen = ctq.MaQuyen
                             WHERE ctq.TrangThaiKichHoat = 1 AND ctq.MaHD = 'view' AND tk.TenDangNhap = @username";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                listMaCN.Add(reader.GetString("MaCN"));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi: " + ex.Message);
            }
            return listMaCN;
        }


        public bool HasPermission(string username, string maCN, string maHD)
        {
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT 1
                             FROM taikhoan tk
                             JOIN quyen q ON tk.MaQuyen = q.MaQuyen
                             JOIN chitietquyen ctq ON q.MaQuyen = ctq.MaQuyen
                             WHERE ctq.TrangThaiKichHoat = 1
                               AND ctq.MaCN = @maCN
                               AND ctq.MaHD = @maHD
                               AND tk.TenDangNhap = @username
                             LIMIT 1";

                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@maCN", maCN);
                        cmd.Parameters.AddWithValue("@maHD", maHD);
                        cmd.Parameters.AddWithValue("@username", username);

                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra quyền: " + ex.Message);
            }

            return false;
        }


    }
}
