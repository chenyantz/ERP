namespace AmbleClient.OrderTemplate
{
    partial class OrderListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderListView));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tscbList = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.tscbFilterColumn = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel3 = new System.Windows.Forms.ToolStripLabel();
            this.tstbFilterString = new System.Windows.Forms.ToolStripTextBox();
            this.tsbApply = new System.Windows.Forms.ToolStripButton();
            this.tsbClear = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cbNew = new System.Windows.Forms.CheckBox();
            this.cbApproved = new System.Windows.Forms.CheckBox();
            this.cbRejected = new System.Windows.Forms.CheckBox();
            this.cbClosed = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tscbList,
            this.toolStripSeparator1,
            this.toolStripLabel2,
            this.tscbFilterColumn,
            this.toolStripLabel3,
            this.tstbFilterString,
            this.tsbApply,
            this.tsbClear,
            this.toolStripSeparator2,
            this.tsbRefresh,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1074, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(28, 22);
            this.toolStripLabel1.Text = "List:";
            // 
            // tscbList
            // 
            this.tscbList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbList.Name = "tscbList";
            this.tscbList.Size = new System.Drawing.Size(121, 25);
            this.tscbList.SelectedIndexChanged += new System.EventHandler(this.tscbList_SelectedIndexChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(52, 22);
            this.toolStripLabel2.Text = "Filter By:";
            // 
            // tscbFilterColumn
            // 
            this.tscbFilterColumn.Name = "tscbFilterColumn";
            this.tscbFilterColumn.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripLabel3
            // 
            this.toolStripLabel3.Name = "toolStripLabel3";
            this.toolStripLabel3.Size = new System.Drawing.Size(70, 22);
            this.toolStripLabel3.Text = "Filter String:";
            // 
            // tstbFilterString
            // 
            this.tstbFilterString.Name = "tstbFilterString";
            this.tstbFilterString.Size = new System.Drawing.Size(100, 25);
            // 
            // tsbApply
            // 
            this.tsbApply.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbApply.Image = ((System.Drawing.Image)(resources.GetObject("tsbApply.Image")));
            this.tsbApply.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbApply.Name = "tsbApply";
            this.tsbApply.Size = new System.Drawing.Size(42, 22);
            this.tsbApply.Text = "Apply";
            this.tsbApply.Click += new System.EventHandler(this.tsbApply_Click);
            // 
            // tsbClear
            // 
            this.tsbClear.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbClear.Image = ((System.Drawing.Image)(resources.GetObject("tsbClear.Image")));
            this.tsbClear.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbClear.Name = "tsbClear";
            this.tsbClear.Size = new System.Drawing.Size(38, 22);
            this.tsbClear.Text = "Clear";
            this.tsbClear.Click += new System.EventHandler(this.tsbClear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(50, 22);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // cbNew
            // 
            this.cbNew.AutoSize = true;
            this.cbNew.Location = new System.Drawing.Point(10, 38);
            this.cbNew.Name = "cbNew";
            this.cbNew.Size = new System.Drawing.Size(48, 17);
            this.cbNew.TabIndex = 1;
            this.cbNew.Text = "New";
            this.cbNew.UseVisualStyleBackColor = true;
            this.cbNew.CheckedChanged += new System.EventHandler(this.OrderStatesCheckedChanged);
            // 
            // cbApproved
            // 
            this.cbApproved.AutoSize = true;
            this.cbApproved.Location = new System.Drawing.Point(77, 38);
            this.cbApproved.Name = "cbApproved";
            this.cbApproved.Size = new System.Drawing.Size(72, 17);
            this.cbApproved.TabIndex = 2;
            this.cbApproved.Text = "Approved";
            this.cbApproved.UseVisualStyleBackColor = true;
            this.cbApproved.CheckedChanged += new System.EventHandler(this.OrderStatesCheckedChanged);
            // 
            // cbRejected
            // 
            this.cbRejected.AutoSize = true;
            this.cbRejected.Location = new System.Drawing.Point(178, 38);
            this.cbRejected.Name = "cbRejected";
            this.cbRejected.Size = new System.Drawing.Size(69, 17);
            this.cbRejected.TabIndex = 3;
            this.cbRejected.Text = "Rejected";
            this.cbRejected.UseVisualStyleBackColor = true;
            this.cbRejected.CheckedChanged += new System.EventHandler(this.OrderStatesCheckedChanged);
            // 
            // cbClosed
            // 
            this.cbClosed.AutoSize = true;
            this.cbClosed.Location = new System.Drawing.Point(265, 38);
            this.cbClosed.Name = "cbClosed";
            this.cbClosed.Size = new System.Drawing.Size(58, 17);
            this.cbClosed.TabIndex = 4;
            this.cbClosed.Text = "Closed";
            this.cbClosed.UseVisualStyleBackColor = true;
            this.cbClosed.CheckedChanged += new System.EventHandler(this.OrderStatesCheckedChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(0, 61);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(1074, 485);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // OrderListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1074, 545);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.cbClosed);
            this.Controls.Add(this.cbRejected);
            this.Controls.Add(this.cbApproved);
            this.Controls.Add(this.cbNew);
            this.Controls.Add(this.toolStrip1);
            this.Name = "OrderListView";
            this.Text = "OrderListView";
            this.Load += new System.EventHandler(this.OrderListView_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OrderListView_KeyDown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        protected System.Windows.Forms.ToolStripComboBox tscbList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        protected System.Windows.Forms.ToolStripComboBox tscbFilterColumn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel3;
        private System.Windows.Forms.ToolStripTextBox tstbFilterString;
        private System.Windows.Forms.ToolStripButton tsbApply;
        private System.Windows.Forms.ToolStripButton tsbClear;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.CheckBox cbNew;
        protected System.Windows.Forms.CheckBox cbApproved;
        protected System.Windows.Forms.CheckBox cbRejected;
        protected System.Windows.Forms.CheckBox cbClosed;
        protected System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}