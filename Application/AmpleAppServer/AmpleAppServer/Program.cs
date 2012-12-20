using System;
using System.Collections.Generic;
using AmpleAppServer.DataClass;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;

namespace AmpleAppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //AccountMgr.AccountMgr mgr = new AccountMgr.AccountMgr();
            TcpServerChannel channel = new TcpServerChannel(1111);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AmpleAppServer.AccountMgr.AccountMgr), "AccountMgr", WellKnownObjectMode.SingleCall);
               
            
            Console.ReadLine();
        }
    }
}
