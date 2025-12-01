using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.BenhNhan
{
    public partial class BenhNhanPage : UserControl
    {
        private string employeeId;
        private TableDataGridView tablePatient;
        private EmployeeBUS employeeBUS;
        private PatientBUS patientBUS;
        private HealthInsuranceBUS healthInsuranceBUS;
        private ServiceRegistrationBUS serviceRegistrationBUS;
        private ServiceRegistrationDetailBUS serviceRegistrationDetailBUS;
        private string oldSoCCCD = "";
        private TableDataGridView tableServiceSelected;
        private List<ServiceDTO> listServiceSelected;
        private ServiceBUS serviceBUS;

        public BenhNhanPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;

            tablePatient = new TableDataGridView();

            employeeBUS = new EmployeeBUS();
            patientBUS = new PatientBUS();
            healthInsuranceBUS = new HealthInsuranceBUS();
            serviceRegistrationBUS = new ServiceRegistrationBUS();
            serviceRegistrationDetailBUS = new ServiceRegistrationDetailBUS();
            serviceBUS = new ServiceBUS();

            listServiceSelected = new List<ServiceDTO>();

        }

        private void BenhNhanPage_Load(object sender, EventArgs e)
        {
            LoadPatientToTable();
            LoadServiceSelectedToPanel();

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
                ;
            }


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
        }

        private void buttonXacNhanBenhNhanClick(object sender, EventArgs e)
        {
            // Validate bắt buộc
            if (string.IsNullOrEmpty(txtSoCCCD.TextValue) ||
                string.IsNullOrEmpty(txtHoVaTen.TextValue) ||
                string.IsNullOrEmpty(txtNgaySinh.TextValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ CCCD, tên bệnh nhân và ngày sinh!");
                return;
            }

            if (!DateTime.TryParseExact(txtNgaySinh.TextValue, "dd-MM-yyyy",
                CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ! Vui lòng nhập theo định dạng dd-MM-yyyy (Ví dụ: 25-12-2000)");
                return;
            }

            if (ngaySinh > DateTime.Now)
            {
                MessageBox.Show("Ngày sinh không được lớn hơn ngày hiện tại!");
                return;
            }

            // Tạo DTO bệnh nhân
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

            // Tạo DTO BHYT nếu có
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
                if (patientBUS.ExistsPatient(patient.SoCCCD))
                {
                    success = patientBUS.UpdatePatient(patient, bhyt, patient.SoCCCD);
                    MessageBox.Show("Cập nhật bệnh nhân thành công!");
                }
                else
                {
                    success = patientBUS.AddPatient(patient, bhyt);
                    MessageBox.Show("Thêm bệnh nhân thành công!");
                }

                if (success)
                {
                    buttonHuyBenhNhanClick(null, null);
                    LoadPatientToTable();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void buttonHuyDangKyDichVuClick(object sender, EventArgs e)
        {
            txtMaDKDV.TextValue = serviceRegistrationBUS.GetNextServiceRegistrationId();
            txtSoCCCDBenhNhan.TextValue = "";
            txtTenBenhNhan.TextValue = "";
            txtTongChiPhi.TextValue = "";
            comboBoxHinhThucThanhToan.GetComboBox().SelectedIndex = -1;
            comboBoxTranhThaiDangKi.GetComboBox().SelectedIndex = -1;

            listServiceSelected.Clear();
            UpdateServiceSelectedTable();

        }

        // sự kiện tabPageDanhSach
        private void buttonThemBenhNhanClick(object sender, EventArgs e)
        {
            tabControlBenhNhan.SelectedTab = tabPageBenhNhan;
            buttonHuyBenhNhanClick(null, null);
        }

        private void buttonSuaBenhNhanClick(object sender, EventArgs e)
        {
            if (tablePatient.SelectedRows.Count > 0)
            {
                var row = tablePatient.SelectedRows[0];
                oldSoCCCD = row.Cells["Số CCCD"].Value?.ToString();

                var patient = patientBUS.GetPatientById(oldSoCCCD);
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
                    LoadPatientToTable(); // Cập nhật lại bảng
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
                case '2': return "95%";
                case '3': return "80%";
                case '4': return "100%";
                default: return "0%";
            }
        }

        private void UpdateServiceSelectedTable()
        {
            if (tableServiceSelected == null) return;

            var dt = new DataTable();
            dt.Columns.Add("Mã Dịch Vụ");
            dt.Columns.Add("Tên Dịch Vụ");
            dt.Columns.Add("Giá");

            foreach (var service in listServiceSelected)
            {
                dt.Rows.Add(service.MaDV, service.TenDV, service.GiaDV);
            }

            tableServiceSelected.DataSource = dt;

            if (tableServiceSelected.Columns["btnDelete"] == null)
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "btnDelete";
                btnDelete.HeaderText = "Thao tác";
                btnDelete.Text = "Xóa";
                btnDelete.UseColumnTextForButtonValue = true;
                btnDelete.Width = 80;
                tableServiceSelected.Columns.Add(btnDelete);
            }

            decimal tongChiPhiCuoiCung = 0;
            decimal phanTramBHYTChiTra = 0;

            string soCCCD = txtSoCCCDBenhNhan.TextValue.Trim();

            if (!string.IsNullOrEmpty(soCCCD))
            {
                var patient = patientBUS.GetPatientByIdOrNull(soCCCD);
                if (patient != null && !string.IsNullOrEmpty(patient.SoBHYT))
                {
                    string strMucHuong = GetMucHuongFromBHYT(patient.SoBHYT); 

                    if (!string.IsNullOrEmpty(strMucHuong) && strMucHuong.Contains("%"))
                    {
                        decimal.TryParse(strMucHuong.Replace("%", ""), out phanTramBHYTChiTra);
                        phanTramBHYTChiTra = phanTramBHYTChiTra / 100;
                    }
                }
            }

            foreach (var service in listServiceSelected)
            {
                if (decimal.TryParse(service.GiaDV, out decimal giaGoc))
                {
                    if (service.BHYTTra == "1")
                    {
                        decimal tienPhaiTra = giaGoc * (1 - phanTramBHYTChiTra);
                        tongChiPhiCuoiCung += tienPhaiTra;
                    }
                    else
                    {
                        tongChiPhiCuoiCung += giaGoc;
                    }
                }
            }

            txtTongChiPhi.TextValue = tongChiPhiCuoiCung.ToString("N0");
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
            {
                table.Rows.Add(service.MaDV, service.TenDV, service.GiaDV, service.BHYTTra);
            }

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

                if (!listServiceSelected.Any(x => x.MaDV == maDV))
                {
                    listServiceSelected.Add(service);
                    UpdateServiceSelectedTable();
                }
                else
                {
                      MessageBox.Show("Dịch vụ đã được chọn rồi!");
                }
            };

            btnClose.Click += (s, args) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        private void buttonXacNhanDangKyDichVuClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCDBenhNhan.TextValue))
            {
                MessageBox.Show("Vui lòng chọn bệnh nhân!");
                return;
            }

            if (listServiceSelected.Count == 0)
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

            if (serviceRegistrationBUS.AddServiceRegistration(registration))
            {
                foreach (var service in listServiceSelected)
                {
                    serviceRegistrationDetailBUS.AddServiceRegistrationDetail(
                        new ServiceRegistrationDetailDTO(txtMaDKDV.TextValue, service.MaDV)
                    );
                }
                MessageBox.Show("Đăng ký dịch vụ thành công!");

                buttonHuyDangKyDichVuClick(null, null);
            }
        }


        private void LoadServiceSelectedToPanel()
        {
            if (tableServiceSelected == null)
            {
                tableServiceSelected = new TableDataGridView();
                tableServiceSelected.Dock = DockStyle.Fill;
                tableServiceSelected.Height = 150;
                tableServiceSelected.ReadOnly = true;
                tableServiceSelected.AllowUserToAddRows = false;
                tableServiceSelected.AllowUserToDeleteRows = false;
                tableServiceSelected.RowHeadersVisible = false;
                tableServiceSelected.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                tableServiceSelected.MultiSelect = false;
                tableServiceSelected.CellContentClick += TableServiceSelected_CellContentClick;
                panel2.Controls.Add(tableServiceSelected);
            }

            var dt = new DataTable();
            dt.Columns.Add("Mã Dịch Vụ");
            dt.Columns.Add("Tên Dịch Vụ");
            dt.Columns.Add("Giá");
            dt.Columns.Add("Xóa");

            tableServiceSelected.DataSource = dt;
            txtTongChiPhi.TextValue = "0";
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

            UpdateServiceSelectedTable();
        }

        private void TableServiceSelected_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && tableServiceSelected.Columns[e.ColumnIndex].Name == "btnDelete")
            {
                string maDV = tableServiceSelected.Rows[e.RowIndex].Cells["Mã Dịch Vụ"].Value.ToString();

                var itemToRemove = listServiceSelected.FirstOrDefault(x => x.MaDV == maDV);
                if (itemToRemove != null)
                {
                    listServiceSelected.Remove(itemToRemove);

                    UpdateServiceSelectedTable();
                }
            }
        }

    }


}
