using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO.ADO
{
    public class DepartmentDAO
    {
        public int AddDepartment(DepartmentDTO obj)
        {
            string sql = "INSERT INTO khoa (MaKhoa, TenKhoa, SoLuong, TrangThaiXoa) " +
                         "VALUES (@MaKhoa, @TenKhoa, @SoLuong, @TrangThaiXoa)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", obj.MaKhoa);
                        cmd.Parameters.AddWithValue("@TenKhoa", obj.TenKhoa);
                        cmd.Parameters.AddWithValue("@SoLuong", obj.SoLuong);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm khoa: " + ex.Message);
            }
            return 0;
        }

        public int UpdateDepartment(DepartmentDTO obj)
        {
            string sql = "UPDATE khoa SET TenKhoa = @TenKhoa, SoLuong = @SoLuong, TrangThaiXoa = @TrangThaiXoa " +
                         "WHERE MaKhoa = @MaKhoa";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", obj.MaKhoa);
                        cmd.Parameters.AddWithValue("@TenKhoa", obj.TenKhoa);
                        cmd.Parameters.AddWithValue("@SoLuong", obj.SoLuong);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật khoa: " + ex.Message);
            }
            return 0;
        }

        public int DeleteDepartment(string maKhoa)
        {
            string sql = "UPDATE khoa SET TrangThaiXoa = '1' WHERE MaKhoa = @MaKhoa";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa khoa: " + ex.Message);
            }
            return 0;
        }

        public List<DepartmentDTO> GetAllDepartment()
        {
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            string sql = "SELECT * FROM khoa WHERE TrangThaiXoa = '0'";
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
                                list.Add(new DepartmentDTO
                                {
                                    MaKhoa = reader["MaKhoa"].ToString(),
                                    TenKhoa = reader["TenKhoa"].ToString(),
                                    SoLuong = reader["SoLuong"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách khoa: " + ex.Message);
            }
            return list;
        }

        public DepartmentDTO GetDepartmentById(string maKhoa)
        {
            string sql = "SELECT * FROM khoa WHERE MaKhoa = @MaKhoa AND TrangThaiXoa = '0'";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaKhoa", maKhoa);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DepartmentDTO
                                {
                                    MaKhoa = reader["MaKhoa"].ToString(),
                                    TenKhoa = reader["TenKhoa"].ToString(),
                                    SoLuong = reader["SoLuong"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin khoa: " + ex.Message);
            }
            return null;
        }

        public string GetNextDepartmentId()
        {
            string sql = "SELECT MaKhoa FROM khoa ORDER BY MaKhoa DESC LIMIT 1";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            string lastID = result.ToString();
                            int number = 0;

                            if (lastID.StartsWith("KHOA") && lastID.Length > 4)
                            {
                                string numberPart = lastID.Substring(4);
                                if (int.TryParse(numberPart, out number))
                                {
                                    number++;
                                    return "KHOA" + number.ToString("D4");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã khoa tiếp theo: " + ex.Message);
            }
            return "KHOA0001";
        }

        public List<DepartmentDTO> SearchDepartmentByName(string keyword)
        {
            List<DepartmentDTO> list = new List<DepartmentDTO>();
            string sql = "SELECT * FROM khoa WHERE TenKhoa LIKE CONCAT('%', @keyword, '%') AND TrangThaiXoa = '0'";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@keyword", keyword);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new DepartmentDTO
                                {
                                    MaKhoa = reader["MaKhoa"].ToString(),
                                    TenKhoa = reader["TenKhoa"].ToString(),
                                    SoLuong = reader["SoLuong"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm khoa: " + ex.Message);
            }
            return list;
        }

    }
}