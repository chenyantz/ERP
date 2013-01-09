using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.RfqMgr;

namespace AmbleClient.Sales
{
    public partial class RfqItems : UserControl
    {
        List<int> mySubs;
        
        public RfqItems()
        {
            InitializeComponent();
        }

        private void RfqItems_Load(object sender, EventArgs e)
        {
            
        }
        public bool SaveInfo()
        {
            CheckItems();
            
            Rfq rfq=new Rfq();
                        rfq.customerName = tbCustomer.Text.Trim();
            rfq.salesId = mySubs[cbSales.SelectedIndex];
            rfq.project = tbProject.Text.Trim();
            rfq.contact = tbContact.Text.Trim();
            rfq.phone = tbPhone.Text.Trim();
            rfq.fax = tbFax.Text.Trim();
            rfq.email = tbEmail.Text.Trim();
            //priority
            if (cbPriority.SelectedIndex == -1)
            {
                rfq.priority = null;
            }
            else
            {
                rfq.priority = cbPriority.SelectedIndex;
            }
            if (cbRohs.Checked)
            {
                rfq.rohs = 1;
            }
            else
            {
                rfq.rohs = 0;
            }
            rfq.rfqdate = DateTime.Now.Date;
            rfq.dockdate = dateTimePicker1.Value.Date;
            rfq.partNo = tbPartNo.Text.Trim();
            rfq.mfg = tbMfg.Text.Trim();
            rfq.dc = tbDc.Text.Trim();
            rfq.custPartNo = tbCustPartNo.Text.Trim();
            rfq.genPartNo = tbGenPartNo.Text.Trim();
            rfq.alt = tbAlt.Text.Trim();
            if (string.IsNullOrWhiteSpace(tbQuantity.Text.Trim()))
            {
                rfq.qty = null;
            }
            else
            {
                rfq.qty = int.Parse(tbQuantity.Text.Trim());//checked if non-number value in checkItems();
            }
            rfq.packaging = tbPackaging.Text.Trim();
            
            if(string.IsNullOrWhiteSpace(tbTargetPrice.Text.Trim()))
            {
             rfq.targetPrice=null;
            }
            else
            {
             rfq.targetPrice=float.Parse(tbTargetPrice.Text.Trim()); //checked  in checkitems()
            }

            if (string.IsNullOrWhiteSpace(tbResale.Text.Trim()))
            {
                rfq.resale = null;
            }
            else
            {
                rfq.resale = float.Parse(tbResale.Text.Trim());
            
            }

            if (string.IsNullOrWhiteSpace(tbCost.Text.Trim()))
            {
                rfq.cost = null;
            }
            else
            {
                rfq.cost = float.Parse(tbCost.Text.Trim());
            }
            rfq.infoToCustomer = tbToCustomer.Text;
            rfq.infoToInternal = tbToInternal.Text;
            rfq.routingHistory = UserInfo.UserName.ToString() + "   Create the RFQ\n";
            

          return  GlobalRemotingClient.GetRfqMgr().SaveRfq(rfq);


           // rfq.salesId
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


        public void FillTheTable()
        { }



        public void CheckItems()
        { }

        public void UpdateInfo()
        { }

        public void RouteRfq()
        { }




    
    }
}
