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



    public static class GlobalRemotingClient
    {

        private static AccountMgr mgr = null;
        private static CustomerVendorMgr cvMgr = null;
        private static RfqMgr rfqMgr = null;
        private static OfferMgr offerMgr = null;
        private static SoMgr soMgr = null;

        public static AccountMgr GetAccountMgr()
        {
            if (mgr == null)
            {
                ChannelServices.RegisterChannel(new TcpClientChannel(), false);
                mgr = (AccountMgr)Activator.GetObject(typeof(AccountMgr),
               "tcp://localhost:1111/AccountMgr");
                return mgr;
            }
            else
            {
                return mgr;
            }

        }

        public static CustomerVendorMgr GetCustomerVendorMgr()
        {
            if (cvMgr == null)
            {
                cvMgr = (CustomerVendorMgr)Activator.GetObject(typeof(CustomerVendorMgr),
                  "tcp://localhost:1111/CustomerVendorMgr");
                return cvMgr;
            }
            else
            {
                return cvMgr;
            }


        }

        public static RfqMgr GetRfqMgr()
        {
            if (rfqMgr == null)
            {
                rfqMgr = (RfqMgr)Activator.GetObject(typeof(RfqMgr),
                  "tcp://localhost:1111/RfqMgr");
             
                return rfqMgr;
            }
            else
            {
                return rfqMgr;
            }

        }

        public static OfferMgr GetOfferMgr()
        {
            if (offerMgr == null)
            {
                offerMgr = (OfferMgr)Activator.GetObject(typeof(OfferMgr),
                  "tcp://localhost:1111/OfferMgr");

                return offerMgr;
            }
            else
            {
                return offerMgr;
            }
        
        
        }

        public static SoMgr GetSoMgr()
        {
            if (soMgr == null)
            {
                soMgr = (SoMgr)Activator.GetObject(typeof(SoMgr),
                  "tcp://localhost:1111/SoMgr");

                return soMgr;
            }
            else
            {
                return soMgr;
            }


        }




    }
}
