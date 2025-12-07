using HM.BUS;
using HM.DTO;
using HM.GUI.Component;
using HM.GUI.Component.TableDataGridView;
using LayoutTest.GUIComponents;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace HM.GUI.Pages.HoSoBenhAn
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
        private MedicalBUS medicalBUS; //benh an
        private DiagnoseBUS diagnoseBUS; //chan doan
        private PrescriptionBUS prescriptionBUS; //don thuoc
        private ServiceDetailBUS serviceDetailBUS; //chi tiet dich vu
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
            tableMedical.CellClick += TableMedicalCellClick;
            tableServiceOfMedical = new TableDataGridView();
            tableServiceOfMedical.CellClick += TableServiceOfMedicalCellClick;
            tableDiagnoseOfMedical = new TableDataGridView();
            tableDiagnoseOfMedical.CellClick += TableDiagnoseOfMedicalCellClick;
            tablePrescriptionOfMedical = new TableDataGridView();
            tablePrescriptionOfMedical.CellClick += TablePrescriptionOfMedicalCellClick;

            medicineBUS = new MedicineBUS();
            diseaseBUS = new DiseaseBUS();
            medicalBUS = new MedicalBUS();
            diagnoseBUS = new DiagnoseBUS();
            prescriptionBUS = new PrescriptionBUS();
            serviceDetailBUS = new ServiceDetailBUS();
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

            txtSoCCCD.SetReadOnly(true);
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
            tableMedical.AutoGenerateColumns = false;
            tableMedical.Columns.Clear();

            tableMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Mã Bệnh Án", DataPropertyName = "Mã Bệnh Án", HeaderText = "Mã Bệnh Án" });

            DataGridViewButtonColumn btnView = new DataGridViewButtonColumn();
            btnView.Name = "btnView";
            btnView.HeaderText = "Xem";
            btnView.Text = "Xem";
            btnView.UseColumnTextForButtonValue = true;
            tableMedical.Columns.Add(btnView);

            tableMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            btnView.DisplayIndex = tableMedical.Columns.Count - 1;

            benhAnPanel.Controls.Add(tableMedical);
        }

        private void LoadServiceOfMedicalToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Tên", typeof(string));

            tableServiceOfMedical.AutoGenerateColumns = false;
            tableServiceOfMedical.Columns.Clear();

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnDelete";
            btnDelete.HeaderText = "Xóa";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;
            tableServiceOfMedical.Columns.Add(btnDelete);

            tableServiceOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Mã",  DataPropertyName = "Mã" });
            tableServiceOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Tên", DataPropertyName = "Tên" });

            tableServiceOfMedical.DataSource = table;
            tableServiceOfMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            btnDelete.DisplayIndex = tableServiceOfMedical.Columns.Count - 1;

            dichVuPanel.Controls.Add(tableServiceOfMedical);
        }

        private void LoadDiagnoseOfMedicalToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Tên", typeof(string));

            tableDiagnoseOfMedical.AutoGenerateColumns = false;
            tableDiagnoseOfMedical.Columns.Clear();

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnDelete";
            btnDelete.HeaderText = "Xóa";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;
            tableDiagnoseOfMedical.Columns.Add(btnDelete);
            tableDiagnoseOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Mã", DataPropertyName = "Mã" });
            tableDiagnoseOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Tên", DataPropertyName = "Tên" });

            tableDiagnoseOfMedical.DataSource = table;
            tableDiagnoseOfMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            btnDelete.DisplayIndex = tableDiagnoseOfMedical.Columns.Count - 1;

            chanDoanPanel.Controls.Add(tableDiagnoseOfMedical);
        }

        private void LoadPrescriptionOfMedicalToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Dược phẩm", typeof(string));
            table.Columns.Add("Số lượng", typeof(string));
            table.Columns.Add("Đơn vị", typeof(string));

            tablePrescriptionOfMedical.AutoGenerateColumns = false;
            tablePrescriptionOfMedical.Columns.Clear();

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnDelete";
            btnDelete.HeaderText = "Xóa";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;
            tablePrescriptionOfMedical.Columns.Add(btnDelete);

            tablePrescriptionOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Mã", DataPropertyName = "Mã" });
            tablePrescriptionOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Dược phẩm", DataPropertyName = "Dược phẩm" });
            tablePrescriptionOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Số lượng", DataPropertyName = "Số lượng" });
            tablePrescriptionOfMedical.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Đơn vị", DataPropertyName = "Đơn vị" });

            tablePrescriptionOfMedical.DataSource = table;
            tablePrescriptionOfMedical.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            btnDelete.DisplayIndex = tablePrescriptionOfMedical.Columns.Count - 1;

            tablePrescriptionOfMedical.CellClick += TablePrescriptionOfMedicalCellClick;
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

        // sự kiện tabPageDanhSach =========================================================================================================================================
        // sự kiện tabPageDanhSach =========================================================================================================================================
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
                    LoadMedicalTableByPatientId(soCCCD);
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
        private void LoadMedicalTableByPatientId(string soCCCD)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Bệnh Án", typeof(string));
            var medicals = medicalBUS.GetAllMedicalsByPatientId(soCCCD);
            foreach (var medical in medicals)
            {
                table.Rows.Add(medical.MaBA);
            }
            tableMedical.DataSource = table;
        }

        private void TableMedicalCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (tableMedical.Columns[e.ColumnIndex].Name == "btnView")
            {
                string maBA = tableMedical.Rows[e.RowIndex].Cells["Mã Bệnh Án"].Value.ToString();
                txtMaBenhAn.TextValue = maBA;
                LoadDiagnosesByMedicalId(maBA);
                LoadServicesByMedicalId(maBA);
                LoadPrescriptionsByMedicalId(maBA);
            }
        }

        private void LoadServicesByMedicalId(string maBA)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Tên", typeof(string));

            var services = serviceDetailBUS.GetServiceDetailByMedicalId(maBA);
            foreach (var serviceDetail in services)
            {
                var service = serviceBUS.GetServiceById(serviceDetail.MaDV);
                if (service != null)
                {
                    table.Rows.Add(service.MaDV, service.TenDV);
                }
            }
            tableServiceOfMedical.DataSource = table;
        }

        private void LoadDiagnosesByMedicalId(string maBA)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Tên", typeof(string));

            var diagnoses = diagnoseBUS.GetDiagnosesByMedicalId(maBA);
            foreach (var diagnose in diagnoses)
            {
                var disease = diseaseBUS.GetDiseaseById(diagnose.MaBenh);
                if (disease != null)
                {
                    table.Rows.Add(disease.MaBenh, disease.TenBenh);
                }
            }
            tableDiagnoseOfMedical.DataSource = table;
        }

        private void LoadPrescriptionsByMedicalId(string maBA)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Dược phẩm", typeof(string));
            table.Columns.Add("Số lượng", typeof(string));
            table.Columns.Add("Đơn vị", typeof(string));

            var prescriptions = prescriptionBUS.GetPrescriptionsByMedicalId(maBA);
            foreach (var prescription in prescriptions)
            {
                var medicine = medicineBUS.GetMedicineById(prescription.MaDP);
                if (medicine != null)
                {
                    table.Rows.Add(medicine.MaDP, medicine.TenDP, prescription.SoLuongDP, prescription.DonViDP);
                }
            }
            tablePrescriptionOfMedical.DataSource = table;
        }

        //sự kiện tabPageBenhAn  ============================================================================================================================================
        //sự kiện tabPageBenhAn  ============================================================================================================================================
        private void buttonThemBenhAnClick(object sender, EventArgs e)
        {
            txtMaBenhAn.TextValue = medicalBUS.GetNextMedicalId();
            LoadDiagnoseOfMedicalToTable();
            LoadServiceOfMedicalToTable();
            LoadPrescriptionOfMedicalToTable();
        }

        private void buttonChonChanDoanClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCD.TextValue)){
                MessageBox.Show("Vui long chọn hồ sơ bệnh án để chọn chẩn đoán!");
                return;
            }
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
                string maBenh = dgv.SelectedRows[0].Cells["Mã Bệnh"].Value.ToString();
                string tenBenh = dgv.SelectedRows[0].Cells["Tên Bệnh"].Value.ToString();

                DataTable diagnoseTable = (DataTable)tableDiagnoseOfMedical.DataSource;

                foreach (DataRow row in diagnoseTable.Rows)
                {
                    if (row["Mã"].ToString() == maBenh)
                    {
                        MessageBox.Show("Bệnh đã được chọn rồi!");
                        return;
                    }
                }
                diagnoseTable.Rows.Add(maBenh, tenBenh);
                popup.Close();
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private void TableDiagnoseOfMedicalCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (tableDiagnoseOfMedical.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DataTable diagnoseTable = (DataTable)tableDiagnoseOfMedical.DataSource;
                string maBenh = tableDiagnoseOfMedical.Rows[e.RowIndex].Cells["Mã"].Value.ToString();

                foreach (DataRow row in diagnoseTable.Rows)
                {
                    if (row["Mã"].ToString() == maBenh)
                    {
                        diagnoseTable.Rows.Remove(row);
                        break;
                    }
                }
            }
        }

        private void buttonChonDichVuClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCD.TextValue))
            {
                MessageBox.Show("Vui long chọn hồ sơ bệnh án để chọn dịch vụ!");
                return;
            }
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
                string tenDV = dgv.SelectedRows[0].Cells["Tên Dịch Vụ"].Value.ToString();

                DataTable serviceTable = (DataTable)tableServiceOfMedical.DataSource;

                foreach (DataRow row in serviceTable.Rows)
                {
                    if (row["Mã"].ToString() == maDV)
                    {
                        MessageBox.Show("Dịch vụ đã được chọn rồi!");
                        return;
                    }
                }

                serviceTable.Rows.Add(maDV, tenDV);
                popup.Close();
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private void TableServiceOfMedicalCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;
            if (tableServiceOfMedical.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DataTable serviceTable = (DataTable)tableServiceOfMedical.DataSource;
                string maDV = tableServiceOfMedical.Rows[e.RowIndex].Cells["Mã"].Value.ToString();

                foreach (DataRow row in serviceTable.Rows)
                {
                    if (row["Mã"].ToString() == maDV)
                    {
                        serviceTable.Rows.Remove(row);
                        break;
                    }
                }
            }
        }

        private void buttonThemDonThuocClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCD.TextValue))
            {
                MessageBox.Show("Vui long chọn hồ sơ bệnh án để thêm đơn thuốc!");
                return;
            }
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

            FlowLayoutPanel pnlInputRow = new FlowLayoutPanel();
            pnlInputRow.Height = 100;
            pnlInputRow.Dock = DockStyle.Bottom;
            pnlInputRow.FlowDirection = FlowDirection.LeftToRight;
            pnlInputRow.Padding = new Padding(10);
            pnlInputRow.BackColor = Color.White;

            LableTextBox txtSoLuong = new LableTextBox(400, 80, "Số lượng:");
            txtSoLuong.Margin = new Padding(15);

            LableComboBox comboboxDonVi = new LableComboBox(400, 80, "Đơn vị:");
            comboboxDonVi.Margin = new Padding(15);
            comboboxDonVi.GetComboBox().Items.AddRange(new object[] { "Viên", "Ống", "Hộp", "Vĩ", "Chai", "Gói", "Tuýp", "Lọ" });
            if (comboboxDonVi.GetComboBox().Items.Count > 0)
                comboboxDonVi.GetComboBox().SelectedIndex = 0;

            pnlInputRow.Controls.Add(txtSoLuong);
            pnlInputRow.Controls.Add(comboboxDonVi);

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
                string maDP = dgv.SelectedRows[0].Cells["Mã Dược Phẩm"].Value.ToString();
                string tenDP = dgv.SelectedRows[0].Cells["Tên Dược Phẩm"].Value.ToString();

                string soLuongText = txtSoLuong.TextValue.Trim();
                if (!int.TryParse(soLuongText, out int soLuong) || soLuong <= 0)
                {
                    MessageBox.Show("Số lượng phải là số nguyên dương!");
                    return;
                }

                string donVi = comboboxDonVi.TextValue.Trim();
                if (string.IsNullOrEmpty(donVi))
                {
                    MessageBox.Show("Vui lòng chọn đơn vị!");
                    return;
                }

                DataTable prescriptionTable = (DataTable)tablePrescriptionOfMedical.DataSource;

                foreach (DataRow row in prescriptionTable.Rows)
                {
                    if (row["Mã"].ToString() == maDP)
                    {
                        MessageBox.Show("Dược phẩm đã được thêm rồi!");
                        return;
                    }
                }

                prescriptionTable.Rows.Add(maDP, tenDP, soLuong, donVi);
                popup.Close();
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(pnlInputRow);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private void TablePrescriptionOfMedicalCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return;

            if (tablePrescriptionOfMedical.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DataTable prescriptionTable = (DataTable)tablePrescriptionOfMedical.DataSource;
                if (e.RowIndex < prescriptionTable.Rows.Count)
                {
                    prescriptionTable.Rows.RemoveAt(e.RowIndex);
                }
            }
        }

        private void buttonHuyBenhAnClick(object sender, EventArgs e)
        {
            txtMaBenhAn.TextValue = medicalBUS.GetNextMedicalId();
            LoadDiagnoseOfMedicalToTable();
            LoadServiceOfMedicalToTable();
            LoadPrescriptionOfMedicalToTable();
        }

        private void buttonXacNhanBenhAnClick(object sender, EventArgs e)
        {
            DataTable diagnoseTable = (DataTable)tableDiagnoseOfMedical.DataSource;
            DataTable serviceTable = (DataTable)tableServiceOfMedical.DataSource;
            DataTable prescriptionTable = (DataTable)tablePrescriptionOfMedical.DataSource;
            if (diagnoseTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một chẩn đoán!");
                return;
            }
            if (serviceTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng thêm ít nhất một dịch vụ!");
                return;
            }
            if (string.IsNullOrEmpty(txtSoCCCD.TextValue))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
                return;
            }

            MedicalDTO medical = new MedicalDTO()
            {
                MaBA = txtMaBenhAn.TextValue,
                SoCCCD = txtSoCCCD.TextValue,
                MaNV = employeeId,
                NgayTao = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
            };

            if (!medicalBUS.ExistsMedicalId(medical.MaBA)) // thêm
            {
                medicalBUS.AddMedical(medical);
                MessageBox.Show("Thêm bệnh án thành công!");

                // Thêm chẩn đoán
                foreach (DataRow row in diagnoseTable.Rows)
                {
                    DiagnoseDTO diagnose = new DiagnoseDTO()
                    {
                        MaBA = medical.MaBA,
                        MaBenh = row["Mã"].ToString(),
                        NgayChanDoan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
                        KetQuaDieuTri = "1"
                    };
                    diagnoseBUS.AddDiagnose(diagnose);
                }

                // Thêm đơn thuốc
                foreach (DataRow row in prescriptionTable.Rows)
                {
                    PrescriptionDTO prescription = new PrescriptionDTO()
                    {
                        MaBA = medical.MaBA,
                        MaDP = row["Mã"].ToString(),
                        SoLuongDP =row["Số lượng"].ToString(),
                        DonViDP = row["Đơn vị"].ToString()
                    };
                    prescriptionBUS.AddPrescription(prescription);
                }

                // Thêm chi tiết dịch vụ
                foreach (DataRow row in serviceTable.Rows)
                {
                    ServiceDetailDTO serviceDetail = new ServiceDetailDTO()
                    {
                        MaBA = medical.MaBA,
                        MaDV = row["Mã"].ToString()
                    };
                    serviceDetailBUS.AddServiceDetail(serviceDetail);
                }

                MessageBox.Show("Thêm bệnh án và các thông tin liên quan thành công!");
                LoadMedicalTableByPatientId(txtSoCCCD.TextValue);
            }
            else // sửa
            {
                //medicalBUS.UpdateMedical(medical);
                //MessageBox.Show("Cập nhật bệnh án thành công!");

                //diagnoseBUS.DeleteDiagnoseByMedicalId(medical.MaBA);
                //foreach (DataRow row in diagnoseTable.Rows)
                //{
                //    DiagnoseDTO diagnose = new DiagnoseDTO()
                //    {
                //        MaBA = medical.MaBA,
                //        MaBenh = row["Mã"].ToString()
                //    };
                //    diagnoseBUS.AddDiagnose(diagnose);
                //}

                //prescriptionBUS.DeletePrescriptionByMedicalId(medical.MaBA);
                //foreach (DataRow row in prescriptionTable.Rows)
                //{
                //    PrescriptionDTO prescription = new PrescriptionDTO()
                //    {
                //        MaBA = medical.MaBA,
                //        MaDP = row["Mã"].ToString(),
                //        SoLuong = int.Parse(row["Số lượng"].ToString()),
                //        DonVi = row["Đơn vị"].ToString()
                //    };
                //    prescriptionBUS.AddPrescription(prescription);
                //}

                //serviceDetailBUS.DeleteServiceDetailByMedicalId(medical.MaBA);
                //foreach (DataRow row in serviceTable.Rows)
                //{
                //    ServiceDetailDTO serviceDetail = new ServiceDetailDTO()
                //    {
                //        MaBA = medical.MaBA,
                //        MaDV = row["Mã"].ToString()
                //    };
                //    serviceDetailBUS.AddServiceDetail(serviceDetail);
                //}

                //MessageBox.Show("Cập nhật bệnh án và các thông tin liên quan thành công!");
            }

            buttonHuyBenhAnClick(null, null);
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

        // Search 
        private void searchBarHoSoBenhAnTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarHoSoBenhAn.Text.Trim();
            var patients = patientBUS.SearchPatient(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Số Căn Cước Công Dân", typeof(string));
            table.Columns.Add("Tên Bệnh Nhân", typeof(string));

            foreach (var patient in patients)
            {
                table.Rows.Add(
                    patient.SoCCCD,
                    patient.TenBN
                );
            }

            tablePatient.DataSource = table;
        }


        private void searchBarBenhTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarBenh.Text.Trim();
            var diseases = diseaseBUS.SearchDiseaseByName(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Mã Bệnh", typeof(string));
            table.Columns.Add("Tên Bệnh", typeof(string));
            table.Columns.Add("Mô Tả", typeof(string));

            foreach (var disease in diseases)
            {
                table.Rows.Add(
                    disease.MaBenh,
                    disease.TenBenh,
                    disease.MoTaBenh
                );
            }

            tableDisease.DataSource = table;
        }


        private void searchBarDuocPhamTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarDuocPham.Text.Trim();
            var medicines = medicineBUS.SearchMedicinesByName(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Mã Dược Phẩm", typeof(string));
            table.Columns.Add("Tên Dược Phẩm", typeof(string));
            table.Columns.Add("Loại Dược Phẩm", typeof(string));

            foreach (var med in medicines)
            {
                table.Rows.Add(
                    med.MaDP,
                    med.TenDP,
                    med.LoaiDP
                );
            }

            tableMedicine.DataSource = table;
        }

    }
}