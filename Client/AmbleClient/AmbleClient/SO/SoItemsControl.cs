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
             shippedDate=dateTimePicker2.Value.Date
            };
               
        
        }

        private void SoItemsControl_Load(object sender, EventArgs e)
        {

        }
        

    }
}
