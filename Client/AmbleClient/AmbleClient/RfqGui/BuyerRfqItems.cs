using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.RfqGui
{
   public class BuyerRfqItems:RfqItems
    {

       public BuyerRfqItems()
       {

           foreach (Control control in this.Controls)
           {
               if (control is Label)
                   continue;

               control.Enabled = false;

           }
       }
       public override void FillTheTable(AmbleAppServer.RfqMgr.Rfq rfq)
       {
           base.FillTheTable(rfq);

           this.tbCustomer.Text = string.Empty;
           this.tbContact.Text = string.Empty;
           this.tbPhone.Text = string.Empty;

           cbSales.Items.Add(GlobalRemotingClient.GetAccountMgr().GetNameById(rfq.salesId));
           cbSales.SelectedIndex = 0;


          if (rfq.firstPA != null) 
           {
               cbPrimaryPA.Items.Add(GlobalRemotingClient.GetAccountMgr().GetNameById(rfq.firstPA.Value));
               cbPrimaryPA.SelectedIndex = 0;

           }
           if (rfq.secondPA != null)
           {
               cbAltPA.Items.Add(GlobalRemotingClient.GetAccountMgr().GetNameById(rfq.secondPA.Value));
              cbAltPA.SelectedIndex = 0;

           }

       }

    }
}
