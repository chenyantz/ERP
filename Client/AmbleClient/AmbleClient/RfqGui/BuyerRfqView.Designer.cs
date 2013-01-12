namespace AmbleClient.RfqGui
{
    partial class BuyerRfqView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BuyerRfqView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.buyerRfqItems1 = new AmbleClient.RfqGui.BuyerRfqItems();
            this.tsbOffer = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbOffer,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(904, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // buyerRfqItems1
            // 
            this.buyerRfqItems1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buyerRfqItems1.Location = new System.Drawing.Point(0, 28);
            this.buyerRfqItems1.Name = "buyerRfqItems1";
            this.buyerRfqItems1.Size = new System.Drawing.Size(904, 506);
            this.buyerRfqItems1.TabIndex = 1;
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
            // BuyerRfqView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(904, 533);
            this.Controls.Add(this.buyerRfqItems1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "BuyerRfqView";
            this.Text = "BuyerRfqView";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private BuyerRfqItems buyerRfqItems1;
        private System.Windows.Forms.ToolStripButton tsbOffer;
        private System.Windows.Forms.ToolStripButton tsbClose;
    }
}