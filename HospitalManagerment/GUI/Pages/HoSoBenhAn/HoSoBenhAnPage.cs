using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component;
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
        private TableDataGridView tablePatient;
        private TableDataGridView tableMedical; // benh an
        private TableDataGridView tableServiceOfMedical; //dich vu
        private TableDataGridView tableDiagnoseOfMedical; //chan doan
        private TableDataGridView tablePrescriptionOfMedical; //dơn thuoc
        private MedicineBUS medicineBUS;
        private DiseaseBUS diseaseBUS;
        private MedicalBUS medicalBUS;
        private EmployeeBUS employeeBUS;
        private PatientBUS patientBUS;
        private ServiceBUS serviceBUS;

        public HoSoBenhAnPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableMedicine = new TableDataGridView();
            tableDisease = new TableDataGridView();
            tablePatient = new TableDataGridView();
            tableMedical = new TableDataGridView();
            tableServiceOfMedical = new TableDataGridView();
            tableDiagnoseOfMedical = new TableDataGridView();
            tablePrescriptionOfMedical = new TableDataGridView();
            medicineBUS = new MedicineBUS();
            diseaseBUS = new DiseaseBUS();
            medicalBUS = new MedicalBUS();
            employeeBUS = new EmployeeBUS();
            patientBUS = new PatientBUS();
            serviceBUS = new ServiceBUS();
        }

        private void HoSoBenhAnPage_Load(object sender, EventArgs e)
        {
            LoadMedicineToTable();
            LoadDiseaseToTable();
            LoadPatientToTable();
            LoadMedicalToTable();
            LoadServiceOfMedicalToTable();
            LoadDiagnoseOfMedicalToTable();
            LoadPrescriptionOfMedicalToTable();

            txtMaBenhAn.SetReadOnly(true);
            txtBacSiPhuTrach.SetReadOnly(true);
            txtTenBenhNhan.SetReadOnly(true);
            txtMaDuocPham.SetReadOnly(true);
            txtMaBenh.SetReadOnly(true);

            txtMaBenh.TextValue = diseaseBUS.GetNextDiseaseId();
            txtMaDuocPham.TextValue = medicineBUS.GetNextMedicineId();
            txtMaBenhAn.TextValue = medicalBUS.GetNextMedicalId();
            txtBacSiPhuTrach.TextValue = employeeBUS.GetEmployeeById(employeeId).TenNV;
        }

        private void LoadPatientToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Số Căn Cước Công Dân", typeof(string));
            table.Columns.Add("Tên Bệnh Nhân", typeof(string));

            foreach (var patient in patientBUS.GetAllPatients())
            {
                table.Rows.Add(patient.SoCCCD, patient.TenBN);
            }

            tablePatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePatient.DataSource = table;
            hoSoBenhAnPanel.Controls.Add(tablePatient);
        }


        private void LoadMedicalToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã bệnh án", typeof(string));
            table.Columns.Add("Sửa", typeof(string));

            tableMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableMedical.DataSource = table;
            benhAnPanel.Controls.Add(tableMedical);
        }
        private void LoadServiceOfMedicalToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Tên dịch vụ", typeof(string));
            table.Columns.Add("Xóa", typeof(string));

            tableServiceOfMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableServiceOfMedical.DataSource = table;
            dichVuPanel.Controls.Add(tableServiceOfMedical);
        }
        private void LoadDiagnoseOfMedicalToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã bệnh", typeof(string));
            table.Columns.Add("Tên bệnh", typeof(string));
            table.Columns.Add("Xóa", typeof(string));

            tableDiagnoseOfMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableDiagnoseOfMedical.DataSource = table;
            chanDoanPanel.Controls.Add(tableDiagnoseOfMedical);
        }
        private void LoadPrescriptionOfMedicalToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã dược phẩm", typeof(string));
            table.Columns.Add("Dược phẩm", typeof(string));
            table.Columns.Add("Số lượng", typeof(string));
            table.Columns.Add("Đơn vị", typeof(string));
            table.Columns.Add("Xóa", typeof(string));

            tablePrescriptionOfMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePrescriptionOfMedical.DataSource = table;
            donThuocPanel.Controls.Add(tablePrescriptionOfMedical);
        }


        private void LoadMedicineToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Dược Phẩm", typeof(string));
            table.Columns.Add("Tên Dược Phẩm", typeof(string));
            table.Columns.Add("Loại Dược Phẩm", typeof(string));

            foreach (var medicine in medicineBUS.GetAllMedicines())
            {
                table.Rows.Add(medicine.MaDP, medicine.TenDP, medicine.LoaiDP);
            }

            tableMedicine.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableMedicine.DataSource = table;
            duocPhamPanel.Controls.Add(tableMedicine);
        }


        private void LoadDiseaseToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Bệnh", typeof(string));
            table.Columns.Add("Tên Bệnh", typeof(string));
            table.Columns.Add("Mô Tả Bệnh", typeof(string));

            foreach (var disease in diseaseBUS.GetAllDiseases())
            {
                table.Rows.Add(disease.MaBenh, disease.TenBenh, disease.MoTaBenh);
            }

            tableDisease.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableDisease.DataSource = table;
            benhPanel.Controls.Add(tableDisease);
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
            }
        }

        // sự kiện tabPageDanhSach =====================================================================================================================================
        // sự kiện tabPageDanhSach =====================================================================================================================================
        private void buttonSuaHoSoBenhAnClick(object sender, EventArgs e)
        {
            if (tablePatient.SelectedRows.Count > 0)
            {
                var row = tablePatient.SelectedRows[0];
                string soCCCD = row.Cells["Số Căn Cước Công Dân"].Value?.ToString();

                var patient = patientBUS.GetPatientById(soCCCD);
                if (patient != null)
                {
                    txtSoCCCD.TextValue = patient.SoCCCD;
                    txtTenBenhNhan.TextValue = patient.TenBN;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy hồ sơ bệnh án!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn hồ sơ bệnh án cần sửa!");
            }
            tabControlHoSoBenhAn.SelectedTab = tabPageBenhAn;
            buttonHuyBenhAnClick(null, null);
        }

        //sự kiện tabPageBenhAn  ============================================================================================================================================
        //sự kiện tabPageBenhAn  ============================================================================================================================================
        private void buttonThemBenhAnClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaBenhAnClick(object sender, EventArgs e)
        {

        }

        private void buttonChonChanDoanClick(object sender, EventArgs e)
        {
            Form popup = new Form();
            popup.Text = "Chọn chẩn đoán";
            popup.Size = new Size(900, 500);
            popup.StartPosition = FormStartPosition.CenterParent;

            DataTable table = new DataTable();
            table.Columns.Add("Mã Bệnh", typeof(string));
            table.Columns.Add("Tên Bệnh", typeof(string));
            foreach (var disease in diseaseBUS.GetAllDiseases())
                table.Rows.Add(disease.MaBenh, disease.TenBenh);

            TableDataGridView dgv = new TableDataGridView();
            dgv.DataSource = table;
            dgv.Dock = DockStyle.Fill;

            popup.Controls.Add(dgv);

            // Panel chứa nút
            FlowLayoutPanel panelButtons = new FlowLayoutPanel();
            panelButtons.Height = 60;
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Padding = new Padding(10);
            panelButtons.BackColor = Color.White;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;

            RoundedLabel btnAdd = new RoundedLabel();
            btnAdd.Text = "Chọn";
            btnAdd.AutoSize = false;
            btnAdd.Size = new Size(100, 35);
            btnAdd.BackColor = Color.White;
            btnAdd.PanelColor = Color.FromArgb(52, 211, 153);

            RoundedLabel btnClose = new RoundedLabel();
            btnClose.Text = "Đóng";
            btnClose.AutoSize = false;
            btnClose.Size = new Size(100, 35);
            btnClose.BackColor = Color.White;
            btnClose.PanelColor = Color.FromArgb(255, 90, 93);

            btnAdd.Click += (s, args) =>
            {
                string maDV = dgv.SelectedRows[0].Cells["Mã Bệnh"].Value.ToString();
                var service = serviceBUS.GetServiceById(maDV);

                //if (!listServiceSelected.Any(x => x.MaDV == maDV))
                //{
                //    listServiceSelected.Add(service);
                //    UpdateServiceSelectedTable();
                //}
                //else
                //{
                //    MessageBox.Show("Dịch vụ đã được chọn rồi!");
                //}
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private void buttonChonDichVuClick(object sender, EventArgs e)
        {
            Form popup = new Form();
            popup.Text = "Chọn dịch vụ";
            popup.Size = new Size(900, 500);
            popup.StartPosition = FormStartPosition.CenterParent;
            DataTable table = new DataTable();
            table.Columns.Add("Mã Dịch Vụ", typeof(string));
            table.Columns.Add("Tên Dịch Vụ", typeof(string));
            table.Columns.Add("Giá Dịch Vụ", typeof(string));
            table.Columns.Add("Bảo hiểm chi trả", typeof(string));

            foreach (var service in serviceBUS.GetAllService())
                table.Rows.Add(service.MaDV, service.TenDV, service.GiaDV, service.BHYTTra);

            TableDataGridView dgv = new TableDataGridView();
            dgv.DataSource = table;
            dgv.Dock = DockStyle.Fill;

            popup.Controls.Add(dgv);

            FlowLayoutPanel panelButtons = new FlowLayoutPanel();
            panelButtons.Height = 60;
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Padding = new Padding(10);
            panelButtons.BackColor = Color.White;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;

            RoundedLabel btnAdd = new RoundedLabel();
            btnAdd.Text = "Chọn";
            btnAdd.AutoSize = false;
            btnAdd.Size = new Size(100, 35);
            btnAdd.BackColor = Color.White;
            btnAdd.PanelColor = Color.FromArgb(52, 211, 153);

            RoundedLabel btnClose = new RoundedLabel();
            btnClose.Text = "Đóng";
            btnClose.AutoSize = false;
            btnClose.Size = new Size(100, 35);
            btnClose.BackColor = Color.White;
            btnClose.PanelColor = Color.FromArgb(255, 90, 93);

            btnAdd.Click += (s, args) =>
            {
                string maDV = dgv.SelectedRows[0].Cells["Mã Dịch Vụ"].Value.ToString();
                var service = serviceBUS.GetServiceById(maDV);

                //if (!listServiceSelected.Any(x => x.MaDV == maDV))
                //{
                //    listServiceSelected.Add(service);
                //    UpdateServiceSelectedTable();
                //}
                //else
                //{
                //    MessageBox.Show("Dịch vụ đã được chọn rồi!");
                //}
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private void buttonThemDonThuocClick(object sender, EventArgs e)
        {
            Form popup = new Form();
            popup.Text = "Thêm đơn thuốc";
            popup.Size = new Size(900, 500);
            popup.StartPosition = FormStartPosition.CenterParent;
            DataTable table = new DataTable();
            table.Columns.Add("Mã Dược Phẩm", typeof(string));
            table.Columns.Add("Tên Dược Phẩm", typeof(string));

            foreach (var medicine in medicineBUS.GetAllMedicines())
                table.Rows.Add(medicine.MaDP, medicine.TenDP);

            TableDataGridView dgv = new TableDataGridView();
            dgv.DataSource = table;
            dgv.Dock = DockStyle.Fill;

            popup.Controls.Add(dgv);

            FlowLayoutPanel panelButtons = new FlowLayoutPanel();
            panelButtons.Height = 60;
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Padding = new Padding(10);
            panelButtons.BackColor = Color.White;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;

            RoundedLabel btnAdd = new RoundedLabel();
            btnAdd.Text = "Chọn";
            btnAdd.AutoSize = false;
            btnAdd.Size = new Size(100, 35);
            btnAdd.BackColor = Color.White;
            btnAdd.PanelColor = Color.FromArgb(52, 211, 153);

            RoundedLabel btnClose = new RoundedLabel();
            btnClose.Text = "Đóng";
            btnClose.AutoSize = false;
            btnClose.Size = new Size(100, 35);
            btnClose.BackColor = Color.White;
            btnClose.PanelColor = Color.FromArgb(255, 90, 93);

            btnAdd.Click += (s, args) =>
            {
                string maDV = dgv.SelectedRows[0].Cells["Mã Dược Phẩm"].Value.ToString();
                var service = serviceBUS.GetServiceById(maDV);

                //if (!listServiceSelected.Any(x => x.MaDV == maDV))
                //{
                //    listServiceSelected.Add(service);
                //    UpdateServiceSelectedTable();
                //}
                //else
                //{
                //    MessageBox.Show("Dịch vụ đã được chọn rồi!");
                //}
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private void buttonHuyBenhAnClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanBenhAnClick(object sender, EventArgs e)
        {

        }

        // sự kiện tabPageBenh ============================================================================================================================================
        // sự kiện tabPageBenh ============================================================================================================================================
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
            LoadDiseaseToTable();
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
                string maBenh = row.Cells["Mã Bệnh"].Value?.ToString();

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
                string maBenh = tableDisease.SelectedRows[0].Cells["Mã Bệnh"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa benh này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    diseaseBUS.DeleteDisease(maBenh);
                    MessageBox.Show("Xóa benh thành công!");
                    LoadDiseaseToTable();
                    buttonHuyBenhClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn benh cần xóa!");
            }
        }

        // sự kiện tabPageDuocPham  ============================================================================================================================================
        // sự kiện tabPageDuocPham  ============================================================================================================================================
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
            LoadMedicineToTable();
            buttonHuyDuocPhamClick(null, null);
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
                string maDP = row.Cells["Mã Dược Phẩm"].Value?.ToString();

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
                string maDP = tableMedicine.SelectedRows[0].Cells["Mã Dược Phẩm"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa duoc pham này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    medicineBUS.DeleteMedicine(maDP);
                    MessageBox.Show("Xóa duoc pham thành công!");
                    LoadMedicineToTable();
                    buttonHuyDuocPhamClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn duoc pham cần xóa!");
            }
        }
    }
}
