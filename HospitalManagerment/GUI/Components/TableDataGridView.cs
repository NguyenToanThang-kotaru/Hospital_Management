using HospitalManagerment.Utils;
using System.Drawing;
using System.Windows.Forms;

namespace HospitalManagerment.GUI.Component.TableDataGridView
{
    internal class TableDataGridView : DataGridView
    {
        public TableDataGridView()
        {
            Dock = DockStyle.Fill;
            AutoGenerateColumns = true;
            BackgroundColor = Color.White;
            AllowUserToAddRows = false;
            AllowUserToDeleteRows = false;
            ReadOnly = true;
            BorderStyle = BorderStyle.None;
            SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            RowHeadersVisible = false;

            EnableHeadersVisualStyles = false;
            ColumnHeadersDefaultCellStyle = new DataGridViewCellStyle
            {
                BackColor = Color.FromArgb(247, 255, 254),
                ForeColor = Consts.FontColorA, 
                Font = new Font("Roboto", 10, FontStyle.Bold),
                Alignment = DataGridViewContentAlignment.MiddleCenter,
                Padding = new Padding(0, 5, 0, 5),
                SelectionBackColor = Color.FromArgb(247, 255, 254)
            };
            DefaultCellStyle = new DataGridViewCellStyle
            {
                Font = new Font("Roboto", 10),
                ForeColor = Color.Black,
                BackColor = Color.White,
                SelectionForeColor = Color.Black
            };
            GridColor = Color.FromArgb(230, 230, 230);
            CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            AllowUserToResizeColumns = false;
            AllowUserToResizeRows = false;
            RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            ColumnHeadersHeight = 35;
            RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
        }
    }
}
