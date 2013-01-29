using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.OfferMgr;

namespace AmbleClient.OfferGui
{
   public class BuyerOfferItems:OfferItems
    {
      
       public BuyerOfferItems()
       { }

       public void AutoFill(string mpn, string mfg)
       {
           tbMpn.Text = mpn;
           tbMfg.Text = mfg;
           VendorAutoComplete();
           tbVendorName.Leave+=new EventHandler(tbVendorName_Leave);
       }

       private void VendorAutoComplete()
       {
           List<string> vendorNames = GlobalRemotingClient.GetCustomerVendorMgr().GetMyTheCustomerVendorNamesOrVendors(1, UserInfo.UserId);

           this.tbVendorName.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           tbVendorName.AutoCompleteSource = AutoCompleteSource.CustomSource;

           AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
           foreach (string vendorName in vendorNames)
           {
               autoSource.Add(vendorName);
           }
           tbVendorName.AutoCompleteCustomSource = autoSource;
       }

       private void tbVendorName_Leave(object sender, EventArgs e)
       {
           //自动填充contact,phone,fax
           Dictionary<string, string> contactInfo = GlobalRemotingClient.GetCustomerVendorMgr().GetContactInfo(0, UserInfo.UserId, tbVendorName.Text.Trim());
           //contact   
           AutoCompleteStringCollection contactSource = new AutoCompleteStringCollection();
           if (contactInfo.Keys.Contains("contact1"))
           {
               tbContact.Text = contactInfo["contact1"];
               contactSource.Add(contactInfo["contact1"]);
           }
           if (contactInfo.Keys.Contains("contact2"))
           {
               contactSource.Add(contactInfo["contact2"]);
           }
           tbContact.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           tbContact.AutoCompleteSource = AutoCompleteSource.CustomSource;
           tbContact.AutoCompleteCustomSource = contactSource;
           //phone
           AutoCompleteStringCollection phoneSource = new AutoCompleteStringCollection();
           if (contactInfo.Keys.Contains("phone1"))
           {
               tbPhone.Text = contactInfo["phone1"];
               phoneSource.Add(contactInfo["phone1"]);
           }
           if (contactInfo.Keys.Contains("phone2"))
           {
               phoneSource.Add(contactInfo["phone2"]);
           }
           if (contactInfo.Keys.Contains("cellphone"))
           {
               phoneSource.Add(contactInfo["cellphone"]);
           }
           tbPhone.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           tbPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;
           tbPhone.AutoCompleteCustomSource = phoneSource;

           AutoCompleteStringCollection faxSource = new AutoCompleteStringCollection();
           if (contactInfo.Keys.Contains("fax"))
           {
               tbFax.Text = contactInfo["fax"];
               faxSource.Add(contactInfo["fax"]);
           }
           tbFax.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           tbFax.AutoCompleteSource = AutoCompleteSource.CustomSource;
           tbFax.AutoCompleteCustomSource = faxSource;

           AutoCompleteStringCollection emailSource = new AutoCompleteStringCollection();
           if (contactInfo.Keys.Contains("email1"))
           {
               tbContact.Text = contactInfo["email1"];
               contactSource.Add(contactInfo["email1"]);
           }
           if (contactInfo.Keys.Contains("email2"))
           {
               contactSource.Add(contactInfo["email2"]);
           }
           tbContact.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
           tbContact.AutoCompleteSource = AutoCompleteSource.CustomSource;
           tbContact.AutoCompleteCustomSource = emailSource;



       }

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
           this.tbNotes.Text = offer.notes;
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
           offer.notes=tbNotes.Text.Trim();

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
