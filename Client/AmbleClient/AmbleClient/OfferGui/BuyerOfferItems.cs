using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.custVendor.customerVendorMgr;
using AmbleClient.OfferGui.OfferMgr;

namespace AmbleClient.OfferGui
{
   public class BuyerOfferItems:OfferItems
    {
       CustomerVendorMgr customerVendorMgr;
       public BuyerOfferItems()
       {
           customerVendorMgr = new CustomerVendorMgr();
       }

       public void AutoFill(string mpn, string mfg)
       {
           tbMpn.Text = mpn;
           tbMfg.Text = mfg;
           VendorAutoComplete();
           tbVendorName.Leave+=new EventHandler(tbVendorName_Leave);
       }

       private void VendorAutoComplete()
       {
           List<string> vendorNames = customerVendorMgr.GetMyTheCustomerVendorNamesOrVendors(1, UserInfo.UserId);

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
           Dictionary<string, string> contactInfo = customerVendorMgr.GetContactInfo(0, UserInfo.UserId, tbVendorName.Text.Trim());
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

       public override void FillTheTable(AmbleClient.OfferGui.OfferMgr.Offer offer)
       {
           offerId = offer.offerId;

           base.FillTheTable(offer);
           tbVendorName.Text = offer.vendorName;
           tbContact.Text = offer.contact;
           tbPhone.Text = offer.phone;
           tbFax.Text = offer.fax;
           tbEmail.Text = offer.email;
       }


       public Offer GetValue()
       {
           Offer offer = new Offer();
           offer.mpn = tbMpn.Text.Trim();
           offer.mfg = tbMfg.Text.Trim();
           offer.vendorName = tbVendorName.Text.Trim();
           offer.contact = tbContact.Text.Trim();
           offer.phone = tbPhone.Text.Trim();
           offer.fax = tbFax.Text.Trim();
           offer.email = tbEmail.Text.Trim();
           if (string.IsNullOrWhiteSpace(tbQuantity.Text.Trim()))
           {
               offer.amount = null;
           }
           else
           {
               offer.amount = int.Parse(tbQuantity.Text.Trim());
           }

           if (string.IsNullOrWhiteSpace(tbPrice.Text.Trim()))
           {
               offer.price = null;
           }
           else
           {
               offer.price = float.Parse(tbPrice.Text.Trim());
           }
           if (string.IsNullOrWhiteSpace(tbDeliverTime.Text.Trim()))
           {
               offer.deliverTime = null;

           }
           else
           {
               offer.deliverTime = int.Parse(tbDeliverTime.Text.Trim());
           }
           offer.timeUnit = cbTimeUnit.SelectedIndex;
           offer.buyerId = UserInfo.UserId;

           offer.offerDate = DateTime.Now;
           offer.offerStates = 0;//new 
           offer.notes = tbNotes.Text.Trim();

           return offer;
       
       
       }

       public bool SaveItems(int rfqId)
       {
           if (CheckItems() == false)
           {
               return false;
           }
           var offer = GetValue();
           offer.rfqNo = rfqId;
           return offerMgr.SaveOffer(offer);

       }

       public int GetTheSavedOfferId()
       {

           return offerMgr.GetNewSavedOfferId(UserInfo.UserId);
       
       }

       public void UpdateItems()
       {
           if (CheckItems() == false)
           {
               return;
           }


           var offer = GetValue();
           offer.offerId = offerId;
           offerMgr.UpdateOffer(offer);
    
       }


       public void UpdateOfferState(int state)
       {
           offerMgr.ChangeOfferState(state, offerId);
       
       }




    }
}
