using System;
using System.Collections.Generic;
using System.Linq;
using System.Text
using System.Data;

namespace AmbleAppServer.RfqMgr
{
    class RfqMgr:System.MarshalByRefObject
    {
        DataClass.DataBase db = new DataClass.DataBase();

        public RfqMgr()
        { }



        public int GetThePagesCountOfDataTable(int itemsPerPage,string filterColumn,string filterString)
        { 
          //Get the account of dataset  of rfq
            string strSql;
            if ((!string.IsNullOrEmpty(filterColumn)) && (!(string.IsNullOrEmpty(filterString))))
            {
                strSql = string.Format("select count(*) from rfq where {0} like '%{1}%'", filterColumn, filterString);

            }
            else

            {
                strSql = "select count(*) from rfq";
            }
            int count = (int)db.GetSingleObject(strSql);
            return (int)(Math.Ceiling((double)count / (double)itemsPerPage));
         
        }


        public DataTable GetTheRfqDataTableAccordingToPageNumber(int pageNumber,int itemsPerPage)
        {
         string strSql=string.Format("select * from rfq limit{0},{1}",(pageNumber-1)*itemsPerPage,itemsPerPage)
         return  db.GetDataTable(strSql,"Table"+pageNumber);

        
        }









    }
}
