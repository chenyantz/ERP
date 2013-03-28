using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using log4net;

namespace AmbleClient.SO
{
    public partial class NewSo : Form
    {
        public int rfqId;

        ILog logger = LogManager.GetLogger(typeof(NewSo));

        public NewSo()
        {
            InitializeComponent();
        }


        public NewSo(int rfqId)
        {
            InitializeComponent();
            this.rfqId = rfqId;
        }

        public void FillCustomerAndContact(string customer,string contact)
        {
         this.soViewControl1.tbCustomer.Text=customer;
         this.soViewControl1.tbContact.Text=contact;
        
        
        }



        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.soViewControl1.rfqId = this.rfqId;
            try
            {
                this.soViewControl1.SoSave();
            }
            catch (Exception ex)
            {
                logger.Error(ex.StackTrace);
                MessageBox.Show("Save So Error");
                return;
            }
            
            AmbleClient.RfqGui.RfqManager.RfqMgr rfqMgr = new RfqGui.RfqManager.RfqMgr();
            if (UserInfo.UserId == soViewControl1.GetAssignedSaleID())
            {
                rfqMgr.AddRfqHistory(rfqId, UserInfo.UserId, "Created an SO");
            }
            else
            { 
              rfqMgr.AddRfqHistory(rfqId,UserInfo.UserId,"Created an SO for "+new AmbleClient.Admin.AccountMgr.AccountMgr().GetNameById(soViewControl1.GetAssignedSaleID()));
            
            }
            this.Close();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void NewSo_Load(object sender, EventArgs e)
        {
            this.soViewControl1.NewSOFill();
        }







    }
}
