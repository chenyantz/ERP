using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Admin.AccountMgr;



namespace AmbleClient
{
    public partial class Login : Form
    {
        AccountMgr accountMgr;


        PropertyClass accountProperty;
        
        public Login()
        {
            accountMgr = new AccountMgr();
            InitializeComponent();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            

        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                accountProperty =accountMgr.CheckNameAndPasswd(textBox1.Text.Trim(), maskedTextBox1.Text.Trim());

            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not connect to the server.Please contact the admin");
                return;
            
            }

            if (accountProperty== null)
            {
                MessageBox.Show("Invalid Name or Password");

            }
            else
            {
                UserInfo.UserId = accountProperty.UserId;
                UserInfo.UserName = accountProperty.AccountName;
                UserInfo.Job = (JobDescription)accountProperty.Job;

                MainFrame mainFrame = new MainFrame();
                this.Hide();
                mainFrame.WindowState = FormWindowState.Maximized;
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
