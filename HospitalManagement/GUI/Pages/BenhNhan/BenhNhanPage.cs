using HM.BUS;
using HM.DTO;
using HM.GUI.Component;
using HM.GUI.Component.TableDataGridView;
using System;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HM.GUI.Pages.BenhNhan
{
    public partial class BenhNhanPage : UserControl
    {
        private string employeeId;
        private TableDataGridView tablePatient;
        private TableDataGridView tableServiceRegistration;
        private TableDataGridView tableServiceOfServiceRegistration;
        private EmployeeBUS employeeBUS;
        private PatientBUS patientBUS;
        private HealthInsuranceBUS healthInsuranceBUS;
        private ServiceRegistrationBUS serviceRegistrationBUS;
        private ServiceRegistrationDetailBUS serviceRegistrationDetailBUS;
        private ServiceBUS serviceBUS;
        private MedicalBUS medicalBUS;

        public BenhNhanPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;

            tablePatient = new TableDataGridView();
            tableServiceRegistration = new TableDataGridView();
            tableServiceOfServiceRegistration = new TableDataGridView();
            tableServiceOfServiceRegistration.CellClick += TableServiceOfServiceRegistrationCellClick;

            employeeBUS = new EmployeeBUS();
            patientBUS = new PatientBUS();
            healthInsuranceBUS = new HealthInsuranceBUS();
            serviceRegistrationBUS = new ServiceRegistrationBUS();
            serviceRegistrationDetailBUS = new ServiceRegistrationDetailBUS();
            serviceBUS = new ServiceBUS();
            medicalBUS = new MedicalBUS();
        }

        private void BenhNhanPage_Load(object sender, EventArgs e)
        {
            LoadPatientToTable();
            LoadServiceRegistrationToTable();
            LoadServiceOfServiceRegistrationToTable();

            checkBoxCoBHYTCheckedChanged(checkBoxCoBHYT, EventArgs.Empty);
            txtMaDKDV.SetReadOnly(true);
            txtNhanVientaoPhieu.SetReadOnly(true);
            txtTenBenhNhan.SetReadOnly(true);
            txtNgayGioTaoPhieu.SetReadOnly(true);
            txtTongChiPhi.SetReadOnly(true);
            txtTiLeChiTra.SetReadOnly(true);

            txtMaDKDV.TextValue = serviceRegistrationBUS.GetNextServiceRegistrationId();
            txtNhanVientaoPhieu.TextValue = employeeBUS.GetEmployeeById(employeeId).TenNV;

            txtNgayGioTaoPhieu.TextValue = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            if (txtSoCCCDBenhNhan.txt != null)
            {
                txtSoCCCDBenhNhan.txt.TextChanged -= layTenBenhNhanTuCCCD;
                txtSoCCCDBenhNhan.txt.TextChanged += layTenBenhNhanTuCCCD;
            }

            comboBoxGioiTinhLoad(null, null);
            comboBoxHinhThucThanhToanLoad(null, null);
            comboBoxTrangThaiDangKyLoad(null, null);
        }

        private void LoadPatientToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Số CCCD", typeof(string));
            table.Columns.Add("Tên Bệnh Nhân", typeof(string));
            table.Columns.Add("Số BHYT", typeof(string));
            table.Columns.Add("Ngày Sinh", typeof(string));
            table.Columns.Add("Giới Tính", typeof(string));
            table.Columns.Add("Số Điện Thoại", typeof(string));

            foreach (var patient in patientBUS.GetAllPatients())
            {
                table.Rows.Add(patient.SoCCCD, patient.TenBN, patient.SoBHYT, patient.NgaySinh, patient.GioiTinh, patient.SdtBN);
            }

            tablePatient.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePatient.DataSource = table;
            benhNhanPanel.Controls.Add(tablePatient);
        }

        private void LoadServiceRegistrationToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Đăng Ký", typeof(string));
            table.Columns.Add("Bệnh Nhân", typeof(string));
            table.Columns.Add("Tổng Chi Phí", typeof(string));
            table.Columns.Add("Hình Thức Thanh Toán", typeof(string));
            table.Columns.Add("Trạng Thái Đăng Ký", typeof(string));

            foreach (var serviceRegistration in serviceRegistrationBUS.GetAllServiceRegistration())
            {
                table.Rows.Add(serviceRegistration.MaDKDV, patientBUS.GetPatientById(serviceRegistration.SoCCCD).TenBN , serviceRegistration.TongChiPhi, serviceRegistration.HinhThucThanhToan, serviceRegistration.TrangThaiDangKy);
            }

            tableServiceRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableServiceRegistration.DataSource = table;
            dangKyDichVuPanel.Controls.Add(tableServiceRegistration);
        }

        private void LoadServiceOfServiceRegistrationToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã", typeof(string));
            table.Columns.Add("Tên Dịch Vụ", typeof(string));
            table.Columns.Add("Giá", typeof(string));

            tableServiceOfServiceRegistration.AutoGenerateColumns = false;
            tableServiceOfServiceRegistration.Columns.Clear();

            DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
            btnDelete.Name = "btnDelete";
            btnDelete.HeaderText = "Xóa";
            btnDelete.Text = "Xóa";
            btnDelete.UseColumnTextForButtonValue = true;
            tableServiceOfServiceRegistration.Columns.Add(btnDelete);

            tableServiceOfServiceRegistration.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Mã", DataPropertyName = "Mã" });
            tableServiceOfServiceRegistration.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Tên Dịch Vụ", DataPropertyName = "Tên Dịch Vụ" });
            tableServiceOfServiceRegistration.Columns.Add(new DataGridViewTextBoxColumn() { Name = "Giá", DataPropertyName = "Giá" });

            tableServiceOfServiceRegistration.DataSource = table;
            tableServiceOfServiceRegistration.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;

            btnDelete.DisplayIndex = tableServiceOfServiceRegistration.Columns.Count - 1;

            dichVuDangKyPanel.Controls.Add(tableServiceOfServiceRegistration);
        }


        private void comboBoxGioiTinhLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxGioiTinh.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Nam");
                cb.Items.Add("Nữ");
            }
        }
        private void comboBoxTrangThaiDangKyLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxTranhThaiDangKi.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Chưa hoàn thành");
                cb.Items.Add("Đã hoàn thành");
                cb.Items.Add("Đã hủy");     
            }
        }

        private void comboBoxHinhThucThanhToanLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxHinhThucThanhToan.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Tiền mặt");
                cb.Items.Add("Chuyển khoản");
            }
        }

        // sự kiện tabPageBenhNhan ===========================================================================================================================================
        // sự kiện tabPageBenhNhan ===========================================================================================================================================
        private void checkBoxCoBHYTCheckedChanged(object sender, EventArgs e)
        {
            bool allowEdit = checkBoxCoBHYT.Checked;

            txtSoBHYT.SetReadOnly(!allowEdit);
            txtNgayCap.SetReadOnly(!allowEdit);
            txtNgayHetHan.SetReadOnly(!allowEdit);
        }
        private void buttonHuyBenhNhanClick(object sender, EventArgs e)
        {
            txtSoCCCD.TextValue = "";
            txtNgaySinh.TextValue = "";
            txtHoVaTen.TextValue = "";
            txtSoDienThoai.TextValue = "";
            comboBoxGioiTinh.GetComboBox().SelectedIndex = -1;
            txtDiaChi.TextValue = "";
            checkBoxCoBHYT.Checked = false;
            txtSoBHYT.TextValue = "";
            txtNgayCap.TextValue = "";
            txtNgayHetHan.TextValue = "";
            txtTiLeChiTra.TextValue = "";
            buttonXacNhanBenhNhan.Text = "Xác nhận";
            checkBoxCoBHYT.Enabled = true;
        }

        private void buttonXacNhanBenhNhanClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCD.TextValue) || string.IsNullOrEmpty(txtHoVaTen.TextValue) || string.IsNullOrEmpty(txtNgaySinh.TextValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ CCCD, tên bệnh nhân và ngày sinh!");
                return;
            }
            if (!DateTime.TryParseExact(txtNgaySinh.TextValue, "dd-MM-yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập theo định dạng dd-MM-yyyy (Ví dụ: 25-12-2000)");
                return;
            }
            if (ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!");
                return;
            }
            if (!HM.Utils.Validators.IsName(txtHoVaTen.TextValue.Trim()))
            {
                MessageBox.Show("Tên bệnh nhân không hợp lệ!");
                return;
            }

            PatientDTO patient = new PatientDTO()
            {
                SoCCCD = txtSoCCCD.TextValue.Trim(),
                TenBN = txtHoVaTen.TextValue.Trim(),
                NgaySinh = ngaySinh.ToString("dd-MM-yyyy"),
                GioiTinh = comboBoxGioiTinh.GetComboBox().SelectedItem?.ToString() ?? "",
                SdtBN = txtSoDienThoai.TextValue.Trim(),
                DiaChi = txtDiaChi.TextValue.Trim(),
                SoBHYT = checkBoxCoBHYT.Checked ? txtSoBHYT.TextValue.Trim() : ""
            };

            HealthInsuranceDTO bhyt = null;
            if (checkBoxCoBHYT.Checked)
            {
                if (string.IsNullOrEmpty(txtSoBHYT.TextValue))
                {
                    MessageBox.Show("Vui lòng nhập số BHYT!");
                    return;
                }

                bhyt = new HealthInsuranceDTO()
                {
                    SoBHYT = txtSoBHYT.TextValue.Trim(),
                    NgayCap = txtNgayCap.TextValue.Trim(),
                    NgayHetHan = txtNgayHetHan.TextValue.Trim(),
                    MucHuong = GetMucHuongFromBHYT(txtSoBHYT.TextValue.Trim()),
                    TrangThaiXoa = "0"
                };
            }

            try
            {
                bool success;

                if (buttonXacNhanBenhNhan.Text == "Lưu")
                {
                    if (tablePatient.SelectedRows.Count > 0)
                    {
                        var row = tablePatient.SelectedRows[0];
                        string oldSoCCCD = row.Cells["Số CCCD"].Value?.ToString();
                        string oldSoBHYT = row.Cells["Số BHYT"].Value?.ToString();

                        bool cccdChanged = (oldSoCCCD != patient.SoCCCD);
                        bool bhytChanged = false;

                        // KIỂM TRA THAY ĐỔI BHYT
                        if (patient.SoBHYT != oldSoBHYT)
                        {
                            bhytChanged = true;

                            // Kiểm tra BHYT mới có tồn tại chưa (trừ BHYT cũ)
                            if (!string.IsNullOrEmpty(patient.SoBHYT) && patient.SoBHYT != oldSoBHYT && healthInsuranceBUS.ExistsHealthInsurance(patient.SoBHYT))
                            {
                                MessageBox.Show($"Số BHYT {patient.SoBHYT} đã tồn tại!");
                                return;
                            }
                        }
                        else if (patient.SoBHYT == oldSoBHYT && !string.IsNullOrEmpty(oldSoBHYT))
                        {
                            bhytChanged = true;
                        }

                        if (cccdChanged)
                        {
                            // Buoc 1: kiem tra CCCD mới
                            if (patientBUS.ExistsPatient(patient.SoCCCD))
                            {
                                MessageBox.Show($"Số CCCD {patient.SoCCCD} đã tồn tại! Vui lòng nhập số CCCD khác.");
                                return;
                            }

                            DialogResult confirm = MessageBox.Show(
                                $"Bạn có chắc chắn muốn đổi số CCCD từ {oldSoCCCD} sang {patient.SoCCCD}?",
                                "Xác nhận đổi số CCCD",
                                MessageBoxButtons.YesNo,
                                MessageBoxIcon.Warning);

                            if (confirm != DialogResult.Yes)
                                return;

                            // Buoc 2: kiểm tra và cập nhật các bản ghi liên quan
                            bool hasMedicalRecords = medicalBUS.HasMedicalRecords(oldSoCCCD);
                            bool hasServiceRecords = serviceRegistrationBUS.HasServiceRecords(oldSoCCCD);
                            string updateMessage = "Cập nhật bệnh nhân";

                            if (hasMedicalRecords)
                            {
                                bool medicalUpdated = medicalBUS.UpdatePatientCCCD(oldSoCCCD, patient.SoCCCD);
                                if (!medicalUpdated)
                                {
                                    MessageBox.Show("Lỗi khi cập nhật bệnh án!");
                                    return;
                                }
                                updateMessage += " và bệnh án";
                            }

                            if (hasServiceRecords)
                            {
                                bool serviceUpdated = serviceRegistrationBUS.UpdatePatientCCCD(oldSoCCCD, patient.SoCCCD);
                                if (!serviceUpdated)
                                {
                                    MessageBox.Show("Lỗi khi cập nhật đăng ký dịch vụ!");
                                    return;
                                }
                                updateMessage += " và đăng ký dịch vụ";
                            }

                            // Buoc 3: cập nhật bệnh nhân
                            success = patientBUS.UpdatePatient(patient, oldSoCCCD);

                            // Buoc 4: xử lý BHYT nếu có thay đổi
                            if (success && bhytChanged)
                            {
                                ProcessBHYTUpdate(bhyt, oldSoBHYT, checkBoxCoBHYT.Checked);
                            }

                            if (success)
                            {
                                updateMessage += " thành công!";
                                MessageBox.Show(updateMessage);
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi cập nhật thông tin bệnh nhân!");
                                return;
                            }
                        }
                        else
                        {
                            // Chỉ thay đổi thông tin khác (không đổi CCCD)
                            success = patientBUS.UpdatePatient(patient, oldSoCCCD);

                            // Xử lý BHYT nếu có thay đổi
                            if (success && bhytChanged)
                            {
                                ProcessBHYTUpdate(bhyt, oldSoBHYT, checkBoxCoBHYT.Checked);
                            }

                            if (success)
                            {
                                MessageBox.Show("Cập nhật bệnh nhân thành công!");
                            }
                            else
                            {
                                MessageBox.Show("Lỗi khi cập nhật thông tin bệnh nhân!");
                                return;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy bệnh nhân cần cập nhật!");
                        return;
                    }
                }
                else // them
                {
                    if (patientBUS.ExistsPatient(patient.SoCCCD))
                    {
                        MessageBox.Show($"Số CCCD {patient.SoCCCD} đã tồn tại! ");
                        return;
                    }

                    if (checkBoxCoBHYT.Checked && !string.IsNullOrEmpty(patient.SoBHYT))
                    {
                        if (healthInsuranceBUS.ExistsHealthInsurance(patient.SoBHYT))
                        {
                            MessageBox.Show($"Số BHYT {patient.SoBHYT} đã tồn tại!");
                            return;
                        }
                    }

                    success = patientBUS.AddPatient(patient, bhyt);
                    if (success)
                    {
                        MessageBox.Show("Thêm bệnh nhân thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Lỗi khi thêm bệnh nhân!");
                        return;
                    }
                }

                if (success)
                {
                    buttonHuyBenhNhanClick(null, null);
                    LoadPatientToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // PHƯƠNG THỨC XỬ LÝ BHYT RIÊNG
        private void ProcessBHYTUpdate(HealthInsuranceDTO bhyt, string oldSoBHYT, bool hasBHYT)
        {
            try
            {
                if (hasBHYT)
                {
                    if (string.IsNullOrEmpty(oldSoBHYT))
                        healthInsuranceBUS.AddHealthInsurance(bhyt);
                    else
                        healthInsuranceBUS.UpdateHealthInsurance(bhyt, oldSoBHYT);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xử lý BHYT: {ex.Message}", "Lỗi BHYT", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // sự kiện tabPageDanhSachBenhNhan ====================================================================================================================
        // sự kiện tabPageDanhSachBenhNhan ====================================================================================================================
        private void buttonThemBenhNhanClick(object sender, EventArgs e)
        {
            tabControlBenhNhan.SelectedTab = tabPageBenhNhan;
            buttonHuyBenhNhanClick(null, null);
            buttonXacNhanBenhNhan.Text = "Xác nhận";
            checkBoxCoBHYT.Enabled = true;
        }

        private void buttonSuaBenhNhanClick(object sender, EventArgs e)
        {
            if (tablePatient.SelectedRows.Count > 0)
            {
                var row = tablePatient.SelectedRows[0];
                string soCCCD = row.Cells["Số CCCD"].Value?.ToString();
                buttonXacNhanBenhNhan.Text = "Lưu";

                var patient = patientBUS.GetPatientById(soCCCD);
                if (patient != null)
                {
                    // Đổ dữ liệu vào form
                    txtSoCCCD.TextValue = patient.SoCCCD;
                    txtHoVaTen.TextValue = patient.TenBN;
                    txtNgaySinh.TextValue = patient.NgaySinh;
                    comboBoxGioiTinh.GetComboBox().SelectedItem = patient.GioiTinh;
                    txtSoDienThoai.TextValue = patient.SdtBN;
                    txtDiaChi.TextValue = patient.DiaChi;

                    // BHYT
                    if (!string.IsNullOrEmpty(patient.SoBHYT))
                    {
                        checkBoxCoBHYT.Checked = true;
                        checkBoxCoBHYT.Enabled = false;

                        var bhyt = healthInsuranceBUS.GetHealthInsuranceByID(patient.SoBHYT);

                        txtSoBHYT.TextValue = bhyt?.SoBHYT ?? "";
                        txtNgayCap.TextValue = bhyt?.NgayCap ?? "";
                        txtNgayHetHan.TextValue = bhyt?.NgayHetHan ?? "";
                        txtTiLeChiTra.TextValue = bhyt?.MucHuong ?? "";
                    }
                    else
                    {
                        checkBoxCoBHYT.Checked = false;
                        txtSoBHYT.TextValue = "";
                        txtNgayCap.TextValue = "";
                        txtNgayHetHan.TextValue = "";
                        txtTiLeChiTra.TextValue = "";
                    }
                    tabControlBenhNhan.SelectedTab = tabPageBenhNhan;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy bệnh nhân!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần sửa!");
            }
        }


        private void buttonXoaBenhNhanClick(object sender, EventArgs e)
        {
            if (tablePatient.SelectedRows.Count > 0)
            {
                string soCCCD = tablePatient.SelectedRows[0].Cells["Số CCCD"].Value?.ToString();
                
                    var patient = patientBUS.GetPatientById(soCCCD);

                    if (!string.IsNullOrEmpty(patient.SoBHYT))
                    {
                        healthInsuranceBUS.DeleteHealthInsurance(patient.SoBHYT);
                    }
                    patientBUS.DeletePatient(soCCCD);
                    buttonHuyBenhNhanClick(null, null);
                    LoadPatientToTable(); 
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân cần xóa!");
            }
        }

        private string GetMucHuongFromBHYT(string soBHYT)
        {
            if (string.IsNullOrEmpty(soBHYT) || soBHYT.Length < 3)
                return "0%";

            char kiTuThu3 = soBHYT[2];

            switch (kiTuThu3)
            {
                case '1': return "100%";
                case '2': return "100%";
                case '3': return "95%";
                case '4': return "80%";
                default: return "0%";
            }
        }

        // sự kiện tabPageDangKyDichVu ====================================================================================================================
        // sự kiện tabPageDangKyDichVu ====================================================================================================================
        private void buttonHuyDangKyDichVuClick(object sender, EventArgs e)
        {
            txtMaDKDV.TextValue = serviceRegistrationBUS.GetNextServiceRegistrationId();
            txtSoCCCDBenhNhan.TextValue = "";
            txtTenBenhNhan.TextValue = "";
            txtTongChiPhi.TextValue = "";
            comboBoxHinhThucThanhToan.GetComboBox().SelectedIndex = -1;
            comboBoxTranhThaiDangKi.GetComboBox().SelectedIndex = -1;
            LoadServiceOfServiceRegistrationToTable();
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
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ!");
                    return;
                }

                string maDV = dgv.SelectedRows[0].Cells["Mã Dịch Vụ"].Value.ToString();
                string tenDV = dgv.SelectedRows[0].Cells["Tên Dịch Vụ"].Value.ToString();
                string giaDV = dgv.SelectedRows[0].Cells["Giá Dịch Vụ"].Value.ToString();
                string bhytTra = dgv.SelectedRows[0].Cells["Bảo hiểm chi trả"].Value.ToString();

                // Kiểm tra xem dịch vụ đã được chọn chưa
                DataTable currentTable = (DataTable)tableServiceOfServiceRegistration.DataSource;
                foreach (DataRow row in currentTable.Rows)
                {
                    if (row["Mã"].ToString() == maDV)
                    {
                        MessageBox.Show("Dịch vụ đã được chọn rồi!");
                        return;
                    }
                }

                // Tính giá đã được tính theo BHYT
                decimal giaGoc;
                if (decimal.TryParse(giaDV, out giaGoc))
                {
                    decimal giaDaTinh = CalculateServicePrice(giaGoc, bhytTra == "1", maDV);
                    // Hiển thị giá đã được tính trong bảng
                    currentTable.Rows.Add(maDV, tenDV, giaDaTinh.ToString("0"));
                    // Tính lại tổng chi phí
                    CalculateTotalCost();

                    popup.Close();
                }
                else
                {
                    MessageBox.Show("Giá dịch vụ không hợp lệ!");
                }
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private decimal CalculateServicePrice(decimal giaGoc, bool bhytChiTra, string maDV)
        {
            // Kiểm tra BHYT của bệnh nhân
            string soCCCD = txtSoCCCDBenhNhan.TextValue.Trim();

            if (!string.IsNullOrEmpty(soCCCD) && bhytChiTra)
            {
                var patient = patientBUS.GetPatientByIdOrNull(soCCCD);
                if (patient != null && !string.IsNullOrEmpty(patient.SoBHYT))
                {
                    string strMucHuong = GetMucHuongFromBHYT(patient.SoBHYT);

                    if (!string.IsNullOrEmpty(strMucHuong) && strMucHuong.Contains("%"))
                    {
                        decimal phanTramBHYTChiTra;
                        if (decimal.TryParse(strMucHuong.Replace("%", ""), out phanTramBHYTChiTra))
                        {
                            phanTramBHYTChiTra = phanTramBHYTChiTra / 100;

                            // Nếu BHYT chi trả 100% thì giá là 0
                            if (phanTramBHYTChiTra >= 1)
                            {
                                return 0;
                            }
                            else
                            {
                                // Tính giá sau khi được BHYT chi trả
                                return giaGoc * (1 - phanTramBHYTChiTra);
                            }
                        }
                    }
                }
            }

            // Trả về giá gốc nếu không có BHYT hoặc dịch vụ không được BHYT chi trả
            return giaGoc;
        }

        private void CalculateTotalCost()
        {
            DataTable serviceTable = (DataTable)tableServiceOfServiceRegistration.DataSource;
            decimal tongChiPhiCuoiCung = 0;

            // Tính tổng chi phí từ DataTable (giá đã được tính theo BHYT)
            foreach (DataRow row in serviceTable.Rows)
            {
                if (decimal.TryParse(row["Giá"].ToString(), out decimal giaDaTinh)
)
                {
                    tongChiPhiCuoiCung += giaDaTinh;
                }
            }

            txtTongChiPhi.TextValue = tongChiPhiCuoiCung.ToString();
        }
        private void TableServiceOfServiceRegistrationCellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tableServiceOfServiceRegistration.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                DataTable serviceTable = (DataTable)tableServiceOfServiceRegistration.DataSource;
                serviceTable.Rows.RemoveAt(e.RowIndex);

                CalculateTotalCost();
            }
        }

        private void buttonXacNhanDangKyDichVuClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCDBenhNhan.TextValue))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
                return;
            }

            DataTable serviceTable = (DataTable)tableServiceOfServiceRegistration.DataSource;
            if (serviceTable.Rows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn dịch vụ!");
                return;
            }

            var registration = new ServiceRegistrationDTO()
            {
                MaDKDV = txtMaDKDV.TextValue,
                SoCCCD = txtSoCCCDBenhNhan.TextValue,
                NgayGioTaoPhieu = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss"),
                TongChiPhi = txtTongChiPhi.TextValue,
                HinhThucThanhToan = comboBoxHinhThucThanhToan.GetComboBox().SelectedItem?.ToString(),
                TrangThaiDangKy = comboBoxTranhThaiDangKi.GetComboBox().SelectedItem?.ToString(),
                MaNV = employeeId
            };

            if (!serviceRegistrationBUS.ExistsServiceRegistrationId(registration.MaDKDV))
            {
                // Trường hợp 1: Mã chưa tồn tại - Thêm mới
                if (serviceRegistrationBUS.AddServiceRegistration(registration))
                {
                    foreach (DataRow row in serviceTable.Rows)
                    {
                        string maDV = row["Mã"].ToString();
                        string tienDV = row["Giá"].ToString();
                        serviceRegistrationDetailBUS.AddServiceRegistrationDetail(
                            new ServiceRegistrationDetailDTO(txtMaDKDV.TextValue, maDV, tienDV)
                        );
                    }

                    MessageBox.Show("Đăng ký dịch vụ thành công!");
                    buttonHuyDangKyDichVuClick(null, null);
                    LoadServiceRegistrationToTable();
                }
                else
                {
                    MessageBox.Show("Đăng ký dịch vụ thất bại!");
                }
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    $"Mã đăng ký dịch vụ {registration.MaDKDV} đã tồn tại!\nBạn có muốn cập nhật thông tin không?",
                    "Xác nhận cập nhật",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Cập nhật đăng ký dịch vụ
                    if (serviceRegistrationBUS.UpdateServiceRegistration(registration))
                    {
                        // Xóa tất cả chi tiết dịch vụ cũ
                        serviceRegistrationDetailBUS.DeleteAllServiceRegistrationDetailByRegistrationId(registration.MaDKDV);

                        // Thêm lại chi tiết dịch vụ mới
                        foreach (DataRow row in serviceTable.Rows)
                        {
                            string maDV = row["Mã"].ToString();
                            string tienDV = row["Giá"].ToString();
                            serviceRegistrationDetailBUS.AddServiceRegistrationDetail(
                                new ServiceRegistrationDetailDTO(txtMaDKDV.TextValue, maDV, tienDV)
                            );
                        }

                        MessageBox.Show("Cập nhật đăng ký dịch vụ thành công!");
                        buttonHuyDangKyDichVuClick(null, null);
                        LoadServiceRegistrationToTable();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đăng ký dịch vụ thất bại!");
                    }
                }
            }
        }


        private void layTenBenhNhanTuCCCD(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCDBenhNhan.TextValue.Trim();

            if (!string.IsNullOrEmpty(soCCCD))
            {
                var patient = patientBUS.GetPatientByIdOrNull(soCCCD);
                if (patient != null)
                {
                    txtTenBenhNhan.TextValue = patient.TenBN;
                }
                else
                {
                    txtTenBenhNhan.TextValue = "";
                }
            }
            else
            {
                txtTenBenhNhan.TextValue = "";
            }
            CalculateTotalCost();
        }



        // sự kiện tabPageDanhSachDangKyDichVu ====================================================================================================================
        // sự kiện tabPageDanhSachDangKyDichVu ====================================================================================================================
        private void buttonThemDangKyDichVuClick(object sender, EventArgs e)
        {
            tabControlBenhNhan.SelectedTab = tabPageDangKyDichVu;
            buttonHuyDangKyDichVuClick(null, null);
        }

        private void buttonSuaDangKyDichVuClick(object sender, EventArgs e)
        {
            if (tableServiceRegistration.SelectedRows.Count > 0)
            {
                var row = tableServiceRegistration.SelectedRows[0];
                string maDKDV = row.Cells["Mã Đăng Ký"].Value?.ToString();

                var serviceRegistration = serviceRegistrationBUS.GetServiceRegistrationById(maDKDV);
                if (serviceRegistration != null)
                {
                    var patient = patientBUS.GetPatientById(serviceRegistration.SoCCCD);
                    if (patient != null)
                    {
                        // Đổ dữ liệu vào form
                        txtMaDKDV.TextValue = serviceRegistration.MaDKDV;
                        txtSoCCCDBenhNhan.TextValue = serviceRegistration.SoCCCD;
                        txtTenBenhNhan.TextValue = patient.TenBN;
                        txtNgayGioTaoPhieu.TextValue = serviceRegistration.NgayGioTaoPhieu;
                        txtTongChiPhi.TextValue = serviceRegistration.TongChiPhi;

                        comboBoxHinhThucThanhToan.GetComboBox().Text = serviceRegistration.HinhThucThanhToan;
                        comboBoxTranhThaiDangKi.GetComboBox().Text = serviceRegistration.TrangThaiDangKy;

                        // Load danh sách dịch vụ đã chọn
                        DataTable serviceTable = (DataTable)tableServiceOfServiceRegistration.DataSource;
                        serviceTable.Rows.Clear();

                        var serviceDetails = serviceRegistrationDetailBUS.GetServiceRegistrationDetailByServiceRegistrationId(maDKDV);
                        foreach (var detail in serviceDetails)
                        {
                            var service = serviceBUS.GetServiceById(detail.MaDV);
                            if (service != null)
                            {
                                serviceTable.Rows.Add(detail.MaDV, service.TenDV, detail.TienDV);
                            }
                        }
                        tabControlBenhNhan.SelectedTab = tabPageDangKyDichVu;
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin bệnh nhân!");
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đăng ký dịch vụ!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đăng ký dịch vụ cần sửa!");
            }
        }

        private void buttonXoaDangKyDichVuClick(object sender, EventArgs e)
        {
            if (tableServiceRegistration.SelectedRows.Count > 0)
            {
                string maDKDV = tableServiceRegistration.SelectedRows[0].Cells["Mã Đăng Ký"].Value?.ToString();

                if (string.IsNullOrEmpty(maDKDV))
                {
                    MessageBox.Show("Không tìm thấy mã đăng ký dịch vụ!");
                    return;
                }

                DialogResult result = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa đăng ký dịch vụ {maDKDV}?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        bool success = serviceRegistrationBUS.DeleteServiceRegistration(maDKDV);

                        if (success)
                        {
                            MessageBox.Show("Xóa đăng ký dịch vụ thành công!");
                            LoadServiceRegistrationToTable();

                            if (tabControlBenhNhan.SelectedTab == tabPageDangKyDichVu &&
                                txtMaDKDV.TextValue == maDKDV)
                            {
                                buttonHuyDangKyDichVuClick(null, null);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Xóa đăng ký dịch vụ thất bại!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi xóa đăng ký dịch vụ: {ex.Message}",
                            "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn đăng ký dịch vụ cần xóa!");
            }
        }

        // search ======================================================================================================================================
        // search ======================================================================================================================================
        private void searchBarBenhNhanTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarBenhNhan.Text.Trim();
            var patient = patientBUS.SearchPatient(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Số CCCD", typeof(string));
            table.Columns.Add("Tên Bệnh Nhân", typeof(string));
            table.Columns.Add("Số BHYT", typeof(string));
            table.Columns.Add("Ngày Sinh", typeof(string));
            table.Columns.Add("Giới Tính", typeof(string));
            table.Columns.Add("Số Điện Thoại", typeof(string));

            foreach (var p in patient)
            {
                table.Rows.Add(p.SoCCCD, p.TenBN, p.SoBHYT, p.NgaySinh, p.GioiTinh, p.SdtBN);
            }
            tablePatient.DataSource = table;
        }
        private void searchBarDangKyDichVuTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarDangKyDichVu.Text.Trim();
            var serviceRegistration = serviceRegistrationBUS.SearchServiceRegistrationByName(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Mã Đăng Ký", typeof(string));
            table.Columns.Add("Bệnh Nhân", typeof(string));
            table.Columns.Add("Tổng Chi Phí", typeof(string));
            table.Columns.Add("Hình Thức Thanh Toán", typeof(string));
            table.Columns.Add("Trạng Thái Đăng Ký", typeof(string));

            foreach (var sr in serviceRegistration)
            {
                table.Rows.Add(sr.MaDKDV, patientBUS.GetPatientById(sr.SoCCCD).TenBN, sr.TongChiPhi, sr.HinhThucThanhToan, sr.TrangThaiDangKy);
            }

            tableServiceRegistration.DataSource = table;
        }
    }
}
