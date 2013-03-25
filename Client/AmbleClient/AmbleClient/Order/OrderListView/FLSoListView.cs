using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.Order.SoMgr;

namespace AmbleClient.Order
{
   public  class FLSoListView:SalesSoListView
    {
       protected override void ViewStart()
       {
           base.ViewStart();
           this.Text = "SO List for Finance && logistics";
           tscbList.Enabled = false;


       }





        protected override void FillTheDataGrid()
        {
            dataGridView1.Rows.Clear();
            soList = SoMgr.SoMgr.SalesGetSoAccordingTofilter(1/*Admin*/, true, filterColumn, filterString, intStateList);

            int i = 0;
            foreach (So so in soList)
            {
                dataGridView1.Rows.Add(i++, so.customerName, so.contact, idNameDict[so.salesId], so.salesOrderNo, so.orderDate.ToShortDateString(), so.customerPo,
                    so.paymentTerm, so.freightTerm, so.customerAccount, soStateList.GetSoStateStringAccordingToValue(so.soStates));
            }

        }






    }
}
