using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.OfferGui.OfferMgr
{
  public class Offer
  {
     public  int offerId;
     public int rfqNo;
     public string mpn;
     public string mfg;
     public string vendorName;
     public string contact;
     public string phone;
     public string fax;
     public string email;
     public int? amount;
     public int? deliverTime;
     public int timeUnit; // 0 days:1week,2,month,3 year
     public float? price;
     public int buyerId;
     public DateTime offerDate;
     public int offerStates;
     public string notes;
   }




}
