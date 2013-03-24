using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.OfferGui.OfferMgr;

namespace AmbleClient.OfferGui
{
    public partial class OfferItems : UserControl
    {

        protected OfferMgr.OfferMgr offerMgr;
        public OfferItems()
        {
            InitializeComponent();
            offerMgr = new OfferMgr.OfferMgr();
        }
      

        public virtual void FillTheTable(Offer offer)
        {
            this.tbMpn.Text = offer.mpn;
            this.tbMfg.Text = offer.mfg;

            this.tbAmount.Text = offer.amount.ToString();
            this.tbPrice.Text = offer.price.ToString();
            this.tbDeliverTime.Text = offer.deliverTime.ToString();
            this.cbTimeUnit.SelectedIndex = offer.timeUnit;
            this.tbOfferDate.Text = offer.offerDate.ToShortDateString();
            this.tbOfferState.Text = (offer.offerStates == 0 ? "New" : "Routed");
            this.tbNotes.Text = offer.notes;
        
        
        }

    }
}
