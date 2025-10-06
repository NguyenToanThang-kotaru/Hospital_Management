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
            this.SideBar = new System.Windows.Forms.Panel();
            this.MainContent = new System.Windows.Forms.Panel();
            this.Tittle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
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
            // SideBar
            // 
            this.SideBar.BackColor = System.Drawing.Color.White;
            this.SideBar.Controls.Add(this.label1);
            this.SideBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.SideBar.Location = new System.Drawing.Point(0, 100);
            this.SideBar.Name = "SideBar";
            this.SideBar.Size = new System.Drawing.Size(285, 744);
            this.SideBar.TabIndex = 1;
            this.SideBar.Paint += new System.Windows.Forms.PaintEventHandler(this.SideBar_Paint);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(43, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Dashboard";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
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
    }
}