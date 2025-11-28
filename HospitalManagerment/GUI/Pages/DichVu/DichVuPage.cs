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
        private string employeeId;
        private TableDataGridView tableService;        
        private TableDataGridView tableServiceDesignation;
        private ServiceBUS serviceBUS;
        private ServiceDesignationBUS serviceDesignationBUS;
        private PatientBUS patientBUS;
        private EmployeeBUS employeeBUS;
        public DichVuPage(string employeeId)
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableService = new TableDataGridView();
            tableServiceDesignation = new TableDataGridView();
            serviceBUS = new ServiceBUS();
            serviceDesignationBUS = new ServiceDesignationBUS();
            patientBUS = new PatientBUS(); 
            employeeBUS = new EmployeeBUS();
        }

        private void DichVuPage_Load(object sender, EventArgs e)
        {
            LoadServiceToTable();
            LoadServiceDesignationToTable();

            txtMaDichVu.SetReadOnly(true);
            txtMaChiDinhDichVu.SetReadOnly(true);
            txtTenBenhNhan.SetReadOnly(true);
            txtNhanVienTaoPhieu.SetReadOnly(true);

            txtMaDichVu.TextValue = serviceBUS.GetNextServiceId();
            txtMaChiDinhDichVu.TextValue = serviceDesignationBUS.GetNextServiceDesignationId();
            txtNhanVienTaoPhieu.TextValue = employeeBUS.GetEmployeeById(employeeId).TenNV;

            if (txtSoCCCDBenhNhan.txt != null)
            {
                txtSoCCCDBenhNhan.txt.TextChanged -= GetPatientNameByCCCD;
                txtSoCCCDBenhNhan.txt.TextChanged += GetPatientNameByCCCD;
            }
        }

        private void LoadServiceToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Dịch Vụ", typeof(string));
            table.Columns.Add("Tên Dịch Vụ", typeof(string));
            table.Columns.Add("Giá Dịch Vụ", typeof(string));
            table.Columns.Add("Bảo hiểm chi trả", typeof(string));

            foreach (var service in serviceBUS.GetAllService())
            {
                table.Rows.Add(service.MaDV, service.TenDV, service.GiaDV, service.BHYTTra);
            }

            tableService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableService.DataSource = table;
            dichVuPanel.Controls.Add(tableService);
        }

        private void LoadServiceDesignationToTable()
        {
            DataTable table = new DataTable();
            table.Columns.Add("Mã Phiếu", typeof(string));
            table.Columns.Add("Bệnh Nhân", typeof(string));
            table.Columns.Add("Dịch Vụ", typeof(string));
            table.Columns.Add("Ngày Tạo Phiếu", typeof(string));

            foreach (var serviceDesignation in serviceDesignationBUS.GetAllServiceDesignation())
            {
                table.Rows.Add(serviceDesignation.MaPCD, serviceDesignation.SoCCCD, serviceDesignation.MaDV, serviceDesignation.NgayGioTaoPhieu);
            }

            tableServiceDesignation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableServiceDesignation.DataSource = table;
            chiDinhDichVuPanel.Controls.Add(tableServiceDesignation);
        }
        private void comboBoxBaoHiemChiTraLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxBaoHiemChiTra.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Có");
                cb.Items.Add("Không");
            }
        }

        private void comboBoxDichVuLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxDichVu.GetComboBox();
            if (cb.DataSource == null)
            {
                cb.DataSource = serviceBUS.GetAllService();
                cb.DisplayMember = "TenDV";   // Tên thuộc tính hiển thị
                cb.ValueMember = "MaDV";      // Giá trị lấy ra để lưu
                cb.SelectedIndex = -1;
            }
        }

        // sự kiệm tabPageDichVu
        private void buttonHuyDichVuClick(object sender, EventArgs e)
        {
            txtMaDichVu.TextValue = serviceBUS.GetNextServiceId();
            txtTenDichVu.TextValue = "";
            txtGiaDichVu.TextValue = "";
            comboBoxBaoHiemChiTra.GetComboBox().SelectedIndex = -1;
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
                MaDV = txtMaDichVu.TextValue.Trim(),
                TenDV = txtTenDichVu.TextValue.Trim(),
                GiaDV = txtGiaDichVu.TextValue.Trim(),
                BHYTTra = comboBoxBaoHiemChiTra.TextValue == "Có" ? "1" : "0"
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
            comboBoxDichVu.GetComboBox().DataSource = null;
            comboBoxDichVuLoad(null, null);
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
                string maDV = row.Cells["Mã Dịch Vụ"].Value?.ToString();

                var dichVu = serviceBUS.GetServiceById(maDV);
                if (serviceBUS.GetServiceById(maDV) != null)
                {
                    txtMaDichVu.TextValue = dichVu.MaDV?.ToString();
                    txtTenDichVu.TextValue = dichVu.TenDV?.ToString();
                    txtGiaDichVu.TextValue = dichVu.GiaDV?.ToString();
                    comboBoxBaoHiemChiTra.TextValue = dichVu.BHYTTra?.ToString() == "1" ? "Có" : "Không";
                }
                else
                {
                    MessageBox.Show("Không tìm thấy dịch vụ với mã này!");
                }
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
                string maDichVu = tableService.SelectedRows[0].Cells["Mã Dịch Vụ"].Value?.ToString();
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
            txtMaChiDinhDichVu.TextValue = serviceDesignationBUS.GetNextServiceDesignationId();
            txtSoCCCDBenhNhan.TextValue = "";
            txtTenBenhNhan.TextValue = "";
            comboBoxDichVu.GetComboBox().SelectedIndex = -1;
            txtSoCCCDBenhNhan.Focus();
        }

        private void buttonXacNhanChiDinhDichVuClick(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSoCCCDBenhNhan.TextValue) || string.IsNullOrEmpty(txtTenBenhNhan.TextValue) || string.IsNullOrEmpty(comboBoxDichVu.TextValue))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin dịch vụ!");
                return;
            }
            ServiceDesignationDTO serviceDesignation = new ServiceDesignationDTO()
            {
                MaPCD = txtMaChiDinhDichVu.TextValue.Trim(),
                SoCCCD = txtSoCCCDBenhNhan.TextValue.Trim(),
                MaNV = employeeId,
                MaDV = comboBoxDichVu.GetComboBox().SelectedValue?.ToString(),
                NgayGioTaoPhieu = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")
            };

            if (!serviceDesignationBUS.ExistsServiceDesignationId(serviceDesignation.MaDV))
            {
                serviceDesignationBUS.AddServiceDesignation(serviceDesignation);
                MessageBox.Show("Thêm dịch vụ thành công!");
            }
            else
            {
                serviceDesignationBUS.UpdateServiceDesignation(serviceDesignation);
                MessageBox.Show("Cập nhật dịch vụ thành công!");
            }
            buttonHuyChiDinhDichVuClick(null, null);
            LoadServiceDesignationToTable();
        }

        private void buttonThemChiDinhDichVuClick(object sender, EventArgs e)
        {
            txtMaChiDinhDichVu.TextValue = serviceDesignationBUS.GetNextServiceDesignationId();
            txtSoCCCDBenhNhan.TextValue = "";
            txtTenBenhNhan.TextValue = "";
            comboBoxDichVu.GetComboBox().SelectedIndex = -1;
            tableServiceDesignation.ClearSelection();
        }

        private void buttonSuaChiDinhDichVuClick(object sender, EventArgs e)
        {
            if (tableServiceDesignation.SelectedRows.Count > 0)
            {
                var row = tableServiceDesignation.SelectedRows[0];
                string maPCD = row.Cells["Mã Phiếu"].Value?.ToString();

                var phieuChiDinh = serviceDesignationBUS.GetServiceDesignationById(maPCD);
                if (phieuChiDinh != null)
                {
                    txtMaChiDinhDichVu.TextValue = phieuChiDinh.MaPCD?.ToString();
                    txtSoCCCDBenhNhan.TextValue = phieuChiDinh.SoCCCD?.ToString();
                    txtTenBenhNhan.TextValue = patientBUS.GetPatientById(phieuChiDinh.SoCCCD?.ToString()).TenBN;
                    txtNhanVienTaoPhieu.TextValue = employeeBUS.GetEmployeeById(phieuChiDinh.MaNV?.ToString()).TenNV;
                    comboBoxDichVu.GetComboBox().SelectedValue = phieuChiDinh.MaDV;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy phiếu chỉ định dịch vụ với mã này!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu chỉ định dịch vụ cần sửa!");
            }
        }

        private void buttonXoaChiDinhDichVuClick(object sender, EventArgs e)
        {
            if (tableServiceDesignation.SelectedRows.Count > 0)
            {
                string maChiDinhDichVu = tableServiceDesignation.SelectedRows[0].Cells["Mã Phiếu"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa phiếu chỉ định này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    serviceDesignationBUS.DeleteServiceDesignation(maChiDinhDichVu);
                    MessageBox.Show("Xóa phiếu chỉ định dịch vụ thành công!");
                    buttonHuyChiDinhDichVuClick(null, null);
                    LoadServiceDesignationToTable();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu chỉ định dịch vụ cần xóa!");
            }
        }

        private void GetPatientNameByCCCD(object sender, EventArgs e)
        {
            string soCCCD = txtSoCCCDBenhNhan.TextValue.Trim();

            if (!string.IsNullOrEmpty(soCCCD))
            {
                var patient = patientBUS.GetPatientByIdOrNull(soCCCD);
                if (patient != null)
                    txtTenBenhNhan.TextValue = patient.TenBN;
                else
                    txtTenBenhNhan.TextValue = "";
            }
            else
                txtTenBenhNhan.TextValue = "";
        }

    }
}
