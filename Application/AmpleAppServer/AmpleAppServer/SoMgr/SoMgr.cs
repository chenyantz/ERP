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


       public bool SaveSoMain(So so)
       {
           string strSql = "insert into So(rfqId,customerName,contact,salesId,salesOrderNo,orderDate,customerPo,paymentTerm,freightTerm,customerAccout,specialInstructions,billTo,shipTo,soStates) " +
               string.Format(" values({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}',0)", so.rfqId, so.customerName, so.contact, so.salesId, so.salesOrderNo, so.orderDate.ToShortDateString(), so.customerPo,
               so.paymentTerm, so.freightTerm, so.customerAccount, so.specialInstructions, so.billTo, so.shipTo);

           if (db.ExecDataBySql(strSql) == 1)
               return true;
           
           return false;
       }


       public int GetTheInsertId(int salesId)
       {
           string strSql = "select max(soId) from So where salesId=" + salesId;
           return Convert.ToInt32(db.GetSingleObject(strSql));
       }

       public bool SaveSoItems(int soId, List<SoItems> soitems)
       {
           List<string> strSqls = new List<string>();
           foreach (SoItems soItem in soitems)
           {

               string strsql = "insert into SoItems(soId,saleType,partNo,mfg,rohs,dc,intPartNo,shipFrom,trackingNo,qty,qtyShipped,currency,unitPrice,dockDate,shippedDate,shippingInstruction,dockingInstruction) " +
                   string.Format(" values({0},{1},'{2}','{3}',{4},'{5}','{6}','{7}','{8}',{9},{10},{11},{12},'{13}','{14}','{15}','{16}')", soId, soItem.saleType, soItem.partNo, soItem.mfg, soItem.rohs, soItem.dc,
                   soItem.intPartNo, soItem.shipFrom, soItem.trackingNo, soItem.qty, soItem.qtyshipped, soItem.currencyType, soItem.unitPrice, soItem.dockDate.ToShortDateString(), soItem.shippedDate.ToShortDateString(),
                   soItem.shippingInstruction, soItem.dockingInstruction);
           
           }

           return db.ExecDataBySqls(strSqls);

       }

    }
}
