using HM.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
namespace HM.DAO
{
    public class ServiceDetailDAO
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

        public List<ServiceDetailDTO> GetServiceDetailByMedicalId(string maBA)
        {
            List<ServiceDetailDTO> list = new List<ServiceDetailDTO>();
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
                            while (reader.Read())
                            {
                                list.Add(new ServiceDetailDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    MaDV = reader["MaDV"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách dịch vụ theo bệnh án: " + ex.Message);
            }
            return list;
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
    }
}