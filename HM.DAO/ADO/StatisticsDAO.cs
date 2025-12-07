using HM.DTO;
using System.Data.SqlClient;
using System.Collections.Generic;
using MySql.Data.MySqlClient;

namespace HM.DAO.ADO
{
    public class StatisticDAO
    {
        public List<StatisticDTO> GetServiceStatistics(string fromDate, string toDate)
        {
            List<StatisticDTO> statistics = new List<StatisticDTO>();
            string query = @"
                SELECT
                    dv.TenDV,
                    COUNT(ctdk.MaDV) AS SoLuongDichVu,
                    SUM(ctdk.TienDV) AS TongTien
                FROM ChiTietDangKy ctdk
                JOIN DangKyDichVu dk ON ctdk.MaDKDV = dk.MaDKDV
                JOIN dichvu dv ON dv.MaDV= ctdk.MaDV 
                WHERE dk.NgayGioTaoPhieu BETWEEN @from AND @to 
                AND dk.TrangThaiXoa = '0'
                GROUP BY dv.TenDV;
            ";
            using (MySqlConnection conn = DatabaseConnection.GetConnection())
            {
                DatabaseConnection.Open(conn);
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@from", fromDate);
                    cmd.Parameters.AddWithValue("@to", toDate);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tenDV = reader["TenDV"].ToString();
                            string soLan = reader["SoLuongDichVu"].ToString();
                            string tongTien = reader["TongTien"].ToString();
                            StatisticDTO statistic = new StatisticDTO(tenDV, soLan, tongTien);
                            statistics.Add(statistic);
                        }
                    }
                }
                DatabaseConnection.Close(conn);
            }
            return statistics;
        }
    }
}
