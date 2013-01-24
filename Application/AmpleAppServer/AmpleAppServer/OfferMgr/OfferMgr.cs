using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace AmbleAppServer.OfferMgr
{
   public class OfferMgr:MarshalByRefObject
    {
       DataClass.DataBase db = new DataClass.DataBase();
       
       public bool SaveOffer(Offer offer)
       {
           string strSql = "insert into offer(rfqNo,mpn,mfg,vendorName,contact,phone,fax,email,amount,price,deliverTime,timeUnit,buyerId,offerDate,offerStates) " +
               string.Format(" values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12},'{13}',{14})", offer.rfqNo, offer.mpn, offer.mfg, offer.vendorName, offer.contact,
               offer.phone, offer.fax, offer.email, offer.amount.HasValue?offer.amount.Value.ToString():"null", offer.price.HasValue?offer.price.ToString():"null", offer.deliverTime.HasValue? offer.deliverTime.Value.ToString():"null", offer.timeUnit, offer.buyerId, offer.offerDate.ToShortDateString(), offer.offerStates);

           int row = db.ExecDataBySql(strSql);
           if (row == 1)
               return true;
           else
               return false;
       }


       public int GetNewSavedOfferId(int buyerId)
       {
           string strSql = "select max(offerId) from offer where buyerId=" + buyerId;
           return Convert.ToInt32(db.GetSingleObject(strSql));
       
       }



       public List<Offer> GetOffersByRfqId(int rfqId)
       {
           List<Offer> offerList = new List<Offer>();

           string strSql = "select * from offer where rfqNo=" + rfqId;

           DataTable dt = db.GetDataTable(strSql, "tempTable");
           foreach (DataRow dr in dt.Rows)
           {
               offerList.Add(GetOfferFromDataRow(dr));
           
           }
           return offerList;

       }


       private Offer GetOfferFromDataRow(DataRow dr)
       {

           int? tmpAmount = null; float? tmpPrice = null; int? tmpDeliverTime = null;
           if (dr["amount"] == DBNull.Value)
           {
               tmpAmount = null;
           }
           else
           {
               tmpAmount = Convert.ToInt32(dr["amount"]);
           }
           if (dr["price"] == DBNull.Value)
           {
               tmpPrice = null;
           }
           else
           {
               tmpPrice = Convert.ToSingle(dr["price"]);
           }
           if (dr["deliverTime"] == DBNull.Value)
           {
               tmpDeliverTime = null;
           }
           else
           {
               tmpDeliverTime = Convert.ToInt32(dr["deliverTime"]);
           }

           return new Offer
           {
               offerId=Convert.ToInt32(dr["offerId"]),
               rfqNo=Convert.ToInt32(dr["rfqNo"]),
               mpn=dr["mpn"].ToString(),
               mfg=dr["mfg"].ToString(),
               vendorName=dr["vendorName"].ToString(),
               contact=dr["contact"].ToString(),
               phone=dr["phone"].ToString(),
               fax=dr["fax"].ToString(),
               email=dr["email"].ToString(),
               amount=tmpAmount,
               price=tmpPrice,
               deliverTime=tmpDeliverTime,
               timeUnit=Convert.ToInt32(dr["timeUnit"]),
               offerDate=Convert.ToDateTime(dr["offerDate"]),
               offerStates=Convert.ToInt32(dr["offerStates"])
           };

       
       
       }



       public bool ChangeOfferState(int offerState, int offerId)
       {
           string strSql = string.Format("update offer set offerStates={0} where offerId={1}", offerState,offerId);
           if (db.ExecDataBySql(strSql) == 1)
           {
               if(offerState==1)
               {
                   FillTheRfqCost(offerId);
                }
               return true;
           
           }

           return false;
       }

       public void FillTheRfqCost(int offerId)
       {
           string strSql = "select rfqNo,price from offer where offerId=" + offerId;
           DataTable dt = db.GetDataTable(strSql, "offer");
           DataRow dr = dt.Rows[0];
           int rfqNo = Convert.ToInt32(dr["rfqNo"]);
           float price = Convert.ToSingle(dr["price"]);
           //get the cost in the RFQ table
           strSql = "select cost,rfqStates from rfq where rfqNo=" + rfqNo;
           dr = db.GetDataTable(strSql, "tmp").Rows[0];
           int rfqStates = Convert.ToInt32(dr["rfqStates"]);

           if ((dr["cost"] == DBNull.Value) || Convert.ToSingle(dr["cost"]) > price)
           {
               if (rfqStates == (int)AmbleAppServer.RfqMgr.RfqStatesEnum.Routed)
               {
                   strSql = string.Format("update rfq set cost={0},rfqStates={1} where rfqNo={2}", price,(int)AmbleAppServer.RfqMgr.RfqStatesEnum.Offered, rfqNo);

               }
               else
               {
                   strSql = string.Format("update rfq set cost={0} where rfqNo={1}", price, rfqNo);
               
               }
               db.ExecDataBySql(strSql);
           }
       }



    }
}
