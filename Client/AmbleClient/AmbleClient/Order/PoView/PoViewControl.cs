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
        public PoViewControl()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void PoViewControl_Load(object sender, EventArgs e)
        {

        }


        public void FillTheTalbe(po poMain)
        {
            tbVendor.Text = poMain.vendorName;
            tbContact.Text = poMain.contact;
            tbPA.Text = new AmbleClient.Admin.AccountMgr.AccountMgr().GetNameById(poMain.pa.Value);//will change
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


        




        public po GetValues()
        { 
        
        
        
        
        }





        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
 