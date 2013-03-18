using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.SoMgr;
using AmbleClient.RfqGui.RfqManager;


namespace AmbleClient.SO
{
    public partial class SoViewControl : UserControl
    {

        bool needFreezeItemControl = false;
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


        private void ShowDataInDataGridView()
        { 
          for(int i=0;i<soItemsList.Count;i++)
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

        public void FreezeAllControls()
        {
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is Label)
                    continue;
                else if (ctrl is DataGridView)
                {
                    ((DataGridView)ctrl).ReadOnly = true;
                }
                else
                {
                    ctrl.Enabled = false;
                }
            }
            needFreezeItemControl = true;
        
        }

        public int GetAssignedSaleID()
        {
            return mySubs[cbSp.SelectedIndex];
        }


        public void NewSOFill()
        {
            FillTheSalesComboBox();
            cbSp.SelectedIndex = 0;
        }

        private void FillTheSalesComboBox()
        {
            mySubs =new AmbleClient.Admin.AccountMgr.AccountMgr().GetAllSubsId(UserInfo.UserId);

            Dictionary<int, string> mySubsIdAndName = new AmbleClient.Admin.AccountMgr.AccountMgr().GetIdsAndNames(mySubs);
            foreach (string name in mySubsIdAndName.Values)
            {
                cbSp.Items.Add(name);
            }
        
        }


        public void FillTheTable(So so)
        {
            tbCustomer.Text = so.customerName;
            tbContact.Text = so.contact;
            tbSalesOrder.Text = so.salesOrderNo;
            if (so.approverId != null)
            {
                tbApprover.Text = new AmbleClient.Admin.AccountMgr.AccountMgr().GetNameById(so.approverId.Value);
            }
            if (so.approveDate != null)
            {
                tbApproveDate.Text = so.approveDate.Value.ToShortDateString();
            }
             dateTimePicker1.Value = so.orderDate;
            tbCustomerPo.Text = so.customerPo;
            tbPaymentTerm.Text = so.paymentTerm;
            tbFreightTerm.Text = so.freightTerm;
            tbCustomerAccount.Text = so.customerAccount;
            tbSpecialInstructions.Text = so.specialInstructions;
            tbBillto.Text = so.billTo;
            tbShipTo.Text = so.shipTo;
            //Fill the sales ID
            FillTheSalesComboBox();

            cbSp.SelectedIndex = mySubs.IndexOf(so.salesId);

            foreach (SoItems item in so.items)
            {
                this.soItemsList.Add(item);            
            }
            ShowDataInDataGridView();

        }


        public void SoSave()
        {
            CheckValues();
            So so=GetValues();
            if (!SoMgr.SaveSoMain(so))
            {
                MessageBox.Show("Save Sale Order Error!");
                return;
            }
            int soId = SoMgr.GetTheInsertId(so.salesId);
            if (!SoMgr.SaveSoItems(soId, so.items))
            {
                MessageBox.Show("Save Sale Order Items Error!");

            }
            else
            {
                new AmbleClient.RfqGui.RfqManager.RfqMgr().ChangeRfqState(RfqStatesEnum.HasSO, rfqId);

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
            billTo=tbBillto.Text.Trim(),
            shipTo=tbShipTo.Text.Trim(),
            rfqId = this.rfqId
           };

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                SoItemView itemView = new SoItemView(false);
                itemView.FillTheTable(soItemsList[e.RowIndex]);

                if (needFreezeItemControl)
                {
                    itemView.FreeTheSoItems();
                }
                itemView.ShowDialog();

            }


        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            SoItemView soItemView = new SoItemView(true);
            if (soItemView.ShowDialog() == DialogResult.Yes)
            {
                soItemsList.Add(soItemView.GetSoItems());
                ShowDataInDataGridView();
            }

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows[0].Index >= 0)
            {
                soItemsList.RemoveAt(dataGridView1.SelectedRows[0].Index);
                ShowDataInDataGridView();
            
            }
        }
    }
}
