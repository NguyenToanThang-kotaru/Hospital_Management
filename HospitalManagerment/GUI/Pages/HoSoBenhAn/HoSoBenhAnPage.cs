using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.HoSoBenhAn
{
    public partial class HoSoBenhAnPage : UserControl
    {
        private string employeeId;
        private TableDataGridView tableMedicine;
        private TableDataGridView tableDisease;
        private MedicineBUS medicineBUS;
        private DiseaseBUS diseaseBUS;
        public HoSoBenhAnPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableMedicine = new TableDataGridView();
            tableDisease = new TableDataGridView();
            medicineBUS = new MedicineBUS();
            diseaseBUS = new DiseaseBUS();
        }

        private void HoSoBenhAnPage_Load(object sender, EventArgs e)
        {
            LoadMedicineToTable();
            LoadDiseaseToTable();

            txtMaBenhAn.SetReadOnly(true);
            txtBacSiPhuTrach.SetReadOnly(true);
            txtNgayTaoBenhAn.SetReadOnly(true);
            txtTenBenhNhan.SetReadOnly(true);
            txtMaDuocPham.SetReadOnly(true);
            txtMaBenh.SetReadOnly(true);
        }

        private void LoadMedicineToTable()
        {
            tableMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableMedicine.DataSource = ToDataTable(medicineBUS.GetAllMedicines());
            duocPhamPanel.Controls.Add(tableMedicine);
        }

        private void LoadDiseaseToTable()
        {
            tableDisease.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableDisease.DataSource = ToDataTable(diseaseBUS.GetAllDiseases());
            benhPanel.Controls.Add(tableDisease);
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

        private void ComboBoxLoaiDuocPhamLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxLoaiDuocPham.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Thuốc giảm đau - hạ sốt - kháng viêm");
                cb.Items.Add("Thuốc kháng sinh - chống nhiễm khuẩn");
                cb.Items.Add("Thuốc tim mạch");
                cb.Items.Add("Thuốc tiêu hóa");
                cb.Items.Add("Thuốc thần kinh - tâm thần");
                cb.Items.Add("Thuốc nội tiết - chuyển hóa");
                cb.Items.Add("Vitamin");
                cb.Items.Add("Thuốc tránh thai");
                cb.Items.Add("Thuốc kháng virus");
                cb.Items.Add("Thuốc chống ung thư");

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

        // sự kiện tabPageDanhSach
        private void buttonSuaHoSoBenhAnClick(object sender, EventArgs e)
        {

        }
        
        //sự kiện tabPageBenhAn
        private void buttonThemBenhAnClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaBenhAnClick(object sender, EventArgs e)
        {

        }

        private void buttonChonChanDoanClick(object sender, EventArgs e)
        {

        }

        private void buttonChonDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonThemDonThuocClick(object sender, EventArgs e)
        {

        }

        private void buttonHuyBenhAnClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanBenhAnClick(object sender, EventArgs e)
        {

        }

        // sự kiện tabPageBenh
        private void buttonHuyBenhClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanBenhClick(object sender, EventArgs e)
        {

        }

        private void buttonThemBenhClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaBenhClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaBenhClick(object sender, EventArgs e)
        {

        }

        // sự kiện tabPageDuocPham
        private void buttonHuyDuocPhamClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanDuocPhamClick(object sender, EventArgs e)
        {

        }

        private void buttonThemDuocPhamClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaDuocPhamClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaDuocPhamClick(object sender, EventArgs e)
        {

        }
    }
}
