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

       public bool AddCustomerOrVendor(int cvtype, string cvname, string country, int? rate, string term,
             string contact1, string contact2, string phone1, string phone2, string cellphone, string fax,
            string email1, string email2, int ownerName, int lastUpdateName, DateTime lastUpdateDate, int blacklisted,
            int? amount, string notes)
       {

           string strSql="";

           if (rate.HasValue && amount.HasValue)
           {
               strSql = "INSERT INTO custVendor VALUES(" + cvtype + ",'" + cvname + "','" + country + "'," + rate + ",'" + term + "','" + contact1 + "','" +
                   contact2 + "','" + phone1 + "','" + phone2 + "','" + cellphone + "','" + fax + "','" + email1 + "','" + email2 + "'," + ownerName + "," + lastUpdateName +
                   ",'" + lastUpdateDate.ToString() + "'," + blacklisted + "," + amount + ",'" + notes + "')";
           }
           else if (rate.HasValue)
           {
               strSql = "INSERT INTO custVendor(cvtype,cvname,country,rate,term,contact1,contact2,phone1,phone2,cellphone,fax,email1,email2,ownerName,lastUpdateName,lastUpdateDate,blacklisted,notes) VALUES(" 
                      + cvtype + ",'" + cvname + "','" + country + "'," + rate + ",'" + term + "','" + contact1 + "','" +
                      contact2 + "','" + phone1 + "','" + phone2 + "','" + cellphone + "','" + fax + "','" + email1 + "','" + email2 + "'," + ownerName + "," + lastUpdateName +
                      ",'" + lastUpdateDate.ToString() + "'," + blacklisted + ",'" + notes + "')";
           }
           else if (amount.HasValue)
           {
               strSql = "INSERT INTO custVendor(cvtype,cvname,country,term,contact1,contact2,phone1,phone2,cellphone,fax,email1,email2,ownerName,lastUpdateName,lastUpdateDate,blacklisted,amount,notes) VALUES("
                   + cvtype + ",'" + cvname + "','" + country + "','" + term + "','" + contact1 + "','" +
                      contact2 + "','" + phone1 + "','" + phone2 + "','" + cellphone + "','" + fax + "','" + email1 + "','" + email2 + "'," + ownerName + "," + lastUpdateName +
                      ",'" + lastUpdateDate.ToString() + "'," + blacklisted + "," + amount + ",'" + notes + "')";

           }
           else
           {
               strSql = "INSERT INTO custVendor(cvtype,cvname,country,term,contact1,contact2,phone1,phone2,cellphone,fax,email1,email2,ownerName,lastUpdateName,lastUpdateDate,blacklisted,notes) VALUES("
                       + cvtype + ",'" + cvname + "','" + country + "','" + term + "','" + contact1 + "','" +
                          contact2 + "','" + phone1 + "','" + phone2 + "','" + cellphone + "','" + fax + "','" + email1 + "','" + email2 + "'," + ownerName + "," + lastUpdateName +
                          ",'" + lastUpdateDate.ToString() + "'," + blacklisted + ",'" + notes + "')";

           
           }

          if( db.ExecDataBySql(strSql)>0)
              return  true;

           return false;

       }
       public bool IsCvtypeandCvNameExist(int cvtype, string cvName)
       {
           string strSql = "select * from custVendor WHERE cvtype=" + cvtype + " AND cvname='" + cvtype + "'";
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

       public DataTable GetMyCustomerOrVendor(int cvtype, int id)
       {
           string strSql = "select * from custVendor where cvtype=" + cvtype + " and ownerName=" + id;
           return db.GetDataTable(strSql, "custVendor");
       
       }




       public bool ModifyCustomerOrVendor(int cvtype,string previousName,string cvname, string country, int? rate, string term,
             string contact1, string contact2, string phone1, string phone2, string cellphone, string fax,
            string email1, string email2, int ownerName, int lastUpdateName, DateTime lastUpdateDate, int blacklisted,
            int? amount, string notes)
       {
           string strSql = "UPDATE custVendor SET cvname='" + cvname + "',country='" + country + "',rate=" + rate + ",term='" + term + "',contact1='" + contact1 + "',contact2'" +
               contact2 + "',phone1='" + phone1 + "',phone2='" + phone2 + "',cellphone='" + cellphone + "',fax='" + fax + "',email='" + email1 + "',email2='" + email2 + "',ownerName=" + ownerName + ",lastUpdateName=" + lastUpdateName +
               ",lastUpdateDate='" + lastUpdateDate.ToString() + "',blackListed=" + blacklisted + ",amount=" + amount + ",notes='" + notes + " WHERE cvtype=" + cvname + " and cvName=" + previousName;
 
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


     //  public Datatable 











    }
}
