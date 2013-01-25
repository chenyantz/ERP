using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.RfqGui
{
   public class BuyerManagerRfqItems:RfqItems
    {
        private List<int> mySubs;

        public List<int> MySubs
        {
            get 
            {
                return mySubs;
            }
        
        }

       public BuyerManagerRfqItems()
       {


           foreach (Control control in this.Controls)
           {
               if (control is Label)
                   continue;

               control.Enabled=false;

           }
           this.cbPrimaryPA.Enabled = true;
           this.cbAltPA.Enabled = true;

       }

       public override void FillTheTable(AmbleAppServer.RfqMgr.Rfq rfq)
       {
           base.FillTheTable(rfq);
           tbCustomer.Text = rfq.customerName;

           this.tbContact.Text = string.Empty;//can not be seen by sales Manager
           this.tbPhone.Text = string.Empty; //can not be seen by sales Manager.


           //Fill the sales
           List<int> sales = new List<int>();
           sales.Add(rfq.salesId);

           cbSales.Items.Add(GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(sales)[rfq.salesId]);
           cbSales.SelectedIndex = 0;
           // cbSales.Text = (GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(sales))[rfq.salesId];
           
           //Fill the PA
           mySubs = GlobalRemotingClient.GetAccountMgr().GetAllSubsId(UserInfo.UserId);
           Dictionary<int, string> mySubsIdAndName = GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(mySubs);

           //确认里面的buyer是不是我的下属，如果不是，不能更改。
           if (rfq.firstPA.HasValue == false || mySubs.Contains(rfq.firstPA.Value))
           {
               foreach (string name in mySubsIdAndName.Values)
               {
                   cbPrimaryPA.Items.Add(name);
               }
               if (rfq.firstPA.HasValue == false)
               {
                   cbPrimaryPA.SelectedIndex = -1;
               }
               else
               {
                   cbPrimaryPA.SelectedIndex = mySubs.IndexOf(rfq.firstPA.Value);
               }

           }
           else
           {
               List<int> buyer = new List<int>();
               buyer.Add(rfq.firstPA.Value);
               cbPrimaryPA.Items.Add(GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(buyer)[rfq.firstPA.Value]);
               cbPrimaryPA.SelectedIndex = 0;
           }
           if (rfq.secondPA.HasValue == false || mySubs.Contains(rfq.secondPA.Value))
           {
               foreach (string name in mySubsIdAndName.Values)
               {
                   cbAltPA.Items.Add(name);
               }

               if (rfq.secondPA.HasValue == false)
               {
                   cbAltPA.SelectedIndex = -1;
               }
               else
               {
                   cbAltPA.SelectedIndex = mySubs.IndexOf(rfq.secondPA.Value);
               }

           }
           else
           {
               List<int> buyer = new List<int>();
               buyer.Add(rfq.secondPA.Value);
              cbAltPA.Items.Add(GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(buyer)[rfq.secondPA.Value]);
              cbAltPA.SelectedIndex = 0;
           }


       }





    }
    



}
