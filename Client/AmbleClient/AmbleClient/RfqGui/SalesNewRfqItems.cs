using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.RfqGui.RfqManager;
using log4net;

namespace AmbleClient.RfqGui
{
    public class SalesNewRfqItems:RfqItems
    {
        List<int> mySubs;

        public SalesNewRfqItems()
        {
            cbCloseReason.Enabled = false;
            tbCost.Enabled = false;
        }
 
    public bool SaveInfo()
        {
            if (base.CheckItems() == false)
            {
                return false;
            }
            
            Rfq rfq=new Rfq();
            GetValuesFromGui(rfq);
            rfq.closeReason = null;
            rfq.salesId = mySubs[cbSales.SelectedIndex];

            bool suc;
            try
            {
                suc = rfqMgr.SaveRfq(rfq);

                if (UserInfo.UserId == rfq.salesId)
                    rfq.routingHistory = DateTime.Now.ToString() + ":" + UserInfo.UserName.ToString() + "  Created the RFQ" + System.Environment.NewLine;
                else
                    rfq.routingHistory = DateTime.Now.ToString() + ":" + UserInfo.UserName.ToString() + " Created the RFQ for " + new AmbleClient.Admin.AccountMgr.AccountMgr().GetNameById(rfq.salesId) + System.Environment.NewLine;
            }
            catch (Exception ex)
            {
                suc = false;
                Logger.Error(ex.StackTrace);
            
            }

            return suc;
        }


    public int GetSavedRfqId()
    {
        return rfqMgr.GetSavedRfqId(mySubs[cbSales.SelectedIndex]);
   
    }


    public void NewRfqFill()
        {

            this.tbCustomer.Leave += new System.EventHandler(this.tbCustomer_Leave);
             
        
            cbCloseReason.Enabled = false;
            tbRfqDate.ReadOnly = true; tbRfqDate.Enabled = false;
            //clear all the necessary textbox

            tbCustomer.Clear();
            //customer auto complete
            CustomerAutoComplete();
            tbProject.Clear();
            tbContact.Clear();
            tbPhone.Clear();
            tbFax.Clear();
            tbEmail.Clear();
            cbPriority.SelectedIndex = -1;
            cbRohs.Checked = false;
            tbPartNo.Clear();
            tbMfg.Clear();
            tbDc.Clear();
            tbCustPartNo.Clear();
            tbGenPartNo.Clear();
            tbAlt.Clear();
            tbQuantity.Clear();
            tbPartNo.Clear();
            tbTargetPrice.Clear();
            tbResale.Clear();
            tbCost.Clear();
            cbPrimaryPA.Text = "";
            cbAltPA.Text = "";
            cbCloseReason.SelectedIndex = -1;
            tbToCustomer.Clear();
            tbToInternal.Clear();
            tbRoutingHistory.Clear();

            
        //Fill the cbSale;
            //获得下级号和名字
            AmbleClient.Admin.AccountMgr.AccountMgr accountMgr = new Admin.AccountMgr.AccountMgr();
          mySubs = accountMgr.GetAllSubsId(UserInfo.UserId,UserCombine.GetUserCanBeSales());

          Dictionary<int, string> mySubsIdAndName = accountMgr.GetIdsAndNames(mySubs);
          foreach (string name in mySubsIdAndName.Values)
          {
              cbSales.Items.Add(name);
          
          }
          cbSales.SelectedIndex = 0;

        }

    private void CustomerAutoComplete()
    {
        List<string> customerNames = new AmbleClient.custVendor.customerVendorMgr.CustomerVendorMgr().GetMyTheCustomerVendorNamesOrVendors(0, UserInfo.UserId);
        tbCustomer.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
        tbCustomer.AutoCompleteSource = AutoCompleteSource.CustomSource;

        AutoCompleteStringCollection autoSource = new AutoCompleteStringCollection();
        foreach (string customerName in customerNames)
        {
            autoSource.Add(customerName);
        }
        tbCustomer.AutoCompleteCustomSource = autoSource;
    
    }


    public override void FillTheTable(Rfq rfq)
    {
        base.FillTheTable(rfq);
        base.tbCustomer.Text = rfq.customerName;

    }

    private void tbCustomer_Leave(object sender, EventArgs e)
    {

        //自动填充contact,phone,fax
        Dictionary<string, string> contactInfo = new AmbleClient.custVendor.customerVendorMgr.CustomerVendorMgr().GetContactInfo(0, UserInfo.UserId, tbCustomer.Text.Trim());
       //contact   
        AutoCompleteStringCollection contactSource=new AutoCompleteStringCollection();
        if (contactInfo.Keys.Contains("contact1"))
        {
            tbContact.Text = contactInfo["contact1"];
            contactSource.Add(contactInfo["contact1"]);
        }
        else
        {
            tbContact.Text = "";
        }
        if(contactInfo.Keys.Contains("contact2"))
           {
            contactSource.Add(contactInfo["contact2"]);
           }
        tbContact.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
        tbContact.AutoCompleteSource=AutoCompleteSource.CustomSource;
        tbContact.AutoCompleteCustomSource=contactSource;
        //phone
        AutoCompleteStringCollection phoneSource=new AutoCompleteStringCollection();
        if (contactInfo.Keys.Contains("phone1"))
        {
            tbPhone.Text = contactInfo["phone1"];
            phoneSource.Add(contactInfo["phone1"]);
        }
        else
        {
            tbPhone.Text = "";
        }
        if(contactInfo.Keys.Contains("phone2"))
        {
         phoneSource.Add(contactInfo["phone2"]);
        }
        if(contactInfo.Keys.Contains("cellphone"))
        {
         phoneSource.Add(contactInfo["cellphone"]);
        }
        tbPhone.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
        tbPhone.AutoCompleteSource=AutoCompleteSource.CustomSource;
        tbPhone.AutoCompleteCustomSource=phoneSource;

        AutoCompleteStringCollection faxSource=new AutoCompleteStringCollection();
        if (contactInfo.Keys.Contains("fax"))
        {
            tbFax.Text = contactInfo["fax"];
            faxSource.Add(contactInfo["fax"]);
        }
        else
        {
            tbFax.Text = "";
        }
        tbFax.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
        tbFax.AutoCompleteSource=AutoCompleteSource.CustomSource;
        tbFax.AutoCompleteCustomSource=faxSource;

        AutoCompleteStringCollection emailSource=new AutoCompleteStringCollection();
        if(contactInfo.Keys.Contains("email1"))
           {
            tbContact.Text=contactInfo["email1"];
            contactSource.Add(contactInfo["email1"]);
           }
        if(contactInfo.Keys.Contains("email2"))
           {
            contactSource.Add(contactInfo["email2"]);
           }
        tbContact.AutoCompleteMode=AutoCompleteMode.SuggestAppend;
        tbContact.AutoCompleteSource=AutoCompleteSource.CustomSource;
        tbContact.AutoCompleteCustomSource=emailSource;

       
    }

   }
}