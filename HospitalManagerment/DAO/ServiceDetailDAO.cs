using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace HospitalManagerment.DAO
{
    internal class ServiceDetailDAO
    {
        public int AddServiceDetail(ServiceDetailDTO obj)
        {
            string sql = "INSERT INTO chitietdichvu (MaDV, MaBA) " +
                           "VALUES (@MaDV, @MaBA)";
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
                MessageBox.Show("Lỗi khi thêm chi tiết dịch vụ: " + ex.Message);
            }
            return 0;
        }
        public List<ServiceDetailDTO> GetAllServiceDetail()
        {
            List<ServiceDetailDTO> list = new List<ServiceDetailDTO>();
            string sql = "SELECT * FROM chitietdichvu";
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
                                list.Add(new ServiceDetailDTO
                                {
                                    MaDV = reader.GetString("MaDV"),
                                    MaBA = reader.GetString("MaBA")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết dịch vụ: " + ex.Message);
            }
            return list;
        }

        public ServiceDetailDTO GetServiceDetailByMedicalId(string maBA)
        {
            string sql = "SELECT * FROM chitietdichvu WHERE MaBA = @MaBA";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ServiceDetailDTO
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

        public int UpdateServiceDetail(ServiceDetailDTO obj)
        {
            string sql = "UPDATE chitietdichvu SET MaBA = @MaBa" +
                         "WHERE MaDV = @MaDV";
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

        public List<ServiceDetailDTO> SearchServiceDetailByName(string maDV)
        {
            List<ServiceDetailDTO> servicedetails = new List<ServiceDetailDTO>();
            string sql = "SELECT * FROM chitietdichvu WHERE MaDV LIKE CONCAT('%', @MaDV, '%')";
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
    }
}