using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class PermissionDAO
    {
        public int AddPermission(PermissionDTO obj)
        {
            string sql = "INSERT INTO quyen (MaQuyen, TenQuyen, TrangThaiXoa) " +
                         "VALUES (@MaQuyen, @TenQuyen, @TrangThaiXoa)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuyen", obj.MaQuyen);
                        cmd.Parameters.AddWithValue("@TenQuyen", obj.TenQuyen);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm quyền: " + ex.Message);
            }
            return 0;
        }

        public int UpdatePermission(PermissionDTO obj)
        {
            string sql = "UPDATE quyen SET TenQuyen = @TenQuyen, TrangThaiXoa = @TrangThaiXoa " +
                         "WHERE MaQuyen = @MaQuyen";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuyen", obj.MaQuyen);
                        cmd.Parameters.AddWithValue("@TenQuyen", obj.TenQuyen);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật quyền: " + ex.Message);
            }
            return 0;
        }

        public int DeletePermission(string maQuyen)
        {
            string sql = "UPDATE quyen SET TrangThaiXoa = 1 WHERE MaQuyen = @MaQuyen";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuyen", maQuyen);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa quyền: " + ex.Message);
            }
            return 0;
        }

        public List<PermissionDTO> GetAllPermissions()
        {
            List<PermissionDTO> list = new List<PermissionDTO>();
            string sql = "SELECT * FROM quyen WHERE TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new PermissionDTO
                                {
                                    MaQuyen = reader["MaQuyen"].ToString(),
                                    TenQuyen = reader["TenQuyen"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách quyền: " + ex.Message);
            }
            return list;
        }

        public PermissionDTO GetPermissionById(string maQuyen)
        {
            string sql = "SELECT * FROM quyen WHERE MaQuyen = @MaQuyen AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuyen", maQuyen);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new PermissionDTO
                                {
                                    MaQuyen = reader["MaQuyen"].ToString(),
                                    TenQuyen = reader["TenQuyen"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin quyền: " + ex.Message);
            }
            return null;
        }

        public string GetNextPermissionId()
        {
            string sql = "SELECT MaQuyen FROM quyen ORDER BY MaQuyen DESC LIMIT 1";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null)
                        {
                            string lastID = result.ToString();
                            int number = 0;

                            if (lastID.Length > 5 && int.TryParse(lastID.Substring(5), out number))
                            {
                                number++;
                                return "QUYEN" + number.ToString("D4");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã quyền tiếp theo: " + ex.Message);
            }
            return "QUYEN0001";
        }

        public List<PermissionDTO> SearchPermissionByName(string keyword)
        {
            List<PermissionDTO> list = new List<PermissionDTO>();
            string sql = "SELECT * FROM quyen WHERE TenQuyen LIKE @keyword AND TrangThaiXoa = 0";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", "%" + keyword + "%");

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new PermissionDTO
                                {
                                    MaQuyen = reader["MaQuyen"].ToString(),
                                    TenQuyen = reader["TenQuyen"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm quyền: " + ex.Message);
            }

            return list;
        }
    }
}
