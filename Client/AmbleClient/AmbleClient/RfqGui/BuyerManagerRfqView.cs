using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.RfqMgr;

namespace AmbleClient.RfqGui
{
    public partial class BuyerManagerRfqView : Form
    {
        int rfqId;
        public BuyerManagerRfqView(int rfqId)
        {
            this.rfqId = rfqId;
            InitializeComponent();
        }

        private void BuyerManagerRfqView_Load(object sender, EventArgs e)
        {
            Rfq rfq = GlobalRemotingClient.GetRfqMgr().GetRfqAccordingToRfqId(rfqId);
            buyerManagerRfqItems1.FillTheTable(rfq);
        }

        private void tsbAssign_Click(object sender, EventArgs e)
        {
            int? primaryPA, altPA;
            if (buyerManagerRfqItems1.cbPrimaryPA.SelectedIndex == -1)
            {
                primaryPA = null;

            }
            else
            {
                primaryPA = buyerManagerRfqItems1.MySubs[buyerManagerRfqItems1.cbPrimaryPA.SelectedIndex];
            }

            if (buyerManagerRfqItems1.cbAltPA.SelectedIndex == -1)
            {
                altPA = null;

            }
            else
            {
                altPA = buyerManagerRfqItems1.MySubs[buyerManagerRfqItems1.cbAltPA.SelectedIndex];
            }

            if (GlobalRemotingClient.GetRfqMgr().AssignPAForRfq(rfqId, primaryPA, altPA))
            {
                MessageBox.Show("Assign the RFQ to Buyer(s) successfully");
            }
            else
            {
                MessageBox.Show("Fail to assign the RFQ");
            }


        }

        private void tsbOffer_Click(object sender, EventArgs e)
        {
            AmbleClient.OfferGui.NewOffer newOffer = new OfferGui.NewOffer(rfqId);
            newOffer.ShowDialog();



        }

        private void tsbViewOffers_Click(object sender, EventArgs e)
        {
            AmbleClient.OfferGui.OfferList offerList = new OfferGui.OfferList(rfqId);
            offerList.ShowDialog();



        }
    }
}
