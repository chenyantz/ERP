using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows;
using System.Windows.Forms;
using AmbleAppServer.AccountMgr;
using AmbleAppServer.customerVendorMgr;
using AmbleAppServer.RfqMgr;
using AmbleAppServer.OfferMgr;
using AmbleAppServer.SoMgr;
using AmbleAppServer.PoMgr;
using System.Runtime.InteropServices;


namespace AmbleClient

{
   public enum JobDescription
    { Admin=0,Boss=1,Sales=2,SalesManager=3,Purchaser=4,PurchasersManager=5,Logistics=6,LogisticsManager=7,Financial=8,FinancialManager=9
    
    }

    public enum Currency
    {
     USD=0,CNY=1,EUR=2,HK=3,JP=4,ERROR=5
    
    }
          

    public static class UserInfo
    {
        public static int UserId;
        public static string UserName;
        public static JobDescription Job;
    }

    public static class UserCombine
    { 
       public static List<int> GetUserCanBeSales()
        {
            List<int> canBeSales = new List<int>();
            canBeSales.Add((int)JobDescription.Admin);
            canBeSales.Add((int)JobDescription.Boss);
           canBeSales.Add((int)JobDescription.Sales);
           canBeSales.Add((int)JobDescription.SalesManager);
           return canBeSales;
        
        }

       public static List<int> GetUserCanBeBuyers()
       {
           List<int> canBeBuyers = new List<int>();
           canBeBuyers.Add((int)JobDescription.Admin);
           canBeBuyers.Add((int)JobDescription.Boss);
           canBeBuyers.Add((int)JobDescription.Purchaser);
           canBeBuyers.Add((int)JobDescription.PurchasersManager);
           return canBeBuyers;
       }



    
    
    }



    public static class Tool
    {
        public static string Get6DigitalNumberAccordingToId(int id)
        {
            int length = (int)Math.Log10(id) + 1;

            switch (length)
            { 
                case 1:
                    return "00000" + id;
                case 2:
                    return "0000" + id;
                case 3:
                    return "000" + id;
                case 4:
                    return "00" + id;
                case 5:
                    return "0" + id;
                default:
                    return id.ToString();
            }
        }

        public static string GetIdAccordingTo6DigitalNumber(string DigitalId)
        {
         int number=Convert.ToInt32(DigitalId);
         return number.ToString();
        }

    }


    public static class ItemsCheck
    {

        public static bool CheckTextBoxEmpty(TextBox tb)
        {
            if (string.IsNullOrWhiteSpace(tb.Text.Trim()))
            {
                tb.Focus();
                 return false;
            }
            return true;
        }

        public static bool CheckPhoneNumber(string phoneNumber)
        { 
        
        return false;
        }

        public static bool CheckEmail(string email)
        {
            return System.Text.RegularExpressions.Regex.IsMatch(email, @"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$");   

        }

        public static bool CheckIntNumber(string intNumber)
        {
            int tempvalue;

            return int.TryParse(intNumber,out tempvalue);

        }
     
        public static bool CheckFloatNumber(string floatNumber)
        {
            float tempvalue;
            return float.TryParse(floatNumber, out tempvalue);
           
        }
            
    
    }


}
