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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.roundedPanel1 = new HospitalManagerment.GUI.Component.RoundedPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lableTextBox1 = new LayoutTest.GUIComponents.LableTextBox();
            this.lableTextBox2 = new LayoutTest.GUIComponents.LableTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.roundedPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.roundedPanel1, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1282, 753);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // roundedPanel1
            // 
            this.roundedPanel1.BackColor = System.Drawing.Color.Transparent;
            this.roundedPanel1.BorderRadius = 40;
            this.roundedPanel1.Controls.Add(this.tableLayoutPanel2);
            this.roundedPanel1.Location = new System.Drawing.Point(387, 191);
            this.roundedPanel1.Name = "roundedPanel1";
            this.roundedPanel1.PanelColor = System.Drawing.Color.White;
            this.roundedPanel1.PanelHeight = 400;
            this.roundedPanel1.PanelWidth = 800;
            this.roundedPanel1.Size = new System.Drawing.Size(635, 445);
            this.roundedPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lableTextBox1, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.lableTextBox2, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(635, 445);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lableTextBox1
            // 
            this.lableTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.lableTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lableTextBox1.LabelText = "Tài khoản";
            this.lableTextBox1.Location = new System.Drawing.Point(120, 136);
            this.lableTextBox1.Margin = new System.Windows.Forms.Padding(120, 25, 120, 5);
            this.lableTextBox1.Name = "lableTextBox1";
            this.lableTextBox1.PanelHeight = 60;
            this.lableTextBox1.PanelWidth = 200;
            this.lableTextBox1.Size = new System.Drawing.Size(395, 81);
            this.lableTextBox1.TabIndex = 0;
            this.lableTextBox1.TextValue = "";
            this.lableTextBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.lableTextBox1_Paint_1);
            // 
            // lableTextBox2
            // 
            this.lableTextBox2.BackColor = System.Drawing.Color.Transparent;
            this.lableTextBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lableTextBox2.LabelText = "Mật khẩu";
            this.lableTextBox2.Location = new System.Drawing.Point(120, 227);
            this.lableTextBox2.Margin = new System.Windows.Forms.Padding(120, 5, 120, 25);
            this.lableTextBox2.Name = "lableTextBox2";
            this.lableTextBox2.PanelHeight = 60;
            this.lableTextBox2.PanelWidth = 200;
            this.lableTextBox2.Size = new System.Drawing.Size(395, 81);
            this.lableTextBox2.TabIndex = 1;
            this.lableTextBox2.TextValue = "";
            this.lableTextBox2.Paint += new System.Windows.Forms.PaintEventHandler(this.lableTextBox2_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(629, 111);
            this.label1.TabIndex = 2;
            this.label1.Text = "ĐĂNG NHẬP VÀO HỆ THỐNG";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(200, 343);
            this.button1.Margin = new System.Windows.Forms.Padding(200, 10, 200, 40);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(235, 62);
            this.button1.TabIndex = 3;
            this.button1.Text = "ĐĂNG NHẬP";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Login_Layout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1282, 753);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Login_Layout";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Login_Layout_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.roundedPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private Component.RoundedPanel roundedPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private LayoutTest.GUIComponents.LableTextBox lableTextBox1;
        private LayoutTest.GUIComponents.LableTextBox lableTextBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}