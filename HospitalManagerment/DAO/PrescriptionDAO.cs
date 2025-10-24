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

        public PrescriptionDTO GetPrescriptionByMedicalId(string maBA)
        {
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
                            if (reader.Read())
                            {
                                return new PrescriptionDTO()
                                {
                                    MaBA = reader.GetString("MaBA"),
                                    MaDP = reader.GetString("MaDP"),
                                    SoLuongDP = reader.GetString("SoLuongDP"),
                                    DonViDP = reader.GetString("DonViDP")
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy đơn thuốc: " + ex.Message);
            }
            return null;
        }
    }
}