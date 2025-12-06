using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO
{
    public class PermissionDetailDAO
    {
        public int AddPermissionDetail(PermissionDetailDTO obj)
        {
            string sql = "INSERT INTO chitietquyen (MaQuyen, MaHD, MaCN, TrangThaiKichHoat) " +
                         "VALUES (@MaQuyen, @MaHD, @MaCN, @TrangThaiKichHoat)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuyen", obj.MaQuyen);
                        cmd.Parameters.AddWithValue("@MaHD", obj.MaHD);
                        cmd.Parameters.AddWithValue("@MaCN", obj.MaCN);
                        cmd.Parameters.AddWithValue("@TrangThaiKichHoat", obj.TrangThaiKichHoat);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết quyền: " + ex.Message);
            }
            return 0;
        }

        public int UpdatePermissionDetail(PermissionDetailDTO obj)
        {
            string sql = "UPDATE chitietquyen SET TrangThaiKichHoat = @TrangThaiKichHoat " +
                         "WHERE MaQuyen = @MaQuyen AND MaHD = @MaHD AND MaCN = @MaCN";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuyen", obj.MaQuyen);
                        cmd.Parameters.AddWithValue("@MaHD", obj.MaHD);
                        cmd.Parameters.AddWithValue("@MaCN", obj.MaCN);
                        cmd.Parameters.AddWithValue("@TrangThaiKichHoat", obj.TrangThaiKichHoat);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết quyền: " + ex.Message);
            }
            return 0;
        }

        public List<PermissionDetailDTO> GetAllPermissionDetails()
        {
            List<PermissionDetailDTO> list = new List<PermissionDetailDTO>();
            string sql = "SELECT * FROM chitietquyen";
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
                                list.Add(new PermissionDetailDTO
                                {
                                    MaQuyen = reader["MaQuyen"].ToString(),
                                    MaHD = reader["MaHD"].ToString(),
                                    MaCN = reader["MaCN"].ToString(),
                                    TrangThaiKichHoat = reader["TrangThaiKichHoat"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết quyền: " + ex.Message);
            }
            return list;
        }

        public List<PermissionDetailDTO> GetPermissionDetailsByPermissionId(string maQuyen)
        {
            List<PermissionDetailDTO> list = new List<PermissionDetailDTO>();
            string sql = "SELECT * FROM chitietquyen WHERE MaQuyen = @MaQuyen AND TrangThaiKichHoat = 1" ;
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
                            while (reader.Read())
                            {
                                list.Add(new PermissionDetailDTO
                                {
                                    MaQuyen = reader["MaQuyen"].ToString(),
                                    MaHD = reader["MaHD"].ToString(),
                                    MaCN = reader["MaCN"].ToString(),
                                    TrangThaiKichHoat = reader["TrangThaiKichHoat"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy chi tiết quyền theo mã: " + ex.Message);
            }
            return list;
        }

        public int ActivePermissionDetail(string maCN, string maQuyen, string maHD)
        {
            string sql = "UPDATE chitietquyen SET TrangThaiKichHoat = 1 WHERE MaCN = @MaCN AND MaQuyen = @MaQuyen AND MaHD = @MaHD";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCN", maCN);
                        cmd.Parameters.AddWithValue("@MaQuyen", maQuyen);
                        cmd.Parameters.AddWithValue("@MaHD", maHD);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kích hoạt chi tiết quyền: " + ex.Message);
                return 0;
            }
        }

        public int ExistsPermissionDetail(string maCN, string maQuyen, string maHD)
        {
            string sql = "SELECT COUNT(*) FROM chitietquyen WHERE MaCN = @MaCN AND MaQuyen = @MaQuyen AND MaHD = @MaHD";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaCN", maCN);
                        cmd.Parameters.AddWithValue("@MaQuyen", maQuyen);
                        cmd.Parameters.AddWithValue("@MaHD", maHD);

                        conn.Open();
                        return Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra tồn tại chi tiết quyền: " + ex.Message);
                return 0;
            }
        }

        public int DeletePermissionDetail(string maQuyen, string maHD, string maCN)
        {
            string sql = "UPDATE chitietquyen SET TrangThaiKichHoat = 0 WHERE MaQuyen = @MaQuyen AND MaHD = @MaHD AND MaCN = @MaCN";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaQuyen", maQuyen);
                        cmd.Parameters.AddWithValue("@MaHD", maHD);
                        cmd.Parameters.AddWithValue("@MaCN", maCN);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết quyền: " + ex.Message);
            }
            return 0;
        }

    }
}
