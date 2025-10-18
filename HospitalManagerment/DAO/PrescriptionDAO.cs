using HospitalManagerment.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagerment.DAO
{
    internal class PrescriptionDAO
    {
        public int AddPrescription(PrescriptionDTO obj)
        {
            string sql = "INSERT INTO donthuoc (MaBA, MaDP, SoLuongDP, DonViDP) " +
                           "VALUES (@MaBA, @MaDP, @SoLuongDP, @DonViDP)";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString.Connection))
            {
                try
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
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm đơn thuốc: " + ex.Message);
                }
                return 0;
            }
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

        public int DeletePrescription(string maBA)
        {
            string sql = "UPDATE donthuoc SET TrangThaiXoa = 1 WHERE MaBA = @MaBA";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa đơn thuốc: " + ex.Message);
            }
            return 0;
        }

        public List<PrescriptionDTO> GetAllPrescription()
        {
            List<PrescriptionDTO> prescriptions = new List<PrescriptionDTO>();
            string sql = "SELECT * FROM donthuoc WHERE TrangThaiXoa = 0";
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
                                PrescriptionDTO prescription = new PrescriptionDTO();
                                {
                                    cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                                    cmd.Parameters.AddWithValue("@MaDP", obj.MaDP);
                                    cmd.Parameters.AddWithValue("@SoLuongDP", obj.SoLuongDP);
                                    cmd.Parameters.AddWithValue("@DonViDP", obj.DonViDP);

                                }
                                ;
                                prescriptions.Add(prescription);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách đơn thuốc: " + ex.Message);
            }
            return prescriptions;
        }

        public PrescriptionDTO GetPrescriptionById(string maBA)
        {
            string sql = "SELECT * FROM donthuoc WHERE MaBA = @MaBA AND TrangThaiXoa = 0";
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
                                prescription = new PrescriptionDTO()
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

        public string GetNextPrescriptionId()
        {
            string sql = "SELECT MaBA FROM donthuoc ORDER BY MaBA DESC LIMIT 1";
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

                            if (lastID.StartsWith("BA") && lastID.Length > 3)
                            {
                                string numberPart = lastID.Substring(3);
                                if (int.TryParse(numberPart, out number))
                                {
                                    number++;
                                    return "BA" + number.ToString("D6");
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy mã bệnh án tiếp theo: " + ex.Message);
            }
            return "BA000001";
        }

        public List<PrescriptionDTO> SearchPrescriptionByName(string maBA)
        {
            List<PrescriptionDTO> prescriptions = new List<PrescriptionDTO>();
            string sql = "SELECT * FROM donthuoc WHERE MaBA LIKE CONCAT('%', @MaBA, '%') AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                PrescriptionDTO prescription = new PrescriptionDTO()
                                {
                                    MaBA = reader.GetString("MaBA"),
                                    MaDP = reader.GetString("MaDP"),
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
    }
}
