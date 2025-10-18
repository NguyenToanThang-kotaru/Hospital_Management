using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DAO
{
    internal class ServiceRegistrationDetailDAO
    {
        public int AddServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            string sql = "INSERT INTO dangkidichvu (MaDKDV, MaDV) " +
                           "VALUES (@MaDKDV, @MaDV)";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString.Connection))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@MaDV", obj.SoCCCD);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm chi tiết đăng ký: " + ex.Message);
                }
                return 0;
            }
        }

        public int UpdateServiceRegistrationDetail(ServiceRegistrationDetailDTO obj)
        {
            string sql = "UPDATE chitietdangky SET MaDV = @MaDV" +
                         "WHERE MaDKDV = @MaDKDV AND TrangThaiXoa = 0";
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
                MessageBox.Show("Lỗi khi cập nhật chi tiết đăng ký: " + ex.Message);
            }
            return 0;
        }

        public int DeleteServiceRegistrationDetail(string maDKDV)
        {
            string sql = "UPDATE chitietdangky SET TrangThaiXoa = 1 WHERE MaDKDV = @MaDKDV";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", maDKDV);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chi tiết đăng ký: " + ex.Message);
            }
            return 0;
        }

        public List<ServiceRegistrationDetailDTO> GetAllServiceRegistrationDetail()
        {
            List<ServiceRegistrationDetailDTO> serviceregistrationdetails = new List<ServiceRegistrationDetailDTO>();
            string sql = "SELECT * FROM chitietdangky WHERE TrangThaiXoa = 0";
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
                                ServiceRegistrationDetailDTO serviceregistrationdetail = new ServiceRegistrationDetailDTO
                                {
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    MaDV = reader.GetString("MaDV")

                                };
                                serviceregistrationdetails.Add(serviceregistrationdetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chi tiết đăng ký: " + ex.Message);
            }
            return serviceregistrationdetails;
        }

        public ServiceRegistrationDetailDTO GetServiceRegistrationDetailById(string maDKDV)
        {
            string sql = "SELECT * FROM chitietdangky WHERE MaDKDV = @MaDKDV AND TrangThaiXoa = 0";
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
                                serviceregistrationdetail = new ServiceRegistrationDetailDTO
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
                MessageBox.Show("Lỗi khi lấy chi tiết đăng ký: " + ex.Message);
            }
            return null;
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

                        if (result != null && result != DBNull.Value)
                        {
                            string lastID = result.ToString();
                            int number = 0;

                            if (lastID.StartsWith("DKDV") && lastID.Length > 3)
                            {
                                string numberPart = lastID.Substring(3);
                                if (int.TryParse(numberPart, out number))
                                {
                                    number++;
                                    return "DKDV" + number.ToString("D6");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã đăng ký dịch vụ tiếp theo: " + ex.Message);
            }
            return "DKDV000001";
        }

        public List<ServiceRegistrationDetailDTO> SearchServiceRegistrationDetailByName(string maDKDV)
        {
            List<ServiceRegistrationDetailDTO> serviceregistrationdetails = new List<ServiceRegistrationDetailDTO>();
            string sql = "SELECT * FROM chitietdangky WHERE MaDKDV LIKE CONCAT('%', @MaDKDV, '%') AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", maDV);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ServiceRegistrationDetailDTO serviceregistrationdetail = new ServiceRegistrationDetailDTO
                                {
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    MaDV = reader.GetString("MaDV")
                                };
                                serviceregistrationdetails.Add(serviceregistrationdetail);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm chi tiết đăng ký: " + ex.Message);
            }
            return serviceregistrationdetails;
        }
    }
}
