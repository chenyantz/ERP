namespace AmbleClient.SO
{
    partial class Form1
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
            this.soItemsGridView1 = new AmbleClient.SO.SoItemsGridView();
            ((System.ComponentModel.ISupportInitialize)(this.soItemsGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // soItemsGridView1
            // 
            this.soItemsGridView1.AllowUserToAddRows = false;
            this.soItemsGridView1.AllowUserToDeleteRows = false;
            this.soItemsGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;

            this.soItemsGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.soItemsGridView1.Enabled = false;
            this.soItemsGridView1.Location = new System.Drawing.Point(0, 0);
            this.soItemsGridView1.Name = "soItemsGridView1";
            this.soItemsGridView1.RowTemplate.Height = 23;
            this.soItemsGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.soItemsGridView1.Size = new System.Drawing.Size(284, 261);
            this.soItemsGridView1.TabIndex = 0;
            // 

            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.soItemsGridView1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.soItemsGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private SoItemsGridView soItemsGridView1;

    }
}