using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleAppServer.OfferMgr;

namespace AmbleClient.OfferGui
{
   public class BuyerOfferItems:OfferItems
    {

       public BuyerOfferItems()
       { }

       public void FillTheTable(AmbleAppServer.OfferMgr.Offer offer)
       {
           this.tbMpn.Text = offer.mpn;
           this.tbMfg.Text = offer.mfg;
           this.tbVendorName.Text = offer.vendorName;
           this.tbContact.Text = offer.contact;
           this.tbPhone.Text = offer.phone;
           this.tbFax.Text = offer.fax;
           this.tbEmail.Text = offer.email;
           this.tbAmount.Text = offer.amount.ToString();
           this.tbPrice.Text = offer.price.ToString();
           this.tbDeliverTime.Text = offer.deliverTime.ToString();
           this.cbTimeUnit.SelectedIndex = offer.timeUnit;
           this.tbOfferDate.Text = offer.offerDate.ToShortDateString();
           this.tbOfferState.Text = (offer.offerStates == 0 ? "New" : "Routed");
       }
       public bool SaveItems(int rfqId)
       {
           Offer offer = new Offer();
           offer.rfqNo = rfqId;
           offer.mpn = tbMpn.Text.Trim();
           offer.mfg = tbMfg.Text.Trim();
           offer.vendorName = tbVendorName.Text.Trim();
           offer.contact = tbContact.Text.Trim();
           offer.phone = tbPhone.Text.Trim();
           offer.fax = tbFax.Text.Trim();
           offer.email = tbEmail.Text.Trim();
           if(string.IsNullOrWhiteSpace(tbAmount.Text.Trim()))
           {
            offer.amount=null;
           }
           else
           {
              offer.amount=int.Parse(tbAmount.Text.Trim());
           }

           if(string.IsNullOrWhiteSpace(tbPrice.Text.Trim()))
           {
            offer.price=null;
           }
           else
           {
             offer.price=float.Parse(tbPrice.Text.Trim());
           }
           if(string.IsNullOrWhiteSpace(tbDeliverTime.Text.Trim()))
           {
            offer.deliverTime=null;
           
           }
           else
           {
            offer.deliverTime=int.Parse(tbDeliverTime.Text.Trim());
           }
           offer.timeUnit = cbTimeUnit.SelectedIndex;
           offer.buyerId = UserInfo.UserId;

           offer.offerDate = DateTime.Now;
           offer.offerStates = 0;//new 

           return GlobalRemotingClient.GetOfferMgr().SaveOffer(offer);

       }

       public int GetTheSavedOfferId()
       {

           return GlobalRemotingClient.GetOfferMgr().GetNewSavedOfferId(UserInfo.UserId);
       
       }

       public bool UpdateItems()
       {
           return true;
       }



    }
}
