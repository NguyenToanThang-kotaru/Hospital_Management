using HospitalManagerment.BUS;
using HospitalManagerment.DTO;
using HospitalManagerment.GUI.Component.TableDataGridView;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Pages.HoSoBenhAn
{
    public partial class QuyenPage : UserControl
    {
        private string employeeId;
        private TableDataGridView tableAccounts;
        private TableDataGridView tablePermission;
        private PermissionBUS permissionBUS;
        private AccountBUS accountBUS;
        public QuyenPage(string employeeId  )
        {
            InitializeComponent();
            this.employeeId = employeeId;
            tableAccounts = new TableDataGridView();
            tablePermission = new TableDataGridView();
            accountBUS = new AccountBUS();
            permissionBUS = new PermissionBUS();
        }

        private void QuyenPage_Load(object sender, EventArgs e)
        {
            LoadAccountToTable();
            LoadPermissionToTable();

            txtMaQuyen.SetReadOnly(true);
        }

        private void LoadAccountToTable()
        {
            tableAccounts.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tableAccounts.DataSource = ToDataTable(accountBUS.GetAllAccount());
            taiKhoanPanel.Controls.Add(tableAccounts);
        }

        private void LoadPermissionToTable()
        {
            tablePermission.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            tablePermission.DataSource = ToDataTable(permissionBUS.GetAllPermissions());
            quyenPanel.Controls.Add(tablePermission);
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


        // sự kiện tabPageTaiKhoan
        private void buttonHuyTaiKhoanClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanTaiKhoanClick(object sender, EventArgs e)
        {

        }

        private void buttonThemTaiKhoanClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaTaiKhoanClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaTaiKhoanClick(object sender, EventArgs e)
        {

        }

        // sự kiện tabPageQuyen
        private void buttonHuyQuyenClick(object sender, EventArgs e)
        {

        }

        private void buttonXacNhanQuyenClick(object sender, EventArgs e)
        {

        }

        private void buttonThemQuyenClick(object sender, EventArgs e)
        {

        }

        private void buttonSuaQuyenClick(object sender, EventArgs e)
        {

        }

        private void buttonXoaQuyenClick(object sender, EventArgs e)
        {

        }
    }
}
