using HM.BUS;
using HM.DTO;
using HM.GUI.Component;
using HM.GUI.Component.TableDataGridView;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace HM.GUI.Pages.BenhNhan
{
    public partial class BenhNhanPage : UserControl
    {
        private string employeeId;
        private string functionId = "CN0002";
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
        private AccountBUS accountBUS;
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
            accountBUS = new AccountBUS();
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
                txtSoCCCDBenhNhan.txt.TextChanged -= getPatientNameByCCCD;
                txtSoCCCDBenhNhan.txt.TextChanged += getPatientNameByCCCD;
            }

            if (txtSoBHYT.txt != null) {
                txtSoBHYT.txt.TextChanged -= getBenefitByBHYT;
                txtSoBHYT.txt.TextChanged += getBenefitByBHYT;
            }

            comboBoxGioiTinhLoad(null, null);
            comboBoxHinhThucThanhToanLoad(null, null);
            comboBoxTrangThaiDangKyLoad(null, null);

            applyPermissions(accountBUS.GetAccountByEmployeeId(employeeId).TenDangNhap, functionId);
        }

        private void applyPermissions(string username, string maCN)
        {
            if (!accountBUS.HasPermission(username, maCN, "add"))
            {
                tableToolBoxBenhNhan.ColumnStyles[1].Width = 0;
                tableToolBoxBenhNhan.ColumnStyles[2].Width = 0f;
                tableToolBoxDangKyDichVu.ColumnStyles[1].Width = 0;
                tableToolBoxDangKyDichVu.ColumnStyles[2].Width = 0f;
            }
            if (!accountBUS.HasPermission(username, maCN, "edit"))
            {
                tableToolBoxBenhNhan.ColumnStyles[3].Width = 0;
                tableToolBoxBenhNhan.ColumnStyles[4].Width = 0f;
                tableToolBoxDangKyDichVu.ColumnStyles[3].Width = 0;
                tableToolBoxDangKyDichVu.ColumnStyles[4].Width = 0f;
            }
            if (!accountBUS.HasPermission(username, maCN, "delete"))
            {
                tableToolBoxBenhNhan.ColumnStyles[5].Width = 0;
                tableToolBoxBenhNhan.ColumnStyles[6].Width = 0f;
                tableToolBoxDangKyDichVu.ColumnStyles[5].Width = 0;
                tableToolBoxDangKyDichVu.ColumnStyles[6].Width = 0f;
            }
        }
        private bool CheckPermissionForXacNhan(bool isNewRecord)
        {
            string username = accountBUS.GetAccountByEmployeeId(employeeId).TenDangNhap;
            string action = isNewRecord ? "add" : "edit";

            if (!accountBUS.HasPermission(username, functionId, action))
            {
                string message = isNewRecord ? "thêm mới" : "sửa";
                MessageBox.Show($"Bạn không có quyền {message}!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
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
            bool isNewPatient = buttonXacNhanBenhNhan.Text == "Xác nhận";
            if (!CheckPermissionForXacNhan(isNewPatient))
            {
                return;
            }

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

                if (string.IsNullOrEmpty(txtTiLeChiTra.TextValue))
                {
                    MessageBox.Show("Sô BHYT không hợp lệ kiểm tra lại kí tự thứ 3!");
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

        private void getBenefitByBHYT(object sender, EventArgs e)
        {
            string soBHYT = txtSoBHYT.TextValue.Trim();

            if (!string.IsNullOrEmpty(soBHYT))
            {
                if (soBHYT.Length >= 3)
                {
                    char kyTuThuBa = soBHYT[2];

                    if (kyTuThuBa == '1' || kyTuThuBa == '2')
                        txtTiLeChiTra.TextValue = "100%";
                    else if (kyTuThuBa == '3')
                        txtTiLeChiTra.TextValue = "95%";
                    else if (kyTuThuBa == '4')
                        txtTiLeChiTra.TextValue = "85%";
                    else
                        txtTiLeChiTra.TextValue = "";
                }
                else
                {
                    txtTiLeChiTra.TextValue = "";
                }
            }
            else
            {
                txtTiLeChiTra.TextValue = "";
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
            popup.Size = new System.Drawing.Size(900, 500);
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
            panelButtons.BackColor = System.Drawing.Color.White;
            panelButtons.FlowDirection = FlowDirection.RightToLeft;

            RoundedLabel btnAdd = new RoundedLabel();
            btnAdd.Text = "Chọn";
            btnAdd.AutoSize = false;
            btnAdd.Size = new System.Drawing.Size(100, 35);
            btnAdd.BackColor = System.Drawing.Color.White;
            btnAdd.PanelColor = System.Drawing.Color.FromArgb(52, 211, 153);

            RoundedLabel btnClose = new RoundedLabel();
            btnClose.Text = "Đóng";
            btnClose.AutoSize = false;
            btnClose.Size = new System.Drawing.Size(100, 35);
            btnClose.BackColor = System.Drawing.Color.White;
            btnClose.PanelColor = System.Drawing.Color.FromArgb(255, 90, 93);

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
                    // Lấy thông tin BHYT từ bảng HealthInsurance
                    var bhytInfo = healthInsuranceBUS.GetHealthInsuranceByID(patient.SoBHYT);

                    if (bhytInfo != null)
                    {
                        // KIỂM TRA BHYT CÒN HẠN KHÔNG
                        if (!string.IsNullOrEmpty(bhytInfo.NgayHetHan))
                        {
                            try
                            {
                                DateTime ngayHetHan = DateTime.ParseExact(bhytInfo.NgayHetHan, "dd-MM-yyyy", null);
                                if (ngayHetHan < DateTime.Now)
                                {
                                    MessageBox.Show($"Bảo hiểm y tế của bệnh nhân đã hết hạn (hết hạn ngày {bhytInfo.NgayHetHan}).\nDịch vụ sẽ được tính giá gốc.",
                                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    return giaGoc;
                                }
                            }
                            catch (FormatException)
                            {
                                MessageBox.Show("Định dạng ngày hết hạn BHYT không hợp lệ. Vui lòng kiểm tra lại.",
                                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return giaGoc;
                            }
                        }

                        if (!string.IsNullOrEmpty(bhytInfo.MucHuong) && bhytInfo.MucHuong.Contains("%"))
                        {
                            decimal phanTramBHYTChiTra;
                            if (decimal.TryParse(bhytInfo.MucHuong.Replace("%", ""), out phanTramBHYTChiTra))
                            {
                                phanTramBHYTChiTra = phanTramBHYTChiTra / 100;
                                if (phanTramBHYTChiTra >= 1)
                                    return 0;
                                else
                                    return giaGoc * (1 - phanTramBHYTChiTra);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Không tìm thấy thông tin BHYT trong hệ thống. Dịch vụ được tính giá gốc.",
                            "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (patient != null && string.IsNullOrEmpty(patient.SoBHYT))
                {
                    MessageBox.Show("Bệnh nhân không có Bảo hiểm y tế.\nDịch vụ sẽ được tính giá gốc.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            return giaGoc;
        }

        private void CalculateTotalCost()
        {
            DataTable serviceTable = (DataTable)tableServiceOfServiceRegistration.DataSource;
            decimal tongChiPhiCuoiCung = 0;

            foreach (DataRow row in serviceTable.Rows)
                if (decimal.TryParse(row["Giá"].ToString(), out decimal giaDaTinh))
                    tongChiPhiCuoiCung += giaDaTinh;
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
            bool isNewServiceRegistration = !serviceRegistrationBUS.ExistsServiceRegistrationId(txtMaDKDV.TextValue.Trim());
            if (!CheckPermissionForXacNhan(isNewServiceRegistration))
            {
                return;
            }

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
                    if (serviceRegistrationBUS.UpdateServiceRegistration(registration))
                    {
                        serviceRegistrationDetailBUS.DeleteAllServiceRegistrationDetailByRegistrationId(registration.MaDKDV);
                        foreach (DataRow row in serviceTable.Rows)
                        {
                            string maDV = row["Mã"].ToString();
                            string tienDV = row["Giá"].ToString();
                            serviceRegistrationDetailBUS.AddServiceRegistrationDetail(
                                new ServiceRegistrationDetailDTO(txtMaDKDV.TextValue, maDV, tienDV)
                            );
                        }
                        MessageBox.Show("Cập nhật đăng ký dịch vụ thành công!");
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật đăng ký dịch vụ thất bại!");
                    }
                }
            }
            buttonHuyDangKyDichVuClick(null, null);
            LoadServiceRegistrationToTable();
            ExportServiceRegistrationToPDF(registration);
        }

        private void ExportServiceRegistrationToPDF(ServiceRegistrationDTO dto)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF file|*.pdf";
                saveFile.FileName = $"PhieuDangKyDichVu_{dto.MaDKDV}.pdf";

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                BaseFont baseFont = File.Exists(fontPath)
                    ? BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
                    : BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                Font titleFont = new Font(baseFont, 18);
                Font headerFont = new Font(baseFont, 12);
                Font contentFont = new Font(baseFont, 12);
                Font smallFont = new Font(baseFont, 10);

                using (var fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document doc = new Document(PageSize.A4, 50, 50, 50, 50);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    Paragraph hospitalHeader = new Paragraph("BỆNH VIỆN ĐA KHOA NHÓM 7", headerFont);
                    hospitalHeader.Alignment = Element.ALIGN_CENTER;
                    doc.Add(hospitalHeader);

                    doc.Add(new Paragraph("\n"));

                    Paragraph title = new Paragraph("PHIẾU ĐĂNG KÝ DỊCH VỤ", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("\n"));

                    var patient = patientBUS.GetPatientById(dto.SoCCCD);
                    var employee = employeeBUS.GetEmployeeById(dto.MaNV);

                    var serviceDetails = serviceRegistrationDetailBUS.GetServiceRegistrationDetailByServiceRegistrationId(dto.MaDKDV);
                    var services = new List<ServiceDTO>();
                    decimal totalAmount = 0;

                    foreach (var detail in serviceDetails)
                    {
                        var service = serviceBUS.GetServiceById(detail.MaDV);
                        if (service != null)
                        {
                            services.Add(service);
                            if (decimal.TryParse(service.GiaDV, out decimal price))
                            {
                                totalAmount += price;
                            }
                        }
                    }

                    PdfPTable infoTable = new PdfPTable(2);
                    infoTable.WidthPercentage = 100;
                    infoTable.SpacingBefore = 10f;
                    infoTable.SpacingAfter = 10f;

                    AddCellToTable(infoTable, "Mã phiếu đăng ký dịch vụ:", dto.MaDKDV, headerFont, contentFont);
                    AddCellToTable(infoTable, "Ngày tạo phiếu:", dto.NgayGioTaoPhieu, headerFont, contentFont);
                    AddCellToTable(infoTable, "Bệnh nhân:", patient?.TenBN ?? "N/A", headerFont, contentFont);
                    AddCellToTable(infoTable, "Số CCCD:", dto.SoCCCD, headerFont, contentFont);
                    AddCellToTable(infoTable, "Nhân viên tạo phiếu:", employee?.TenNV ?? "N/A", headerFont, contentFont);
                    AddCellToTable(infoTable, "Hình thức thanh toán:", dto.HinhThucThanhToan ?? "Chưa xác định", headerFont, contentFont);

                    doc.Add(infoTable);

                    // Bảng danh sách dịch vụ
                    if (services.Count > 0)
                    {
                        doc.Add(new Paragraph("\n"));
                        Paragraph serviceTitle = new Paragraph("DANH SÁCH DỊCH VỤ ĐÃ ĐĂNG KÝ", headerFont);
                        serviceTitle.Alignment = Element.ALIGN_CENTER;
                        doc.Add(serviceTitle);
                        doc.Add(new Paragraph("\n"));

                        PdfPTable serviceTable = new PdfPTable(4);
                        serviceTable.WidthPercentage = 100;
                        serviceTable.SpacingBefore = 10f;
                        serviceTable.SpacingAfter = 10f;

                        // Header cho bảng dịch vụ
                        AddServiceTableHeader(serviceTable, "STT", headerFont);
                        AddServiceTableHeader(serviceTable, "Mã dịch vụ", headerFont);
                        AddServiceTableHeader(serviceTable, "Tên dịch vụ", headerFont);
                        AddServiceTableHeader(serviceTable, "Đơn giá", headerFont);

                        // Thêm dữ liệu dịch vụ
                        for (int i = 0; i < services.Count; i++)
                        {
                            var service = services[i];
                            AddServiceTableCell(serviceTable, (i + 1).ToString(), contentFont);
                            AddServiceTableCell(serviceTable, service.MaDV, contentFont);
                            AddServiceTableCell(serviceTable, service.TenDV, contentFont);
                            AddServiceTableCell(serviceTable, FormatCurrency(service.GiaDV), contentFont);
                        }

                        AddServiceTableCell(serviceTable, "", contentFont);
                        AddServiceTableCell(serviceTable, "", contentFont);
                        AddServiceTableCell(serviceTable, "TỔNG CỘNG:", headerFont);
                        AddServiceTableCell(serviceTable, FormatCurrency(totalAmount.ToString()), headerFont);

                        doc.Add(serviceTable);
                    }

                    PdfPTable paymentTable = new PdfPTable(2);
                    paymentTable.WidthPercentage = 100;
                    paymentTable.SpacingBefore = 10f;

                    AddCellToTable(paymentTable, "Tổng chi phí phải trả:", FormatCurrency(dto.TongChiPhi), headerFont, contentFont);

                    doc.Add(paymentTable);


                    // Phần chữ ký
                    doc.Add(new Paragraph("\n\n\n"));

                    PdfPTable signatureTable = new PdfPTable(3);
                    signatureTable.WidthPercentage = 100;
                    signatureTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                    signatureTable.AddCell(new Phrase("", contentFont));

                    PdfPCell patientCell = new PdfPCell(new Phrase("Bệnh nhân/ Người đại diện\n(Ký và ghi rõ họ tên)", contentFont));
                    patientCell.Border = PdfPCell.NO_BORDER;
                    patientCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    signatureTable.AddCell(patientCell);

                    PdfPCell staffCell = new PdfPCell(new Phrase("Nhân viên tiếp nhận\n(Ký và ghi rõ họ tên)", contentFont));
                    staffCell.Border = PdfPCell.NO_BORDER;
                    staffCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    signatureTable.AddCell(staffCell);

                    doc.Add(signatureTable);

                    doc.Close();
                }

                MessageBox.Show("Đã xuất phiếu đăng ký dịch vụ ra file PDF!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo PDF: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string FormatCurrency(string amount)
        {
            if (decimal.TryParse(amount, out decimal value))
            {
                return value.ToString("N0") + " VNĐ";
            }
            return amount;
        }

        private void AddServiceTableHeader(PdfPTable table, string text, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.BorderWidth = 0.5f;
            cell.Padding = 5f;
            cell.BackgroundColor = new BaseColor(220, 220, 220);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
        }

        private void AddServiceTableCell(PdfPTable table, string text, Font font)
        {
            PdfPCell cell = new PdfPCell(new Phrase(text, font));
            cell.BorderWidth = 0.5f;
            cell.Padding = 5f;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            table.AddCell(cell);
        }

        private void AddCellToTable(PdfPTable table, string label, string value, Font labelFont, Font valueFont)
        {
            PdfPCell labelCell = new PdfPCell(new Phrase(label, labelFont));
            labelCell.BorderWidth = 0.5f;
            labelCell.Padding = 5f;
            labelCell.BackgroundColor = new BaseColor(245, 245, 245);
            table.AddCell(labelCell);

            PdfPCell valueCell = new PdfPCell(new Phrase(value, valueFont));
            valueCell.BorderWidth = 0.5f;
            valueCell.Padding = 5f;
            table.AddCell(valueCell);
        }

        private void getPatientNameByCCCD(object sender, EventArgs e)
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
