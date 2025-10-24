using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class DiagnoseDAO
    {
        public int AddDiagnose(DiagnoseDTO obj)
        {
            string sql = "INSERT INTO chandoan (MaBA, MaBenh, NgayChanDoan, KetQuaDieuTri) " +
                         "VALUES (@MaBA, @MaBenh, @NgayChanDoan, @KetQuaDieuTri)";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                        cmd.Parameters.AddWithValue("@MaBenh", obj.MaBenh);
                        cmd.Parameters.AddWithValue("@NgayChanDoan", obj.NgayChanDoan);
                        cmd.Parameters.AddWithValue("@KetQuaDieuTri", obj.KetQuaDieuTri);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm chẩn đoán: " + ex.Message);
            }
            return 0;
        }

        public int UpdateDiagnose(DiagnoseDTO obj)
        {
            string sql = "UPDATE chandoan SET NgayChanDoan = @NgayChanDoan, KetQuaDieuTri = @KetQuaDieuTri " +
                         "WHERE MaBA = @MaBA AND MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", obj.MaBA);
                        cmd.Parameters.AddWithValue("@MaBenh", obj.MaBenh);
                        cmd.Parameters.AddWithValue("@NgayChanDoan", obj.NgayChanDoan);
                        cmd.Parameters.AddWithValue("@KetQuaDieuTri", obj.KetQuaDieuTri);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật chẩn đoán: " + ex.Message);
            }
            return 0;
        }

        public int DeleteDiagnose(string maBA, string maBenh)
        {
            string sql = "DELETE FROM chandoan WHERE MaBA = @MaBA AND MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);
                        cmd.Parameters.AddWithValue("@MaBenh", maBenh);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa chẩn đoán: " + ex.Message);
            }
            return 0;
        }

        public List<DiagnoseDTO> GetAllDiagnose()
        {
            List<DiagnoseDTO> list = new List<DiagnoseDTO>();
            string sql = "SELECT * FROM chandoan";
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
                                list.Add(new DiagnoseDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    MaBenh = reader["MaBenh"].ToString(),
                                    NgayChanDoan = reader["NgayChanDoan"].ToString(),
                                    KetQuaDieuTri = reader["KetQuaDieuTri"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chẩn đoán: " + ex.Message);
            }
            return list;
        }

        public DiagnoseDTO GetDiagnoseById(string maBA, string maBenh)
        {
            string sql = "SELECT * FROM chandoan WHERE MaBA = @MaBA AND MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);
                        cmd.Parameters.AddWithValue("@MaBenh", maBenh);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new DiagnoseDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    MaBenh = reader["MaBenh"].ToString(),
                                    NgayChanDoan = reader["NgayChanDoan"].ToString(),
                                    KetQuaDieuTri = reader["KetQuaDieuTri"].ToString()
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy thông tin chẩn đoán: " + ex.Message);
            }
            return null;
        }

        public List<DiagnoseDTO> GetDiagnoseByMedicalId(string maBA)
        {
            List<DiagnoseDTO> list = new List<DiagnoseDTO>();
            string sql = "SELECT * FROM chandoan WHERE MaBA = @MaBA";
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
                                list.Add(new DiagnoseDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    MaBenh = reader["MaBenh"].ToString(),
                                    NgayChanDoan = reader["NgayChanDoan"].ToString(),
                                    KetQuaDieuTri = reader["KetQuaDieuTri"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chẩn đoán theo bệnh án: " + ex.Message);
            }
            return list;
        }

        public List<DiagnoseDTO> GetDiagnoseByDiseaseId(string maBenh)
        {
            List<DiagnoseDTO> list = new List<DiagnoseDTO>();
            string sql = "SELECT * FROM chandoan WHERE MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBenh", maBenh);

                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                list.Add(new DiagnoseDTO
                                {
                                    MaBA = reader["MaBA"].ToString(),
                                    MaBenh = reader["MaBenh"].ToString(),
                                    NgayChanDoan = reader["NgayChanDoan"].ToString(),
                                    KetQuaDieuTri = reader["KetQuaDieuTri"].ToString()
                                });
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách chẩn đoán theo bệnh: " + ex.Message);
            }
            return list;
        }

        public bool IsDiagnoseExists(string maBA, string maBenh)
        {
            string sql = "SELECT COUNT(*) FROM chandoan WHERE MaBA = @MaBA AND MaBenh = @MaBenh";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaBA", maBA);
                        cmd.Parameters.AddWithValue("@MaBenh", maBenh);

                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi kiểm tra chẩn đoán: " + ex.Message);
            }
            return false;
        }
    }
}