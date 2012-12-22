using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmpleAppServer.AccountMgr;


namespace AmbleClient.Admin
{
    public partial class AccountOperation : Form
    {
     
      public  AccountMgr mgr;
      public  DataTable dt;
      
        
        public AccountOperation()
        {
            InitializeComponent();
        
        }


        public void SetAccountMgr(AccountMgr mgr,DataTable dt)
        {
            this.mgr = mgr;
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
                if (job == (int)JobDescription.admin ||
                    job == (int)JobDescription.boss ||
                    job == (int)JobDescription.buyerManager ||
                    job == (int)JobDescription.financialManager ||
                    job == (int)JobDescription.saleManager ||
                    job == (int)JobDescription.wareshousekeeperManager)
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
                       
            //Check password is same
            if (maskedTextBox1.Text.Trim() != maskedTextBox2.Text.Trim())
            {
                MessageBox.Show("Not same password!");
            
            }
            //check the integry

            if (textBox1.Text.Trim() == null)
            {
                MessageBox.Show("Please input the name");
            
            }
            if (maskedTextBox1.Text.Trim() == null)
            {
                MessageBox.Show("Please input the password");
            
            }

            Save();
            this.Close();
            //check if the name exist;

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
