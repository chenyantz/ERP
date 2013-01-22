using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.SoMgr;

namespace AmbleClient.SO
{
    public partial class SoItemsControl : UserControl
    {
        public SoItemsControl()
        {
            InitializeComponent();
        }

        public void NewCreateItems()
        {
            this.cbCurrency.SelectedIndex = 0;
            this.cbSaleType.SelectedIndex = 0;
        
        
        }

        public void FillItems(SoItems soItem)
        {
            cbSaleType.SelectedIndex = soItem.saleType;
            tbPartNo.Text = soItem.partNo;
            tbMfg.Text = soItem.mfg;
            cbRohs.Checked =( soItem.rohs == 1 ? true : false);
            tbDc.Text = soItem.dc;
            tbIntPartNo.Text = soItem.intPartNo;
            tbShipFrom.Text = soItem.shipFrom;
            tbShipMethod.Text = soItem.shipMethod;
            tbTrackingNo.Text = soItem.trackingNo;
            tbQty.Text = soItem.qty.ToString();
            tbQtyShipped.Text=soItem.qtyshipped.ToString();
            cbCurrency.SelectedIndex = soItem.currencyType;
            tbUnitPrice.Text = soItem.unitPrice.ToString();
            dateTimePicker1.Value = soItem.dockDate;
            dateTimePicker2.Value = soItem.shippedDate;
            tbShipInst.Text = soItem.shippingInstruction;
            tbPackingInst.Text = soItem.packingInstruction;
        
        }



        public SoItems GetSoItem()
        {
            return new SoItems
            {
             saleType=cbSaleType.SelectedIndex,
             partNo=tbPartNo.Text.Trim(),
             mfg=tbMfg.Text.Trim(),
             rohs=cbRohs.Checked?1:0,
             dc=tbDc.Text.Trim(),
             intPartNo=tbIntPartNo.Text.Trim(),
             shipFrom=tbShipFrom.Text.Trim(),
             shipMethod=tbShipMethod.Text.Trim(),
             trackingNo=tbTrackingNo.Text.Trim(),
             qty=Convert.ToInt32(tbQty.Text.Trim()), //will check first
             qtyshipped=Convert.ToInt32(tbQtyShipped.Text.Trim()),
             currencyType=cbCurrency.SelectedIndex,
             unitPrice=Convert.ToSingle(tbUnitPrice.Text.Trim()),
             dockDate=dateTimePicker1.Value.Date,
             shippedDate=dateTimePicker2.Value.Date,
             shippingInstruction=tbShipInst.Text.Trim(),
             packingInstruction=tbPackingInst.Text.Trim()
            };
               
        
        }

        private void SoItemsControl_Load(object sender, EventArgs e)
        {

        }

        private void tbUnitPrice_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(tbQtyShipped.Text.Trim())) && ItemsCheck.CheckIntNumber(tbQtyShipped.Text.Trim()))
            {
                if (ItemsCheck.CheckFloatNumber(tbUnitPrice.Text.Trim()))
                {
                    tbTotal.Text = (Convert.ToInt32(tbQtyShipped.Text.Trim()) * Convert.ToSingle(tbUnitPrice.Text.Trim())).ToString();
                }
                else
                {
                    tbTotal.Text = "";
                }
            }

                

        }

        private void tbQtyShipped_TextChanged(object sender, EventArgs e)
        {
            if ((!string.IsNullOrWhiteSpace(tbUnitPrice.Text.Trim())) && ItemsCheck.CheckFloatNumber(tbUnitPrice.Text.Trim()))
            {
                if (ItemsCheck.CheckIntNumber(tbQtyShipped.Text.Trim()))
                {
                    tbTotal.Text = (Convert.ToInt32(tbQtyShipped.Text.Trim()) * Convert.ToSingle(tbUnitPrice.Text.Trim())).ToString();
                }
                else
                {
                    tbTotal.Text = "";
                }
            }



        }
        

    }
}
