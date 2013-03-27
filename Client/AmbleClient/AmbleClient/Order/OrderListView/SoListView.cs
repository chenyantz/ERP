using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.Order.SoMgr;
using System.Windows.Forms;

namespace AmbleClient.Order
{
    public class SoListView:OrderListView
    {
       protected List<So> soList;

       protected SoOrderStateList soStateList = new SoOrderStateList();
    


       protected override void FillTheStateCombox()
       {
           //fill the state List
           foreach (SoState soState in soStateList.GetWholeSoStateList())
           {
               tscbListState.Items.Add(soState.GetStateString());
           }

       }

       protected override void GetTheStateList()
       {
           foreach (SoState soState in soStateList.GetWholeSoStateList())
           {
               intStateList.Add(soState.GetStateValue());
           }
           intStateList.Remove(new SoRejected().GetStateValue());
           intStateList.Remove(new SoCancelled().GetStateValue());
           intStateList.Remove(new SoClose().GetStateValue());



       }


       protected override void FillTheFilterColumnDict()
       {
           filterColumnDict.Add("Customer", "customerName");
           filterColumnDict.Add("SO number", "salesOrderNo");
           filterColumnDict.Add("Customer PO No", "customerPo");
       }

       protected override void StateChanged(object sender, EventArgs e)
       {
           intStateList.Clear();
           intStateList.Add(tscbListState.SelectedIndex);
           FillTheDataGrid();



       }



       protected override void OpenOrderDetails(int rowIndex)
       {
           if (rowIndex >= soList.Count)
               return;
           int realRowIndex = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["No"].Value);
           SO.SoView soView=new SO.SoView(soList[realRowIndex]);
           if (DialogResult.Yes == soView.ShowDialog())
           {
               FillTheDataGrid();
           }

       }


    }
}
