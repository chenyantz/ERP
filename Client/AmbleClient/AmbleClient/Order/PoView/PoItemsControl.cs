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

        public bool CheckValues()
        {
            if (ItemsCheck.CheckTextBoxEmpty(tbPartNo) == false)
            {
                MessageBox.Show("Please input the Part Number");
                 return false;
            }

            if (!ItemsCheck.CheckTextBoxEmpty(tbMfg))
            {
                MessageBox.Show("Please input the MFG");
                return false;
            }

            if (!ItemsCheck.CheckTextBoxEmpty(tbDc))
            {
                MessageBox.Show("Please input the D/C");
                return false;
            }

            if (!ItemsCheck.CheckTextBoxEmpty(tbQty))
            {
                MessageBox.Show("Please input the Qty");
                return false;
            }
            else
            {
                if (!ItemsCheck.CheckIntNumber(tbQty))
                {
                    MessageBox.Show("The Qty should be an integer value");
                    tbQty.Focus();
                    return false;
                
                }
            
            }

            if (ItemsCheck.CheckIntNumber(tbQtyRevd) && (!ItemsCheck.CheckIntNumber(tbQtyRevd)))
            {
                MessageBox.Show("The Qty Recv should be an integer value");
                tbQtyRevd.Focus();
                return false;
            }
            if (ItemsCheck.CheckIntNumber(tbQtyCorrected) && (!ItemsCheck.CheckIntNumber(tbQtyCorrected)))
            {
                MessageBox.Show("The Qty Corrected should be an integer value");
                tbQtyCorrected.Focus();
                return false;
            }
            if (ItemsCheck.CheckIntNumber(tbQtyAccept) && (!ItemsCheck.CheckIntNumber(tbQtyAccept)))
            {
                MessageBox.Show("The Qty Accept should be an integer value");
                tbQtyAccept.Focus();
                return false;
            }
            if (ItemsCheck.CheckIntNumber(tbQtyRejected) && (!ItemsCheck.CheckIntNumber(tbQtyRejected)))
            {
                MessageBox.Show("The Qty Rejected should be an integer value");
                tbQtyRejected.Focus();
                return false;
            }
            if (ItemsCheck.CheckIntNumber(tbQtyRtv) && (!ItemsCheck.CheckIntNumber(tbQtyRtv)))
            {
                MessageBox.Show("The Qty RTV should be an integer value");
                tbQtyRtv.Focus();
                return false;
            }
            if (ItemsCheck.CheckIntNumber(tbQcPending) && (!ItemsCheck.CheckIntNumber(tbQcPending)))
            {
                MessageBox.Show("The QC/Pending should be an integer value");
                tbQcPending.Focus();
                return false;
            }
            if (ItemsCheck.CheckIntNumber(tbUnitPrice) && (!ItemsCheck.CheckFloatNumber(tbUnitPrice)))
            {
                MessageBox.Show("The Unit Price should be a float value");
                tbUnitPrice.Focus();
                return false;
            }

            return true;
        }






    
    
    
    }
}
