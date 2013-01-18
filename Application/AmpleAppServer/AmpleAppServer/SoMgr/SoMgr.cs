using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace AmbleAppServer.SoMgr
{
   public class SoMgr:MarshalByRefObject
    {
       DataClass.DataBase db = new DataClass.DataBase(); 


       public List<So> GetSoAccordingToRfqId(int rfqId)
       {
           List<So> soList = new List<So>();
         string strSql="select soId from So where rfqId"+rfqId;

         DataTable dt = db.GetDataTable(strSql,"soId");
         foreach (DataRow dr in dt.Rows)
         {
             soList.Add(GetSoAccordingToSoId(Convert.ToInt32(dr["soId"])));
         
         }

         return soList;
       }

       public So GetSoAccordingToSoId(int soId)
       {
           string strSql = "select * from So where soId=" + soId;

           DataTable dt = db.GetDataTable(strSql,"So");
           if (dt.Rows.Count != 1)
           {
               return null;
           }
           DataRow dr = dt.Rows[0];

           int? tmpApproverId=null;
           if(dr["approverId"]!=DBNull.Value)
           {
            tmpApproverId=Convert.ToInt32(dr["approverId"]);
           }
           DateTime? tmpApproveDate=null;
           if(dr["approveDate"]!=DBNull.Value)
           {
            tmpApproveDate=Convert.ToDateTime(dr["approveDate"]);
           }

           return new So
           {
               soId = Convert.ToInt32(dr["soId"]),
               rfqId = Convert.ToInt32(dr["rfqId"]),
               customerName = dr["customerName"].ToString(),
               contact = dr["contact"].ToString(),
               salesId = Convert.ToInt32(dr["salesId"]),
               approverId = tmpApproverId,
               approveDate = tmpApproveDate,
               salesOrderNo = dr["salesOrderNo"].ToString(),
               orderDate = Convert.ToDateTime(dr["orderDate"]),
               customerPo = dr["customerPo"].ToString(),
               paymentTerm = dr["paymentTerm"].ToString(),
               freightTerm = dr["freightTerm"].ToString(),
               customerAccount = dr["customerAccount"].ToString(),
               specialInstructions = dr["specialInstructions"].ToString(),
               billTo = dr["billTo"].ToString(),
               shipTo = dr["shipTo"].ToString(),
               soStates = Convert.ToInt32(dr["soStates"]),
               items=GetSoItemsAccordingToSoId(soId)
           };

       }

       public List<SoItems> GetSoItemsAccordingToSoId(int soId)
       {
           List<SoItems> soItemsList = new List<SoItems>();

           string strSql = "select * from SoItems where soId="+soId;
           DataTable dt = db.GetDataTable(strSql, "soitems");
           foreach (DataRow dr in dt.Rows)
           {
               soItemsList.Add(
                   new SoItems
                   {
                       soItemsId = Convert.ToInt32(dr["soItemsId"]),
                       soId = Convert.ToInt32(dr["soId"]),
                       saleType = Convert.ToInt32(dr["saleType"]),
                       partNo = dr["partNo"].ToString(),
                       mfg = dr["mfg"].ToString(),
                       rohs = Convert.ToInt32(dr["rohs"]),
                       dc = dr["dc"].ToString(),
                       intPartNo = dr["intPartNo"].ToString(),
                       shipFrom = dr["shipFrom"].ToString(),
                       trackingNo = dr["trackingNo"].ToString(),
                       qty = Convert.ToInt32("qty"),
                       qtyshipped = Convert.ToInt32("qtyShipped"),
                       currencyType = Convert.ToInt32("currency"),
                       unitPrice = Convert.ToSingle(dr["unitPrice"]),
                       dockDate = Convert.ToDateTime(dr["dockDate"]),
                       shippedDate = Convert.ToDateTime(dr["shippedDate"]),
                       shippingInstruction = dr["shippingInstruction"].ToString(),
                       dockingInstruction = dr["dockingInstruction"].ToString()

                   });
          }
           return soItemsList; 
    
       }

    }
}
