namespace AmbleClient.RfqGui
{
    partial class BuyerManagerRfqView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyerManagerRfqView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbAssign = new System.Windows.Forms.ToolStripButton();
            this.tsbOffer = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.buyerManagerRfqItems1 = new AmbleClient.RfqGui.BuyerManagerRfqItems();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAssign,
            this.tsbOffer,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(886, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbAssign
            // 
            this.tsbAssign.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAssign.Image = ((System.Drawing.Image)(resources.GetObject("tsbAssign.Image")));
            this.tsbAssign.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAssign.Name = "tsbAssign";
            this.tsbAssign.Size = new System.Drawing.Size(146, 22);
            this.tsbAssign.Text = "Assign P/A and Update";
            this.tsbAssign.Click += new System.EventHandler(this.tsbAssign_Click);
            // 
            // tsbOffer
            // 
            this.tsbOffer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOffer.Image = ((System.Drawing.Image)(resources.GetObject("tsbOffer.Image")));
            this.tsbOffer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOffer.Name = "tsbOffer";
            this.tsbOffer.Size = new System.Drawing.Size(75, 22);
            this.tsbOffer.Text = "Enter Offer";
            // 
            // tsbClose
            // 
            this.tsbClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(43, 22);
            this.tsbClose.Text = "Close";
            // 
            // buyerManagerRfqItems1
            // 
            this.buyerManagerRfqItems1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buyerManagerRfqItems1.Location = new System.Drawing.Point(0, 28);
            this.buyerManagerRfqItems1.Name = "buyerManagerRfqItems1";
            this.buyerManagerRfqItems1.Size = new System.Drawing.Size(886, 515);
            this.buyerManagerRfqItems1.TabIndex = 1;
            // 
            // BuyerManagerRfqView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 546);
            this.Controls.Add(this.buyerManagerRfqItems1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BuyerManagerRfqView";
            this.Text = "BuyManagerRfqView";
            this.Load += new System.EventHandler(this.BuyerManagerRfqView_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbAssign;
        private System.Windows.Forms.ToolStripButton tsbOffer;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private BuyerManagerRfqItems buyerManagerRfqItems1;
    }
}