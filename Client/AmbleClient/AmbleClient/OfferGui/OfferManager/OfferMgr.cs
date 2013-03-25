using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;


namespace AmbleClient.OfferGui.OfferMgr
{
   public class OfferMgr
    {
      
       
       DataClass.DataBase db = new DataClass.DataBase();


       
       public bool SaveOffer(Offer offer)
       {
           string strSql = "insert into offer(rfqNo,mpn,mfg,vendorName,contact,phone,fax,email,amount,price,deliverTime,timeUnit,buyerId,offerDate,offerStates,notes) " +
               string.Format(" values('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}',{9},{10},{11},{12},'{13}',{14})", offer.rfqNo, offer.mpn, offer.mfg, offer.vendorName, offer.contact,
               offer.phone, offer.fax, offer.email, offer.amount.HasValue?offer.amount.Value.ToString():"null", offer.price.HasValue?offer.price.ToString():"null", offer.deliverTime.HasValue? offer.deliverTime.Value.ToString():"null", offer.timeUnit, offer.buyerId, offer.offerDate.ToShortDateString(), offer.offerStates,offer.notes);

           int row = db.ExecDataBySql(strSql);
           if (row == 1)
               return true;
           else
               return false;
       }


       public void UpdateOffer(Offer offer)
       {
           string strSql = string.Format("update offer set mpn='{0}',mfg='{1}',vendorName='{2}',contact='{3}',phone='{4}',fax='{5}',email='{6}',amount={7},price={8},deliverTime='{9}',timeUnit={10},buyerId={11},notes='{12}' where offerId={13} ",
          offer.mpn, offer.mfg, offer.vendorName, offer.contact,offer.phone, offer.fax, offer.email, offer.amount.HasValue ? offer.amount.Value.ToString() : "null", offer.price.HasValue ? offer.price.ToString() : "null", offer.deliverTime.HasValue ? offer.deliverTime.Value.ToString() : "null", offer.timeUnit, offer.buyerId, offer.notes,offer.offerId);

         db.ExecDataBySql(strSql);

       }



       public int GetNewSavedOfferId(int buyerId)
       {
           string strSql = "select max(offerId) from offer where buyerId=" + buyerId;
           return Convert.ToInt32(db.GetSingleObject(strSql));
       
       }

       public List<Offer> GetOfferAccordingToFilter(int userId, bool includeSubs,string filterColumn,string filterString, List<int> intStateList)
        {
            List<Offer> offerList = new List<Offer>();
            if (intStateList.Count == 0) return offerList;
            List<int> buyerId = new List<int>();

            if (includeSubs)
            {
                var accountMgr = new AmbleClient.Admin.AccountMgr.AccountMgr();
                buyerId.AddRange(accountMgr.GetAllSubsId(userId, UserCombine.GetUserCanBeBuyers()));
            }
            else
            {
                buyerId.Add(userId);
            }

           StringBuilder sb=new StringBuilder();
           sb.Append("select * from offer where ( buyerId="+buyerId[0]);
           for(int i=1;i<buyerId.Count;i++)
           {
               sb.Append(" or buyerId=" + buyerId[i]);
           }
           sb.Append(" ) ");

           //append the filter
           if ((!string.IsNullOrWhiteSpace(filterColumn)) && (!string.IsNullOrWhiteSpace(filterString)))
           { 
            sb.Append(string.Format(" and {0} like '%{1}%' ",filterColumn,filterString));
           }

           sb.Append(" and ( offerStates="+intStateList[0]);
           for(int i=1;i<intStateList.Count;i++)
           {
            sb.Append(" or offerStates="+intStateList[i]);
           
           }
           sb.Append(" )");

           DataTable dt=db.GetDataTable(sb.ToString(),"offers");
           foreach (DataRow dr in dt.Rows)
           {
               offerList.Add(GetOfferFromDataRow(dr));
           
           }
           return offerList;
  
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

       public Offer GetOfferByOfferId(int offerId)
       {

           string strSql = "select * from offer where offerId=" + offerId.ToString();

           DataTable dt = db.GetDataTable(strSql, "tempTable");

         return GetOfferFromDataRow(dt.Rows[0]);


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
               buyerId=Convert.ToInt32(dr["buyerId"]),
               timeUnit=Convert.ToInt32(dr["timeUnit"]),
               offerDate=Convert.ToDateTime(dr["offerDate"]),
               offerStates=Convert.ToInt32(dr["offerStates"]),
               notes=dr["notes"].ToString()
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
