namespace HM.GUI.Pages.Statistics
{
    partial class StatisticPage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControlThongKe = new HM.GUI.Components.TabControlDesign();
            this.tabPageThongKe = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.thongKePanel = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.toDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.formDate = new System.Windows.Forms.DateTimePicker();
            this.buttonThongKe = new HM.GUI.Component.RoundedLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTongTien = new System.Windows.Forms.TextBox();
            this.tabControlThongKe.SuspendLayout();
            this.tabPageThongKe.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlThongKe
            // 
            this.tabControlThongKe.Controls.Add(this.tabPageThongKe);
            this.tabControlThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlThongKe.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlThongKe.ItemSize = new System.Drawing.Size(200, 45);
            this.tabControlThongKe.Location = new System.Drawing.Point(0, 0);
            this.tabControlThongKe.Margin = new System.Windows.Forms.Padding(0);
            this.tabControlThongKe.Name = "tabControlThongKe";
            this.tabControlThongKe.SelectedIndex = 0;
            this.tabControlThongKe.Size = new System.Drawing.Size(1400, 820);
            this.tabControlThongKe.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlThongKe.TabIndex = 0;
            // 
            // tabPageThongKe
            // 
            this.tabPageThongKe.BackColor = System.Drawing.Color.White;
            this.tabPageThongKe.Controls.Add(this.tableLayoutPanel1);
            this.tabPageThongKe.Location = new System.Drawing.Point(4, 49);
            this.tabPageThongKe.Margin = new System.Windows.Forms.Padding(50);
            this.tabPageThongKe.Name = "tabPageThongKe";
            this.tabPageThongKe.Size = new System.Drawing.Size(1392, 767);
            this.tabPageThongKe.TabIndex = 0;
            this.tabPageThongKe.Text = "Thống kê";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.thongKePanel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(50);
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1392, 767);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // thongKePanel
            // 
            this.thongKePanel.BackColor = System.Drawing.Color.IndianRed;
            this.thongKePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.thongKePanel.Location = new System.Drawing.Point(50, 111);
            this.thongKePanel.Margin = new System.Windows.Forms.Padding(0);
            this.thongKePanel.Name = "thongKePanel";
            this.thongKePanel.Size = new System.Drawing.Size(1292, 555);
            this.thongKePanel.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(50, 50);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 0, 0, 30);
            this.panel2.Size = new System.Drawing.Size(1292, 61);
            this.panel2.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 5;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.Controls.Add(this.toDate, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.formDate, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonThongKe, 4, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1292, 31);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // toDate
            // 
            this.toDate.CalendarForeColor = System.Drawing.Color.Gray;
            this.toDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toDate.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toDate.Location = new System.Drawing.Point(612, 0);
            this.toDate.Margin = new System.Windows.Forms.Padding(0);
            this.toDate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.toDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.toDate.Name = "toDate";
            this.toDate.Size = new System.Drawing.Size(452, 35);
            this.toDate.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.label2.Location = new System.Drawing.Point(515, 0);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label2.Size = new System.Drawing.Size(94, 31);
            this.label2.TabIndex = 1;
            this.label2.Text = "Đến:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label1.Size = new System.Drawing.Size(54, 31);
            this.label1.TabIndex = 0;
            this.label1.Text = "Từ:";
            // 
            // formDate
            // 
            this.formDate.CalendarForeColor = System.Drawing.Color.Gray;
            this.formDate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formDate.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.formDate.Location = new System.Drawing.Point(60, 0);
            this.formDate.Margin = new System.Windows.Forms.Padding(0);
            this.formDate.MaxDate = new System.DateTime(3000, 12, 31, 0, 0, 0, 0);
            this.formDate.MinDate = new System.DateTime(2020, 1, 1, 0, 0, 0, 0);
            this.formDate.Name = "formDate";
            this.formDate.Size = new System.Drawing.Size(452, 35);
            this.formDate.TabIndex = 2;
            // 
            // buttonThongKe
            // 
            this.buttonThongKe.AutoSize = true;
            this.buttonThongKe.BackColor = System.Drawing.Color.White;
            this.buttonThongKe.BorderRadius = 20;
            this.buttonThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonThongKe.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThongKe.ForeColor = System.Drawing.Color.White;
            this.buttonThongKe.Location = new System.Drawing.Point(1067, 0);
            this.buttonThongKe.MarginBottom = 5;
            this.buttonThongKe.MarginLeft = 60;
            this.buttonThongKe.MarginRight = 0;
            this.buttonThongKe.MarginTop = 0;
            this.buttonThongKe.Name = "buttonThongKe";
            this.buttonThongKe.PanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(211)))), ((int)(((byte)(152)))));
            this.buttonThongKe.PanelHeight = 45;
            this.buttonThongKe.PanelWidth = 160;
            this.buttonThongKe.Size = new System.Drawing.Size(222, 31);
            this.buttonThongKe.TabIndex = 4;
            this.buttonThongKe.Text = "THỐNG KÊ";
            this.buttonThongKe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.buttonThongKe.Click += new System.EventHandler(this.buttonThongKeClick);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.tableLayoutPanel3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(53, 669);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1286, 45);
            this.panel3.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel3.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtTongTien, 2, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1286, 45);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(125)))), ((int)(((byte)(125)))), ((int)(((byte)(125)))));
            this.label3.Location = new System.Drawing.Point(684, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.label3.Size = new System.Drawing.Size(144, 45);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tổng tiền:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txtTongTien
            // 
            this.txtTongTien.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTongTien.Font = new System.Drawing.Font("Tahoma", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTongTien.ForeColor = System.Drawing.Color.Black;
            this.txtTongTien.Location = new System.Drawing.Point(834, 3);
            this.txtTongTien.Name = "txtTongTien";
            this.txtTongTien.Size = new System.Drawing.Size(449, 35);
            this.txtTongTien.TabIndex = 3;
            this.txtTongTien.Text = "..";
            // 
            // StatisticPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.Controls.Add(this.tabControlThongKe);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StatisticPage";
            this.Size = new System.Drawing.Size(1400, 820);
            this.tabControlThongKe.ResumeLayout(false);
            this.tabPageThongKe.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TabControlDesign tabControlThongKe;
        private System.Windows.Forms.TabPage tabPageThongKe;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel thongKePanel;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker formDate;
        private System.Windows.Forms.DateTimePicker toDate;
        private Component.RoundedLabel buttonThongKe;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTongTien;
    }
}
