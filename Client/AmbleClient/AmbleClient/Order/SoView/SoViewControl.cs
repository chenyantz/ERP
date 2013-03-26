using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.SoMgr;
using AmbleClient.Order;
using AmbleClient.RfqGui.RfqManager;


namespace AmbleClient.SO
{

    public partial class SoViewControl : UserControl
    {
        bool needFreezeItemControl = false;
        List<SoItemsContentAndState> soItemsStateList = new List<SoItemsContentAndState>();
        List<SoItemsContentAndState> deletedList = new List<SoItemsContentAndState>();

        List<int> mySubs;

        public int rfqId;
        private int soId=int.MinValue;
        
        public SoViewControl()
        {
            InitializeComponent();
        }

        private void SoViewControl_Load(object sender, EventArgs e)
        {

        }


        private void ShowDataInDataGridView()
        {
            dataGridView1.Rows.Clear();

          for(int i=0;i<soItemsStateList.Count;i++)
          {
              string strSaleType, strCurrency;
              switch (soItemsStateList[i].soitem.saleType)
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

              strCurrency = Enum.GetName(typeof(AmbleClient.Currency), soItemsStateList[i].soitem.currencyType);


              dataGridView1.Rows.Add(i + 1, strSaleType, soItemsStateList[i].soitem.partNo, soItemsStateList[i].soitem.mfg, soItemsStateList[i].soitem.rohs, soItemsStateList[i].soitem.dc,
                  soItemsStateList[i].soitem.intPartNo, soItemsStateList[i].soitem.shipFrom, soItemsStateList[i].soitem.shipMethod, soItemsStateList[i].soitem.trackingNo, soItemsStateList[i].soitem.qty,
                  soItemsStateList[i].soitem.qtyshipped, strCurrency, soItemsStateList[i].soitem.unitPrice, soItemsStateList[i].soitem.qtyshipped * soItemsStateList[i].soitem.unitPrice, soItemsStateList[i].soitem.dockDate,
                  soItemsStateList[i].soitem.shippedDate);
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

            AmbleClient.Admin.AccountMgr.AccountMgr accMgr = new Admin.AccountMgr.AccountMgr();

            mySubs =accMgr.GetAllSubsId(UserInfo.UserId,UserCombine.GetUserCanBeSales());

            Dictionary<int, string> mySubsIdAndName = accMgr.GetIdsAndNames(mySubs);
            foreach (string name in mySubsIdAndName.Values)
            {
                cbSp.Items.Add(name);
            }
        
        }


        public void FillTheTable(So so)
        {

            this.soId = so.soId;
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




            foreach (SoItems item in SoMgr.GetSoItemsAccordingToSoId(so.soId))
            {
                this.soItemsStateList.Add(
                new SoItemsContentAndState
                {
                    soitem = item,
                    state = OrderItemsState.Normal
                }
                );
            }
            ShowDataInDataGridView();

        }


        public void SoSave()
        {
            if (false == CheckValues())
            { return; }
            So so=GetValues();
            if (!SoMgr.SaveSoMain(so))
            {
                MessageBox.Show("Save Sale Order Error!");
                return;
            }
            int soId = SoMgr.GetTheInsertId(so.salesId);

            foreach(SoItemsContentAndState sics in soItemsStateList)
            {
              sics.soitem.soId=soId;
            }
             SoMgr.UpdatePoItems(soItemsStateList);

                new AmbleClient.RfqGui.RfqManager.RfqMgr().ChangeRfqState(RfqStatesEnum.HasSO, rfqId);

                MessageBox.Show("Save Sale Order Successfully");

        }


        public void SoUpdate()
        {
            if (false == CheckValues())
            { return; }
            So so = GetValues();
            if (!SoMgr.UpdateSoMain(so))
            {
                MessageBox.Show("Update Sale Order Error!");
                return;
            }

            SoMgr.UpdatePoItems(soItemsStateList);

            foreach (SoItemsContentAndState sics in deletedList)
            {
                SoMgr.DeleteSoItembySoItemId(sics.soitem.soItemsId);
            }


            MessageBox.Show("Update Sale Order Successfully");
        }




        private bool CheckValues()
        {
            if (ItemsCheck.CheckTextBoxEmpty(tbCustomer) == false)
            {
                MessageBox.Show("Please input the customer name");
                return false;
            }

            if (ItemsCheck.CheckTextBoxEmpty(tbContact) == false)
            {
                MessageBox.Show("Please input the Contact name");
                return false;
            }

            return true;

        }

        private So GetValues()
        {
           
            return new So
            {
             soId=this.soId,
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

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                SoItemView itemView = new SoItemView(false);
                itemView.FillTheTable(soItemsStateList[e.RowIndex].soitem);

                if (DialogResult.Yes == itemView.ShowDialog())
                {
                    int soId = soItemsStateList[e.RowIndex].soitem.soId;
                    int soItemId = soItemsStateList[e.RowIndex].soitem.soItemsId;
                    soItemsStateList[e.RowIndex].soitem = itemView.GetSoItems();
                    soItemsStateList[e.RowIndex].soitem.soId = soId;
                    soItemsStateList[e.RowIndex].soitem.soItemsId = soItemId;

                    if (soItemsStateList[e.RowIndex].state != OrderItemsState.New)
                    {
                        soItemsStateList[e.RowIndex].state = OrderItemsState.Modified;
                    }
                }

            }


        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            SoItemView soItemView = new SoItemView(true);
            if (soItemView.ShowDialog() == DialogResult.Yes)
            {
                SoItems item = soItemView.GetSoItems();
                var soItemContentAndState = new SoItemsContentAndState();
                soItemContentAndState.soitem = item;
                soItemContentAndState.soitem.soId = this.soId;
                soItemContentAndState.state = OrderItemsState.New;
                soItemsStateList.Add(soItemContentAndState);
                ShowDataInDataGridView();

            }

        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0)
            {
                return;
            }
            if (DialogResult.Yes == MessageBox.Show("Delete the selected SO item ?", "Warning", MessageBoxButtons.YesNo))
            {
                int rowIndex = dataGridView1.SelectedRows[0].Index;
                deletedList.Add(soItemsStateList[rowIndex]);
                soItemsStateList.RemoveAt(rowIndex);
                ShowDataInDataGridView();
            }



        }
    }
  
    
    public class SoItemsContentAndState
    {
      public  SoItems soitem;
      public   OrderItemsState state;
    }
    
}
