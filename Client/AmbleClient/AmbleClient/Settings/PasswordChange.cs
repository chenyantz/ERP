using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.Settings
{
    public partial class PasswordChange : Form
    {
        public PasswordChange()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (maskedTextBox1.Text.Trim() == maskedTextBox2.Text.Trim())
            {
                MessageBox.Show("Two passwords do not match");
                maskedTextBox1.Focus();
                return;
            }
            GlobalRemotingClient.GetAccountMgr().ChangePasswd(UserInfo.UserId, maskedTextBox1.Text.Trim());
        }
    }
}
