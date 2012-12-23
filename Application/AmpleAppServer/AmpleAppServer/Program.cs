using System;
using System.Collections.Generic;
using AmbleAppServer.DataClass;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace AmbleAppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //AccountMgr.AccountMgr mgr = new AccountMgr.AccountMgr();
            TcpServerChannel channel = new TcpServerChannel(1111);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AmbleAppServer.AccountMgr.AccountMgr), "AccountMgr", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AmbleAppServer.customerVendorMgr.CustomerVendorMgr),"CustomerVendorMgr",WellKnownObjectMode.Singleton);


            Console.ReadLine();
        }
    }
}
