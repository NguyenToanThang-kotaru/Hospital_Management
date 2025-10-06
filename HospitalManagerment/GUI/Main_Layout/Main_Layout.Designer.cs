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
            this.BacSiLB = new System.Windows.Forms.Label();
            this.HoSoBenhAnLB = new System.Windows.Forms.Label();
            this.QuyenLB = new System.Windows.Forms.Label();
            this.NhanVienLB = new System.Windows.Forms.Label();
            this.DichVuLB = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.MainContent = new System.Windows.Forms.Panel();
            this.Header.SuspendLayout();
            this.SideBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // Header
            // 
            this.Header.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(77)))), ((int)(((byte)(146)))));
            this.Header.Controls.Add(this.Tittle);
            this.Header.Dock = System.Windows.Forms.DockStyle.Top;
            this.Header.Location = new System.Drawing.Point(0, 0);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1578, 100);
            this.Header.TabIndex = 0;
            // 
            // Tittle
            // 
            this.Tittle.AutoSize = true;
            this.Tittle.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Tittle.ForeColor = System.Drawing.Color.White;
            this.Tittle.Location = new System.Drawing.Point(12, 27);
            this.Tittle.Name = "Tittle";
            this.Tittle.Size = new System.Drawing.Size(252, 43);
            this.Tittle.TabIndex = 0;
            this.Tittle.Text = "Administrator";
            this.Tittle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.White;
            this.SideBar.Controls.Add(this.BacSiLB);
            this.SideBar.Controls.Add(this.HoSoBenhAnLB);
            this.SideBar.Controls.Add(this.QuyenLB);
            this.SideBar.Controls.Add(this.NhanVienLB);
            this.SideBar.Controls.Add(this.DichVuLB);
            this.SideBar.Controls.Add(this.label2);
            this.SideBar.Controls.Add(this.label1);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 100);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(285, 744);
            this.SideBar.TabIndex = 1;
            this.SideBar.Paint += new System.Windows.Forms.PaintEventHandler(this.SideBar_Paint);
            // 
            // BacSiLB
            // 
            this.BacSiLB.AutoSize = true;
            this.BacSiLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BacSiLB.Location = new System.Drawing.Point(53, 274);
            this.BacSiLB.Name = "BacSiLB";
            this.BacSiLB.Size = new System.Drawing.Size(91, 32);
            this.BacSiLB.TabIndex = 6;
            this.BacSiLB.Text = "Bác sĩ";
            this.BacSiLB.Click += new System.EventHandler(this.BacSi_LB);
            // 
            // HoSoBenhAnLB
            // 
            this.HoSoBenhAnLB.AutoSize = true;
            this.HoSoBenhAnLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HoSoBenhAnLB.Location = new System.Drawing.Point(53, 161);
            this.HoSoBenhAnLB.Name = "HoSoBenhAnLB";
            this.HoSoBenhAnLB.Size = new System.Drawing.Size(197, 32);
            this.HoSoBenhAnLB.TabIndex = 5;
            this.HoSoBenhAnLB.Text = "Hồ sơ bệnh án";
            this.HoSoBenhAnLB.Click += new System.EventHandler(this.HoSoBenhAnLB_Click);
            // 
            // QuyenLB
            // 
            this.QuyenLB.AutoSize = true;
            this.QuyenLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.QuyenLB.Location = new System.Drawing.Point(53, 398);
            this.QuyenLB.Name = "QuyenLB";
            this.QuyenLB.Size = new System.Drawing.Size(98, 32);
            this.QuyenLB.TabIndex = 4;
            this.QuyenLB.Text = "Quyền";
            this.QuyenLB.Click += new System.EventHandler(this.QuyenLB_Click);
            // 
            // NhanVienLB
            // 
            this.NhanVienLB.AutoSize = true;
            this.NhanVienLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NhanVienLB.Location = new System.Drawing.Point(52, 339);
            this.NhanVienLB.Name = "NhanVienLB";
            this.NhanVienLB.Size = new System.Drawing.Size(142, 32);
            this.NhanVienLB.TabIndex = 3;
            this.NhanVienLB.Text = "Nhân viên";
            this.NhanVienLB.Click += new System.EventHandler(this.NhanVienLB_Click);
            // 
            // DichVuLB
            // 
            this.DichVuLB.AutoSize = true;
            this.DichVuLB.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DichVuLB.Location = new System.Drawing.Point(53, 218);
            this.DichVuLB.Name = "DichVuLB";
            this.DichVuLB.Size = new System.Drawing.Size(108, 32);
            this.DichVuLB.TabIndex = 2;
            this.DichVuLB.Text = "Dịch vụ";
            this.DichVuLB.Click += new System.EventHandler(this.DichVuLB_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(53, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 32);
            this.label2.TabIndex = 1;
            this.label2.Text = "Bệnh nhân";
            this.label2.Click += new System.EventHandler(this.BenhNhan_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(52, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // MainContent
            // 
            this.MainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContent.Location = new System.Drawing.Point(285, 100);
            this.MainContent.Name = "MainContent";
            this.MainContent.Size = new System.Drawing.Size(1293, 744);
            this.MainContent.TabIndex = 2;
            this.MainContent.Paint += new System.Windows.Forms.PaintEventHandler(this.MainContent_Paint);
            // 
            // Main_Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1578, 844);
            this.Controls.Add(this.MainContent);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.Header);
            this.Name = "Main_Layout";
            this.Text = "Hospital Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Header.ResumeLayout(false);
            this.Header.PerformLayout();
            this.SideBar.ResumeLayout(false);
            this.SideBar.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel Header;
        private System.Windows.Forms.Panel SideBar;
        private System.Windows.Forms.Panel MainContent;
        private System.Windows.Forms.Label Tittle;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label QuyenLB;
        private System.Windows.Forms.Label NhanVienLB;
        private System.Windows.Forms.Label HoSoBenhAnLB;
        private System.Windows.Forms.Label DichVuLB;
        private System.Windows.Forms.Label BacSiLB;
    }
}