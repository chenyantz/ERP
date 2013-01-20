using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.SoMgr;

namespace AmbleClient.SO
{
    public partial class SoViewControl : UserControl
    {
        List<SoItems> soItemsList = new List<SoItems>();
        
        List<int> mySubs;

        public int rfqId;
        
        public SoViewControl()
        {
            InitializeComponent();
        }

        private void SoViewControl_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SoItemView soItemView = new SoItemView("Add an SO Item");
            soItemView.ShowDialog();
            soItemsList.Add(soItemView.GetSoItems());
            ShowDataInDataGridView();  
        }


        private void ShowDataInDataGridView()
        { 
          for(int i=0;i<=soItemsList.Count;i++)
          {
              string strSaleType, strCurrency;
              switch (soItemsList[i].saleType)
              { 
                  case 0:
                      strSaleType = "OEM EXCESS";
                      break;
                  case 1:
                      strSaleType = "OWN STOCK";
                      break;
                  case 2:
                      strSaleType = "OTHERS";
                      break;
                  default:
                      strSaleType = "ERROR";
                      break;
              
              }

              switch (soItemsList[i].currencyType)
              { 
                  case 0:
                      strCurrency = "USD";
                      break;
                  case 1:
                      strCurrency = "CNY";break;
                  case 2:
                      strCurrency = "EUR";break;
                  case 3:
                      strCurrency = "HK";break;
                  case 4:
                      strCurrency = "JP";break;
                  default:
                      strCurrency = "ERROR";break;
            
              }

              dataGridView1.Rows.Add(i + 1, strSaleType, soItemsList[i].partNo, soItemsList[i].mfg, soItemsList[i].rohs, soItemsList[i].dc,
                  soItemsList[i].intPartNo, soItemsList[i].shipFrom, soItemsList[i].shipMethod, soItemsList[i].trackingNo, soItemsList[i].qty,
                  soItemsList[i].qtyshipped, strCurrency, soItemsList[i].unitPrice, soItemsList[i].qtyshipped * soItemsList[i].unitPrice, soItemsList[i].dockDate,
                  soItemsList[i].shippedDate);
          }

     
        }





        public void NewSOFill()
        {
            mySubs = GlobalRemotingClient.GetAccountMgr().GetAllSubsId(UserInfo.UserId);

            Dictionary<int, string> mySubsIdAndName = GlobalRemotingClient.GetAccountMgr().GetIdsAndNames(mySubs);
            foreach (string name in mySubsIdAndName.Values)
            {
                cbSp.Items.Add(name);
            }
            cbSp.SelectedIndex = 0;
        }

        public void SoViewFill(So so)
        { 
        
        }


        public void SoSave()
        {
            CheckValues();
            So so=GetValues();
            if (!GlobalRemotingClient.GetSoMgr().SaveSoMain(so))
            {
                MessageBox.Show("Save Sale Order Error!");
                return;
            }
            int soId = GlobalRemotingClient.GetSoMgr().GetTheInsertId(so.salesId);
            if (!GlobalRemotingClient.GetSoMgr().SaveSoItems(soId, so.items))
            {
                MessageBox.Show("Save Sale Order Items Error!");

            }
            else
            {
                MessageBox.Show("Save Sale Order Successfully");
            
            }

        }

        private void CheckValues()
        { 
        
        }

        private So GetValues()
        {
            return new So
            {
            items = soItemsList,
            customerName = tbCustomer.Text.Trim(),
            contact = tbContact.Text.Trim(),
            salesId = mySubs[cbSp.SelectedIndex],
            salesOrderNo = tbSalesOrder.Text.Trim(),
            orderDate = dateTimePicker1.Value.Date,
            customerPo = tbCustomerPo.Text.Trim(),
            paymentTerm = tbPaymentTerm.Text.Trim(),
            freightTerm = tbFreightTerm.Text.Trim(),
            customerAccount = tbCustomerAccount.Text.Trim(),
            specialInstructions = tbSpecialInstructions.Text.Trim(),
            rfqId = this.rfqId
           };

        }


    }
}
