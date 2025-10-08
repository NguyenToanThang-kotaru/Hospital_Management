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
            this.sidebarItem1 = new HospitalManagerment.GUI.Components.SidebarItem();
            this.sidebarItem2 = new HospitalManagerment.GUI.Components.SidebarItem();
            this.sidebarItem3 = new HospitalManagerment.GUI.Components.SidebarItem();
            this.sidebarItem4 = new HospitalManagerment.GUI.Components.SidebarItem();
            this.sidebarItem5 = new HospitalManagerment.GUI.Components.SidebarItem();
            this.sidebarItem6 = new HospitalManagerment.GUI.Components.SidebarItem();
            this.sidebarItem7 = new HospitalManagerment.GUI.Components.SidebarItem();
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
            this.Header.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Header.Name = "Header";
            this.Header.Size = new System.Drawing.Size(1882, 80);
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
            this.SideBar.Paint += new System.Windows.Forms.PaintEventHandler(this.SideBar_Paint);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.sidebarItem1);
            this.flowLayoutPanel1.Controls.Add(this.sidebarItem2);
            this.flowLayoutPanel1.Controls.Add(this.sidebarItem3);
            this.flowLayoutPanel1.Controls.Add(this.sidebarItem4);
            this.flowLayoutPanel1.Controls.Add(this.sidebarItem5);
            this.flowLayoutPanel1.Controls.Add(this.sidebarItem6);
            this.flowLayoutPanel1.Controls.Add(this.sidebarItem7);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(310, 873);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // sidebarItem1
            // 
            this.sidebarItem1.BackColor = System.Drawing.Color.Transparent;
            this.sidebarItem1.BorderRadius = 20;
            this.sidebarItem1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarItem1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sidebarItem1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem1.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.sidebarItem1.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.sidebarItem1.LabelHeight = 50;
            this.sidebarItem1.LabelWidth = 250;
            this.sidebarItem1.Location = new System.Drawing.Point(30, 10);
            this.sidebarItem1.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.sidebarItem1.Name = "sidebarItem1";
            this.sidebarItem1.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebarItem1.PanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebarItem1.PanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem1.Size = new System.Drawing.Size(250, 50);
            this.sidebarItem1.TabIndex = 0;
            this.sidebarItem1.Text = "Dashboard";
            this.sidebarItem1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sidebarItem1.Click += new System.EventHandler(this.sidebarItem1_Click_2);
            // 
            // sidebarItem2
            // 
            this.sidebarItem2.BackColor = System.Drawing.Color.Transparent;
            this.sidebarItem2.BorderRadius = 20;
            this.sidebarItem2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarItem2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sidebarItem2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem2.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.sidebarItem2.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.sidebarItem2.LabelHeight = 50;
            this.sidebarItem2.LabelWidth = 250;
            this.sidebarItem2.Location = new System.Drawing.Point(30, 80);
            this.sidebarItem2.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.sidebarItem2.Name = "sidebarItem2";
            this.sidebarItem2.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebarItem2.PanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebarItem2.PanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem2.Size = new System.Drawing.Size(250, 50);
            this.sidebarItem2.TabIndex = 1;
            this.sidebarItem2.Text = "Bệnh nhân";
            this.sidebarItem2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sidebarItem3
            // 
            this.sidebarItem3.BackColor = System.Drawing.Color.Transparent;
            this.sidebarItem3.BorderRadius = 20;
            this.sidebarItem3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarItem3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sidebarItem3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem3.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.sidebarItem3.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.sidebarItem3.LabelHeight = 50;
            this.sidebarItem3.LabelWidth = 250;
            this.sidebarItem3.Location = new System.Drawing.Point(30, 150);
            this.sidebarItem3.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.sidebarItem3.Name = "sidebarItem3";
            this.sidebarItem3.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebarItem3.PanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebarItem3.PanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem3.Size = new System.Drawing.Size(250, 50);
            this.sidebarItem3.TabIndex = 2;
            this.sidebarItem3.Text = "Hồ sơ bệnh án";
            this.sidebarItem3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sidebarItem4
            // 
            this.sidebarItem4.BackColor = System.Drawing.Color.Transparent;
            this.sidebarItem4.BorderRadius = 20;
            this.sidebarItem4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarItem4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sidebarItem4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem4.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.sidebarItem4.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.sidebarItem4.LabelHeight = 50;
            this.sidebarItem4.LabelWidth = 250;
            this.sidebarItem4.Location = new System.Drawing.Point(30, 220);
            this.sidebarItem4.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.sidebarItem4.Name = "sidebarItem4";
            this.sidebarItem4.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebarItem4.PanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebarItem4.PanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem4.Size = new System.Drawing.Size(250, 50);
            this.sidebarItem4.TabIndex = 3;
            this.sidebarItem4.Text = "Dịch vụ";
            this.sidebarItem4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sidebarItem4.Click += new System.EventHandler(this.sidebarItem4_Click);
            // 
            // sidebarItem5
            // 
            this.sidebarItem5.BackColor = System.Drawing.Color.Transparent;
            this.sidebarItem5.BorderRadius = 20;
            this.sidebarItem5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarItem5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sidebarItem5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem5.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.sidebarItem5.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.sidebarItem5.LabelHeight = 50;
            this.sidebarItem5.LabelWidth = 250;
            this.sidebarItem5.Location = new System.Drawing.Point(30, 290);
            this.sidebarItem5.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.sidebarItem5.Name = "sidebarItem5";
            this.sidebarItem5.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebarItem5.PanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebarItem5.PanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem5.Size = new System.Drawing.Size(250, 50);
            this.sidebarItem5.TabIndex = 4;
            this.sidebarItem5.Text = "Bác sĩ";
            this.sidebarItem5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sidebarItem6
            // 
            this.sidebarItem6.BackColor = System.Drawing.Color.Transparent;
            this.sidebarItem6.BorderRadius = 20;
            this.sidebarItem6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarItem6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sidebarItem6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem6.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.sidebarItem6.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.sidebarItem6.LabelHeight = 50;
            this.sidebarItem6.LabelWidth = 250;
            this.sidebarItem6.Location = new System.Drawing.Point(30, 360);
            this.sidebarItem6.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.sidebarItem6.Name = "sidebarItem6";
            this.sidebarItem6.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebarItem6.PanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebarItem6.PanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem6.Size = new System.Drawing.Size(250, 50);
            this.sidebarItem6.TabIndex = 5;
            this.sidebarItem6.Text = "Nhân viên";
            this.sidebarItem6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // sidebarItem7
            // 
            this.sidebarItem7.BackColor = System.Drawing.Color.Transparent;
            this.sidebarItem7.BorderRadius = 20;
            this.sidebarItem7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.sidebarItem7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.sidebarItem7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem7.HoverBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(251)))), ((int)(((byte)(249)))));
            this.sidebarItem7.HoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(52)))), ((int)(((byte)(211)))), ((int)(((byte)(153)))));
            this.sidebarItem7.LabelHeight = 50;
            this.sidebarItem7.LabelWidth = 250;
            this.sidebarItem7.Location = new System.Drawing.Point(30, 430);
            this.sidebarItem7.Margin = new System.Windows.Forms.Padding(30, 10, 30, 10);
            this.sidebarItem7.Name = "sidebarItem7";
            this.sidebarItem7.Padding = new System.Windows.Forms.Padding(20, 0, 0, 0);
            this.sidebarItem7.PanelBgColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.sidebarItem7.PanelTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.sidebarItem7.Size = new System.Drawing.Size(250, 50);
            this.sidebarItem7.TabIndex = 6;
            this.sidebarItem7.Text = "Quyền";
            this.sidebarItem7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // MainContent
            // 
            this.MainContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainContent.Location = new System.Drawing.Point(310, 80);
            this.MainContent.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MainContent.Name = "MainContent";
            this.MainContent.Size = new System.Drawing.Size(1572, 873);
            this.MainContent.TabIndex = 2;
            this.MainContent.Paint += new System.Windows.Forms.PaintEventHandler(this.MainContent_Paint);
            // 
            // Main_Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(248)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1882, 953);
            this.Controls.Add(this.MainContent);
            this.Controls.Add(this.SideBar);
            this.Controls.Add(this.Header);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Main_Layout";
            this.Text = "Hospital Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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
        private Components.SidebarItem sidebarItem1;
        private Components.SidebarItem sidebarItem2;
        private Components.SidebarItem sidebarItem3;
        private Components.SidebarItem sidebarItem4;
        private Components.SidebarItem sidebarItem5;
        private Components.SidebarItem sidebarItem6;
        private Components.SidebarItem sidebarItem7;
    }
}