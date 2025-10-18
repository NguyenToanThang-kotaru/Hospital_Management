using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DAO
{
    internal class ServiceRegistrationDAO
    {
        public int AddServiceRegistration(ServiceRegistrationDTO obj)
        {
            string sql = "INSERT INTO dangkidichvu (MaDKDV, SoCCCD, NgayGioTaoPhieu, TrangThaiDangKy, TongChiPhi, HinhThucThanhToan, MaNV, TrangThaiXoa) " +
                           "VALUES (@MaDKDV, @SoCCCD, @NgayGioTaoPhieu, @TrangThaiDangKy, @TongChiPhi, @HinhThucThanhToan, @MaNV, 0)";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString.Connection))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@NgayGioTaoPhieu", obj.NgayGioTao);
                        cmd.Parameters.AddWithValue("@TrangThaiDangKy", obj.TrangThaiDK);
                        cmd.Parameters.AddWithValue("@TongChiPhi", obj.TongChiPhi);
                        cmd.Parameters.AddWithValue("@HinhThucThanhToan", obj.HinhThucTT);
                        cmd.Parameters.AddWithValue("@MaNV", obj.MaNV);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm đăng ký dịch vụ: " + ex.Message);
                }
                return 0;
            }
        }

        public int UpdateServiceRegistration(ServiceRegistrationDTO obj)
        {
            string sql = "UPDATE dangkydichvu SET SoCCCD = @SoCCCD, NgayGioTaoPhieu = @NgayGioTaoPhieu, TrangThaiDangKy = @TrangThaiDangKy, TongChiPhi = @TongChiPhi, HinhThucThanhToan = @HinhThucThanhToan, MaNV = @MaNV" +
                         "WHERE MaDKDV = @MaDKDV AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@NgayGioTaoPhieu", obj.NgayGioTao);
                        cmd.Parameters.AddWithValue("@TrangThaiDangKy", obj.TrangThaiDK);
                        cmd.Parameters.AddWithValue("@TongChiPhi", obj.TongChiPhi);
                        cmd.Parameters.AddWithValue("@HinhThucThanhToan", obj.HinhThucTT);
                        cmd.Parameters.AddWithValue("@MaNV", obj.MaNV);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đăng ký dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public int DeleteServiceRegistration(string maDKDV)
        {
            string sql = "UPDATE dangkydichvu SET TrangThaiXoa = 1 WHERE MaDKDV = @MaDKDV";
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
                MessageBox.Show("Lỗi khi xóa đăng ký dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public List<ServiceRegistrationDTO> GetAllServiceRegistration()
        {
            List<ServiceRegistrationDTO> serviceregistrations = new List<ServiceRegistrationDTO>();
            string sql = "SELECT * FROM dangkydichvu WHERE TrangThaiXoa = 0";
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
                                ServiceRegistrationDTO serviceregistration = new ServiceRegistrationDTO
                                {
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    SoCCCD = reader.GetString("SoCCCD"),
                                    NgayGioTao = reader.GetString("NgayGioTaoPhieu"),
                                    TrangThaiDK = reader.GetString("TrangThaiDangKy"),
                                    TongChiPhi = reader.GetString("TongChiPhi"),
                                    HinhThucTT = reader.GetString("HinhThucThanhToan"),
                                    MaNV = reader.GetString("MaNV")

                                };
                                serviceregistrations.Add(serviceregistration);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách đăng ký dịch vụ: " + ex.Message);
            }
            return serviceregistrations;
        }

        public ServiceRegistrationDTO GetServiceRegistrationById(string maDKDV)
        {
            string sql = "SELECT * FROM dangkydichvu WHERE MaDKDV = @MaDKDV AND TrangThaiXoa = 0";
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
                                serviceregistration = new ServiceRegistrationDTO
                                {
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    SoCCCD = reader.GetString("SoCCCD"),
                                    NgayGioTao = reader.GetString("NgayGioTaoPhieu"),
                                    TrangThaiDK = reader.GetString("TrangThaiDangKy"),
                                    TongChiPhi = reader.GetString("TongChiPhi"),
                                    HinhThucTT = reader.GetString("HinhThucThanhToan"),
                                    MaNV = reader.GetString("MaNV")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đăng ký dịch vụ: " + ex.Message);
            }
            return null;
        }

        public string GetNextServiceRegistrationId()
        {
            string sql = "SELECT MaDKDV FROM dangkydichvu ORDER BY MaDKDV DESC LIMIT 1";
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

        public List<ServiceRegistrationDTO> SearchServiceRegistrationByName(string maDKDV)
        {
            List<ServiceRegistrationDTO> serviceregistrations = new List<ServiceRegistrationDTO>();
            string sql = "SELECT * FROM dangkydichvu WHERE MaDKDV LIKE CONCAT('%', @MaDKDV, '%') AND TrangThaiXoa = 0";
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
                                ServiceRegistrationDTO serviceregistration = new ServiceRegistrationDTO
                                {
                                    MaDKDV = reader.GetString("MaDKDV"),
                                    SoCCCD = reader.GetString("SoCCCD"),
                                    NgayGioTao = reader.GetString("NgayGioTaoPhieu"),
                                    TrangThaiDK = reader.GetString("TrangThaiDangKy"),
                                    TongChiPhi = reader.GetString("TongChiPhi"),
                                    HinhThucTT = reader.GetString("HinhThucThanhToan"),
                                    MaNV = reader.GetString("MaNV")
                                };
                                serviceregistrations.Add(serviceregistration);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đăng ký dịch vụ: " + ex.Message);
            }
            return serviceregistrations;
        }
    }
}
