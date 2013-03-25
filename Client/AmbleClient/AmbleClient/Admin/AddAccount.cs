using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.Admin
{
    public class AddAccount:AccountOperation
    {


        public AddAccount()
        {
           base.Text = "Add an account";
        
        }

        public override void FillTheTextBox()
        {
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            
            
        }

       

        public override void Save()
        {

              accountMgr.AddAnAccount(textBox1.Text.Trim(), maskedTextBox1.Text.Trim(), textBox2.Text.Trim(),
                GetJobIdFromJobName(comboBox1.Text), GetIdFromName(comboBox2.Text));

        }

    }
}
