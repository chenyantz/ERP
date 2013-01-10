namespace AmbleClient.RfqGui
{
    partial class NewRfq
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewRfq));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.tsbCreateAnother = new System.Windows.Forms.ToolStripButton();
            this.tsbRoute = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.rfqItems1 = new AmbleClient.RfqGui.SalesNewRfqItems();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.tsbPaste,
            this.tsbCreateAnother,
            this.tsbRoute,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(933, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSave.Image = ((System.Drawing.Image)(resources.GetObject("tsbSave.Image")));
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(35, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPaste.Image = ((System.Drawing.Image)(resources.GetObject("tsbPaste.Image")));
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(64, 22);
            this.tsbPaste.Text = "Paste RFQ";
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            // 
            // tsbCreateAnother
            // 
            this.tsbCreateAnother.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCreateAnother.Image = ((System.Drawing.Image)(resources.GetObject("tsbCreateAnother.Image")));
            this.tsbCreateAnother.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCreateAnother.Name = "tsbCreateAnother";
            this.tsbCreateAnother.Size = new System.Drawing.Size(116, 22);
            this.tsbCreateAnother.Text = "Create Another RFQ";
            this.tsbCreateAnother.Click += new System.EventHandler(this.tsbCreateAnother_Click);
            // 
            // tsbRoute
            // 
            this.tsbRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRoute.Image = ((System.Drawing.Image)(resources.GetObject("tsbRoute.Image")));
            this.tsbRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoute.Name = "tsbRoute";
            this.tsbRoute.Size = new System.Drawing.Size(42, 22);
            this.tsbRoute.Text = "Route";
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
            // rfqItems1
            // 
            this.rfqItems1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfqItems1.Location = new System.Drawing.Point(0, 25);
            this.rfqItems1.Name = "rfqItems1";
            this.rfqItems1.Size = new System.Drawing.Size(933, 545);
            this.rfqItems1.TabIndex = 1;
            // 
            // NewRfq
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(933, 570);
            this.Controls.Add(this.rfqItems1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "NewRfq";
            this.Text = "New RFQ";
            this.Load += new System.EventHandler(this.NewRfq_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripButton tsbRoute;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private SalesNewRfqItems rfqItems1;
        private System.Windows.Forms.ToolStripButton tsbCreateAnother;
        private System.Windows.Forms.ToolStripButton tsbPaste;
    }
}