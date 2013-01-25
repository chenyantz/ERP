namespace AmbleClient.SO
{
    partial class SoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SoView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbApprove = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbApprove,
            this.tsbUpdate,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(949, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbApprove
            // 
            this.tsbApprove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbApprove.Image = ((System.Drawing.Image)(resources.GetObject("tsbApprove.Image")));
            this.tsbApprove.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApprove.Name = "tsbApprove";
            this.tsbApprove.Size = new System.Drawing.Size(56, 22);
            this.tsbApprove.Text = "Approve";
            this.tsbApprove.Click += new System.EventHandler(this.tsbApprove_Click);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(49, 22);
            this.tsbUpdate.Text = "Update";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(40, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(949, 523);
            this.tabControl1.TabIndex = 1;
            // 
            // SoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 548);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SoView";
            this.Text = "SoView";
            this.Load += new System.EventHandler(this.SoView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbApprove;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.TabControl tabControl1;
       // private System.Windows.Forms.TabPage tabPage1;
       //private System.Windows.Forms.TabPage tabPage2;
    }
}