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
            txtNhanVienTaoPhieu.TextValue = employeeBUS.GetEmployeeByID(employeeId).TenNV;
        }

        private void LoadServiceToTable()
        {
            tableService.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableService.DataSource = ToDataTable(serviceBUS.GetAllService());
            dichVuPanel.Controls.Add(tableService);
        }

        private void LoadServiceDesignationToTable()
        {
            tableServiceDesignation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableServiceDesignation.DataSource = ToDataTable(serviceDesignationBUS.GetAllServiceDesignation());
            chiDinhDichVuPanel.Controls.Add(tableServiceDesignation);
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

        private void comboBoxBaoHiemChiTraLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxBaoHiemChiTra.GetComboBox();
            if (cb.Items.Count == 0)
            {
                cb.Items.Add("Có");
                cb.Items.Add("Không");

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

        private void comboBoxDichVuLoad(object sender, PaintEventArgs e)
        {
            ComboBox cb = comboBoxDichVu.GetComboBox();
            if (cb.DataSource == null)
            {
                cb.DataSource = serviceBUS.GetAllService();
                cb.DisplayMember = "TenDV";   // Tên thuộc tính hiển thị
                cb.ValueMember = "MaDV";      // Giá trị lấy ra để lưu
                cb.SelectedIndex = -1;

                cb.DrawMode = DrawMode.OwnerDrawFixed;
                cb.DrawItem += (s, ev) =>
                {
                    if (ev.Index < 0) return;
                    string text = ((ServiceDTO)cb.Items[ev.Index]).TenDV;
                    Color textColor = Color.FromArgb(125, 125, 125);
                    ev.DrawBackground();
                    ev.Graphics.DrawString(text, cb.Font, new SolidBrush(textColor), ev.Bounds);
                    ev.DrawFocusRectangle();
                };
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
                string maDV = row.Cells["MaDV"].Value?.ToString();

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
                string maDichVu = tableService.SelectedRows[0].Cells["MaDV"].Value?.ToString();
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
                string maPCD = row.Cells["MaPCD"].Value?.ToString();

                var phieuChiDinh = serviceDesignationBUS.GetServiceDesignationById(maPCD);
                if (phieuChiDinh != null)
                {
                    txtMaChiDinhDichVu.TextValue = phieuChiDinh.MaPCD?.ToString();
                    txtSoCCCDBenhNhan.TextValue = phieuChiDinh.SoCCCD?.ToString();
                    txtTenBenhNhan.TextValue = patientBUS.GetPatientById(phieuChiDinh.SoCCCD?.ToString()).TenBN;
                    txtNhanVienTaoPhieu.TextValue = employeeBUS.GetEmployeeByID(phieuChiDinh.MaNV?.ToString()).TenNV;
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
                string maChiDinhDichVu = tableServiceDesignation.SelectedRows[0].Cells["MaPCD"].Value?.ToString();
                var result = MessageBox.Show("Bạn có chắc muốn xóa phiếu chỉ định này?", "Xác nhận", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    serviceDesignationBUS.DeleteServiceDesignation(maChiDinhDichVu);
                    MessageBox.Show("Xóa phiếu chỉ định dịch vụ thành công!");
                    buttonHuyChiDinhDichVuClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phiếu chỉ định dịch vụ cần xóa!");
            }
        }

        
    }
}
