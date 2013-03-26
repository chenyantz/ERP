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
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbPoEnter = new System.Windows.Forms.ToolStripButton();
            this.tsbViewPo = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbStateList = new System.Windows.Forms.ToolStripComboBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUpdate,
            this.tsbPoEnter,
            this.tsbViewPo,
            this.tsbClose,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.tscbStateList});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(959, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(54, 22);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbPoEnter
            // 
            this.tsbPoEnter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPoEnter.Image = ((System.Drawing.Image)(resources.GetObject("tsbPoEnter.Image")));
            this.tsbPoEnter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPoEnter.Name = "tsbPoEnter";
            this.tsbPoEnter.Size = new System.Drawing.Size(62, 22);
            this.tsbPoEnter.Text = "Enter PO";
            this.tsbPoEnter.Click += new System.EventHandler(this.tsbPoEnter_Click);
            // 
            // tsbViewPo
            // 
            this.tsbViewPo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbViewPo.Image = ((System.Drawing.Image)(resources.GetObject("tsbViewPo.Image")));
            this.tsbViewPo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewPo.Name = "tsbViewPo";
            this.tsbViewPo.Size = new System.Drawing.Size(59, 22);
            this.tsbViewPo.Text = "View PO";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(43, 22);
            this.tsbClose.Text = "Close";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(120, 22);
            this.toolStripLabel1.Text = "Set the SO to State:";
            // 
            // tscbStateList
            // 
            this.tscbStateList.Name = "tscbStateList";
            this.tscbStateList.Size = new System.Drawing.Size(200, 25);
            this.tscbStateList.SelectedIndexChanged += new System.EventHandler(this.tscbStateList_SelectedIndexChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 25);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(959, 595);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // SoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 620);
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
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox tscbStateList;
        private System.Windows.Forms.ToolStripButton tsbPoEnter;
        private System.Windows.Forms.ToolStripButton tsbViewPo;
       // private System.Windows.Forms.TabPage tabPage1;
       //private System.Windows.Forms.TabPage tabPage2;
    }
}