using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class ServiceRegistrationDetailDAO
    {
        public int AddServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            string sql = "INSERT INTO dangkidichvu (MaDKDV, MaDV) " +
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

        public ServiceRegistrationDetailDTO GetServiceRegistrationDetailByServiceRegistrationId(string maDKDV)
        {
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
                            if (reader.Read())
                            {
                                return new ServiceRegistrationDetailDTO
                                {
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    MaDV = reader.GetString("MaDV")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy chi tiết đăng ký theo đăng ký dịch vụ: " + ex.Message);
            }
            return null;
        }
    }
}