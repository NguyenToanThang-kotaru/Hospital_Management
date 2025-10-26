using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class ServiceDAO
    {
        public int AddService(ServiceDTO obj)
        {
            string sql = "INSERT INTO dichvu (MaDV, TenDV, GiaDV, DuocBHYTChiTra, TrangThaiXoa) " +
                           "VALUES (@MaDV, @TenDV, @GiaDV, @DuocBHYTChiTra, 0)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@TenDV", obj.TenDV);
                        cmd.Parameters.AddWithValue("@GiaDV", obj.GiaDV);
                        cmd.Parameters.AddWithValue("@DuocBHYTChiTra", obj.BHYTTra);

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

        public int UpdateService(ServiceDTO obj)
        {
            string sql = "UPDATE dichvu SET TenDV = @TenDV, GiaDV = @GiaDV, DuocBHYTChiTra = @DuocBHYTChiTra" +
                         "WHERE MaDV = @MaDV AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@TenDV", obj.TenDV);
                        cmd.Parameters.AddWithValue("@GiaDV", obj.GiaDV);
                        cmd.Parameters.AddWithValue("@DuocBHYTChiTra", obj.BHYTTra);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public int DeleteService(string maDV)
        {
            string sql = "UPDATE dichvu SET TrangThaiXoa = 1 WHERE MaDV = @MaDV";
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
                MessageBox.Show("Lỗi khi xóa dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public List<ServiceDTO> GetAllService()
        {
            List<ServiceDTO> services = new List<ServiceDTO>();
            string sql = "SELECT MaDV, TenDV, GiaDV, DuocBHYTChiTra FROM dichvu WHERE TrangThaiXoa = 0";
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
                                ServiceDTO service = new ServiceDTO
                                {
                                    MaDV = reader.GetString("MaDV"),
                                    TenDV = reader.GetString("TenDV"),
                                    GiaDV = reader.GetString("GiaDV"),
                                    BHYTTra = reader.GetString("BHYTTra")
                                };
                                services.Add(service);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách dịch vụ: " + ex.Message);
            }
            return services;
        }

        public ServiceDTO GetServiceById(string maDV)
        {
            string sql = "SELECT * FROM dichvu WHERE MaDV = @MaDV AND TrangThaiXoa = 0";
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
                                return new ServiceDTO
                                {
                                    MaDV = reader.GetString("MaDV"),
                                    GiaDV = reader.GetString("GiaDV"),
                                    BHYTTra = reader.GetString("BHYTTra")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy dịch vụ: " + ex.Message);
            }
            return null;
        }

        public string GetNextServiceId()
        {
            string sql = "SELECT MaDV FROM dichvu ORDER BY MaDV DESC LIMIT 1";
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
                            return "DV" + numericPart.ToString("D6");
                        }
                        else
                        {
                            return "DV000001";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã dịch vụ tiếp theo: " + ex.Message);
            }
            return "DV000001";
        }

        public List<ServiceDTO> SearchServiceByName(string maDV)
        {
            List<ServiceDTO> services = new List<ServiceDTO>();
            string sql = "SELECT * FROM dichvu WHERE MaDV LIKE CONCAT('%', @MaDV, '%') AND TrangThaiXoa = 0";
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
                            while (reader.Read())
                            {
                                ServiceDTO service = new ServiceDTO
                                {
                                    MaDV = reader.GetString("MaDV"),
                                    TenDV = reader.GetString("TenDV"),
                                    GiaDV = reader.GetString("GiaDV"),
                                    BHYTTra = reader.GetString("BHYTTra")
                                };
                                services.Add(service);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm dịch vụ: " + ex.Message);
            }
            return services;
        }
    }
}