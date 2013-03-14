using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.OfferGui.OfferMgr;

namespace AmbleClient.OfferGui
{
    public partial class NewOffer : Form
    {
        int rfqId;
        int? newOfferId = null;
        OfferMgr.OfferMgr offerMgr;
        
        public NewOffer(int rfqId)
        {
            this.rfqId = rfqId;
            InitializeComponent();
            tsbRoute.Enabled = false;
            offerMgr = new OfferMgr.OfferMgr();
            
        }


        public void NewOfferAutoFill(string mpn, string mfg)
        {
            this.buyerOfferItems1.AutoFill(mpn, mfg);
        
        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (buyerOfferItems1.SaveItems(rfqId))
            {
                MessageBox.Show("Save the Offer Info Successfully");
                tsbSave.Enabled = false;
                newOfferId = buyerOfferItems1.GetTheSavedOfferId();
                tsbRoute.Enabled = true;
            }
            else
            {
                MessageBox.Show("Fail to Save the Offer Info");
            }
        }
        private void tsbRoute_Click(object sender, EventArgs e)
        {
            tsbRoute.Enabled = false;
            offerMgr.ChangeOfferState(1, newOfferId.Value);


        }

        private void tsbClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }

        private void NewOffer_Load(object sender, EventArgs e)
        {
            buyerOfferItems1.tbOfferDate.Enabled = false;
            buyerOfferItems1.tbOfferState.Enabled = false;
        }
    }
}
