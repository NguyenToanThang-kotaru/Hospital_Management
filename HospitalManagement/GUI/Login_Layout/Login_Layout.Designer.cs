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
            this.btnLogin = new System.Windows.Forms.Button();
            this.lblTxtMatKhau = new LayoutTest.GUIComponents.LableTextBox();
            this.lblTxtTaiKhoan = new LayoutTest.GUIComponents.LableTextBox();
            this.lblHeader = new System.Windows.Forms.Label();
            this.tableLayoutForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutForm
            // 
            this.tableLayoutForm.BackColor = System.Drawing.Color.White;
            this.tableLayoutForm.ColumnCount = 1;
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutForm.Controls.Add(this.btnLogin, 0, 3);
            this.tableLayoutForm.Controls.Add(this.lblTxtMatKhau, 0, 1);
            this.tableLayoutForm.Controls.Add(this.lblTxtTaiKhoan, 0, 1);
            this.tableLayoutForm.Controls.Add(this.lblHeader, 0, 0);
            this.tableLayoutForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutForm.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutForm.Name = "tableLayoutForm";
            this.tableLayoutForm.RowCount = 4;
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutForm.Size = new System.Drawing.Size(682, 453);
            this.tableLayoutForm.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLogin.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(200, 354);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(200, 15, 200, 45);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(282, 54);
            this.btnLogin.TabIndex = 1;
            this.btnLogin.Text = "ĐĂNG NHẬP";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lblTxtMatKhau
            // 
            this.lblTxtMatKhau.BackColor = System.Drawing.Color.White;
            this.lblTxtMatKhau.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTxtMatKhau.IsPassword = true;
            this.lblTxtMatKhau.LabelText = "Mật khẩu";
            this.lblTxtMatKhau.Location = new System.Drawing.Point(100, 231);
            this.lblTxtMatKhau.Margin = new System.Windows.Forms.Padding(100, 5, 100, 25);
            this.lblTxtMatKhau.Name = "lblTxtMatKhau";
            this.lblTxtMatKhau.PanelHeight = 60;
            this.lblTxtMatKhau.PanelWidth = 200;
            this.lblTxtMatKhau.Size = new System.Drawing.Size(482, 83);
            this.lblTxtMatKhau.TabIndex = 3;
            this.lblTxtMatKhau.TextValue = "";
            // 
            // lblTxtTaiKhoan
            // 
            this.lblTxtTaiKhoan.BackColor = System.Drawing.Color.White;
            this.lblTxtTaiKhoan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTxtTaiKhoan.IsPassword = false;
            this.lblTxtTaiKhoan.LabelText = "Tài khoản";
            this.lblTxtTaiKhoan.Location = new System.Drawing.Point(100, 138);
            this.lblTxtTaiKhoan.Margin = new System.Windows.Forms.Padding(100, 25, 100, 5);
            this.lblTxtTaiKhoan.Name = "lblTxtTaiKhoan";
            this.lblTxtTaiKhoan.PanelHeight = 60;
            this.lblTxtTaiKhoan.PanelWidth = 200;
            this.lblTxtTaiKhoan.Size = new System.Drawing.Size(482, 83);
            this.lblTxtTaiKhoan.TabIndex = 2;
            this.lblTxtTaiKhoan.TextValue = "";
            // 
            // lblHeader
            // 
            this.lblHeader.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHeader.AutoSize = true;
            this.lblHeader.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHeader.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.lblHeader.Location = new System.Drawing.Point(68, 34);
            this.lblHeader.Name = "lblHeader";
            this.lblHeader.Size = new System.Drawing.Size(546, 45);
            this.lblHeader.TabIndex = 2;
            this.lblHeader.Text = "ĐĂNG NHẬP VÀO HỆ THỐNG";
            this.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Login_Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(682, 453);
            this.Controls.Add(this.tableLayoutForm);
            this.Name = "Login_Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Layout_Load);
            this.tableLayoutForm.ResumeLayout(false);
            this.tableLayoutForm.PerformLayout();
            this.ResumeLayout(false);

            }

            #endregion

            private System.Windows.Forms.TableLayoutPanel tableLayoutForm;
            private System.Windows.Forms.Label lblHeader;
        private System.Windows.Forms.Button btnLogin;
        private LayoutTest.GUIComponents.LableTextBox lblTxtMatKhau;
        private LayoutTest.GUIComponents.LableTextBox lblTxtTaiKhoan;
    }
    }