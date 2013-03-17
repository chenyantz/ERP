using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.SO.SoMgr;

namespace AmbleClient.SO
{
   public class BuyerSoListView:OrderTemplate.OrderListView
    {

        List<So> soList;

        protected override void ViewStart()
        {
            tscbList.Items.Add("List All SO I Can See");
            tscbList.Items.Add("List My Related SO");
            tscbFilterColumn.Items.Add("SalesOrderNo");

            OrderStatesCheckedChanged(null, null);

            //Add columns for datagridView1

            System.Windows.Forms.DataGridViewTextBoxColumn No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            No.Visible = false;
            No.Name = "No";

            System.Windows.Forms.DataGridViewTextBoxColumn Customer = new System.Windows.Forms.DataGridViewTextBoxColumn();
                Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
                Customer.HeaderText = "Customer";
                Customer.Name = "Customer";

            System.Windows.Forms.DataGridViewTextBoxColumn Sp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn SalesOrderNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn OrderDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn CustomerPo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn PaymentTerms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn FreightTerms = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn CustomerAccount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            System.Windows.Forms.DataGridViewTextBoxColumn SoState = new System.Windows.Forms.DataGridViewTextBoxColumn();




            Sp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            Sp.HeaderText = "S/P";
            Sp.Name = "Sp";

            SalesOrderNo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            SalesOrderNo.HeaderText = "Sales Order #";
            SalesOrderNo.Name = "SalesOrderNo";

            OrderDate.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            OrderDate.HeaderText = "Order Date";
            OrderDate.Name = "OrderDate";

            CustomerPo.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            CustomerPo.HeaderText = "Customer Po #";
            CustomerPo.Name = "CustomerPo";

            PaymentTerms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            PaymentTerms.HeaderText = "Payment Terms";
            PaymentTerms.Name = "PaymentTerms";

            FreightTerms.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            FreightTerms.HeaderText = "Freight Terms";
            FreightTerms.Name = "FreightTerms";

            CustomerAccount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            CustomerAccount.HeaderText = "Customer Account";
            CustomerAccount.Name = "CustomerAccount";

            SoState.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            SoState.HeaderText = "So State";
            SoState.Name = "SoState";

          
            if (UserInfo.Job != JobDescription.sales)
            {
                dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            No,
            Customer,
            Sp,
            SalesOrderNo,
            OrderDate,
            CustomerPo,
            PaymentTerms,
            FreightTerms,
            CustomerAccount,
            SoState
              });
            }
            else
            {
                dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            No,
            Sp,
            SalesOrderNo,
            OrderDate,
            CustomerPo,
            PaymentTerms,
            FreightTerms,
            CustomerAccount,
            SoState
              });
            
            }

        }


        protected override void FillTheDataGrid()
        {
            if (tscbList.SelectedIndex < 0) return;

            bool includeSubs = false;
            dataGridView1.Rows.Clear();

            if (tscbList.SelectedIndex == 0)
            {
                includeSubs = true;
            }
            List<int> intStateList = new List<int>();
            foreach (OrderTemplate.OrderState orderState in orderStates)
            {
                intStateList.Add(orderState.GetHashCode());
            }

            soList =AmbleClient.SO.SoMgr.SoMgr.BuyerGetSoAccordingToFilter(UserInfo.UserId, includeSubs, filterColumn, filterString, intStateList);

            int i = 0;
            foreach (So so in soList)
            {
                if (UserInfo.Job == JobDescription.sales)
                {
                    dataGridView1.Rows.Add(i++,idNameDict[so.salesId], so.salesOrderNo, so.orderDate.ToShortDateString(), so.customerPo,
                        so.paymentTerm, so.freightTerm, so.customerAccount, Enum.GetName(typeof(OrderTemplate.OrderState), so.soStates));
                }
                else
                {
                    dataGridView1.Rows.Add(i++,so.customerName, idNameDict[so.salesId], so.salesOrderNo, so.orderDate.ToShortDateString(), so.customerPo,
                          so.paymentTerm, so.freightTerm, so.customerAccount, Enum.GetName(typeof(OrderTemplate.OrderState), so.soStates));
                
                }
            }

        }


        protected override void OpenOrderDetails(int rowIndex)
        {
            if (rowIndex >= soList.Count)
                return;
            int realRowIndex = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells["No"].Value);
            BuyerSoView buyerSoView = new BuyerSoView(soList[realRowIndex]);
            buyerSoView.ShowDialog();

        }




    }
}
