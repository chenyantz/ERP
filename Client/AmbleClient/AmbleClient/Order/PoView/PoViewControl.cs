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
    public partial class PoViewControl : UserControl
    {

        List<int> mysubs;
        Dictionary<int, string> buyerIdsAndNames;
        public PoViewControl()
        {
            InitializeComponent();
            FillThePACombo();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void PoViewControl_Load(object sender, EventArgs e)
        {

        }


        private void FillThePACombo()
        {

            AmbleClient.Admin.AccountMgr.AccountMgr accountMgr = new Admin.AccountMgr.AccountMgr();
            mysubs = accountMgr.GetAllSubsId(UserInfo.UserId, UserCombine.GetUserCanBeBuyers());

            buyerIdsAndNames=accountMgr.GetIdsAndNames(mysubs);

            foreach (string buyerName in buyerIdsAndNames.Values)
            {
                cbPa.Items.Add(buyerName);
            
            }
        }




        public void FillTheTalbe(po poMain)
        {
            tbVendor.Text = poMain.vendorName;
            tbContact.Text = poMain.contact;
            cbPa.SelectedItem = buyerIdsAndNames[poMain.pa.Value]; 
                   
            tbVendorNumber.Text = poMain.vendorNumber;
            tbPoDate.Text = poMain.poDate.Value.ToShortDateString();
            tbPoNo.Text = poMain.poNo;
            tbFreight.Text = poMain.freight;
            tbShipMethod.Text = poMain.shipMethod;
            tbPaymentTerms.Text = poMain.paymentTerms;
            tbShipToLocation.Text = poMain.shipToLocation;
            tbBillTo.Text = poMain.billTo;
            tbShipTo.Text = poMain.shipTo;

            //fill the datagrid
        }

        public void FillTheDataGridPoItems(List<poitems> items)
        {



            foreach (poitems item in items)
            {
                dataGridView1.Rows.Add(item.PoItemsId, item.partNo, item.mfg, item.dc, item, VendorIntPartNo, item.org, item.qty,
                                       item.qtyRecd, item.qtyCorrected, item.qtyAccept, item.qtyRejected, item.qtyRTV, item.qcPending,
                                       Enum.GetName(typeof(AmbleClient.Currency), item.currency), item.unitPrice, item.qty * item.currency, item.stepCode, "Unknown");

            
            
            }
        
        
        }
        

        public po GetValues()
        {
            return new po
            {
                vendorName = tbVendor.Text.Trim(),
                contact = tbContact.Text.Trim(),
                pa = (short)mysubs[cbPa.SelectedIndex]




            };
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
 