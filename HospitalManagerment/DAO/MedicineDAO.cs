using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class MedicineDAO
    {
        public int AddMedicine(MedicineDTO obj)
        {
            string query = "INSERT INTO duocpham (MaDP, TenDP, LoaiDP, TrangThaiXoa) " +
                           "VALUES (@MaDP, @TenDP, @LoaiDP, 0)";
            using (MySqlConnection conn = new MySqlConnection(ConnectionString.Connection))
            {
                try
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDP", obj.MaDP);
                        cmd.Parameters.AddWithValue("@TenDP", obj.TenDP);
                        cmd.Parameters.AddWithValue("@LoaiDP", obj.LoaiDP);

                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi thêm dược phẩm: " + ex.Message);
                }
                return 0;
            }
        }

        public int UpdateMedicine(MedicineDTO obj)
        {
            string sql = "UPDATE duocpham SET TenDP = @TenDP, LoaiDP = @LoaiDP " +
                         "WHERE MaDP = @MaDP AND TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@TenDP", obj.TenDP);
                        cmd.Parameters.AddWithValue("@LoaiDP", obj.LoaiDP);
                        cmd.Parameters.AddWithValue("@MaDP", obj.MaDP);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi cập nhật dược phẩm: " + ex.Message);
            }
            return 0;
        }

        public int DeleteMedicine(string maDP)
        {
            string sql = "UPDATE duocpham SET TrangThaiXoa = 1 WHERE MaDP = @MaDP";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        cmd.Parameters.AddWithValue("@MaDP", maDP);
                        conn.Open();
                        return cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dược phẩm: " + ex.Message);
            }
            return 0;
        }

        public List<MedicineDTO> GetAllMedicines()
        {
            List<MedicineDTO> medicines = new List<MedicineDTO>();
            string query = "SELECT MaDP, TenDP, LoaiDP FROM duocpham WHERE TrangThaiXoa = 0";
            try
            {
                using (MySqlConnection conn = DatabaseConnection.GetConnection())
                {
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        conn.Open();
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                MedicineDTO medicine = new MedicineDTO
                                {
                                    MaDP = reader.GetString("MaDP"),
                                    TenDP = reader.GetString("TenDP"),
                                    LoaiDP = reader.GetString("LoaiDP")
                                };
                                medicines.Add(medicine);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lấy danh sách dược phẩm: " + ex.Message);
            }
            return medicines;
        }
    }
}
