namespace AmbleClient.Order.PoView
{
    partial class PoItemsView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoItemsView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tscbOp = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.poItemsControl1 = new AmbleClient.PO.PoItemsControl();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbOp,
            this.tsbClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(699, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tscbOp
            // 
            this.tscbOp.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tscbOp.Image = ((System.Drawing.Image)(resources.GetObject("tscbOp.Image")));
            this.tscbOp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tscbOp.Name = "tscbOp";
            this.tscbOp.Size = new System.Drawing.Size(66, 22);
            this.tscbOp.Text = "Op&&Close";
            this.tscbOp.Click += new System.EventHandler(this.tscbOp_Click);
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
            // poItemsControl1
            // 
            this.poItemsControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.poItemsControl1.Location = new System.Drawing.Point(0, 25);
            this.poItemsControl1.Name = "poItemsControl1";
            this.poItemsControl1.Size = new System.Drawing.Size(699, 463);
            this.poItemsControl1.TabIndex = 1;
            // 
            // PoItemsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(699, 488);
            this.Controls.Add(this.poItemsControl1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PoItemsView";
            this.Text = "PoItemsViewAdd";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tscbOp;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private PO.PoItemsControl poItemsControl1;
    }
}