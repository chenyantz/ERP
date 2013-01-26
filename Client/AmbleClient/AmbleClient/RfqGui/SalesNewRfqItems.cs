using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.RfqMgr;

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
            base.CheckItems();
            
            Rfq rfq=new Rfq();
            GetValuesFromGui(rfq);
            rfq.closeReason = null;
            rfq.salesId = mySubs[cbSales.SelectedIndex];
            rfq.routingHistory =DateTime.Now.ToShortDateString()+":"+UserInfo.UserName.ToString() + ":Create the RFQ\n";
            

          return  GlobalRemotingClient.GetRfqMgr().SaveRfq(rfq);


           // rfq.salesId
        }
    public int GetSavedRfqId()
    {
        return GlobalRemotingClient.GetRfqMgr().GetSavedRfqId(mySubs[cbSales.SelectedIndex]);
   
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
          mySubs = GlobalRemotingClient.GetAccountMgr().GetAllSubsId(UserInfo.UserId);
          Dictionary<int, string> mySubsIdAndName = GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(mySubs);
          foreach (string name in mySubsIdAndName.Values)
          {
              cbSales.Items.Add(name);
          
          }
          cbSales.SelectedIndex = 0;

        }

    private void CustomerAutoComplete()
    {
        List<string> customerNames = GlobalRemotingClient.GetCustomerVendorMgr().GetMyTheCustomerVendorNamesOrVendors(0, UserInfo.UserId);
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

    /*private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // tbCustomer
        // 

        // 
        // SalesNewRfqItems
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.Name = "SalesNewRfqItems";
        this.ResumeLayout(false);
        this.PerformLayout();

    }*/

    private void tbCustomer_Leave(object sender, EventArgs e)
    {

        //自动填充contact,phone,fax
        Dictionary<string, string> contactInfo = GlobalRemotingClient.GetCustomerVendorMgr().GetContactInfo(0, UserInfo.UserId, tbCustomer.Text.Trim());
       //contact   
        AutoCompleteStringCollection contactSource=new AutoCompleteStringCollection();
        if(contactInfo.Keys.Contains("contact1"))
           {
            tbContact.Text=contactInfo["contact1"];
            contactSource.Add(contactInfo["contact1"]);
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
        if(contactInfo.Keys.Contains("phone1"))
        {
          tbPhone.Text=contactInfo["phone1"];
            phoneSource.Add(contactInfo["phone1"]);
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
        if(contactInfo.Keys.Contains("fax"))
        {
         tbFax.Text=contactInfo["fax"];
          faxSource.Add(contactInfo["fax"]);
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