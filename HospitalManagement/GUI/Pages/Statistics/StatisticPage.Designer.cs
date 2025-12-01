namespace HospitalManagerment.GUI.Pages.Statistics
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
            this.tabControlThongKe = new HospitalManagerment.GUI.Components.TabControlDesign();
            this.tabPageThongKe = new System.Windows.Forms.TabPage();
            this.tabControlThongKe.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlThongKe
            // 
            this.tabControlThongKe.Controls.Add(this.tabPageThongKe);
            this.tabControlThongKe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlThongKe.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlThongKe.ItemSize = new System.Drawing.Size(200, 45);
            this.tabControlThongKe.Location = new System.Drawing.Point(0, 0);
            this.tabControlThongKe.Name = "tabControlThongKe";
            this.tabControlThongKe.SelectedIndex = 0;
            this.tabControlThongKe.Size = new System.Drawing.Size(1400, 820);
            this.tabControlThongKe.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlThongKe.TabIndex = 0;
            // 
            // tabPageThongKe
            // 
            this.tabPageThongKe.BackColor = System.Drawing.Color.White;
            this.tabPageThongKe.Location = new System.Drawing.Point(4, 49);
            this.tabPageThongKe.Name = "tabPageThongKe";
            this.tabPageThongKe.Size = new System.Drawing.Size(1392, 767);
            this.tabPageThongKe.TabIndex = 0;
            this.tabPageThongKe.Text = "Thống kê";
            // 
            // StatisticPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlThongKe);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "StatisticPage";
            this.Size = new System.Drawing.Size(1400, 820);
            this.tabControlThongKe.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TabControlDesign tabControlThongKe;
        private System.Windows.Forms.TabPage tabPageThongKe;
    }
}
