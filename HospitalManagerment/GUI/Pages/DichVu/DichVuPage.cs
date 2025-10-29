using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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

            txtMaDichVu.SetReadOnly(true);
            txtMaChiDinhDichVu.SetReadOnly(true);
            txtTenBenhNhan.SetReadOnly(true);

            txtMaDichVu.TextValue = serviceBUS.GetNextServiceId();
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

        private void comboBoxBaoHiemChiTraLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxBaoHiemChiTra.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Có");
                cb.Items.Add("Không");

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;

                    string text = cb.Items[ev.Index].ToString();
                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
            }
        }

        // sự kiệm tabPageDichVu
        private void buttonHuyDichVuClick(object sender, EventArgs e)
        {
            txtMaDichVu.TextValue = serviceBUS.GetNextServiceId();
            txtTenDichVu.TextValue = "";
            txtGiaDichVu.TextValue = "";
            comboBoxBaoHiemChiTra.TextValue = "";
            tableService.ClearSelection();
        }

        private void buttonXacNhanDichVuClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDichVu.TextValue) || string.IsNullOrEmpty(txtGiaDichVu.TextValue) || string.IsNullOrEmpty(comboBoxBaoHiemChiTra.TextValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin dịch vụ!");
                return;
            }

            ServiceDTO service = new ServiceDTO()
            {
                MaDV = txtMaDichVu.TextValue,
                TenDV = txtTenDichVu.TextValue,
                GiaDV = txtGiaDichVu.TextValue,
                BHYTTra = comboBoxBaoHiemChiTra.TextValue == "Có" ? "1" : "Không"
            };

            if (!serviceBUS.ExistsServiceId(service.MaDV))
            {
                serviceBUS.AddService(service);
                MessageBox.Show("Thêm dịch vụ thành công!");
            }
            else
            {
                serviceBUS.UpdateService(service);
                MessageBox.Show("Cập nhật dịch vụ thành công!");
            }
            LoadServiceToTable();
            buttonHuyDichVuClick(null, null);
        }


        private void buttonThemDichVuClick(object sender, EventArgs e)
        {
            txtMaDichVu.TextValue = serviceBUS.GetNextServiceId();
            txtTenDichVu.TextValue = "";
            txtGiaDichVu.TextValue = "";
            comboBoxBaoHiemChiTra.TextValue = "";
            txtTenDichVu.Focus();
        }

        private void buttonSuaDichVuClick(object sender, EventArgs e)
        {
            if (tableService.SelectedRows.Count > 0)
            {
                var row = tableService.SelectedRows[0];
                txtMaDichVu.TextValue = row.Cells["MaDV"].Value?.ToString();
                txtTenDichVu.TextValue = row.Cells["TenDV"].Value?.ToString();
                txtGiaDichVu.TextValue = row.Cells["GiaDV"].Value?.ToString();
                if (row.Cells["BHYTTra"].Value?.ToString() == "1")
                    comboBoxBaoHiemChiTra.TextValue = "Có";
                else
                    comboBoxBaoHiemChiTra.TextValue = "Không";
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần sửa!");
            }
        }

        private void buttonXoaDichVuClick(object sender, EventArgs e)
        {
            if (tableService.SelectedRows.Count > 0)
            {
                string maDichVu = tableService.SelectedRows[0].Cells["MaDV"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa dịch vụ này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    serviceBUS.DeleteService(maDichVu);
                    MessageBox.Show("Xóa dịch vụ thành công!");
                    LoadServiceToTable();
                    buttonHuyDichVuClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!");
            }
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
