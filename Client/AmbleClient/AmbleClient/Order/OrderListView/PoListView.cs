using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.Order.PoMgr;

namespace AmbleClient.Order
{
    public class PoListView:OrderListView
    {
        protected PoStateList poStateList = new PoStateList();


        protected override void ViewStart()
        {
            this.Text = "PO List";
            tscbList.Items.Add("List All PO I Can See");
            tscbList.Items.Add("List My PO");
            tscbFilterColumn.Items.Add("vendorName");

            //Add columns for datagridView1
            System.Windows.Forms.DataGridViewTextBoxColumn PoId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn PoNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn PA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn PoDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn PaymentTerms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Freight = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn VendorNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn PoState = new System.Windows.Forms.DataGridViewTextBoxColumn();

            PoId.Name = "PoId";
            PoId.Visible = false;

            PoNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PoNo.HeaderText = "Po #";
            PoNo.Name = "PoNo";

            VendorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PoNo.HeaderText = "Vendor Name";
            PoNo.Name = "VendorName";

            Contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Contact.HeaderText = "Contact";
            Contact.Name = "Contact";

            PA.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PA.HeaderText = "PA";
            PA.Name = "PA";

            PoDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PoDate.HeaderText = "PO Date";
            PoDate.Name = "PoDate";

            PaymentTerms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PaymentTerms.HeaderText = "Payment Terms";
            PaymentTerms.Name = "PaymentTerms";

            Freight.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Freight.HeaderText = "Freight";
            Freight.Name = "Freight";

            VendorNumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            VendorNumber.HeaderText = "Vendor Number";
            VendorNumber.Name = "VendorNumber";

            PoState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PoState.HeaderText = "Po State";
            PoState.Name = "PoState";

            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {            PoNo,
            VendorName,
            Contact,
            PA,
            PoDate,
            PaymentTerms,
            Freight,
            VendorNumber,
            PoState
         });

        }

        protected override void GetTheStateList()
        {
            foreach (PoState soState in poStateList.GetWholeSoStateList())
            {
                intStateList.Add(soState.GetStateValue());
            }


        }




        protected override void FillTheStateCombox()
        {
            //fill the state List
            foreach (PoState poState in poStateList.GetWholeSoStateList())
            {
                tscbListState.Items.Add(poState.GetStateString());
            }

        }

        protected override void StateChanged(object sender, EventArgs e)
        {
            intStateList.Clear();
            intStateList.Add(tscbListState.SelectedIndex);
            FillTheDataGrid();

        }


        protected override void FillTheDataGrid()
        {
            if (tscbList.SelectedIndex < 0) return;

            bool includeSubs = false;
            dataGridView1.Rows.Clear();

            if (tscbList.SelectedIndex == 0)
            {
                includeSubs = true;
            }

           // soList = SoMgr.SoMgr.SalesGetSoAccordingTofilter(UserInfo.UserId, includeSubs, filterColumn, filterString, intStateList);

            int i = 0;
          //  foreach (So so in soList)
           // {
            //    dataGridView1.Rows.Add(i++, so.customerName, so.contact, idNameDict[so.salesId], so.salesOrderNo, so.orderDate.ToShortDateString(), so.customerPo,
           //         so.paymentTerm, so.freightTerm, so.customerAccount, soStateList.GetSoStateStringAccordingToValue(so.soStates));
           // }

        }





        protected override void OpenOrderDetails(int rowIndex)
        {

        }



    }
}
