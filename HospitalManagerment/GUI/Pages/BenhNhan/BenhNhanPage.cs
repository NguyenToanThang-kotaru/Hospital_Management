using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
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
        private bool isEditMode = false;
        private string oldSoCCCD = "";
        private TableDataGridView tableServiceAll; 
        private TableDataGridView tableServiceSelected; 
        private List<ServiceDTO> listServiceSelected = new List<ServiceDTO>(); 
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
            txtNhanVientaoPhieu.TextValue = employeeBUS.GetEmployeeByID(employeeId).TenNV;

            txtNgayGioTaoPhieu.TextValue = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            if (txtSoCCCDBenhNhan.txt != null)
            {
                txtSoCCCDBenhNhan.txt.TextChanged -= layTenBenhNhanTuCCCD;
                txtSoCCCDBenhNhan.txt.TextChanged += layTenBenhNhanTuCCCD;
                ;
            }


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

            if (!DateTime.TryParse(txtNgaySinh.TextValue, out DateTime ngaySinh))
            {
                MessageBox.Show("Ngày sinh không hợp lệ!");
                return;
            }

            // Tạo DTO bệnh nhân
            PatientDTO patient = new PatientDTO()
            {
                SoCCCD = txtSoCCCD.TextValue.Trim(),
                TenBN = txtHoVaTen.TextValue.Trim(),
                NgaySinh = ngaySinh.ToString("yyyy-MM-dd"),
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

            // Lưu bệnh nhân
            bool success;

            try
            {
                if (isEditMode)
                {
                    success = patientBUS.UpdatePatient(patient, bhyt, oldSoCCCD);
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
                    isEditMode = false; // reset
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
                oldSoCCCD = row.Cells["SoCCCD"].Value?.ToString();
                isEditMode = true;

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

                    // Chuyển sang tab "Bệnh nhân"
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
                string soCCCD = tablePatient.SelectedRows[0].Cells["SoCCCD"].Value?.ToString();
                //var result = MessageBox.Show("Bạn có chắc muốn xóa bệnh nhân này?", "Xác nhận", MessageBoxButtons.YesNo);
                //if (result == DialogResult.Yes)
                
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

        private void ShowServiceSelectionDialog()
        {
            // Tạo form popup
            Form popup = new Form();
            popup.Text = "Chọn dịch vụ";
            popup.Size = new Size(1200, 500);
            popup.StartPosition = FormStartPosition.CenterParent;

            // DataGridView hiển thị tất cả dịch vụ
            TableDataGridView dgv = new TableDataGridView();
            dgv.DataSource = ToDataTable(serviceBUS.GetAllService());
            dgv.Dock = DockStyle.Fill;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            popup.Controls.Add(dgv);

            // Panel chứa nút
            FlowLayoutPanel panelButtons = new FlowLayoutPanel();
            panelButtons.Height = 50;
            panelButtons.Dock = DockStyle.Bottom;
            panelButtons.Padding = new Padding(10);
            panelButtons.BackColor = Color.WhiteSmoke;
            panelButtons.FlowDirection = FlowDirection.RightToLeft; 
            panelButtons.WrapContents = false;
            panelButtons.AutoSize = false;
            panelButtons.AutoSizeMode = AutoSizeMode.GrowAndShrink;

            // NÚT THÊM
            Button btnAdd = new Button();
            btnAdd.Text = "Thêm dịch vụ";
            btnAdd.Width = 150;
            btnAdd.Height = 35;
            btnAdd.BackColor = Color.LightGreen;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Location = new Point(10, 7);

            btnAdd.Click += (s, e) =>
            {
                if (dgv.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Vui lòng chọn dịch vụ!");
                    return;
                }

                string maDV = dgv.SelectedRows[0].Cells["MaDV"].Value.ToString();
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

            // NÚT ĐÓNG
            Button btnClose = new Button();
            btnClose.Text = "Đóng";
            btnClose.Width = 100;
            btnClose.Height = 35;
            btnClose.BackColor = Color.LightCoral;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Location = new Point(180, 7);

            btnClose.Click += (s, e) => popup.Close();

            panelButtons.Controls.Add(btnClose);
            panelButtons.Controls.Add(btnAdd);
            popup.Controls.Add(panelButtons);

            popup.ShowDialog();
        }

        // Cập nhật bảng dịch vụ đã chọn và tổng chi phí
        private void UpdateServiceSelectedTable()
        {
            if (tableServiceSelected == null) return;

            var dt = new DataTable();
            dt.Columns.Add("MaDV");
            dt.Columns.Add("TenDV");
            dt.Columns.Add("GiaDV");

            foreach (var service in listServiceSelected)
            {
                dt.Rows.Add(service.MaDV, service.TenDV, service.GiaDV);
            }

            tableServiceSelected.DataSource = dt;

            decimal tongChiPhi = listServiceSelected.Sum(s => decimal.TryParse(s.GiaDV, out var g) ? g : 0);
            txtTongChiPhi.TextValue = tongChiPhi.ToString("N0");
        }


        private void buttonChonDichVuClick(object sender, EventArgs e)
        {
            ShowServiceSelectionDialog();
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
                NgayGioTaoPhieu = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"),
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

                panel2.Controls.Add(tableServiceSelected);
            }

            var dt = new DataTable();
            dt.Columns.Add("MaDV");
            dt.Columns.Add("TenDV");
            dt.Columns.Add("GiaDV");

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
        }

    }
}
