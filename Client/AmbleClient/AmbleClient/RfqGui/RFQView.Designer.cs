namespace AmbleClient.RfqGui
{
    partial class RFQView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RFQView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbRoute = new System.Windows.Forms.ToolStripButton();
            this.tsbQuote = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbSo = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tsbViewSo = new System.Windows.Forms.ToolStripButton();
            this.tsbPrint = new System.Windows.Forms.ToolStripButton();
            this.tsbCloseRfq = new System.Windows.Forms.ToolStripButton();
            this.rfqItems1 = new AmbleClient.RfqGui.SalesRfqItems();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRoute,
            this.tsbQuote,
            this.tsbUpdate,
            this.tsbCopy,
            this.tsbSo,
            this.tsbViewSo,
            this.tsbPrint,
            this.tsbCloseRfq,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(912, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbRoute
            // 
            this.tsbRoute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRoute.Image = ((System.Drawing.Image)(resources.GetObject("tsbRoute.Image")));
            this.tsbRoute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRoute.Name = "tsbRoute";
            this.tsbRoute.Size = new System.Drawing.Size(42, 22);
            this.tsbRoute.Text = "Route";
            this.tsbRoute.Click += new System.EventHandler(this.tsbRoute_Click);
            // 
            // tsbQuote
            // 
            this.tsbQuote.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQuote.Image = ((System.Drawing.Image)(resources.GetObject("tsbQuote.Image")));
            this.tsbQuote.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQuote.Name = "tsbQuote";
            this.tsbQuote.Size = new System.Drawing.Size(44, 22);
            this.tsbQuote.Text = "Quote";
            this.tsbQuote.Click += new System.EventHandler(this.tsbQuote_Click);
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCopy.Image = ((System.Drawing.Image)(resources.GetObject("tsbCopy.Image")));
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(39, 22);
            this.tsbCopy.Text = "Copy";
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            // 
            // tsbSo
            // 
            this.tsbSo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSo.Image = ((System.Drawing.Image)(resources.GetObject("tsbSo.Image")));
            this.tsbSo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSo.Name = "tsbSo";
            this.tsbSo.Size = new System.Drawing.Size(70, 22);
            this.tsbSo.Text = "Sales Order";
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdate.Image = ((System.Drawing.Image)(resources.GetObject("tsbUpdate.Image")));
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(49, 22);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tsbViewSo
            // 
            this.tsbViewSo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbViewSo.Image = ((System.Drawing.Image)(resources.GetObject("tsbViewSo.Image")));
            this.tsbViewSo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbViewSo.Name = "tsbViewSo";
            this.tsbViewSo.Size = new System.Drawing.Size(54, 22);
            this.tsbViewSo.Text = "View SO";
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPrint.Image = ((System.Drawing.Image)(resources.GetObject("tsbPrint.Image")));
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(36, 22);
            this.tsbPrint.Text = "Print";
            // 
            // tsbCloseRfq
            // 
            this.tsbCloseRfq.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCloseRfq.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseRfq.Image")));
            this.tsbCloseRfq.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseRfq.Name = "tsbCloseRfq";
            this.tsbCloseRfq.Size = new System.Drawing.Size(65, 22);
            this.tsbCloseRfq.Text = "Close RFQ";
            // 
            // rfqItems1
            // 
            this.rfqItems1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rfqItems1.Location = new System.Drawing.Point(0, 25);
            this.rfqItems1.Name = "rfqItems1";
            this.rfqItems1.Size = new System.Drawing.Size(912, 555);
            this.rfqItems1.TabIndex = 1;
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(40, 22);
            this.tsbClose.Text = "Close";
            // 
            // RFQView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 580);
            this.Controls.Add(this.rfqItems1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "RFQView";
            this.Text = "RFQView";
            this.Load += new System.EventHandler(this.RFQView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbRoute;
        private System.Windows.Forms.ToolStripButton tsbQuote;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripButton tsbCopy;
        private System.Windows.Forms.ToolStripButton tsbSo;
        private System.Windows.Forms.ToolStripButton tsbViewSo;
        private System.Windows.Forms.ToolStripButton tsbPrint;
        private System.Windows.Forms.ToolStripButton tsbCloseRfq;
        private SalesRfqItems rfqItems1;
        private System.Windows.Forms.ToolStripButton tsbClose;
    }
}