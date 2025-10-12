    namespace HospitalManagerment.GUI.Login_Layout
    {
        partial class Login_Layout
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
            this.tableLayoutForm = new System.Windows.Forms.TableLayoutPanel();
            this.pnlLogin = new HospitalManagerment.GUI.Component.RoundedPanel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblTxtTaiKhoan = new LayoutTest.GUIComponents.LableTextBox();
            this.lblTxtMatKhau = new LayoutTest.GUIComponents.LableTextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tableLayoutForm.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutForm
            // 
            this.tableLayoutForm.ColumnCount = 3;
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutForm.Controls.Add(this.pnlLogin, 1, 1);
            this.tableLayoutForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutForm.Name = "tableLayoutForm";
            this.tableLayoutForm.RowCount = 3;
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutForm.Size = new System.Drawing.Size(1710, 844);
            this.tableLayoutForm.TabIndex = 0;
            // 
            // pnlLogin
            // 
            this.pnlLogin.AutoSize = true;
            this.pnlLogin.BackColor = System.Drawing.Color.Transparent;
            this.pnlLogin.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pnlLogin.BorderRadius = 40;
            this.pnlLogin.Controls.Add(this.tableLayoutPanel);
            this.pnlLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlLogin.Location = new System.Drawing.Point(516, 214);
            this.pnlLogin.MarginBottom = 0;
            this.pnlLogin.MarginLeft = 0;
            this.pnlLogin.MarginRight = 0;
            this.pnlLogin.MarginTop = 0;
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.PanelColor = System.Drawing.Color.White;
            this.pnlLogin.Size = new System.Drawing.Size(678, 416);
            this.pnlLogin.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.lblTxtTaiKhoan, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.lblTxtMatKhau, 0, 2);
            this.tableLayoutPanel.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.btnLogin, 0, 3);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 4;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(678, 416);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // lblTxtTaiKhoan
            // 
            this.lblTxtTaiKhoan.BackColor = System.Drawing.Color.Transparent;
            this.lblTxtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTxtTaiKhoan.IsPassword = false;
            this.lblTxtTaiKhoan.LabelText = "Tài khoản";
            this.lblTxtTaiKhoan.Location = new System.Drawing.Point(150, 129);
            this.lblTxtTaiKhoan.Margin = new System.Windows.Forms.Padding(150, 25, 150, 5);
            this.lblTxtTaiKhoan.Name = "lblTxtTaiKhoan";
            this.lblTxtTaiKhoan.PanelHeight = 60;
            this.lblTxtTaiKhoan.PanelWidth = 200;
            this.lblTxtTaiKhoan.Size = new System.Drawing.Size(378, 74);
            this.lblTxtTaiKhoan.TabIndex = 0;
            this.lblTxtTaiKhoan.TextValue = "";
            // 
            // lblTxtMatKhau
            // 
            this.lblTxtMatKhau.BackColor = System.Drawing.Color.Transparent;
            this.lblTxtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTxtMatKhau.IsPassword = true;
            this.lblTxtMatKhau.LabelText = "Mật khẩu";
            this.lblTxtMatKhau.Location = new System.Drawing.Point(150, 213);
            this.lblTxtMatKhau.Margin = new System.Windows.Forms.Padding(150, 5, 150, 25);
            this.lblTxtMatKhau.Name = "lblTxtMatKhau";
            this.lblTxtMatKhau.PanelHeight = 60;
            this.lblTxtMatKhau.PanelWidth = 200;
            this.lblTxtMatKhau.Size = new System.Drawing.Size(378, 74);
            this.lblTxtMatKhau.TabIndex = 1;
            this.lblTxtMatKhau.TextValue = "";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblHeader.Location = new System.Drawing.Point(43, 28);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(591, 48);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "ĐĂNG NHẬP VÀO HỆ THỐNG";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(240, 327);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(240, 15, 240, 45);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(198, 44);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // Login_Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1710, 844);
            this.Controls.Add(this.tableLayoutForm);
            this.Name = "Login_Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Layout_Load);
            this.tableLayoutForm.ResumeLayout(false);
            this.tableLayoutForm.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.TableLayoutPanel tableLayoutForm;
            private Component.RoundedPanel pnlLogin;
            private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
            private LayoutTest.GUIComponents.LableTextBox lblTxtTaiKhoan;
            private LayoutTest.GUIComponents.LableTextBox lblTxtMatKhau;
            private System.Windows.Forms.Label lblHeader;
            private System.Windows.Forms.Button btnLogin;
    }
    }