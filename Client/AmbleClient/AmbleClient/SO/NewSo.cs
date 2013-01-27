using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.SO
{
    public partial class NewSo : Form
    {
        public int rfqId;

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
            this.soViewControl1.SoSave();
            if (UserInfo.UserId == soViewControl1.GetAssignedSaleID())
            {
                GlobalRemotingClient.GetRfqMgr().AddRfqHistory(rfqId, UserInfo.UserId, "Created an SO");
            }
            else
            { 
              GlobalRemotingClient.GetRfqMgr().AddRfqHistory(rfqId,UserInfo.UserId,"Created an SO for "+GlobalRemotingClient.GetAccountMgr().GetNameById(soViewControl1.GetAssignedSaleID()));
            
            }
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
