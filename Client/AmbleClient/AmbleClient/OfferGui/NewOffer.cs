using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.OfferMgr;

namespace AmbleClient.OfferGui
{
    public partial class NewOffer : Form
    {
        int rfqId;
        
        public NewOffer(int rfqId)
        {
            this.rfqId = rfqId;
            InitializeComponent();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (buyerOfferItems1.SaveItems(rfqId))
            {
                MessageBox.Show("Save the Offer Info Successfully");
                tsbSave.Enabled = false;
            }
            else
            {
                MessageBox.Show("Fail to Save the Offer Info");
            }
        }
        private void tsbRoute_Click(object sender, EventArgs e)
        {

        }

        private void tsbClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}
