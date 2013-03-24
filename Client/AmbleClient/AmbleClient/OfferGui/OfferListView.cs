using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.OfferGui.OfferMgr;

namespace AmbleClient.OfferGui
{
    public class OfferListView:AmbleClient.Order.OrderListView
    {

        private List<Offer> offerList;

        protected override void ViewStart()
        {
            this.Text = "Offer List";
            tscbList.Items.Add("List All Offer I Can See");
            tscbList.Items.Add("List My Offer");
            tscbFilterColumn.Items.Add("vendorName");

            //Add columns for datagridView1
            System.Windows.Forms.DataGridViewTextBoxColumn OfferId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn RfqNo = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewTextBoxColumn mpn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn mfg = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewTextBoxColumn VendorName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Contact = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Fax = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewTextBoxColumn Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn Amount = new System.Windows.Forms.DataGridViewTextBoxColumn();

            System.Windows.Forms.DataGridViewTextBoxColumn Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn DeliverTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn PurchaseName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn OfferDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn OfferState = new System.Windows.Forms.DataGridViewTextBoxColumn();

            OfferId.Name = "OfferId";
            OfferId.Visible = false;

            RfqNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            RfqNo.HeaderText = "RFQ #";
            RfqNo.Name = "RfqNo";

            mpn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            mpn.HeaderText = "MPN";
            mpn.Name = "mpn";

            mfg.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            mfg.HeaderText = "MFG";
            mfg.Name = "mfg";

            VendorName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            VendorName.HeaderText = "Vendor Name";
            VendorName.Name = "VendorName";

            Contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Contact.HeaderText = "Contact";
            Contact.Name = "Contact";



            Phone.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Phone.HeaderText = "Phone";
            Phone.Name = "Phone";

            Fax.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Fax.HeaderText = "Fax";
            Fax.Name = "Fax";

            Email.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Email.HeaderText = "Email";
            Email.Name = "Email";

            Amount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Amount.HeaderText = "Payment Terms";
            Amount.Name = "PaymentTerms";

            Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Price.HeaderText = "Price";
            Price.Name = "Price";



            DeliverTime.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            DeliverTime.HeaderText = "Deliver Time";
            DeliverTime.Name = "DeliverTime";

            PurchaseName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PurchaseName.HeaderText = "Purchaser Name";
            PurchaseName.Name = "PurchaseName";

            OfferDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            OfferDate.HeaderText = "Offer Date";
            OfferDate.Name = "OfferDate";

            OfferState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            OfferState.HeaderText = "Offer State";
            OfferState.Name = "OfferState";

            dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { 
            OfferId,
            RfqNo,
            mpn,
            mfg,
            VendorName,
            Contact,
            Phone,
            Fax,
            Email,
            Amount,
            Price,
            DeliverTime,
            PurchaseName,
            OfferDate,
            OfferState
         });

        }

        protected override void GetTheStateList()
        {
                intStateList.Add((int)OfferState.New);
                intStateList.Add((int)OfferState.Routed);
                intStateList.Add((int)OfferState.Closed);
        }

        protected override void FillTheStateCombox()
        {
            //fill the state List
            tscbListState.Items.Add(Enum.GetName(typeof(OfferState), 0));
            tscbListState.Items.Add(Enum.GetName(typeof(OfferState), 1));
            tscbListState.Items.Add(Enum.GetName(typeof(OfferState), 2));
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

            offerList = new OfferMgr.OfferMgr().GetOfferAccordingToFilter(UserInfo.UserId, includeSubs, filterColumn, filterString, intStateList);

            foreach (Offer offer in offerList)
            {
                dataGridView1.Rows.Add(offer.offerId, offer.rfqNo, offer.mpn, offer.mfg, offer.vendorName, offer.contact, offer.phone, offer.fax, offer.email,
                    offer.amount, offer.price, offer.deliverTime +" "+Enum.GetName(typeof(TimeUnit), offer.timeUnit), idNameDict[offer.buyerId], offer.offerDate,
                    Enum.GetName(typeof(OfferState), offer.offerStates));
            }

        }


        protected override void OpenOrderDetails(int rowIndex)
        {
            if (rowIndex >= offerList.Count)
                return;
            int offerId = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["OfferId"].Value);
            OfferView offerView = new OfferView(offerId,0);
            offerView.ShowDialog();
        }






    }
}
