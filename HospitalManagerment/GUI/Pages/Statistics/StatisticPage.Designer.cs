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
            this.tabControlDesign1 = new HospitalManagerment.GUI.Components.TabControlDesign();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabControlDesign1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlDesign1
            // 
            this.tabControlDesign1.Controls.Add(this.tabPage1);
            this.tabControlDesign1.Controls.Add(this.tabPage2);
            this.tabControlDesign1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlDesign1.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
            this.tabControlDesign1.ItemSize = new System.Drawing.Size(200, 45);
            this.tabControlDesign1.Location = new System.Drawing.Point(0, 0);
            this.tabControlDesign1.Name = "tabControlDesign1";
            this.tabControlDesign1.SelectedIndex = 0;
            this.tabControlDesign1.Size = new System.Drawing.Size(1600, 820);
            this.tabControlDesign1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControlDesign1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Location = new System.Drawing.Point(4, 49);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1592, 767);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "tabPage1";
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.Color.White;
            this.tabPage2.Location = new System.Drawing.Point(4, 49);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1592, 767);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            // 
            // StatisticPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControlDesign1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "StatisticPage";
            this.Size = new System.Drawing.Size(1600, 820);
            this.tabControlDesign1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Components.TabControlDesign tabControlDesign1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
    }
}
