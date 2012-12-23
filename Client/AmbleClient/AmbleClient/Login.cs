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
using AmbleAppServer.AccountMgr;


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
            try
            {
                accountProperty = mgr.CheckNameAndPasswd(textBox1.Text.Trim(), maskedTextBox1.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not connect to the server");
            
            }

            if (accountProperty== null)
            {
                MessageBox.Show("Invalid Name or Password");

            }
            else
            {
                MainFrame mainFrame = new MainFrame();
                mainFrame.SetProperty(this.accountProperty);
                this.Hide();
                mainFrame.Show();
                             
            
            }
    



        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        //enter enter
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                maskedTextBox1.Focus();
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                BtnLogin_Click(sender, e);
            }
        }

        



    }
}
