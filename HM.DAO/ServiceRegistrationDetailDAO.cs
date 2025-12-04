using HM.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HM.DAO
{
    public class ServiceRegistrationDetailDAO
    {
        public int AddServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            string sql = "INSERT INTO chitietdangky (MaDKDV, MaDV) " +
                           "VALUES (@MaDKDV, @MaDV)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
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
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    MaDV = reader.GetString("MaDV")
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
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    MaDV = reader.GetString("MaDV")
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
            string sql = "UPDATE chitietdangky SET MaDV = @MaDV" +
                         "WHERE MaDKDV = @MaDKDV";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
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
    }
}