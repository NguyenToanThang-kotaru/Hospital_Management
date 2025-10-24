using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class PermissionDetailDAO
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

        public int DeletePermissionDetail(string maQuyen, string maHD, string maCN)
        {
            string sql = "DELETE FROM chitietquyen WHERE MaQuyen = @MaQuyen AND MaHD = @MaHD AND MaCN = @MaCN";
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

        public List<PermissionDetailDTO> GetPermissionDetailsById(string maQuyen)
        {
            List<PermissionDetailDTO> list = new List<PermissionDetailDTO>();
            string sql = "SELECT * FROM chitietquyen WHERE MaQuyen = @MaQuyen";
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

        public List<PermissionDetailDTO> SearchPermissionDetailByAction(string keyword)
        {
            List<PermissionDetailDTO> list = new List<PermissionDetailDTO>();
            string sql = "SELECT * FROM chitietquyen WHERE MaHD LIKE @keyword";
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
                MessageBox.Show("Lỗi khi tìm kiếm chi tiết quyền: " + ex.Message);
            }
            return list;
        }
    }
}
