namespace HospitalManagerment.GUI.Pages.DichVu
{
    partial class DichVuPage
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.DichVuTab = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.DichVuTab);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1338, 882);
            this.tabControl1.TabIndex = 0;
            // 
            // DichVuTab
            // 
            this.DichVuTab.Location = new System.Drawing.Point(4, 29);
            this.DichVuTab.Name = "DichVuTab";
            this.DichVuTab.Padding = new System.Windows.Forms.Padding(3);
            this.DichVuTab.Size = new System.Drawing.Size(1330, 849);
            this.DichVuTab.TabIndex = 0;
            this.DichVuTab.Text = "Dịch vụ";
            this.DichVuTab.UseVisualStyleBackColor = true;
            // 
            // DichVuPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "DichVuPage";
            this.Size = new System.Drawing.Size(1338, 882);
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage DichVuTab;
    }
}
