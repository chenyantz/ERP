using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.RfqGui
{
    public class BuyerRfqListView:RFQListView
    {
        public BuyerRfqListView()
        {
            tsbNewRfq.Enabled = false;
            Customer.Visible = false;
        }

    }
}
