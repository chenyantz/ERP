using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.SoMgr;

namespace AmbleClient.SO
{
   public partial class SoItemsGridView:DataGridView
    {
       public SoItemsGridView()
       {
           InitializeComponent();
       }

       public void FillSoItemsGridView(List<SoItems> soItemList)
       {

           this.Rows.Insert(0, 1, 1, "1981", 1, 1, 1, 1, 1);
          for(int i=1;i<=20;i++)
           this.Rows.Insert(i, "test");
       }

   
   }
}
