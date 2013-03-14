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
       public override void FillTheTable(AmbleClient.RfqGui.RfqManager.Rfq rfq)
       {
           base.FillTheTable(rfq);


           this.tbCustomer.Text = string.Empty;
           this.tbContact.Text = string.Empty;
           this.tbPhone.Text = string.Empty;

           AmbleClient.Admin.AccountMgr.AccountMgr accountMgr = new Admin.AccountMgr.AccountMgr();
           cbSales.Items.Add(accountMgr.GetNameById(rfq.salesId));
           cbSales.SelectedIndex = 0;


          if (rfq.firstPA != null) 
           {
               cbPrimaryPA.Items.Add(accountMgr.GetNameById(rfq.firstPA.Value));
               cbPrimaryPA.SelectedIndex = 0;

           }
           if (rfq.secondPA != null)
           {
               cbAltPA.Items.Add(accountMgr.GetNameById(rfq.secondPA.Value));
              cbAltPA.SelectedIndex = 0;

           }

       }

    }
}
