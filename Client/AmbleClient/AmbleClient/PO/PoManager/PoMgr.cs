using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AmbleClient.PO.PoMgr
{
   public class PoMgrBak
    {
       DataClass.DataBase db = new DataClass.DataBase();

       public List<Po> GetPoAccordingToSoId(int soId)
       {
           List<Po> poList = new List<Po>();
           string strSql = "select poId from Po where soId=" + soId;
           DataTable dt = db.GetDataTable(strSql, "poId");
           foreach (DataRow dr in dt.Rows)
           {
               poList.Add(GetPoAccordingToPoId(Convert.ToInt32(dr["poId"])));
           }
           return poList;          
       }

       public Po GetPoAccordingToPoId(int poId)
       {
           string strSql = "select * from Po where poId=" + poId;
           DataTable dt = db.GetDataTable(strSql, "Po");
           if (dt.Rows.Count != 1)
           {
               return null;
           }
           DataRow dr = dt.Rows[0];

           return new Po
           {
             poId=Convert.ToInt32(dr["poId"]),
             soId=Convert.ToInt32(dr["soId"]),
             vendorName=dr["vendorName"].ToString(),
             contact=dr["contact"].ToString(),
             pa=Convert.ToInt32(dr["pa"]),
             paDate=Convert.ToDateTime(dr["paDate"]),
             vendorNumber=dr["vendorNumber"].ToString(),
             poDate=Convert.ToDateTime(dr["poDate"]),
             poNo=dr["poNo"].ToString(),
             paymentTerms=dr["paymentTerms"].ToString(),
             shipMethod=dr["shipMethod"].ToString(),
             freight=dr["freight"].ToString(),
             shipToLocation=dr["shipToLocation"].ToString(),
             billTo=dr["billTo"].ToString(),
             shipTo=dr["shipTo"].ToString(),
             poStates=Convert.ToInt32(dr["poStates"])
           };

          
       }

       public List<PoItems> GetPoItemsAccordingToPoId(int poId)
       {
           List<PoItems> poItemsList = new List<PoItems>();
           string strSql = "select * from PoItems where poId=" + poId;
           DataTable dt = db.GetDataTable(strSql, "poItems");
           foreach (DataRow dr in dt.Rows)
           {
             
           }
           return poItemsList;
           
       }



       public bool SavePoMain(Po po)
       {
           string strSql = "insert into Po(soId,vendorName,contact,pa,paDate,vendorNumber,poDate,poNo,paymentTerms,shipMethod,freight,shipToLocation,billTo,shipTo,poStates) "+
               string.Format(" values({0},'{1}','{2}',{3},'{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}',0)", po.soId, po.vendorName, po.contact, po.pa, po.paDate.ToShortDateString(), po.vendorNumber, po.poDate.ToShortDateString(), po.poNo, po.paymentTerms, po.shipMethod, po.freight, po.shipToLocation, po.billTo, po.shipTo, po.poStates);

           if (db.ExecDataBySql(strSql) == 1)
               return true;

           return false; 
       }

       public int GetTheInsertId(int paId)
       {
           string strSql = "select max(soId) from So where pa=" + paId;
           return Convert.ToInt32(db.GetSingleObject(strSql));
       }

       public bool SavePoItems(int poId, List<PoItems> poitems)
       {
           List<string> strSqls = new List<string>();
           foreach (PoItems poItem in poitems)
           {

               string strsql = "insert into PoItems(poId,partNo,mfg,dc,vendorIntPartNo,org,qty,qtyRecd,qtyCorrected,qtyAccept,qtyRejected,qtyRTV,qcPending,currency,unitPrice,dueDate,receiveDate,stepCode,salesAgent,noteToVendor) " +
                   string.Format(" values({0},'{1}','{2}','{3}',{4},'{5}',{6},{7},{8},{9},{10},{11},{12},{13},{14},'{15}','{16}','{17}',{18})", 
                   poId, poItem.partNo, poItem.mfg, poItem.dc, poItem.vendorIntPartNo, poItem.org, poItem.qty, poItem.qtyRecd, poItem.qtyCorrected, poItem.qtyAccept, poItem.qtyRejected, poItem.qtyRTV, poItem.qcPending, poItem.currency, poItem.unitPrice, poItem.dueDate, poItem.receiveDate, poItem.stepCode, poItem.salesAgent,poItem.noteToVendor);
               strSqls.Add(strsql);

           }

           return db.ExecDataBySqls(strSqls);

       }




    }
}
