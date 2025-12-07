using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO
{
    public class ServiceRegistrationDetailDAO
    {
        public int AddServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            string sql = "INSERT INTO chitietdangky (MaDKDV, MaDV, TienDV) " +
                           "VALUES (@MaDKDV, @MaDV, @TienDV)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@TienDV", obj.TienDV);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chi tiết đăng ký: " + ex.Message);
            }
            return 0;
        }

        public List<ServiceRegistrationDetailDTO> GetAllServiceRegistrationDetail()
        {
            List<ServiceRegistrationDetailDTO> list = new List<ServiceRegistrationDetailDTO>();
            string sql = "SELECT * FROM chitietdangky";
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
                                list.Add(new ServiceRegistrationDetailDTO
                                {
                                    MaDKDV = reader["MaDKDV"].ToString(),
                                    MaDV = reader["MaDV"].ToString(),
                                    TienDV = reader["TienDV"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết đăng ký: " + ex.Message);
            }
            return list;
        }

        public List<ServiceRegistrationDetailDTO> GetServiceRegistrationDetailByServiceRegistrationId(string maDKDV)
        {
            List<ServiceRegistrationDetailDTO> details = new List<ServiceRegistrationDetailDTO>();
            string sql = "SELECT * FROM chitietdangky WHERE MaDKDV = @MaDKDV";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", maDKDV);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                details.Add(new ServiceRegistrationDetailDTO
                                {
                                    MaDKDV = reader["MaDKDV"].ToString(),
                                    MaDV = reader["MaDV"].ToString(),
                                    TienDV = reader["TienDV"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết đăng ký dịch vụ: " + ex.Message);
            }
            return details;
        }

        public int UpdateServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            string sql = "UPDATE chitietdangky SET MaDV = @MaDV, TienDV = @TienDV " +
                         "WHERE MaDKDV = @MaDKDV";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@TienDV", obj.TienDV);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết đăng ký dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public int DeleteServiceRegistrationDetail(string maDKDV, string maDV)
        {
            string sql = "DELETE FROM chitietdangky WHERE MaDKDV = @MaDKDV AND MaDV = @MaDV";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", maDKDV);
                        cmd.Parameters.AddWithValue("@MaDV", maDV);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết đăng ký dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public bool DeleteAllServiceRegistrationDetailByRegistrationId(string maDKDV)
        {
            try
            {
                string sql = "DELETE FROM chitietdangky WHERE MaDKDV = @MaDKDV";
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", maDKDV);
                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();
                        return rowsAffected >= 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết đăng ký dịch vụ: " + ex.Message);
                return false;
            }
        }
    }
}