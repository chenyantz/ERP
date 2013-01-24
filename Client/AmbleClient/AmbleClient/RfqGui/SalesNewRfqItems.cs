using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
            cbCloseReason.Enabled = false;
            tbRfqDate.ReadOnly = true; tbRfqDate.Enabled = false;
            //clear all the necessary textbox
            tbCustomer.Clear();
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

    public override void FillTheTable(Rfq rfq)
    {
        base.FillTheTable(rfq);
        base.tbCustomer.Text = rfq.customerName;

    }


   }
}