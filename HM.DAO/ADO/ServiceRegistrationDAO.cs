using HM.DTO;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace HM.DAO.ADO
{
    public class ServiceRegistrationDAO
    {
        public int AddServiceRegistration(ServiceRegistrationDTO obj)
        {
            string sql = "INSERT INTO dangkydichvu (MaDKDV, SoCCCD, NgayGioTaoPhieu, TrangThaiDangKy, TongChiPhi, HinhThucThanhToan, MaNV, TrangThaiXoa) " +
                           "VALUES (@MaDKDV, @SoCCCD, @NgayGioTaoPhieu, @TrangThaiDangKy, @TongChiPhi, @HinhThucThanhToan, @MaNV, 0)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@NgayGioTaoPhieu", obj.NgayGioTaoPhieu);
                        cmd.Parameters.AddWithValue("@TrangThaiDangKy", obj.TrangThaiDangKy);
                        cmd.Parameters.AddWithValue("@TongChiPhi", obj.TongChiPhi);
                        cmd.Parameters.AddWithValue("@HinhThucThanhToan", obj.HinhThucThanhToan);
                        cmd.Parameters.AddWithValue("@MaNV", obj.MaNV);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm đăng ký dịch vụ: " + ex.Message);
            }
            return 0;
        }

        public int UpdateServiceRegistration(ServiceRegistrationDTO obj)
        {
            string sql = "UPDATE dangkydichvu SET SoCCCD = @SoCCCD, NgayGioTaoPhieu = @NgayGioTaoPhieu, TrangThaiDangKy = @TrangThaiDangKy, TongChiPhi = @TongChiPhi, HinhThucThanhToan = @HinhThucThanhToan, MaNV = @MaNV " +
                         "WHERE MaDKDV = @MaDKDV AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDKDV", obj.MaDKDV);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@NgayGioTaoPhieu", obj.NgayGioTaoPhieu);
                        cmd.Parameters.AddWithValue("@TrangThaiDangKy", obj.TrangThaiDangKy);
                        cmd.Parameters.AddWithValue("@TongChiPhi", obj.TongChiPhi);
                        cmd.Parameters.AddWithValue("@HinhThucThanhToan", obj.HinhThucThanhToan);
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
            List<ServiceRegistrationDTO> list = new List<ServiceRegistrationDTO>();
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
                                list.Add(new ServiceRegistrationDTO
                                {
                                    MaDKDV = reader["MaDKDV"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    NgayGioTaoPhieu = reader["NgayGioTaoPhieu"].ToString(),
                                    TrangThaiDangKy = reader["TrangThaiDangKy"].ToString(),
                                    TongChiPhi = reader["TongChiPhi"].ToString(),
                                    HinhThucThanhToan = reader["HinhThucThanhToan"].ToString(),
                                    MaNV = reader["MaNV"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách đăng ký dịch vụ: " + ex.Message);
            }
            return list;
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
                                return new ServiceRegistrationDTO
                                {
                                    MaDKDV = reader["MaDKDV"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    NgayGioTaoPhieu = reader["NgayGioTaoPhieu"].ToString(),
                                    TrangThaiDangKy = reader["TrangThaiDangKy"].ToString(),
                                    TongChiPhi = reader["TongChiPhi"].ToString(),
                                    HinhThucThanhToan = reader["HinhThucThanhToan"].ToString(),
                                    MaNV = reader["MaNV"].ToString()
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

                            if (lastID.StartsWith("DKDV") && lastID.Length > 4)
                            {
                                string numberPart = lastID.Substring(4);
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

        public List<ServiceRegistrationDTO> SearchServiceRegistration(string keyword)
        {
            List<ServiceRegistrationDTO> list = new List<ServiceRegistrationDTO>();
            string sql = @"SELECT * FROM dangkydichvu 
                   WHERE (MaDKDV LIKE CONCAT('%', @Keyword, '%') 
                          OR SoCCCD LIKE CONCAT('%', @Keyword, '%'))
                   AND TrangThaiXoa = 0
                   ORDER BY MaDKDV";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@Keyword", keyword);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ServiceRegistrationDTO
                                {
                                    MaDKDV = reader["MaDKDV"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    NgayGioTaoPhieu = reader["NgayGioTaoPhieu"].ToString(),
                                    TrangThaiDangKy = reader["TrangThaiDangKy"].ToString(),
                                    TongChiPhi = reader["TongChiPhi"].ToString(),
                                    HinhThucThanhToan = reader["HinhThucThanhToan"].ToString(),
                                    MaNV = reader["MaNV"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đăng ký dịch vụ: " + ex.Message);
            }
            return list;
        }
        public List<ServiceRegistrationDTO> GetAllServiceRegistrationsByPatientId(string soCCCD)
        {
            List<ServiceRegistrationDTO> list = new List<ServiceRegistrationDTO>();
            string sql = "SELECT * FROM dangkydichvu WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0 ORDER BY NgayGioTaoPhieu DESC";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new ServiceRegistrationDTO
                                {
                                    MaDKDV = reader["MaDKDV"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    NgayGioTaoPhieu = reader["NgayGioTaoPhieu"].ToString(),
                                    TrangThaiDangKy = reader["TrangThaiDangKy"].ToString(),
                                    TongChiPhi = reader["TongChiPhi"].ToString(),
                                    HinhThucThanhToan = reader["HinhThucThanhToan"].ToString(),
                                    MaNV = reader["MaNV"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách đăng ký dịch vụ theo bệnh nhân: {ex.Message}");
            }
            return list;
        }

        public bool UpdatePatientCCCD(string oldCCCD, string newCCCD)
        {
            string sql = "UPDATE dangkydichvu SET SoCCCD = @NewCCCD WHERE SoCCCD = @OldCCCD AND TrangThaiXoa = 0";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewCCCD", newCCCD);
                        cmd.Parameters.AddWithValue("@OldCCCD", oldCCCD);

                        conn.Open();
                        int rowsAffected = cmd.ExecuteNonQuery();

                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi cập nhật số CCCD trong đăng ký dịch vụ: {ex.Message}");
                return false;
            }
        }

        public bool HasServiceRecords(string soCCCD)
        {
            string sql = "SELECT COUNT(*) FROM dangkydichvu WHERE SoCCCD = @SoCCCD AND TrangThaiXoa = 0";

            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@SoCCCD", soCCCD);

                        conn.Open();
                        object result = cmd.ExecuteScalar();

                        if (result != null && result != DBNull.Value)
                        {
                            int count = Convert.ToInt32(result);
                            return count > 0;
                        }
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi kiểm tra đăng ký dịch vụ: {ex.Message}");
                return false;
            }
        }

        
    }
}