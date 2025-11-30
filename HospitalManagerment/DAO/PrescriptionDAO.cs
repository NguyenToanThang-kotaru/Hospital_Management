using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class PrescriptionDAO
    {
        public int AddPrescription(PrescriptionDTO obj)
        {
            string sql = "INSERT INTO donthuoc (MaBA, MaDP, SoLuongDP, DonViDP) " +
                           "VALUES (@MaBA, @MaDP, @SoLuongDP, @DonViDP)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                        cmd.Parameters.AddWithValue("@MaDP", obj.MaDP);
                        cmd.Parameters.AddWithValue("@SoLuongDP", obj.SoLuongDP);
                        cmd.Parameters.AddWithValue("@DonViDP", obj.DonViDP);

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
        public int UpdatePrescription(PrescriptionDTO obj)
        {
            string sql = "UPDATE donthuoc SET MaDP = @MaDP, SoLuongDP = @SoLuongDP, DonViDP = @DonViDP" +
                         "WHERE MaBA = @MaBA AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                        cmd.Parameters.AddWithValue("@MaDP", obj.MaDP);
                        cmd.Parameters.AddWithValue("@SoLuongDP", obj.SoLuongDP);
                        cmd.Parameters.AddWithValue("@DonViDP", obj.DonViDP);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật đơn thuốc: " + ex.Message);
            }
            return 0;
        }

        public List<PrescriptionDTO> GetAllPrescription()
        {
            List<PrescriptionDTO> list = new List<PrescriptionDTO>();
            string sql = "SELECT * FROM donthuoc";
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
                                list.Add(new PrescriptionDTO()
                                {
                                    MaBA = reader.GetString("MaBA"),
                                    MaDP = reader.GetString("MaDP"),
                                    SoLuongDP = reader.GetString("SoLuongDP"),
                                    DonViDP = reader.GetString("DonViDP")

                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách đơn thuốc: " + ex.Message);
            }
            return list;
        }

        public List<PrescriptionDTO> GetPrescriptionsByMedicalId(string maBA)
        {
            List<PrescriptionDTO> list = new List<PrescriptionDTO>();
            string sql = "SELECT * FROM donthuoc WHERE MaBA = @MaBA";

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
                                list.Add(new PrescriptionDTO
                                {
                                    MaBA = reader.GetString("MaBA"),
                                    MaDP = reader.GetString("MaDP"),
                                    SoLuongDP = reader.GetString("SoLuongDP"),
                                    DonViDP = reader.GetString("DonViDP")
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách đơn thuốc theo bệnh án: " + ex.Message);
            }
            return list;
        }

        public List<PrescriptionDTO> SearchPrescriptionByName(string maDP)
        {
            List<PrescriptionDTO> prescriptions = new List<PrescriptionDTO>();
            string sql = "SELECT * FROM donthuoc WHERE MaDP LIKE CONCAT('%', @MaDP, '%')";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDP", maDP);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PrescriptionDTO prescription = new PrescriptionDTO
                                {
                                    MaDP = reader.GetString("MaDP"),
                                    MaBA = reader.GetString("MaBA"),
                                    SoLuongDP = reader.GetString("SoLuongDP"),
                                    DonViDP = reader.GetString("DonViDP")
                                };
                                prescriptions.Add(prescription);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đơn thuốc: " + ex.Message);
            }
            return prescriptions;
        }

        public string GetNextPrescriptionId()
        {
            string sql = "SELECT MaDP FROM donthuoc ORDER BY MaDP DESC LIMIT 1";
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
                            return "DP" + numericPart.ToString("D6");
                        }
                        else
                        {
                            return "DP000001";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã đơn thuốc tiếp theo: " + ex.Message);
            }
            return "DP000001";
        }
    }
}