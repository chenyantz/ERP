namespace AmbleClient.SO
{
    partial class SoItemsControl
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.tbPartNo = new System.Windows.Forms.TextBox();
            this.cbSaleType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbMfg = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbRohs = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbDc = new System.Windows.Forms.TextBox();
            this.tbIntPartNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbShipFrom = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbShipMethod = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbTrackingNo = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbQty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbQtyShipped = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbUnitPrice = new System.Windows.Forms.TextBox();
            this.cbCurrency = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tbTotal = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label16 = new System.Windows.Forms.Label();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label17 = new System.Windows.Forms.Label();
            this.tbShipInst = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbPackingInst = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sale Type:";
            // 
            // tbPartNo
            // 
            this.tbPartNo.Location = new System.Drawing.Point(322, 28);
            this.tbPartNo.Name = "tbPartNo";
            this.tbPartNo.Size = new System.Drawing.Size(100, 20);
            this.tbPartNo.TabIndex = 1;
            // 
            // cbSaleType
            // 
            this.cbSaleType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSaleType.FormattingEnabled = true;
            this.cbSaleType.Items.AddRange(new object[] {
            "OEM EXCESS",
            "OWN STOCK",
            "OTHERS"});
            this.cbSaleType.Location = new System.Drawing.Point(104, 29);
            this.cbSaleType.Name = "cbSaleType";
            this.cbSaleType.Size = new System.Drawing.Size(121, 21);
            this.cbSaleType.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(254, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Part #";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(451, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mfg";
            // 
            // tbMfg
            // 
            this.tbMfg.Location = new System.Drawing.Point(493, 31);
            this.tbMfg.Name = "tbMfg";
            this.tbMfg.Size = new System.Drawing.Size(100, 20);
            this.tbMfg.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(23, 74);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "RoHS";
            // 
            // cbRohs
            // 
            this.cbRohs.AutoSize = true;
            this.cbRohs.Location = new System.Drawing.Point(73, 74);
            this.cbRohs.Name = "cbRohs";
            this.cbRohs.Size = new System.Drawing.Size(15, 14);
            this.cbRohs.TabIndex = 7;
            this.cbRohs.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(127, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "D/C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(348, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Int Part #";
            // 
            // tbDc
            // 
            this.tbDc.Location = new System.Drawing.Point(183, 70);
            this.tbDc.Name = "tbDc";
            this.tbDc.Size = new System.Drawing.Size(100, 20);
            this.tbDc.TabIndex = 10;
            // 
            // tbIntPartNo
            // 
            this.tbIntPartNo.Location = new System.Drawing.Point(443, 70);
            this.tbIntPartNo.Name = "tbIntPartNo";
            this.tbIntPartNo.Size = new System.Drawing.Size(150, 20);
            this.tbIntPartNo.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 121);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ship From:";
            // 
            // tbShipFrom
            // 
            this.tbShipFrom.Location = new System.Drawing.Point(104, 112);
            this.tbShipFrom.Name = "tbShipFrom";
            this.tbShipFrom.Size = new System.Drawing.Size(129, 20);
            this.tbShipFrom.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(251, 121);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Ship Method";
            // 
            // tbShipMethod
            // 
            this.tbShipMethod.Location = new System.Drawing.Point(350, 112);
            this.tbShipMethod.Name = "tbShipMethod";
            this.tbShipMethod.Size = new System.Drawing.Size(119, 20);
            this.tbShipMethod.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(20, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 13);
            this.label9.TabIndex = 16;
            this.label9.Text = "Tracking #";
            // 
            // tbTrackingNo
            // 
            this.tbTrackingNo.Location = new System.Drawing.Point(99, 147);
            this.tbTrackingNo.Name = "tbTrackingNo";
            this.tbTrackingNo.Size = new System.Drawing.Size(134, 20);
            this.tbTrackingNo.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(251, 157);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 13);
            this.label10.TabIndex = 18;
            this.label10.Text = "Qty:";
            // 
            // tbQty
            // 
            this.tbQty.Location = new System.Drawing.Point(287, 147);
            this.tbQty.Name = "tbQty";
            this.tbQty.Size = new System.Drawing.Size(100, 20);
            this.tbQty.TabIndex = 19;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(408, 157);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 13);
            this.label11.TabIndex = 20;
            this.label11.Text = "Qty Shipped:";
            // 
            // tbQtyShipped
            // 
            this.tbQtyShipped.Location = new System.Drawing.Point(501, 147);
            this.tbQtyShipped.Name = "tbQtyShipped";
            this.tbQtyShipped.Size = new System.Drawing.Size(92, 20);
            this.tbQtyShipped.TabIndex = 21;
            this.tbQtyShipped.TextChanged += new System.EventHandler(this.tbQtyShipped_TextChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(20, 204);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 22;
            this.label12.Text = "Currency:";
            // 
            // tbUnitPrice
            // 
            this.tbUnitPrice.Location = new System.Drawing.Point(287, 194);
            this.tbUnitPrice.Name = "tbUnitPrice";
            this.tbUnitPrice.Size = new System.Drawing.Size(100, 20);
            this.tbUnitPrice.TabIndex = 23;
            this.tbUnitPrice.TextChanged += new System.EventHandler(this.tbUnitPrice_TextChanged);
            // 
            // cbCurrency
            // 
            this.cbCurrency.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurrency.FormattingEnabled = true;

            this.cbCurrency.Location = new System.Drawing.Point(99, 194);
            this.cbCurrency.Name = "cbCurrency";
            this.cbCurrency.Size = new System.Drawing.Size(86, 21);
            this.cbCurrency.TabIndex = 24;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(212, 203);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 13);
            this.label13.TabIndex = 25;
            this.label13.Text = "Unit Price:";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(433, 203);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 26;
            this.label14.Text = "Total:";
            // 
            // tbTotal
            // 
            this.tbTotal.Location = new System.Drawing.Point(493, 192);
            this.tbTotal.Name = "tbTotal";
            this.tbTotal.ReadOnly = true;
            this.tbTotal.Size = new System.Drawing.Size(100, 20);
            this.tbTotal.TabIndex = 27;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 247);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(62, 13);
            this.label15.TabIndex = 28;
            this.label15.Text = "Dock Date:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(93, 241);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(134, 20);
            this.dateTimePicker1.TabIndex = 29;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(287, 246);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(72, 13);
            this.label16.TabIndex = 30;
            this.label16.Text = "Shipped Date";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(387, 241);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.ShowCheckBox = true;
            this.dateTimePicker2.Size = new System.Drawing.Size(144, 20);
            this.dateTimePicker2.TabIndex = 31;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 291);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(108, 13);
            this.label17.TabIndex = 32;
            this.label17.Text = "Shipping Instructions:";
            // 
            // tbShipInst
            // 
            this.tbShipInst.Location = new System.Drawing.Point(22, 309);
            this.tbShipInst.Multiline = true;
            this.tbShipInst.Name = "tbShipInst";
            this.tbShipInst.Size = new System.Drawing.Size(604, 63);
            this.tbShipInst.TabIndex = 33;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(18, 393);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(106, 13);
            this.label18.TabIndex = 34;
            this.label18.Text = "Packing Instructions:";
            // 
            // tbPackingInst
            // 
            this.tbPackingInst.Location = new System.Drawing.Point(20, 410);
            this.tbPackingInst.Multiline = true;
            this.tbPackingInst.Name = "tbPackingInst";
            this.tbPackingInst.Size = new System.Drawing.Size(606, 57);
            this.tbPackingInst.TabIndex = 35;
            // 
            // SoItemsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tbPackingInst);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.tbShipInst);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.tbTotal);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.cbCurrency);
            this.Controls.Add(this.tbUnitPrice);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.tbQtyShipped);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbQty);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.tbTrackingNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.tbShipMethod);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tbShipFrom);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.tbIntPartNo);
            this.Controls.Add(this.tbDc);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cbRohs);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbMfg);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbSaleType);
            this.Controls.Add(this.tbPartNo);
            this.Controls.Add(this.label1);
            this.Name = "SoItemsControl";
            this.Size = new System.Drawing.Size(672, 496);
            this.Load += new System.EventHandler(this.SoItemsControl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbPartNo;
        private System.Windows.Forms.ComboBox cbSaleType;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbMfg;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox cbRohs;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbDc;
        private System.Windows.Forms.TextBox tbIntPartNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbShipFrom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbShipMethod;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox tbTrackingNo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbQty;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbQtyShipped;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbUnitPrice;
        private System.Windows.Forms.ComboBox cbCurrency;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbShipInst;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox tbPackingInst;
    }
}
