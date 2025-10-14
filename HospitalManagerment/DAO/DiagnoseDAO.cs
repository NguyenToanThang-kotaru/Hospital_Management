using HospitalManagerment.DTO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalManagerment.DAO
{
    internal class DiagnoseDAO
    {
        //public int AddDiagnose(DiagnoseDTO obj)
        //{
        //    string sql = "INSERT INTO benh (MaBA, MABenh, MoTaBenh, TrangThaiXoa) " +
        //                 "VALUES (@MaBenh, @TenBenh, @MoTaBenh, @TrangThaiXoa)";
        //    //try
        //    //{
        //    //    using (MySqlConnection conn = DatabaseConnection.GetConnection())
        //    //    {
        //    //        using (MySqlCommand cmd = new MySqlCommand(sql, conn))
        //    //        {
        //    //            cmd.Parameters.AddWithValue("@MaBenh", obj.MaBenh);
        //    //            cmd.Parameters.AddWithValue("@TenBenh", obj.TenBenh);
        //    //            cmd.Parameters.AddWithValue("@MoTaBenh", obj.MoTaBenh);
        //    //            cmd.Parameters.AddWithValue("@TrangThaiXoa", obj.TrangThaiXoa);

        //    //            conn.Open();
        //    //            return cmd.ExecuteNonQuery();
        //    //        }
        //    //    }
        //    //}
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Lỗi khi thêm bệnh: " + ex.Message);
        //    }
        //    return 0;
        //}
    }
}
