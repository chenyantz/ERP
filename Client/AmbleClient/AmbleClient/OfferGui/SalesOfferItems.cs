using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.OfferGui
{
    public class SalesOfferItems : OfferItems
    {


        public void FillTheTable(AmbleClient.OfferGui.OfferMgr.Offer offer)
        {
            base.FillTheTable(offer);
            this.tbVendorName.Enabled = false;
            this.tbContact.Enabled = false;
            this.tbPhone.Enabled = false;
            this.tbFax.Enabled = false;
            this.tbEmail.Enabled = false;
        }
    }


}
