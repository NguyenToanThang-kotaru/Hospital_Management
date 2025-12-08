using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using HM.GUI.Component.TableDataGridView;
using HM.DTO;
using HM.BUS;
using HM.Utils;

namespace HM.GUI.Pages.Statistics
{
    public partial class StatisticPage : UserControl
    {
        private TableDataGridView tableStatistics;
        private StatisticsBUS statisticsBUS;
        private decimal totalNum;
        private string employeeId;

        public StatisticPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableStatistics = new TableDataGridView();
        }
        private void StatitcPage_Load(object sender, EventArgs e)
        {
            LoadStatisticToTable();
        }
        
        private void LoadStatisticToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Số thứ tự", typeof(String));
            table.Columns.Add("Tên dịch vụ", typeof(String));
            table.Columns.Add("Số lần sử dụng", typeof(String));
            table.Columns.Add("Tổng tiền", typeof(String));

            tableStatistics.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableStatistics.DataSource = table;
            thongKePanel.Controls.Add(tableStatistics);
        }
        private void AddStatisticRow(string stt, string tenDichVu, string soLuong, string tongTien)
        {
            DataTable table = (DataTable)tableStatistics.DataSource;
            table.Rows.Add(stt, tenDichVu, soLuong, tongTien);
        }

        private void buttonThongKe_Click(object sender, EventArgs e)
        {
            statisticsBUS = new StatisticsBUS();

            string dateStarStr = fromDate.Value.ToString("dd-MM-yyyy");
            string dateEndStr = toDate.Value.ToString("dd-MM-yyyy");
            List<StatisticDTO> statistics = statisticsBUS.GetServiceStatistics(dateStarStr,dateEndStr);
            if (statistics != null)
            {
                // Xóa dữ liệu cũ trong bảng
                DataTable table = (DataTable)tableStatistics.DataSource;
                table.Rows.Clear();
                foreach (StatisticDTO stat in statistics)
                {
                    AddStatisticRow(
                        (table.Rows.Count + 1).ToString(),
                        stat.TenDV,
                        stat.SoLan,
                        stat.TongTien);
                    totalNum += decimal.Parse(stat.TongTien);
                }
                txtTongTien.Text = Helpers.MoneyFormater(totalNum); 

            }
        }
    }
}
