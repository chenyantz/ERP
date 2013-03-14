using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.RfqGui.RfqManager
{
 
    public class Rfq
    {
       public int rfqNo;
       public string customerName;
       public string partNo;
       public int salesId;
       public string contact;
       public string project;
       public int rohs;
       public string phone;
       public string fax;
       public string email;
       public DateTime rfqdate;
       public int? priority;
       public DateTime dockdate;
       public string mfg;
       public string dc;
       public string custPartNo;
       public string genPartNo;
       public string alt;
       public int? qty;
       public string packaging;
       public float? targetPrice;
       public float? resale;
       public float? cost;
       public int? firstPA;
       public int? secondPA;
       public int rfqStates;
       public int? closeReason;
       public string infoToCustomer;
       public string infoToInternal;
       public string routingHistory;
   }

    public enum RfqStatesEnum 
    { 
     New=0,
     Routed=1,
     Offered=2,
     Quoted=3,
     HasSO=4,
     Closed=5
    };


}
