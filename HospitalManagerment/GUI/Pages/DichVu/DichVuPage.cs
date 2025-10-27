using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.DichVu
{
    public partial class DichVuPage : UserControl
    {
        private TableDataGridView tableService;        
        private TableDataGridView tableServiceDesignation;
        private ServiceBUS serviceBUS;
        private ServiceDesignationBUS serviceDesignationBUS;
        public DichVuPage()
        {
            InitializeComponent();
            tableService = new TableDataGridView();
            tableServiceDesignation = new TableDataGridView();
            serviceBUS = new ServiceBUS();
            serviceDesignationBUS = new ServiceDesignationBUS();
        }

        private void DichVuPage_Load(object sender, EventArgs e)
        {
            LoadServiceToTable();
            LoadServiceDesignationToTable();
        }

        private void LoadServiceToTable()
        {
            tableService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableService.DataSource = ToDataTable(serviceBUS.GetAllService());
            dichVuPanel.Controls.Add(tableService);
        }

        private void LoadServiceDesignationToTable()
        {
            tableServiceDesignation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableServiceDesignation.DataSource = ToDataTable(serviceDesignationBUS.GetAllServiceDesignation());
            chiDinhDichVuPanel.Controls.Add(tableServiceDesignation);
        }

        private DataTable ToDataTable<T>(List<T> data)
        {
            DataTable table = new DataTable();
            var properties = typeof(T).GetProperties();
            foreach (var prop in properties)
            {
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }
            foreach (var item in data)
            {
                var row = table.NewRow();
                foreach (var prop in properties)
                {
                    row[prop.Name] = prop.GetValue(item, null) ?? DBNull.Value;
                }
                table.Rows.Add(row);
            }
            return table;
        }

        // sự kiệm tabPageDichVu
        private void buttonHuyDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonThemDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaDichVuClick(object sender, EventArgs e)
        {

        }

        // sự kiệm tabPageChiDinhDichVu
        private void buttonHuyChiDinhDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanChiDinhDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonThemChiDinhDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaChiDinhDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaChiDinhDichVuClick(object sender, EventArgs e)
        {

        }
    }
}
