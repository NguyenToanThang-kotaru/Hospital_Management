namespace HospitalManagerment.GUI.Main_Layout
{
    partial class Main_Layout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.Header = new System.Windows.Forms.Panel();
            this.Tittle = new System.Windows.Forms.Label();
            this.SideBar = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.DashboardItem = new HospitalManagerment.GUI.Components.SidebarItem();
            this.BenhNhanItem = new HospitalManagerment.GUI.Components.SidebarItem();
            this.HoSoBenhAnItem = new HospitalManagerment.GUI.Components.SidebarItem();
            this.DichVuItem = new HospitalManagerment.GUI.Components.SidebarItem();
            this.NhanVienItem = new HospitalManagerment.GUI.Components.SidebarItem();
            this.QuyenItem = new HospitalManagerment.GUI.Components.SidebarItem();
            this.MainContent = new System.Windows.Forms.Panel();
            this.Header.SuspendLayout();
            this.SideBar.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(77)))), ((int)(((byte)(146)))));
            this.Header.Controls.Add(this.Tittle);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Margin = new System.Windows.Forms.Padding(0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1682, 80);
            this.Header.TabIndex = 0;
            // 
            // Tittle
            // 
            this.Tittle.AutoSize = true;
            this.Tittle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Tittle.ForeColor = System.Drawing.Color.White;
            this.Tittle.Location = new System.Drawing.Point(11, 22);
            this.Tittle.Name = "Tittle";
            this.Tittle.Size = new System.Drawing.Size(210, 35);
            this.Tittle.TabIndex = 0;
            this.Tittle.Text = "Administrator";
            this.Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.White;
            this.SideBar.Controls.Add(this.flowLayoutPanel1);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 80);
            this.SideBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(310, 873);
            this.SideBar.TabIndex = 1;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.DashboardItem);
            this.flowLayoutPanel1.Controls.Add(this.BenhNhanItem);
            this.flowLayoutPanel1.Controls.Add(this.HoSoBenhAnItem);
            this.flowLayoutPanel1.Controls.Add(this.DichVuItem);
            this.flowLayoutPanel1.Controls.Add(this.NhanVienItem);
            this.flowLayoutPanel1.Controls.Add(this.QuyenItem);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(310, 873);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // DashboardItem
            // 
            this.DashboardItem.BackColor = System.Drawing.Color.Transparent;
            this.DashboardItem.BorderRadius = 20;
            this.DashboardItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DashboardItem.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DashboardItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.DashboardItem.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.DashboardItem.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.DashboardItem.LabelFont = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold);
            this.DashboardItem.LabelHeight = 50;
            this.DashboardItem.LabelWidth = 250;
            this.DashboardItem.LanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DashboardItem.LanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.DashboardItem.Location = new System.Drawing.Point(30, 10);
            this.DashboardItem.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.DashboardItem.Name = "DashboardItem";
            this.DashboardItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.DashboardItem.Size = new System.Drawing.Size(250, 50);
            this.DashboardItem.TabIndex = 0;
            this.DashboardItem.Text = "Dashboard";
            this.DashboardItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DashboardItem.Click += new System.EventHandler(this.Dashboard_Click);
            // 
            // BenhNhanItem
            // 
            this.BenhNhanItem.BackColor = System.Drawing.Color.Transparent;
            this.BenhNhanItem.BorderRadius = 20;
            this.BenhNhanItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.BenhNhanItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.BenhNhanItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.BenhNhanItem.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.BenhNhanItem.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.BenhNhanItem.LabelFont = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold);
            this.BenhNhanItem.LabelHeight = 50;
            this.BenhNhanItem.LabelWidth = 250;
            this.BenhNhanItem.LanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.BenhNhanItem.LanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.BenhNhanItem.Location = new System.Drawing.Point(30, 80);
            this.BenhNhanItem.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.BenhNhanItem.Name = "BenhNhanItem";
            this.BenhNhanItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.BenhNhanItem.Size = new System.Drawing.Size(250, 50);
            this.BenhNhanItem.TabIndex = 1;
            this.BenhNhanItem.Text = "Bệnh nhân";
            this.BenhNhanItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BenhNhanItem.Click += new System.EventHandler(this.BenhNhanItem_Click);
            // 
            // HoSoBenhAnItem
            // 
            this.HoSoBenhAnItem.BackColor = System.Drawing.Color.Transparent;
            this.HoSoBenhAnItem.BorderRadius = 20;
            this.HoSoBenhAnItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HoSoBenhAnItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.HoSoBenhAnItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.HoSoBenhAnItem.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.HoSoBenhAnItem.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.HoSoBenhAnItem.LabelFont = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold);
            this.HoSoBenhAnItem.LabelHeight = 50;
            this.HoSoBenhAnItem.LabelWidth = 250;
            this.HoSoBenhAnItem.LanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.HoSoBenhAnItem.LanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.HoSoBenhAnItem.Location = new System.Drawing.Point(30, 150);
            this.HoSoBenhAnItem.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.HoSoBenhAnItem.Name = "HoSoBenhAnItem";
            this.HoSoBenhAnItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.HoSoBenhAnItem.Size = new System.Drawing.Size(250, 50);
            this.HoSoBenhAnItem.TabIndex = 2;
            this.HoSoBenhAnItem.Text = "Hồ sơ bệnh án";
            this.HoSoBenhAnItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.HoSoBenhAnItem.Click += new System.EventHandler(this.HoSoBenhAnItem_Click);
            // 
            // DichVuItem
            // 
            this.DichVuItem.BackColor = System.Drawing.Color.Transparent;
            this.DichVuItem.BorderRadius = 20;
            this.DichVuItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DichVuItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.DichVuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.DichVuItem.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.DichVuItem.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.DichVuItem.LabelFont = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold);
            this.DichVuItem.LabelHeight = 50;
            this.DichVuItem.LabelWidth = 250;
            this.DichVuItem.LanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.DichVuItem.LanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.DichVuItem.Location = new System.Drawing.Point(30, 220);
            this.DichVuItem.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.DichVuItem.Name = "DichVuItem";
            this.DichVuItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.DichVuItem.Size = new System.Drawing.Size(250, 50);
            this.DichVuItem.TabIndex = 3;
            this.DichVuItem.Text = "Dịch vụ";
            this.DichVuItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.DichVuItem.Click += new System.EventHandler(this.DichVu_Click);
            // 
            // NhanVienItem
            // 
            this.NhanVienItem.BackColor = System.Drawing.Color.Transparent;
            this.NhanVienItem.BorderRadius = 20;
            this.NhanVienItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NhanVienItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.NhanVienItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.NhanVienItem.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.NhanVienItem.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.NhanVienItem.LabelFont = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold);
            this.NhanVienItem.LabelHeight = 50;
            this.NhanVienItem.LabelWidth = 250;
            this.NhanVienItem.LanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.NhanVienItem.LanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.NhanVienItem.Location = new System.Drawing.Point(30, 290);
            this.NhanVienItem.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.NhanVienItem.Name = "NhanVienItem";
            this.NhanVienItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.NhanVienItem.Size = new System.Drawing.Size(250, 50);
            this.NhanVienItem.TabIndex = 5;
            this.NhanVienItem.Text = "Nhân viên";
            this.NhanVienItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.NhanVienItem.Click += new System.EventHandler(this.NhanVien_Click);
            // 
            // QuyenItem
            // 
            this.QuyenItem.BackColor = System.Drawing.Color.Transparent;
            this.QuyenItem.BorderRadius = 20;
            this.QuyenItem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.QuyenItem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.QuyenItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.QuyenItem.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.QuyenItem.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.QuyenItem.LabelFont = new System.Drawing.Font("Roboto", 16F, System.Drawing.FontStyle.Bold);
            this.QuyenItem.LabelHeight = 50;
            this.QuyenItem.LabelWidth = 250;
            this.QuyenItem.LanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.QuyenItem.LanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.QuyenItem.Location = new System.Drawing.Point(30, 360);
            this.QuyenItem.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.QuyenItem.Name = "QuyenItem";
            this.QuyenItem.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.QuyenItem.Size = new System.Drawing.Size(250, 50);
            this.QuyenItem.TabIndex = 6;
            this.QuyenItem.Text = "Quyền";
            this.QuyenItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.QuyenItem.Click += new System.EventHandler(this.Quyen_Click);
            // 
            // MainContent
            // 
            this.MainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContent.Location = new System.Drawing.Point(310, 80);
            this.MainContent.Margin = new System.Windows.Forms.Padding(0);
            this.MainContent.Name = "MainContent";
            this.MainContent.Size = new System.Drawing.Size(1372, 873);
            this.MainContent.TabIndex = 2;
            // 
            // Main_Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1682, 953);
            this.Controls.Add(this.MainContent);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.Header);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main_Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hospital Management";
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.SideBar.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Panel SideBar;
        private System.Windows.Forms.Panel MainContent;
        private System.Windows.Forms.Label Tittle;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private Components.SidebarItem DashboardItem;
        private Components.SidebarItem BenhNhanItem;
        private Components.SidebarItem HoSoBenhAnItem;
        private Components.SidebarItem DichVuItem;
        private Components.SidebarItem NhanVienItem;
        private Components.SidebarItem QuyenItem;
    }
}