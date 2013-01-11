using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.RfqGui
{
    public class BuyerManagerRfqListView:RFQListView
    {
        public BuyerManagerRfqListView()
        {
            tsbNewRfq.Enabled = false;
        }

      public override int GetPageCount(int itemsPerPage, string filterColumn, string filterString, bool includeSubs)
      {


          return 0;

      }




        
    }
}
