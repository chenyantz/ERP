using System;
using System.Collections.Generic;
using AmbleAppServer.DataClass;
using System.Linq;
using System.Text;
using System.Data;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Collections;
using System.Runtime.Serialization.Formatters;

namespace AmbleAppServer
{
    class Program
    {
        static void Main(string[] args)
        {
            //AccountMgr.AccountMgr mgr = new AccountMgr.AccountMgr();
           BinaryServerFormatterSinkProvider provider = new BinaryServerFormatterSinkProvider();
provider.TypeFilterLevel = TypeFilterLevel.Full;
// Creating the IDictionary to set the port on the channel instance.
IDictionary props = new Hashtable();
props["port"] = 1111;
// Pass the properties for the port setting and the server provider in the server chain argument. (Client remains null here.)
TcpServerChannel channel = new TcpServerChannel(props, provider);


           // TcpServerChannel channel = new TcpServerChannel(1111);
            ChannelServices.RegisterChannel(channel, false);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AmbleAppServer.AccountMgr.AccountMgr), "AccountMgr", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AmbleAppServer.customerVendorMgr.CustomerVendorMgr),"CustomerVendorMgr",WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AmbleAppServer.RfqMgr.RfqMgr),"RfqMgr", WellKnownObjectMode.Singleton);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(AmbleAppServer.OfferMgr.OfferMgr), "OfferMgr", WellKnownObjectMode.Singleton);

            Console.ReadLine();
        }
    }
}
