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
        private MedicalBUS medicalBUS;
        private EmployeeBUS employeeBUS;
        public HoSoBenhAnPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableMedicine = new TableDataGridView();
            tableDisease = new TableDataGridView();
            medicineBUS = new MedicineBUS();
            diseaseBUS = new DiseaseBUS();
            medicalBUS = new MedicalBUS();
            employeeBUS = new EmployeeBUS();
        }

        private void HoSoBenhAnPage_Load(object sender, EventArgs e)
        {
            LoadMedicineToTable();
            LoadDiseaseToTable();

            txtMaBenhAn.SetReadOnly(true);
            txtBacSiPhuTrach.SetReadOnly(true);
            txtTenBenhNhan.SetReadOnly(true);
            txtMaDuocPham.SetReadOnly(true);
            txtMaBenh.SetReadOnly(true);

            txtMaBenh.TextValue = diseaseBUS.GetNextDiseaseId();
            txtMaDuocPham.TextValue = medicineBUS.GetNextMedicineId();
            txtMaBenhAn.TextValue = medicalBUS.GetNextMedicalId();
            txtBacSiPhuTrach.TextValue = employeeBUS.GetEmployeeByID(employeeId).TenNV;
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
            // chọn dòng
            tabControlHoSoBenhAn.SelectedTab = tabPageBenhAn;
            buttonHuyBenhAnClick(null, null);
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
            txtMaBenh.TextValue = diseaseBUS.GetNextDiseaseId();
            txtTenBenh.TextValue = "";
            txtMoTaBenh.TextValue = "";
        }

        private void buttonXacNhanBenhClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenBenh.TextValue))
            {
                MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin benh!");
                return;
            }
            DiseaseDTO disease = new DiseaseDTO()
            {
                MaBenh = txtMaBenh.TextValue.Trim(),
                TenBenh = txtTenBenh.TextValue.Trim(),
                MoTaBenh = txtMoTaBenh.TextValue.Trim()
            };

            if (!diseaseBUS.ExistsDiseaseId(disease.MaBenh))
            {
                diseaseBUS.AddDisease(disease);
                MessageBox.Show("Thêm benh thành công!");
            }
            else
            {
                diseaseBUS.UpdateDisease(disease);
                MessageBox.Show("Cập nhật benh thành công!");
            }
            buttonHuyBenhClick(null, null);
        }

        private void buttonThemBenhClick(object sender, EventArgs e)
        {
            txtMaBenh.TextValue = diseaseBUS.GetNextDiseaseId();
            txtTenBenh.TextValue = "";
            txtMoTaBenh.TextValue = "";
        }

        private void buttonSuaBenhClick(object sender, EventArgs e)
        {
            if (tableDisease.SelectedRows.Count > 0)
            {
                var row = tableDisease.SelectedRows[0];
                string maBenh = row.Cells["MaBenh"].Value?.ToString();

                var benh = diseaseBUS.GetDiseaseById(maBenh);
                if (diseaseBUS.GetDiseaseById(maBenh) != null)
                {
                    txtMaBenh.TextValue = benh.MaBenh;
                    txtTenBenh.TextValue = benh.TenBenh;
                    txtMoTaBenh.TextValue = benh.MoTaBenh;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy benh!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn benh cần sửa!");
            }
        }

        private void buttonXoaBenhClick(object sender, EventArgs e)
        {
            if (tableDisease.SelectedRows.Count > 0)
            {
                string maBenh = tableDisease.SelectedRows[0].Cells["MaBenh"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa benh này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    diseaseBUS.DeleteDisease(maBenh);
                    MessageBox.Show("Xóa benh thành công!");
                    buttonHuyBenhClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn benh cần xóa!");
            }
        }

        // sự kiện tabPageDuocPham
        private void buttonHuyDuocPhamClick(object sender, EventArgs e)
        {
            txtMaDuocPham.TextValue = medicineBUS.GetNextMedicineId();
            txtTenDuocPham.TextValue = "";
            comboBoxLoaiDuocPham.GetComboBox().SelectedIndex = -1;
        }

        private void buttonXacNhanDuocPhamClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenDuocPham.TextValue) || string.IsNullOrEmpty(comboBoxLoaiDuocPham.TextValue))
            {
                MessageBox.Show("Vui lòng cung cấp đầy đủ thông tin duoc pham!");
                return;
            }
            MedicineDTO medicine = new MedicineDTO()
            {
                MaDP = txtMaDuocPham.TextValue.Trim(),
                TenDP = txtTenDuocPham.TextValue.Trim(),
                LoaiDP = comboBoxLoaiDuocPham.TextValue,
            };

            if (!medicineBUS.ExistsMedicineId(medicine.MaDP))
            {
                medicineBUS.AddMedicine(medicine);
                MessageBox.Show("Thêm duoc pham thành công!");
            }
            else
            {
                medicineBUS.UpdateMedicine(medicine);
                MessageBox.Show("Cập nhật duoc pham thành công!");
            }
            buttonHuyBenhClick(null, null);
        }

        private void buttonThemDuocPhamClick(object sender, EventArgs e)
        {
            txtMaDuocPham.TextValue = medicineBUS.GetNextMedicineId();
            txtTenDuocPham.TextValue = "";
            comboBoxLoaiDuocPham.GetComboBox().SelectedIndex = -1;
        }

        private void buttonSuaDuocPhamClick(object sender, EventArgs e)
        {
            if (tableMedicine.SelectedRows.Count > 0)
            {
                var row = tableMedicine.SelectedRows[0];
                string maDP = row.Cells["MaDP"].Value?.ToString();

                var duocpham = medicineBUS.GetMedicineById(maDP);
                if (medicineBUS.GetMedicineById(maDP) != null)
                {
                    txtMaDuocPham.TextValue = duocpham.MaDP;
                    txtTenDuocPham.TextValue = duocpham.TenDP;
                    comboBoxLoaiDuocPham.TextValue = duocpham.LoaiDP;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy duoc pham!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn duoc pham cần sửa!");
            }
        }

        private void buttonXoaDuocPhamClick(object sender, EventArgs e)
        {
            if (tableMedicine.SelectedRows.Count > 0)
            {
                string maDP = tableMedicine.SelectedRows[0].Cells["MaDP"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa duoc pham này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    medicineBUS.DeleteMedicine(maDP);
                    MessageBox.Show("Xóa duoc pham thành công!");
                    buttonHuyBenhClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn duoc pham cần xóa!");
            }
        }
    }
}
