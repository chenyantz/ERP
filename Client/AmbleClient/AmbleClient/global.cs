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


    public class OperatorFile
    {
        [DllImport("kernel32")] //引入“shell32.dll”API文件
        public static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public OperatorFile()
        {

        }

        /// <summary>
        /// 从INI文件中读取指定节点的内容
        /// </summary>
        /// <param name="section">INI节点</param>
        /// <param name="key">节点下的项</param>
        /// <param name="def">没有找到内容时返回的默认值</param>
        /// <param name="filePath">要读取的INI文件</param>
        /// <returns>读取的节点内容</returns>
        public static string GetIniFileString(string section, string key, string def, string filePath)
        {
            StringBuilder temp = new StringBuilder(1024);
            GetPrivateProfileString(section, key, def, temp, 1024, filePath);
            return temp.ToString();
        }
    }


    public static class GlobalRemotingClient
    {

        private static AccountMgr mgr = null;
        private static CustomerVendorMgr cvMgr = null;
        private static RfqMgr rfqMgr = null;
        private static OfferMgr offerMgr = null;
        private static SoMgr soMgr = null;
        private static PoMgr poMgr = null;

        private static string address = OperatorFile.GetIniFileString("Server", "IP", "", Environment.CurrentDirectory + "\\AmbleClient.ini")
            + ":" + OperatorFile.GetIniFileString("Server", "Port", "", Environment.CurrentDirectory + "\\AmbleClient.ini");


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
                  "tcp://"+address+"/CustomerVendorMgr");
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
                  "tcp://" + address + "/RfqMgr");
             
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
                  "tcp://" + address + "/OfferMgr");

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
                  "tcp://" + address + "/SoMgr");

                return soMgr;
            }
            else
            {
                return soMgr;
            }


        }

        public static PoMgr GetPoMgr()
        {
            if (poMgr == null)
            {
                poMgr = (PoMgr)Activator.GetObject(typeof(PoMgr),
                  "tcp://" + address + "/PoMgr");

                return poMgr;
            }
            else
            {
                return poMgr;
            }


        }




    }
}
