using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.RfqMgr;

namespace AmbleClient.RfqGui
{
    public partial class RfqItems : UserControl
    {
        
        public RfqItems()
        {
            InitializeComponent();
        }

        private void RfqItems_Load(object sender, EventArgs e)
        {
            
        }

        protected void GetValuesFromGui(Rfq rfq)
        {
            rfq.customerName = tbCustomer.Text.Trim();

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

            if (string.IsNullOrWhiteSpace(tbTargetPrice.Text.Trim()))
            {
                rfq.targetPrice = null;
            }
            else
            {
                rfq.targetPrice = float.Parse(tbTargetPrice.Text.Trim()); //checked  in checkitems()
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

            if (cbCloseReason.SelectedIndex == -1)
            {
                rfq.closeReason = null;

            }
            else
            {
                rfq.closeReason = cbCloseReason.SelectedIndex;
            }
        
        }

        public virtual void FillTheTable(AmbleAppServer.RfqMgr.Rfq rfq)
        {
           /*
            tbCustomer.Text = rfq.customerName;
            //select the sales ID
            //获得下级号和名字
            mySubs = GlobalRemotingClient.GetAccountMgr().GetAllSubsId(UserInfo.UserId);
            Dictionary<int, string> mySubsIdAndName = GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(mySubs);
            foreach (string name in mySubsIdAndName.Values)
            {
                cbSales.Items.Add(name);

            }
            for (int i = 0; i < mySubs.Count; i++)
            {
                if (mySubs[i] == rfq.salesId)
                {
                    cbSales.SelectedIndex = i;
                    break;

                }

            }
            * */
            tbProject.Text = rfq.project;
            tbContact.Text = rfq.contact;
            tbPhone.Text = rfq.phone;
            tbFax.Text = rfq.fax;
            tbEmail.Text = rfq.email;
            cbPriority.SelectedIndex = (rfq.priority.HasValue ? rfq.priority.Value : -1);
            cbRohs.Checked = (rfq.rohs == 1 ? true : false);
            tbRfqDate.Text = rfq.rfqdate.ToShortDateString();
            dateTimePicker1.Value = rfq.dockdate;
            tbPartNo.Text = rfq.partNo;
            tbMfg.Text = rfq.mfg;
            tbDc.Text = rfq.dc;
            tbCustPartNo.Text = rfq.custPartNo;
            tbGenPartNo.Text = rfq.genPartNo;
            tbAlt.Text = rfq.alt;
            tbQuantity.Text = rfq.qty.ToString();
            tbPackaging.Text = rfq.packaging.ToString();
            tbTargetPrice.Text = rfq.targetPrice.ToString();
            tbResale.Text = rfq.resale.ToString();
            tbCost.Text = rfq.cost.ToString();
           // tbPrimaryPA.Text = rfq.firstPA.ToString();
            //tbAltPA.Text = rfq.secondPA.ToString();
            cbCloseReason.SelectedIndex = (rfq.closeReason.HasValue ? rfq.closeReason.Value : -1);
            tbToCustomer.Text = rfq.infoToCustomer;
            tbToInternal.Text = rfq.infoToInternal;
            tbRoutingHistory.Text = rfq.routingHistory;
        }

        public void CheckItems()
        {}

    }
}
