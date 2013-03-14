namespace AmbleClient.SO
{
    partial class BuyerSoView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyerSoView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbEnterPo = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.soViewControl1 = new AmbleClient.SO.SoViewControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbEnterPo,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(916, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbEnterPo
            // 
            this.tsbEnterPo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbEnterPo.Image = ((System.Drawing.Image)(resources.GetObject("tsbEnterPo.Image")));
            this.tsbEnterPo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbEnterPo.Name = "tsbEnterPo";
            this.tsbEnterPo.Size = new System.Drawing.Size(57, 22);
            this.tsbEnterPo.Text = "Enter PO";
            this.tsbEnterPo.Click += new System.EventHandler(this.tsbEnterPo_Click);
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
            // soViewControl1
            // 
            this.soViewControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soViewControl1.Location = new System.Drawing.Point(0, 25);
            this.soViewControl1.Name = "soViewControl1";
            this.soViewControl1.Size = new System.Drawing.Size(916, 575);
            this.soViewControl1.TabIndex = 1;
            // 
            // BuyerSoView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(916, 600);
            this.Controls.Add(this.soViewControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BuyerSoView";
            this.Text = "BuyerSoView";
            this.Load += new System.EventHandler(this.BuyerSoView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbEnterPo;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private SoViewControl soViewControl1;

    }
}