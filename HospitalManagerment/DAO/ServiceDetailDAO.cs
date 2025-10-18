using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
namespace HospitalManagerment.DAO
{
    internal class ServiceDetailDAO
    {
        public int AddServiceDetail(ServiceDetailDTO obj)
        {
            string sql = "INSERT INTO chitietdichvu (MaDV, MaBA, TrangThaiXoa) " +
                           "VALUES (@MaDV, @MaBA, 0)";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString.Connection))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm chi tiết dịch vụ: " + ex.Message);
                }
                return 0;
            }
        }

        public int UpdateServiceDetail(ServiceDetailDTO obj)
        {
            string sql = "UPDATE chitietdichvu SET MaBA = @MaBA" +
                         "WHERE MaDV = @MaDV AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chi tiết dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public int DeleteServiceDetail(string maDV)
        {
            string sql = "UPDATE chitietdichvu SET TrangThaiXoa = 1 WHERE MaDV = @MaDV";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", maDV);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public List<ServiceDetailDTO> GetAllServiceDetail()
        {
            List<ServiceDetailDTO> servicedetails = new List<ServiceDetailDTO>();
            string sql = "SELECT MaDV, MaBA FROM chitietdichvu WHERE TrangThaiXoa = 0";
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
                                ServiceDetailDTO servicedetail = new ServiceDetailDTO
                                {
                                    MaDV = reader.GetString("MaDV"),
                                    MaBA = reader.GetString("MaBA")
                                };
                                servicedetails.Add(servicedetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết dịch vụ: " + ex.Message);
            }
            return servicedetails;
        }

        public ServiceDetailDTO GetServiceDetailById(string maDV)
        {
            string sql = "SELECT * FROM chitietdichvu WHERE MaDV = @MaDV AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", maDV);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                servicedetail = new ServiceDetailDTO
                                {
                                    MaDV = reader.GetString("MaDV"),
                                    MaBA = reader.GetString("MaBA")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy chi tiết dịch vụ: " + ex.Message);
            }
            return null;
        }

        public string GetNextServiceDetailId()
        {
            string sql = "SELECT MaDV FROM chitietdichvu ORDER BY MaDV DESC LIMIT 1";
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

                            if (lastID.StartsWith("DV") && lastID.Length > 3)
                            {
                                string numberPart = lastID.Substring(3);
                                if (int.TryParse(numberPart, out number))
                                {
                                    number++;
                                    return "DV" + number.ToString("D6");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã chi tiết dịch vụ tiếp theo: " + ex.Message);
            }
            return "DV000001";
        }

        public List<ServiceDetailDTO> SearchServiceDetailByName(string maDV)
        {
            List<ServiceDetailDTO> servicedetails = new List<ServiceDetailDTO>();
            string sql = "SELECT * FROM chitietdichvu WHERE MaDV LIKE CONCAT('%', @MaDV, '%') AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", maDV);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceDetailDTO servicedetail = new ServiceDetailDTO
                                {
                                    MaDV = reader.GetString("MaDV"),
                                    MaBA = reader.GetString("MaBA")
                                };
                                servicedetails.Add(servicedetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm chi tiết dịch vụ: " + ex.Message);
            }
            return servicedetails;
        }
    }
}
