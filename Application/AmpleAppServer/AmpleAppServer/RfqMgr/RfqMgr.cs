using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AmbleAppServer.RfqMgr
{
   public class RfqMgr:System.MarshalByRefObject
    {
        DataClass.DataBase db = new DataClass.DataBase();

        public RfqMgr()
        { }


        public int GetThePageCountOfDataTable(int itemsPerPage,int salesId,string filterColumn,string filterString)
        { int count=0;
                     //get the subs IDs include himself
           AmbleAppServer.AccountMgr.AccountMgr accountMgr = new AccountMgr.AccountMgr();

           List<int> subIds = accountMgr.GetAllSubsId(salesId);

           foreach (int id in subIds)
           {
               count += GetThePageCountOfDataTablePerSale(itemsPerPage, id, filterColumn, filterString);
           }
           return count;
        
        }



        public int GetThePageCountOfDataTablePerSale(int itemsPerPage,int salesId,string filterColumn,string filterString)
        { 
          //Get the account of dataset  of rfq
            string strSql;
            if ((!string.IsNullOrEmpty(filterColumn)) && (!(string.IsNullOrEmpty(filterString))))
            {
                strSql = string.Format("select count(*) from rfq where {0} like '%{1}%' and salesId={2}", filterColumn, filterString,salesId);

            }
            else

            {
                strSql = "select count(*) from rfq where salesId="+salesId;
            }
            int count = Convert.ToInt32(db.GetSingleObject(strSql));
            return (int)(Math.Ceiling((double)count / (double)itemsPerPage));
         
        }


        public DataTable GetMyRfqDataTableAccordingToPageNumber(int salesId,int pageNumber,int itemsPerPage)
        {
            string strSql = string.Format("select * from rfq r left join rfqStateRecord rsr on r.rfqNo=rsr.rfqNo where salesId={0} limit{1},{2}", salesId, (pageNumber - 1) * itemsPerPage, itemsPerPage);
         return  db.GetDataTable(strSql,"Table"+pageNumber);
        }

        public DataTable GetICanSeeRfqDataTableAccordingToPageNumber(int salesId, int pageNumber, int itemsPerPage)
        {
            AmbleAppServer.AccountMgr.AccountMgr accountMgr = new AccountMgr.AccountMgr();

            List<int> subIds = accountMgr.GetAllSubsId(salesId);

            StringBuilder sb = new StringBuilder();
            sb.Append("select * from rfq r left join rfqStateRecord rsr on r.rfqNo=rsr.rfqNo where salesId="+subIds[0]);
            if (subIds.Count() > 1)
            {
                for (int i = 1; i < subIds.Count(); i++)
                    sb.Append(" or salesId=" + subIds[i]);
             }
            sb.Append(string.Format("  limit {0},{1}", pageNumber, itemsPerPage));

            return db.GetDataTable(sb.ToString(), "Table" + pageNumber);

        }





        public void CopyRfq(int rfqNo,int salesId)
        {
        //delete all the previous record
            string strSql=string.Format("delete from rfqCopy where salesId={0}",salesId);
            db.ExecDataBySql(strSql);
            strSql=string.Format("insert into rfqCopy values({0},{1})",rfqNo,salesId);
            db.ExecDataBySql(strSql);
        }

        public bool hasCopiedRfq(int salesId)
        {
         string strSql=string.Format("select count(*) from rfqCopy where salesId={0}",salesId);
         if((int)db.GetSingleObject(strSql)==1)
         {
          return true;
         }
         else
         {
        return false;
         }
        }

        public DataTable GetTheCopiedRecord(int salesId)
        {
        
        return null;
        }






    }
}
