using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Admin.AccountMgr;


namespace AmbleClient.Admin
{
    public partial class AccountOperation : Form
    {
     
           public  DataTable dt;
          protected AccountMgr.AccountMgr accountMgr;
        
        public AccountOperation()
        {
            InitializeComponent();
            accountMgr = new AccountMgr.AccountMgr();
        
        }


        public void SetDataTable(DataTable dt)
        {
           this.dt = dt;
        }
                
        private void AddModifyAccount_Load(object sender, EventArgs e)
        {
            //set the combox1



            foreach (int jobD in Enum.GetValues(typeof(JobDescription)))
            {
                string strName = Enum.GetName(typeof(JobDescription), jobD);
                comboBox1.Items.Add(strName);

            }
            //set the managerName

            foreach (DataRow dr in dt.Rows)
            {
                int job = int.Parse(dr["job"].ToString());
                if (job == (int)JobDescription.Admin ||
                    job == (int)JobDescription.Boss ||
                    job == (int)JobDescription.PurchasersManager ||
                    job == (int)JobDescription.FinancialManager ||
                    job == (int)JobDescription.SalesManager ||
                    job == (int)JobDescription.LogisticsManager)
                {
                    comboBox2.Items.Add(dr["accountName"]);

                }
                

            }

            FillTheTextBox();

        }


        public virtual void FillTheTextBox()
        { 
        
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //check the integry

            if (String.IsNullOrWhiteSpace(textBox1.Text.Trim()))
            {
                MessageBox.Show("Please input the name");
                textBox1.Focus();
                return;

            }
            if (String.IsNullOrWhiteSpace(maskedTextBox1.Text.Trim()))
            {
                MessageBox.Show("Please input the password");
                maskedTextBox1.Focus();
                return;
            }

            if (accountMgr.IsNameExist(textBox1.Text.Trim()))
            {
                MessageBox.Show(string.Format("The name:{0} already exists!"), textBox1.Text.Trim());
                textBox1.Focus();
                return;

            }


            //Check password is same
            if (maskedTextBox1.Text.Trim() != maskedTextBox2.Text.Trim())
            {
                MessageBox.Show("The Passwords do not match!");
                maskedTextBox1.Focus();
                return;

            }


            if (GetJobIdFromJobName(comboBox1.Text) == (int)JobDescription.Admin)
            {
                MessageBox.Show("You can not add an Admin.");
                comboBox1.Focus();
                return;
            }
           
            Save();
            this.Close();
        }

        public virtual void Save()
        { 
        
        }


        protected int GetJobIdFromJobName(string jobName)
        {
            foreach (int jobD in Enum.GetValues(typeof(JobDescription)))
            {
                string strName = Enum.GetName(typeof(JobDescription), jobD);
                if (strName == jobName)
                {
                    return jobD;
                }

            }
            return -1;
        
        }


        protected int GetIdFromName(string name)
        {
            foreach (DataRow dr in dt.Rows)
            {
                if (dr["accountName"].ToString().Trim() == name)
                {
                    return int.Parse(dr["id"].ToString());

                
                }
              
            }
            return -1;
        
        }






        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
