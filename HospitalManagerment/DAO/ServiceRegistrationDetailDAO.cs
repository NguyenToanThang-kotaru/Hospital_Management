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

        public List<ServiceRegistrationDetailDTO> SearchServiceRegistrationDetailByName(string maDKDV)
        {
            List<ServiceRegistrationDetailDTO> servicesregistrationdetails = new List<ServiceRegistrationDetailDTO>();
            string sql = "SELECT * FROM chitietdangky WHERE MaDKDV LIKE CONCAT('%', @MaDKDV, '%')";
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
                                ServiceRegistrationDetailDTO servicesregistrationdetail = new ServiceRegistrationDetailDTO
                                {
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    MaDV = reader.GetString("MaDV"),
                                };
                                servicesregistrationdetails.Add(servicesregistrationdetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm chi tiết đăng ký dịch vụ: " + ex.Message);
            }
            return servicesregistrationdetails;
        }

        public string GetNextServiceRegistrationDetailId()
        {
            string sql = "SELECT MaDKDV FROM chitietdangky ORDER BY MaDKDV DESC LIMIT 1";
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
                            string lastId = result.ToString();
                            int numericPart = int.Parse(lastId.Substring(2));
                            numericPart++;
                            return "DKDV" + numericPart.ToString("D6");
                        }
                        else
                        {
                            return "DKDV000001";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã đăng ký dịch vụ tiếp theo: " + ex.Message);
            }
            return "DV000001";
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