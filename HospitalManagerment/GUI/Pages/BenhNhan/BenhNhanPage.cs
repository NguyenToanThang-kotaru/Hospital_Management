using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.BenhNhan
{
    public partial class BenhNhanPage : UserControl
    {
        private TableDataGridView tablePatient;
        private PatientBUS patientBUS;
        public BenhNhanPage()
        {
            InitializeComponent();
            tablePatient = new TableDataGridView();
            patientBUS = new PatientBUS();
        }

        private void BenhNhanPage_Load(object sender, EventArgs e)
        {
            LoadPatientToTable();

            checkBoxCoBHYTCheckedChanged(checkBoxCoBHYT, EventArgs.Empty);
            txtMaDKDV.SetReadOnly(true);
            txtNhanVientaoPhieu.SetReadOnly(true);
            txtTenBenhNhan.SetReadOnly(true);
            txtNgayGioTaoPhieu.SetReadOnly(true);
            txtTongChiPhi.SetReadOnly(true);
            txtTiLeChiTra.SetReadOnly(true);
        }

        private void LoadPatientToTable()
        {
            tablePatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePatient.DataSource = ToDataTable(patientBUS.GetAllPatients());
            benhNhanPanel.Controls.Add(tablePatient);
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

        private void comboBoxGioiTinhLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxGioiTinh.GetComboBox();

            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Nam");
                cb.Items.Add("Nữ");

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

        private void comboBoxTrangThaiDangKyLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxTranhThaiDangKi.GetComboBox();

            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Đã hoàn thành");
                cb.Items.Add("Đã hủy");

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

        private void comboBoxHinhThucThanhToanLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxHinhThucThanhToan.GetComboBox();

            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Tiền mặt");
                cb.Items.Add("Chuyển khoản");

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

        // sự kiện tabPageBenhNhan
        private void checkBoxCoBHYTCheckedChanged(object sender, EventArgs e)
        {
            bool allowEdit = checkBoxCoBHYT.Checked;

            txtSoBHYT.SetReadOnly(!allowEdit);
            txtNgayCap.SetReadOnly(!allowEdit);
            txtNgayHetHan.SetReadOnly(!allowEdit);
        }
        private void buttonHuyBenhNhanClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanBenhNhanClick(object sender, EventArgs e)
        {

        }

        // sự kiện tabPageDangKyDichVu
        private void buttonChonDichVuClick(object sender, EventArgs e)
        {

        }
        private void buttonHuyDangKyDichVuClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanDangKyDichVuClick(object sender, EventArgs e)
        {

        }

        // sự kiện tabPageDanhSach
        private void buttonThemBenhNhanClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaBenhNhanClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaBenhNhanClick(object sender, EventArgs e)
        {

        }
        //  


    }
}
