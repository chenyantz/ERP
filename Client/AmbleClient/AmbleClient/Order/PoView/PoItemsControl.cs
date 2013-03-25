using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.PoMgr;

namespace AmbleClient.PO
{
    public partial class PoItemsControl : UserControl
    {
        public PoItemsControl()
        {
            InitializeComponent();
            this.cbCurrency.Items.AddRange(
                       Enum.GetNames(typeof(Currency))
              );

        }

        public void FillTheItems(poitems item)
        {
            tbPartNo.Text = item.partNo;
            tbMfg.Text = item.mfg;
            tbDc.Text = item.dc;
            tbVendorIntPartNo.Text = item.vendorIntPartNo;
            tbOrg.Text = item.org;
            tbQty.Text = item.qty.ToString();
            tbQtyRevd.Text=item.qtyRecd.ToString();
            tbQtyCorrected.Text=item.qtyCorrected.ToString();
            tbQtyAccept.Text=item.qtyAccept.ToString();
            tbQtyRejected.Text = item.qtyRejected.ToString();
            tbQtyRtv.Text = item.qtyRTV.ToString();
            tbQcPending.Text = item.qcPending.ToString();
            cbCurrency.SelectedIndex =(int)item.currency;
            tbUnitPrice.Text = item.unitPrice.ToString();
            tbTotal.Text = (item.qtyAccept * item.unitPrice).ToString();
            dateTimePicker1.Value = item.dueDate.Value;

            if (item.receiveDate == null)
            {
                dateTimePicker2.Checked = false;
            }
            else
            {
                dateTimePicker2.Value = item.receiveDate.Value;
            }
            tbStepCode.Text = item.stepCode;
           // tbSalesAgent.Text=
            tbNoteToVendor.Text = item.noteToVendor;
        }

        public poitems GetPoItem()
        {

            DateTime? datetime;
            if (dateTimePicker2.Checked)
            {
                datetime = dateTimePicker2.Value.Date;
            }
            else
            {
                datetime = null;
            }

            return new poitems
            {
                partNo = tbPartNo.Text.Trim(),
                mfg = tbMfg.Text.Trim(),
                dc = tbDc.Text.Trim(),
                vendorIntPartNo = tbVendorIntPartNo.Text.Trim(),
                org = tbOrg.Text.Trim(),
                qty = int.Parse(tbQty.Text.Trim()),
                qtyRecd = int.Parse(tbQtyRevd.Text.Trim()),
                qtyCorrected = int.Parse(tbQtyCorrected.Text.Trim()),
                qtyAccept = int.Parse(tbQtyAccept.Text.Trim()),
                qtyRejected = int.Parse(tbQtyRejected.Text.Trim()),
                qtyRTV = int.Parse(tbQtyRtv.Text.Trim()),
                qcPending = int.Parse(tbQcPending.Text.Trim()),
                currency = (sbyte)cbCurrency.SelectedIndex,
                unitPrice = float.Parse(tbUnitPrice.Text.Trim()),
                dueDate = dateTimePicker1.Value,
                receiveDate = datetime,
                stepCode = tbStepCode.Text.Trim(),
                salesAgent = 0,
                noteToVendor = tbNoteToVendor.Text.Trim()
            };



        
        }







    
    
    
    }
}
