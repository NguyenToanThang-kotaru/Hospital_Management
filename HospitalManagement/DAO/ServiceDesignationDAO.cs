using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class ServiceDesignationDAO
    {
        public int AddServiceDesignation(ServiceDesignationDTO obj)
        {
            string sql = "INSERT INTO phieuchidinh (MaPCD, SoCCCD, MaNV, MaDV, NgayGioTaoPhieu, TrangThaiXoa) " +
                         "VALUES (@MaPCD, @SoCCCD, @MaNV, @MaDV, @NgayGioTaoPhieu, @TrangThaiXoa)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPCD", obj.MaPCD);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@MaNV", obj.MaNV);
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@NgayGioTaoPhieu", obj.NgayGioTaoPhieu);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm phiếu chỉ định: " + ex.Message);
            }
            return 0;
        }

        public int UpdateServiceDesignation(ServiceDesignationDTO obj)
        {
            string sql = "UPDATE phieuchidinh SET SoCCCD = @SoCCCD, MaNV = @MaNV, MaDV = @MaDV" +
                         "NgayGioTaoPhieu = @NgayGioTaoPhieu, TrangThaiXoa = @TrangThaiXoa " +
                         "WHERE MaPCD = @MaPCD";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPCD", obj.MaPCD);
                        cmd.Parameters.AddWithValue("@SoCCCD", obj.SoCCCD);
                        cmd.Parameters.AddWithValue("@MaNV", obj.MaNV);
                        cmd.Parameters.AddWithValue("@MaDV", obj.MaDV);
                        cmd.Parameters.AddWithValue("@NgayGioTaoPhieu", obj.NgayGioTaoPhieu);
                        cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật phiếu chỉ định: " + ex.Message);
            }
            return 0;
        }

        public int DeleteServiceDesignation(string maPCD)
        {
            string sql = "UPDATE phieuchidinh SET TrangThaiXoa = '1' WHERE MaPCD = @MaPCD";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPCD", maPCD);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa phiếu chỉ định: " + ex.Message);
            }
            return 0;
        }

        public List<ServiceDesignationDTO> GetAllServiceDesignation()
        {
            List<ServiceDesignationDTO> list = new List<ServiceDesignationDTO>();
            string sql = "SELECT * FROM phieuchidinh WHERE TrangThaiXoa = '0'";
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
                                list.Add(new ServiceDesignationDTO
                                {
                                    MaPCD = reader["MaPCD"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    MaNV = reader["MaNV"].ToString(),
                                    MaDV = reader["MaDV"].ToString(),
                                    NgayGioTaoPhieu = reader["NgayGioTaoPhieu"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách phiếu chỉ định: " + ex.Message);
            }
            return list;
        }

        public ServiceDesignationDTO GetServiceDesignationById(string maPCD)
        {
            string sql = "SELECT * FROM phieuchidinh WHERE MaPCD = @MaPCD AND TrangThaiXoa = '0'";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaPCD", maPCD);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new ServiceDesignationDTO
                                {
                                    MaPCD = reader["MaPCD"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    MaNV = reader["MaNV"].ToString(),
                                    MaDV = reader["MaDV"].ToString(),
                                    NgayGioTaoPhieu = reader["NgayGioTaoPhieu"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin phiếu chỉ định: " + ex.Message);
            }
            return null;
        }

        public string GetNextServiceDesignationId()
        {
            string sql = "SELECT MaPCD FROM phieuchidinh ORDER BY MaPCD DESC LIMIT 1";
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

                            if (lastID.StartsWith("PCD") && lastID.Length > 3)
                            {
                                string numberPart = lastID.Substring(3);
                                if (int.TryParse(numberPart, out number))
                                {
                                    number++;
                                    return "PCD" + number.ToString("D6");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã phiếu chỉ định tiếp theo: " + ex.Message);
            }
            return "PCD000001";
        }

        public List<ServiceDesignationDTO> SearchServiceDesignationByCustomer(string soCCCD)
        {
            List<ServiceDesignationDTO> list = new List<ServiceDesignationDTO>();
            string sql = "SELECT * FROM phieuchidinh WHERE SoCCCD LIKE CONCAT('%', @SoCCCD, '%') AND TrangThaiXoa = '0'";

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
                                list.Add(new ServiceDesignationDTO
                                {
                                    MaPCD = reader["MaPCD"].ToString(),
                                    SoCCCD = reader["SoCCCD"].ToString(),
                                    MaNV = reader["MaNV"].ToString(),
                                    MaDV = reader["MaDV"].ToString(),
                                    NgayGioTaoPhieu = reader["NgayGioTaoPhieu"].ToString(),
                                    TrangThaiXoa = reader["TrangThaiXoa"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm phiếu chỉ định: " + ex.Message);
            }
            return list;
        }

    }
}