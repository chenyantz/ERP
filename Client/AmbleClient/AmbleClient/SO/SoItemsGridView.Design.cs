using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace AmbleClient.SO
{
    public partial class SoItemsGridView : DataGridView
    {
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn saleType;
        private System.Windows.Forms.DataGridViewTextBoxColumn PartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Mfg;
        private System.Windows.Forms.DataGridViewTextBoxColumn Rohs;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dc;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntPartNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipFrom;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShipMethod;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrackingNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Qty;
        private System.Windows.Forms.DataGridViewTextBoxColumn QtyShipped;
        private System.Windows.Forms.DataGridViewTextBoxColumn Currency;
        private System.Windows.Forms.DataGridViewTextBoxColumn UnitPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn Total;
        private System.Windows.Forms.DataGridViewTextBoxColumn DockDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ShippedDate;


        private void InitializeComponent()
        {
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.saleType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Mfg = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Rohs = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntPartNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipFrom = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShipMethod = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrackingNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Qty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QtyShipped = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Currency = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UnitPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Total = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DockDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ShippedDate = new System.Windows.Forms.DataGridViewTextBoxColumn();

            // No
            // 
            this.No.HeaderText = "No";
            this.No.Name = "No";
           
            // 
            // saleType
            // 
            this.saleType.HeaderText = "Sale Type";
            this.saleType.Name = "saleType";
            // 
            // PartNo
            // 
            this.PartNo.HeaderText = "Part #";
            this.PartNo.Name = "PartNo";
            // 
            // Mfg
            // 
            this.Mfg.HeaderText = "Mfg";
            this.Mfg.Name = "Mfg";
            // 
            // Rohs
            // 
            this.Rohs.HeaderText = "ROHS";
            this.Rohs.Name = "Rohs";
            // 
            // Dc
            // 
            this.Dc.HeaderText = "D/C";
            this.Dc.Name = "Dc";
            // 
            // IntPartNo
            // 
            this.IntPartNo.HeaderText = "Int Part #";
            this.IntPartNo.Name = "IntPartNo";
            // 
            // ShipFrom
            // 
            this.ShipFrom.HeaderText = "Ship From";
            this.ShipFrom.Name = "ShipFrom";
            // 
            // ShipMethod
            // 
            this.ShipMethod.HeaderText = "Ship Method";
            this.ShipMethod.Name = "ShipMethod";
            // 
            // TrackingNo
            // 
            this.TrackingNo.HeaderText = "tracking #";
            this.TrackingNo.Name = "TrackingNo";
            // 
            // Qty
            // 
            this.Qty.HeaderText = "Qty";
            this.Qty.Name = "Qty";
            // 
            // QtyShipped
            // 
            this.QtyShipped.HeaderText = "Qty.shipped";
            this.QtyShipped.Name = "QtyShipped";
            // 
            // Currency
            // 
            this.Currency.HeaderText = "Currency";
            this.Currency.Name = "Currency";
            // 
            // UnitPrice
            // 
            this.UnitPrice.HeaderText = "Unit Price";
            this.UnitPrice.Name = "UnitPrice";
            // 
            // Total
            // 
            this.Total.HeaderText = "Total";
            this.Total.Name = "Total";
            // 
            // DockDate
            // 
            this.DockDate.HeaderText = "Dock Date";
            this.DockDate.Name = "DockDate";
            // 
            // ShippedDate
            // 
            this.ShippedDate.HeaderText = "Shipped Date";
            this.ShippedDate.Name = "ShippedDate";

 
            ((System.ComponentModel.ISupportInitialize)this).BeginInit();
            this.AllowUserToAddRows = false;
            this.AllowUserToDeleteRows = false;
            this.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.saleType,
            this.PartNo,
            this.Mfg,
            this.Rohs,
            this.Dc,
            this.IntPartNo,
            this.ShipFrom,
            this.ShipMethod,
            this.TrackingNo,
            this.Qty,
            this.QtyShipped,
            this.Currency,
            this.UnitPrice,
            this.Total,
            this.DockDate,
            this.ShippedDate});
            this.Enabled = false;
            this.Location = new System.Drawing.Point(30, 356);
            this.Name = "dataGridView1";
            this.RowTemplate.Height = 23;
            this.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            //this.Size = new System.Drawing.Size(829, 188);
            this.TabIndex = 0;
            ((System.ComponentModel.ISupportInitialize)this).EndInit();

        }


        /*
        private SortedList<int,Rectangle> rowSpan = new SortedList<int,Rectangle>();//取得需要重新绘制的单元格
        
        #region  单元格绘制

        public void MerageRowSpan(DataGridView dgv, DataGridViewCellPaintingEventArgs cellArgs, int minColIndex, int maxColIndex)
        {
            if (cellArgs.ColumnIndex < minColIndex || cellArgs.ColumnIndex > maxColIndex) return;

            Rectangle rect=new Rectangle();
            using (Brush gridBrush = new SolidBrush(dgv.GridColor),
                backColorBrush = new SolidBrush(cellArgs.CellStyle.BackColor))
            {
               //抹去原来的cell背景
                cellArgs.Graphics.FillRectangle(backColorBrush, cellArgs.CellBounds);
            }
            cellArgs.Handled = true;

            if (!rowSpan.Keys.Contains(cellArgs.ColumnIndex))
            {
                rect.X = cellArgs.CellBounds.X;
                rect.Y = cellArgs.CellBounds.Y;
                rect.Width = cellArgs.CellBounds.Width;
                rect.Height = cellArgs.CellBounds.Height;

                rowSpan.Add(cellArgs.ColumnIndex, rect);

                if (cellArgs.ColumnIndex != maxColIndex)
                    return;
                MeragePrint(dgv, cellArgs, minColIndex, maxColIndex);
            }
            else
            {
                IsPostMerage(dgv, cellArgs, minColIndex, maxColIndex);
            }

        }

        public void IsPostMerage(DataGridView dgv, DataGridViewCellPaintingEventArgs cellArgs, int minColIndex, int maxColIndex)
        {
            //比较单元是否有变化
            Rectangle rectArgs = (Rectangle)rowSpan[cellArgs.ColumnIndex];
            if (rectArgs.X != cellArgs.CellBounds.X || rectArgs.Y != cellArgs.CellBounds.Y
                || rectArgs.Width != cellArgs.CellBounds.Width || rectArgs.Height != cellArgs.CellBounds.Height)
            {
                rectArgs.X = cellArgs.CellBounds.X;
                rectArgs.Y = cellArgs.CellBounds.Y;
                rectArgs.Width = cellArgs.CellBounds.Width;
                rectArgs.Height = cellArgs.CellBounds.Height;
                rowSpan[cellArgs.ColumnIndex] = rectArgs;
            }
            MeragePrint(dgv, cellArgs, minColIndex, maxColIndex);

        }

        //画制单元格
        private void MeragePrint(DataGridView dgv, DataGridViewCellPaintingEventArgs cellArgs, int minColIndex, int maxColIndex)
            {

                int width = 0;//合并后单元格总宽度
                int height = cellArgs.CellBounds.Height;//合并后单元格总高度
                
                for (int i = minColIndex; i <= maxColIndex;i++ )
                {
                    width += ((Rectangle)rowSpan[i]).Width;
                }

                Rectangle rectBegin = (Rectangle)rowSpan[minColIndex];//合并第一个单元格的位置信息
                Rectangle rectEnd = (Rectangle)rowSpan[maxColIndex];//合并最后一个单元格的位置信息
                
                //合并单元格的位置信息
                Rectangle reBounds = new Rectangle();
                reBounds.X = rectBegin.X;
                reBounds.Y = rectBegin.Y;
                reBounds.Width = width - 1;
                reBounds.Height = height - 1;


                using (Brush gridBrush = new SolidBrush(dgv.GridColor),
                             backColorBrush = new SolidBrush(cellArgs.CellStyle.BackColor))
                {
                    using (Pen gridLinePen = new Pen(gridBrush))
                    {
                        // 画出上下两条边线，左右边线无
                        Point blPoint = new Point(rectBegin.Left, rectBegin.Bottom - 1);//底线左边位置
                        Point brPoint = new Point(rectEnd.Right - 1, rectEnd.Bottom - 1);//底线右边位置
                        cellArgs.Graphics.DrawLine(gridLinePen, blPoint, brPoint);//下边线

                        Point tlPoint = new Point(rectBegin.Left, rectBegin.Top);//上边线左边位置
                        Point trPoint = new Point(rectEnd.Right - 1, rectEnd.Top);//上边线右边位置
                        cellArgs.Graphics.DrawLine(gridLinePen, tlPoint, trPoint); //上边线

                        Point ltPoint = new Point(rectBegin.Left, rectBegin.Top);//左边线顶部位置
                        Point lbPoint = new Point(rectBegin.Left, rectBegin.Bottom - 1);//左边线底部位置
                        cellArgs.Graphics.DrawLine(gridLinePen, ltPoint, lbPoint); //左边线

                        Point rtPoint = new Point(rectEnd.Right - 1, rectEnd.Top);//右边线顶部位置
                        Point rbPoint = new Point(rectEnd.Right - 1, rectEnd.Bottom - 1);//右边线底部位置
                        cellArgs.Graphics.DrawLine(gridLinePen, rtPoint, rbPoint); //右边线

                        //计算绘制字符串的位置
                        SizeF sf = cellArgs.Graphics.MeasureString("Test", cellArgs.CellStyle.Font);
                        float lstr = (width - sf.Width) / 2;
                        float rstr = (height - sf.Height) / 2;

                        //画出文本框
                            cellArgs.Graphics.DrawString("Test", cellArgs.CellStyle.Font,
                                                       new SolidBrush(cellArgs.CellStyle.ForeColor),
                                                         rectBegin.Left + lstr,
                                                         rectBegin.Top + rstr,
                                                         StringFormat.GenericDefault);
                    }
                    cellArgs.Handled = true;
                }
                    
            }
        #endregion


 
    
        protected override void  OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex!=-1&&e.RowIndex%3!=0)//  && this.Rows[e.RowIndex].Cells[1].Value.ToString()==" "  )
            {
                e.CellStyle.Font = new Font(this.DefaultCellStyle.Font, FontStyle.Regular);
                e.CellStyle.WrapMode = DataGridViewTriState.True;
                MerageRowSpan(this, e, 0, 5);//this.ShippedDate.Index);
            }
                      
        }
        #endregion
        */

     
    }


    }
