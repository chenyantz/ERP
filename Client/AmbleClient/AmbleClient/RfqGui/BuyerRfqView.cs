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
    public partial class BuyerRfqView : Form
    {
        int rfqId;
        public BuyerRfqView(int rfqId)
        {
            this.rfqId = rfqId;
            InitializeComponent();
        }

        private void BuyerRfqView_Load(object sender, EventArgs e)
        {
            Rfq rfq = GlobalRemotingClient.GetRfqMgr().GetRfqAccordingToRfqId(rfqId);
            buyerRfqItems1.FillTheTable(rfq);
            //SetMenuStateAccordingToRfqState((RfqStatesEnum)rfq.rfqStates);
        }

        private void tsbOffer_Click(object sender, EventArgs e)
        {
            AmbleClient.OfferGui.NewOffer newOffer = new OfferGui.NewOffer(rfqId);
            newOffer.ShowDialog();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
