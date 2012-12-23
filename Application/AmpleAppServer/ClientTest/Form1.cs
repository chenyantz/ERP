using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using AmbleAppServer.AccountMgr;


namespace ClientTest
{
    public partial class Form1 : Form
    {

        AccountMgr mgr;
        public Form1()
        {
            InitializeComponent();
            ChannelServices.RegisterChannel(new TcpClientChannel(),false);

             mgr = (AccountMgr)Activator.GetObject(typeof(AccountMgr),
            "tcp://192.168.1.104:1111/AccountMgr");

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
           DataSet ds= mgr.ReturnDataSet();
          

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }
    }
}
