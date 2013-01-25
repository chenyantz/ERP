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


       public List<So> SalesGetSoAccordingTofilter(int userId, bool includedSubs, string filterColumn, string filterString, List<int> states)
       {
           

           List<So> soList=new List<So>();
           if (states.Count == 0) return soList;
           List<int> salesIds = new List<int>();

           if (includedSubs)
           {
               AmbleAppServer.AccountMgr.AccountMgr accountMgr = new AccountMgr.AccountMgr();
               salesIds.AddRange(accountMgr.GetAllSubsId(userId));
           }
           else
           {
               salesIds.Add(userId);
           }

           StringBuilder sb=new StringBuilder();
           sb.Append("select soId from So where ( salesId="+salesIds[0]);
           for(int i=1;i<salesIds.Count;i++)
           {
               sb.Append(" or salesId=" + salesIds[i]);
           }
           sb.Append(" ) ");

           //append the filter
           if ((!string.IsNullOrWhiteSpace(filterColumn)) && (!string.IsNullOrWhiteSpace(filterString)))
           { 
            sb.Append(string.Format(" and {0} like '%{1}%' ",filterColumn,filterString));
           }

           sb.Append(" and (soStates="+states[0]);
           for(int i=1;i<states.Count;i++)
           {
            sb.Append(" or soStates="+states[i]);
           
           }
           sb.Append(" )");

           DataTable dt=db.GetDataTable(sb.ToString(),"soId");

           foreach(DataRow dr in dt.Rows)
           {
           soList.Add(GetSoAccordingToSoId(Convert.ToInt32(dr["soId"])));
           }
           return soList;

       }

       public List<So> BuyerGetSoAccordingToFilter(int userId, bool includedSubs, string filterColumn, string filterString, List<int> states)

       {
           

           List<So> soList = new List<So>();
           
           if (states.Count == 0) return soList;

           List<int> buyersIds = new List<int>();

           if (includedSubs)
           {
               AmbleAppServer.AccountMgr.AccountMgr accountMgr = new AccountMgr.AccountMgr();
               buyersIds.AddRange(accountMgr.GetAllSubsId(userId));
           }
           else
           {
               buyersIds.Add(userId);
           }

           StringBuilder sb = new StringBuilder();
           sb.Append(string .Format("select soId from So s,rfq r where(s.rfqId=r.rfqNo) and ( (r.firstPA={0} or r.secondPa={0})",buyersIds[0]));
           for (int i = 1; i < buyersIds.Count; i++)
           {
               sb.Append(string.Format(" or (firstPA={0} or secondPA={0}) ",buyersIds[i]));
           }
           sb.Append(" ) ");

           //append the filter
           if ((!string.IsNullOrWhiteSpace(filterColumn)) && (!string.IsNullOrWhiteSpace(filterString)))
           {
               sb.Append(string.Format(" and {0} like '%{1}%' ", filterColumn, filterString));
           }

           sb.Append(" and (soStates=" + states[0]);
           for (int i = 1; i < states.Count; i++)
           {
               sb.Append(" or soStates=" + states[i]);

           }
           sb.Append(" )");

           DataTable dt = db.GetDataTable(sb.ToString(), "soId");

           foreach (DataRow dr in dt.Rows)
           {
               soList.Add(GetSoAccordingToSoId(Convert.ToInt32(dr["soId"])));
           }
           return soList; 
       }





       public List<So> GetSoAccordingToRfqId(int rfqId)
       {
           List<So> soList = new List<So>();
         string strSql="select soId from So where rfqId="+rfqId;

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
                       shipMethod=dr["shipMethod"].ToString(),
                       trackingNo = dr["trackingNo"].ToString(),
                       qty = Convert.ToInt32(dr["qty"]),
                       qtyshipped = Convert.ToInt32(dr["qtyShipped"]),
                       currencyType = Convert.ToInt32(dr["currency"]),
                       unitPrice = Convert.ToSingle(dr["unitPrice"]),
                      
                       dockDate = Convert.ToDateTime(dr["dockDate"]),
                       shippedDate = Convert.ToDateTime(dr["shippedDate"]),
                       shippingInstruction = dr["shippingInstruction"].ToString(),
                       packingInstruction = dr["packingInstruction"].ToString()

                   });
          }
           return soItemsList; 
    
       }

       
       public bool SaveSoMain(So so)
       {
           string strSql = "insert into So(rfqId,customerName,contact,salesId,salesOrderNo,orderDate,customerPo,paymentTerm,freightTerm,customerAccount,specialInstructions,billTo,shipTo,soStates) " +
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

               string strsql = "insert into SoItems(soId,saleType,partNo,mfg,rohs,dc,intPartNo,shipFrom,shipMethod,trackingNo,qty,qtyShipped,currency,unitPrice,dockDate,shippedDate,shippingInstruction,packingInstruction) " +
                   string.Format(" values({0},{1},'{2}','{3}',{4},'{5}','{6}','{7}','{8}','{9}',{10},{11},{12},{13},'{14}','{15}','{16}','{17}')", soId, soItem.saleType, soItem.partNo, soItem.mfg, soItem.rohs, soItem.dc,
                   soItem.intPartNo, soItem.shipFrom,soItem.shipMethod,soItem.trackingNo, soItem.qty, soItem.qtyshipped, soItem.currencyType, soItem.unitPrice, soItem.dockDate.ToShortDateString(), soItem.shippedDate.ToShortDateString(),
                   soItem.shippingInstruction, soItem.packingInstruction);
               strSqls.Add(strsql);
           
           }

           return db.ExecDataBySqls(strSqls);

       }

       public bool UpdateSoState(int soId,int userid, SoStateEnum state)
       {
           string strSql = string.Format("update so set soStates={0},approverId={1},approveDate='{2}' where soId={3}",(int)state,userid,DateTime.Now.ToShortDateString(),soId);
           if (db.ExecDataBySql(strSql) == 1)
           {
               return true;
           }
           else
           {
               return false;
           }
       }
    }
}
