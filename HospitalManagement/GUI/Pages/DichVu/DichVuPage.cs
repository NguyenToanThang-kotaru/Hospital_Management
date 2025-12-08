using HM.BUS;
using HM.DTO;
using HM.GUI.Component.TableDataGridView;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace HM.GUI.Pages.DichVu
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
                table.Rows.Add(service.MaDV, service.TenDV, service.GiaDV, service.BHYTTra == "1" ? "Có" : "Không");
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
                table.Rows.Add(serviceDesignation.MaPCD, serviceDesignation.SoCCCD, serviceBUS.GetServiceById(serviceDesignation.MaDV).TenDV, serviceDesignation.NgayGioTaoPhieu);
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

        // sự kiệm tabPageDichVu =========================================================================================================================================================
        // sự kiệm tabPageDichVu =========================================================================================================================================================
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

            string giaDichVu = txtGiaDichVu.TextValue.Trim();

            if (!HM.Utils.Validators.IsNumber(giaDichVu) || (decimal.TryParse(giaDichVu, out decimal gia) && gia < 0))
            {
                MessageBox.Show("Giá dịch vụ phải là số nguyên dương");
                txtGiaDichVu.Focus();
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
            LoadServiceDesignationToTable();    
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
                    comboBoxDichVu.GetComboBox().DataSource = null;
                    comboBoxDichVuLoad(null, null);
                    LoadServiceToTable();
                    buttonHuyDichVuClick(null, null);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn dịch vụ cần xóa!");
            }
        }


        // sự kiệm tabPageChiDinhDichVu ================================================================================================================================================
        // sự kiệm tabPageChiDinhDichVu ================================================================================================================================================
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
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin phiếu chỉ định dịch vụ!");
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

            if (!serviceDesignationBUS.ExistsServiceDesignationId(serviceDesignation.MaPCD))
            {
                serviceDesignationBUS.AddServiceDesignation(serviceDesignation);
                MessageBox.Show("Thêm phiếu chỉ định dịch vụ thành công!");
            }
            else
            {
                serviceDesignationBUS.UpdateServiceDesignation(serviceDesignation);
                MessageBox.Show("Cập nhật phiếu chỉ định dịch vụ thành công!");
            }
            ExportServiceDesignationToPDF(serviceDesignation);
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

        private void ExportServiceDesignationToPDF(ServiceDesignationDTO dto)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "PDF file|*.pdf";
                saveFile.FileName = $"PhieuChiDinh_{dto.MaPCD}.pdf";

                if (saveFile.ShowDialog() != DialogResult.OK)
                    return;

                string fontPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "arial.ttf");

                BaseFont baseFont = File.Exists(fontPath)
                    ? BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED)
                    : BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                Font titleFont = new Font(baseFont, 18);
                Font contentFont = new Font(baseFont, 12);

                using (var fs = new FileStream(saveFile.FileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    Document doc = new Document(PageSize.A4);
                    PdfWriter writer = PdfWriter.GetInstance(doc, fs);
                    doc.Open();

                    Paragraph header = new Paragraph("BỆNH VIỆN ĐA KHOA NHÓM 7", contentFont);
                    header.Alignment = Element.ALIGN_CENTER;
                    doc.Add(header);


                    doc.Add(new Paragraph("\n"));

                    Paragraph title = new Paragraph("PHIẾU CHỈ ĐỊNH DỊCH VỤ", titleFont);
                    title.Alignment = Element.ALIGN_CENTER;
                    doc.Add(title);
                    doc.Add(new Paragraph("\n"));

                    var patient = patientBUS.GetPatientById(dto.SoCCCD);
                    var employee = employeeBUS.GetEmployeeById(dto.MaNV);
                    var service = serviceBUS.GetServiceById(dto.MaDV);

                    PdfPTable table = new PdfPTable(2);
                    table.WidthPercentage = 90;
                    table.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.SpacingBefore = 10f;
                    table.SpacingAfter = 20f;

                    AddCellToTable(table, "Mã phiếu:", dto.MaPCD, contentFont, contentFont);
                    AddCellToTable(table, "Ngày tạo:", dto.NgayGioTaoPhieu, contentFont, contentFont);
                    AddCellToTable(table, "Bệnh nhân:", patient?.TenBN ?? "N/A", contentFont, contentFont);
                    AddCellToTable(table, "Số CCCD:", dto.SoCCCD, contentFont, contentFont);
                    AddCellToTable(table, "Dịch vụ:", service?.TenDV ?? "N/A", contentFont, contentFont);
                    AddCellToTable(table, "Giá dịch vụ:", service?.GiaDV ?? "0", contentFont, contentFont);
                    AddCellToTable(table, "Nhân viên:", employee?.TenNV ?? "N/A", contentFont, contentFont);
                    doc.Add(table);

                    doc.Add(new Paragraph("\n\n\n"));

                    PdfPTable signatureTable = new PdfPTable(3);
                    signatureTable.WidthPercentage = 100;
                    signatureTable.DefaultCell.Border = PdfPCell.NO_BORDER;

                    signatureTable.AddCell(new Phrase("", contentFont));

                    PdfPCell patientCell = new PdfPCell(new Phrase("Bệnh nhân\n(Ký và ghi rõ họ tên)", contentFont));
                    patientCell.Border = PdfPCell.NO_BORDER;
                    patientCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    signatureTable.AddCell(patientCell);

                    PdfPCell staffCell = new PdfPCell(new Phrase("Nhân viên y tế\n(Ký và ghi rõ họ tên)", contentFont));
                    staffCell.Border = PdfPCell.NO_BORDER;
                    staffCell.HorizontalAlignment = Element.ALIGN_CENTER;
                    signatureTable.AddCell(staffCell);

                    doc.Add(signatureTable);
                    doc.Close();
                }

                MessageBox.Show("Đã xuất phiếu chỉ định dịch vụ ra file PDF!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tạo PDF: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void searchBarDichVuTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarDichVu.Text.Trim();
            var services = serviceBUS.SearchServiceByName(keyword); 

            DataTable table = new DataTable();
            table.Columns.Add("Mã Dịch Vụ", typeof(string));
            table.Columns.Add("Tên Dịch Vụ", typeof(string));
            table.Columns.Add("Giá Dịch Vụ", typeof(string));
            table.Columns.Add("Bảo hiểm chi trả", typeof(string));

            foreach (var service in services)
            {
                table.Rows.Add(service.MaDV, service.TenDV, service.GiaDV, service.BHYTTra);
            }

            tableService.DataSource = table;
        }

        private void searchBarChiDinhDichVuTextChanged(object sender, EventArgs e)
        {
            string keyword = searchBarChiDinhDichVu.Text.Trim();
            var serviceDesignations = serviceDesignationBUS.SearchServiceDesignationByCustomer(keyword);

            DataTable table = new DataTable();
            table.Columns.Add("Mã Phiếu", typeof(string));
            table.Columns.Add("Bệnh Nhân", typeof(string));
            table.Columns.Add("Dịch Vụ", typeof(string));
            table.Columns.Add("Ngày Tạo Phiếu", typeof(string));

            foreach (var sd in serviceDesignations)
            {
                var patient = patientBUS.GetPatientById(sd.SoCCCD);
                var service = serviceBUS.GetServiceById(sd.MaDV);

                table.Rows.Add(
                    sd.MaPCD,
                    patient != null ? patient.TenBN : "",
                    service != null ? service.TenDV : "",
                    sd.NgayGioTaoPhieu
                );
            }

            tableServiceDesignation.DataSource = table;
        }

    }
}
