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
    { admin=0,boss=1,sales=2,saleManager=3,buyer=4,buyerManager=5,warehousekeeper=6,wareshousekeeperManager=7,financial=8,financialManager=9
    
    }

    public static class UserInfo
    {
        public static int UserId;
        public static string UserName;
        public static JobDescription Job;
    
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
