using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using AmpleAppServer.AccountMgr;


namespace AmbleClient
{
    public partial class Login : Form
    {

        AccountMgr mgr;
        PropertyClass accountProperty;
        
        public Login()
        {
            InitializeComponent();
           ChannelServices.RegisterChannel(new TcpClientChannel(),false);
            mgr = (AccountMgr)Activator.GetObject(typeof(AccountMgr),
            "tcp://192.168.1.104:1111/AccountMgr");


        }

        private void Login_Load(object sender, EventArgs e)
        {
            

        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            accountProperty=mgr.CheckNameAndPasswd(textBox1.Text.Trim(), maskedTextBox1.Text.Trim());
            
            if (accountProperty== null)
            {
                MessageBox.Show("Invalid Name or Password");

            }
            else
            {
                MainFrame mainFrame = new MainFrame();
                this.Hide();
                mainFrame.Show();
                             
            
            }
    



        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }
    }
}
