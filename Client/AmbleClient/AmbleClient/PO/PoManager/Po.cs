using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.PO.PoMgr
{
    public class Po
    {
        public int poId;
        public int soId;
        public string vendorName;
        public string contact;
        public int pa;
        public DateTime paDate;
        public string vendorNumber;
        public DateTime poDate;
        public string poNo;
        public string paymentTerms;
        public string shipMethod;
        public string freight;
        public string shipToLocation;
        public string billTo;
        public string shipTo;
        public int poStates;
        public List<PoItems> poItems;
    }

    public class PoItems
    { 
      public int poItemsId;
      public int poId;
      public string partNo;
      public string mfg;
      public string dc;
      public string vendorIntPartNo;
      public string org;
      public int qty;
      public int qtyRecd;
      public int qtyCorrected;
      public int qtyAccept;
      public int qtyRejected;
      public int qtyRTV;
      public int qcPending;
      public int currency;
      public float unitPrice;
      public DateTime dueDate;
      public DateTime receiveDate;
      public string stepCode;
      public int salesAgent;
      public string noteToVendor;

    }



}
