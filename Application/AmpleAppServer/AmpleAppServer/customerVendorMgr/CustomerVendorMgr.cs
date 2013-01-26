using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;



namespace AmbleAppServer.customerVendorMgr
{
   public class CustomerVendorMgr:System.MarshalByRefObject
    {
       DataClass.DataBase db = new DataClass.DataBase();

       public CustomerVendorMgr()
       { 
              
       }

       public bool AddCustomerOrVendor(int cvtype, string cvname, string country, string cvnumber,int? rate, string term,
             string contact1, string contact2, string phone1, string phone2, string cellphone, string fax,
            string email1, string email2, int ownerName, int lastUpdateName, DateTime lastUpdateDate, int blacklisted,
            int? amount, string notes)
       {

           string strSql="INSERT INTO custVendor VALUES(" + cvtype + ",'" + cvname + "','" + country +"','"+cvnumber+ "'," + (rate.HasValue?rate.ToString():"null") + ",'" + term + "','" + contact1 + "','" +
                   contact2 + "','" + phone1 + "','" + phone2 + "','" + cellphone + "','" + fax + "','" + email1 + "','" + email2 + "'," + ownerName + "," + lastUpdateName +
                   ",'" + lastUpdateDate.ToString() + "'," + blacklisted + "," + (amount.HasValue?amount.ToString():"null") + ",'" + notes + "')";
          

          if( db.ExecDataBySql(strSql)>0)
              return  true;

           return false;

       }
       public bool IsCvtypeandCvNameExist(int cvtype, string cvName,int userId)
       {
           string strSql = "select * from custVendor WHERE cvtype=" + cvtype + " AND cvname='" + cvName + "' And ownerName="+userId;
           DataTable dt = db.GetDataTable(strSql, "CheckCvNameAndCvType");
           if(dt.Rows.Count>0)
             return true;
           return false;
        }



       public DataTable GetTheCustomersOrVendorsICanSee(int cvtype,int id)
       {
           //get the subs IDs include himself
           AmbleAppServer.AccountMgr.AccountMgr accountMgr = new AccountMgr.AccountMgr();

           List<int> subIds = accountMgr.GetAllSubsId(id);
           List<string> sqlCodes = new List<string>();


           DataTable theCustomerOrVendorICanSee = new DataTable();

           foreach (int subId in subIds)
           {
             string  strSql = "select * from custVendor where cvtype=" + cvtype + " and ownerName=" + subId;

             sqlCodes.Add(strSql);
           }

            //get the whole datatable

           return db.GetDataTable(sqlCodes, "custVendor");
           
       }


       public List<string> GetMyTheCustomerVendorNamesOrVendors(int cvtype, int id)
       { 
         List<string> customerVendorNames=new List<string>();
         string strSql = string.Format("select cvname from custVendor where cvtype={0} and ownerName={1}", cvtype, id);
         DataTable dt=db.GetDataTable(strSql,"cvnames");
         foreach(DataRow dr in dt.Rows)
         {
          customerVendorNames.Add(dr["cvname"].ToString());
         }
         return customerVendorNames;
       }

       public Dictionary<string, string> GetContactInfo(int cvtype, int id,string cvname)
       {
           Dictionary<string, string> contactInfo = new Dictionary<string, string>();
           string strSql = string.Format("select contact1,contact2,phone1,phone2,cellphone,fax,email1,email2 from custVendor where cvtype={0} and ownerName={1} and cvname='{2}'",
               cvtype, id, cvname);
           DataTable dt = db.GetDataTable(strSql, "contactInfo");
           if (dt == null || dt.Rows.Count == 0)
               return contactInfo;
           DataRow dr = dt.Rows[0];
           if(dr["contact1"]!=DBNull.Value)
           {
               contactInfo.Add("contact1",dr["contact1"].ToString());
            }
           if(dr["contact2"]!=DBNull.Value)
           {
               contactInfo.Add("contact2",dr["contact2"].ToString());
           }
           if (dr["phone1"] != DBNull.Value)
           {
               contactInfo.Add("phone1", dr["phone1"].ToString());
           }
           if (dr["phone2"] != DBNull.Value)
           {
               contactInfo.Add("phone2", dr["phone2"].ToString());
           }
           if (dr["cellphone"] != DBNull.Value)
           {
               contactInfo.Add("cellphone", dr["cellphone"].ToString());
           }
           if (dr["fax"] != DBNull.Value)
           {
               contactInfo.Add("fax", dr["fax"].ToString());
           }
           if (dr["email1"] != DBNull.Value)
           {
               contactInfo.Add("email1", dr["email1"].ToString());
           }
           if (dr["email2"] != DBNull.Value)
           {
               contactInfo.Add("email2", dr["email2"].ToString());
           }

           return contactInfo;
       
       }


       public DataTable GetTheCompanyNecessaryInfoForFinance()
       {
           string strSql = "select cvtype,cvname,country,cvnumber,ownerName from custVendor";
           return db.GetDataTable(strSql, "custVendorForFinance");
       }
       public bool AssignCompanyNumberByFinance(int cvtype,string cvname,int ownerName,string cvNumber)
       {
           string strSql = string.Format("update custVendor set cvNumber='{0}' where cvtype={1} and cvname='{2}' and ownerName={3}", cvNumber, cvtype, cvname, ownerName);
         if (db.ExecDataBySql(strSql) > 0)
             return true;
           return false;
       }

       public DataTable GetMyCustomerOrVendor(int cvtype, int id)
       {
           string strSql = "select * from custVendor where cvtype=" + cvtype + " and ownerName=" + id;
           return db.GetDataTable(strSql, "custVendor");
       
       }

       public bool ModifyCustomerOrVendor(int cvtype,string previousName,string cvname, string country,string cvnumber, int? rate, string term,
             string contact1, string contact2, string phone1, string phone2, string cellphone, string fax,
            string email1, string email2,int lastUpdateName, DateTime lastUpdateDate, int blacklisted,
            int? amount, string notes,int userId)
       {
           string strSql = "UPDATE custVendor SET cvname='" + cvname + "',country='" + country +"',cvnumber='"+cvnumber+ "',rate=" + (rate.HasValue?rate.ToString():"null") + ",term='" + term + "',contact1='" + contact1 + "',contact2='" +
               contact2 + "',phone1='" + phone1 + "',phone2='" + phone2 + "',cellphone='" + cellphone + "',fax='" + fax + "',email1='" + email1 + "',email2='" + email2 + "',lastUpdateName=" + lastUpdateName +
               ",lastUpdateDate='" + lastUpdateDate.ToString() + "',blackListed=" + blacklisted + ",amount=" + (amount.HasValue?amount.ToString():"null") + ",notes='" + notes + "' WHERE cvtype=" + cvtype + " and cvName='" + previousName+"' and ownerName="+userId;
 
           if (db.ExecDataBySql(strSql) > 0)
               return true;

           return false;
                      
       }

       public bool DeleteCustomerOrVendor(int cvtype, string cvname)
       {
           string strSql = "DELETE from custVendor WHERE cvtype=" + cvtype + " AND cvname='" + cvtype + "'";
           if (db.ExecDataBySql(strSql) > 0)
               return true;
           return false;
       }
 
    }
}
