using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.Order.SoMgr;

namespace AmbleClient.Order
{
   public class SalesSoListView:SoListView
    {



       protected override void ViewStart()
       {
           this.Text = "SO List for Sales";
           tscbList.Items.Add("List All SO I Can See");
           tscbList.Items.Add("List My SO");

           //Add columns for datagridView1
         System.Windows.Forms.DataGridViewTextBoxColumn No = new System.Windows.Forms.DataGridViewTextBoxColumn(); 
         System.Windows.Forms.DataGridViewTextBoxColumn Customer=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn Contact=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn Sp=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn SalesOrderNo=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn OrderDate=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn CustomerPo=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn PaymentTerms=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn FreightTerms=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn CustomerAccount=new System.Windows.Forms.DataGridViewTextBoxColumn();
         System.Windows.Forms.DataGridViewTextBoxColumn SoState = new System.Windows.Forms.DataGridViewTextBoxColumn();

         No.Name = "No";
         No.Visible = false;

         Customer.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         Customer.HeaderText = "Customer";
         Customer.Name = "Customer";

         Contact.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
         Contact.HeaderText = "Contact";
         Contact.Name = "Contact";

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

         dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            No,
            Customer,
            Contact,
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



       protected override void FillTheDataGrid()
       {
           if (tscbList.SelectedIndex < 0) return;

          bool includeSubs=false;
          dataGridView1.Rows.Clear();

          if (tscbList.SelectedIndex == 0)
          {
              includeSubs = true;
          }

          soList = SoMgr.SoMgr.SalesGetSoAccordingTofilter(UserInfo.UserId, includeSubs, filterColumn, filterString, intStateList);

           int i = 0;
           foreach(So so in soList)
           {
               dataGridView1.Rows.Add(i++,so.customerName, so.contact,idNameDict[so.salesId], so.salesOrderNo, so.orderDate.ToShortDateString(), so.customerPo,
                   so.paymentTerm, so.freightTerm, so.customerAccount,soStateList.GetSoStateStringAccordingToValue(so.soStates));
           }

       }






    }
}
