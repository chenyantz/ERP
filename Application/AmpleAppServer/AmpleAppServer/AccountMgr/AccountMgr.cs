using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels;
using MySql.Data.MySqlClient;




namespace AmbleAppServer.AccountMgr
{
    public class AccountMgr:System.MarshalByRefObject
    {
        DataClass.DataBase db = new DataClass.DataBase();
        MySqlDataReader sdr=null;


        public AccountMgr()
        {
          
        }


       //when check name and password, get the user's information
       public PropertyClass CheckNameAndPasswd(string name,string password)
       {
           PropertyClass accountClass=null;


       string strSql="select * from account where accountName='"+name.Trim()+"' and accountPassword='"+password.Trim()+"'";
        try{
           sdr=db.GetDataReader(strSql);
            sdr.Read();
            if(sdr.HasRows)
            {
            accountClass=new PropertyClass();
            accountClass.UserId=(int)sdr["id"];
            accountClass.AccountName=name.Trim();
            accountClass.AccountPassword=password.Trim();
            accountClass.Email=sdr["email"].ToString();
            accountClass.Job=(int)sdr["job"];
            accountClass.Superviser=(int)sdr["superviser"];
            }
        }
           catch(Exception ex)
        {
           
          }
        finally
        {
            sdr.Close();
        }
          return accountClass; 
      
       }

       public bool IsNameExist(string name)
       {
       string strSql="select * from account where accountName='"+name.Trim()+"'";
           try{
               sdr=db.GetDataReader(strSql);
               sdr.Read();
               if(sdr.HasRows)
               {
                 sdr.Close();
                return true;
               }
               else
               {
               sdr.Close();
               return false;
               }
            
           }
           catch(Exception e)
           {
           
           }
           finally
           {
           sdr.Close();
           }
           return true;
       }
       
  
        public DataSet ReturnDataSet()
        {

           return db.GetDataSet("select * from account", "test");
        
      
        }
       public DataTable ReturnWholeAccountTable()
       {
           return db.GetDataTable("select * from account", "AccountTable");
       
       }

       public bool AddAnAccount(string accountName,string password,string email,int job,int superviser)
       {
           string strSql = "INSERT INTO account(accountName,accountPassword,email,job,superviser)VALUES('" + accountName + "','" + password+ "','" +
               email + "'," + job + "," + superviser + ")";
           if (db.ExecDataBySql(strSql) > 0)
               return true;
                    
           return false;
       }
       public bool ModifyAnAccount(int id,string accountName,string password,string email,int job,int superviser)
       {
           string strSql = "UPDATE account SET accountName='" + accountName + "',accountPassword='" + password + "',email='" + email + "',job="
               + job + ",superviser=" + superviser + "   WHERE id="+id;
           if (db.ExecDataBySql(strSql) > 0)
               return true;
           return false;

       }

       public List<int> GetAllSubsId(int id)
       {
               
           
           List<int> allSubsId = new List<int>();
           allSubsId.Add(id);
           int numberOfSubs = allSubsId.Count; int newAddedIds = 0;

           for (int startIndex = 0;numberOfSubs>startIndex;)
           { 
              string strSql = "select id from account where superviser=" +allSubsId[startIndex];
              DataTable dt = db.GetDataTable(strSql,"idTable");
           if (dt.Rows.Count > 0)
           {
               foreach (DataRow dr in dt.Rows)
               {
                   int subId = int.Parse(dr["id"].ToString());
                   if (!allSubsId.Contains(subId))
                   {
                       allSubsId.Add(subId);
                       newAddedIds++;

                   }
                   
               }
           
           }
         numberOfSubs = allSubsId.Count;
         startIndex = numberOfSubs - newAddedIds + 1;
        }

           return allSubsId;           
       
       }



    }
}
;

