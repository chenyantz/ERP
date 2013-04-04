using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.PoMgr;

namespace AmbleClient.Order.PoView
{

    public partial class PoViewControl : UserControl
    {

      private  List<int> mysubs;
      private  Dictionary<int, string> buyerIdsAndNames;
      private int poId = int.MinValue;

        List<PoItemContentAndState> poItemsStateList = new List<PoItemContentAndState>();
        List<PoItemContentAndState> deletedList = new List<PoItemContentAndState>();


        public PoViewControl()
        {
            InitializeComponent();
            FillThePACombo();

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void PoViewControl_Load(object sender, EventArgs e)
        {
          
        }


        public List<PoItemContentAndState> GetPoItemContentAndSate()
        {
            return poItemsStateList;
        }


        private void FillThePACombo()
        {
          
            AmbleClient.Admin.AccountMgr.AccountMgr accountMgr = new Admin.AccountMgr.AccountMgr();
            mysubs = accountMgr.GetAllSubsId(UserInfo.UserId, UserCombine.GetUserCanBeBuyers());

            buyerIdsAndNames=accountMgr.GetIdsAndNames(mysubs);

            foreach (string buyerName in buyerIdsAndNames.Values)
            {
                cbPa.Items.Add(buyerName);
            
            }
        }


        public void PoSave()
        {
            if (false == CheckValues())
            {
                return;
            }
            po poMain = GetValues();
            poMain.poDate = DateTime.Now;
            PoMgr.PoMgr.SavePoMain(poMain);

            int poId = PoMgr.PoMgr.GetTheInsertId((int)poMain.pa);

            foreach (PoItemContentAndState pics in poItemsStateList)
            {
                pics.poItem.poId = poId;
            }
            PoMgr.PoMgr.UpDatePoItems(poItemsStateList);

            MessageBox.Show("Save Purchase Order Successfully");

        }


        public void PoUpdate()
        {
            if (false == CheckValues())
            {
                return;
            }
            po poMain = GetValues();
            PoMgr.PoMgr.UpdatePo(poMain);

            PoMgr.PoMgr.UpDatePoItems(poItemsStateList);

            foreach (PoItemContentAndState pics in deletedList)
            {
                PoMgr.PoMgr.DeletePoItembyPoItemId(pics.poItem.PoItemsId);
            }


            MessageBox.Show("Update Purchase Order Successfully");
        }

        private bool CheckValues()
        {
            if (ItemsCheck.CheckTextBoxEmpty(tbVendor) == false)
            {
                MessageBox.Show("Please input the Vendor name");
                return false;
            }
            if (ItemsCheck.CheckTextBoxEmpty(tbContact) == false)
            {
                MessageBox.Show("Please input the Contact name");
                return false;
            }
            return true;
        }

  


        public void FillTheTable(po poMain)
        {
            this.poId = poMain.poId;
            tbVendor.Text = poMain.vendorName;
            tbContact.Text = poMain.contact;
            cbPa.SelectedItem = buyerIdsAndNames[poMain.pa.Value]; 
                   
            tbVendorNumber.Text = poMain.vendorNumber;
            tbPoDate.Text = poMain.poDate.Value.ToShortDateString();
            tbPoNo.Text = poMain.poNo;
            tbFreight.Text = poMain.freight;
            tbShipMethod.Text = poMain.shipMethod;
            tbPaymentTerms.Text = poMain.paymentTerms;
            tbShipToLocation.Text = poMain.shipToLocation;
            tbBillTo.Text = poMain.billTo;
            tbShipTo.Text = poMain.shipTo;

            foreach (poitems itemDb in PoMgr.PoMgr.GetPoItemsAccordingToPoId(poMain.poId))
            {
                poItemsStateList.Add(new PoItemContentAndState
                {
                    poItem = itemDb,
                    state = OrderItemsState.Normal

                }
                );
            
            }

            FillTheDataGridPoItems();


        }

        public void FillTheDataGridPoItems()
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (PoItemContentAndState cSitem in poItemsStateList)
            {
                dataGridView1.Rows.Add(i, cSitem.poItem.partNo, cSitem.poItem.mfg, cSitem.poItem.dc, cSitem.poItem.vendorIntPartNo, cSitem.poItem.org, cSitem.poItem.qty,
                                       cSitem.poItem.qtyRecd, cSitem.poItem.qtyCorrected, cSitem.poItem.qtyAccept, cSitem.poItem.qtyRejected, cSitem.poItem.qtyRTV, cSitem.poItem.qcPending,
                                       Enum.GetName(typeof(AmbleClient.Currency), cSitem.poItem.currency), cSitem.poItem.unitPrice, cSitem.poItem.qty * cSitem.poItem.currency, cSitem.poItem.stepCode, "Unknown");
                i++;
            }
        
        
        }
        
        public po GetValues()
        {
            return new po
            {
                poId=this.poId,
                vendorName = tbVendor.Text.Trim(),
                contact = tbContact.Text.Trim(),
                pa = (short)mysubs[cbPa.SelectedIndex],
                vendorNumber=tbVendorNumber.Text.Trim(),
                //poDate=DateTime.Now, //update时不可写入
                poNo=tbPoNo.Text.Trim(),
                freight=tbFreight.Text.Trim(),
                shipMethod=tbShipMethod.Text.Trim(),
                paymentTerms=tbPaymentTerms.Text.Trim(),
                shipToLocation=tbShipToLocation.Text.Trim(),
                billTo=tbBillTo.Text.Trim(),
                shipTo=tbShipTo.Text.Trim()
            };
        }


       private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {

                PoItemsView itemView = new PoItemsView(false);
                itemView.FillTheTable(poItemsStateList[e.RowIndex].poItem);

                if (DialogResult.Yes == itemView.ShowDialog())
                {
                    int poId = poItemsStateList[e.RowIndex].poItem.poId.Value;
                    int poItemId = poItemsStateList[e.RowIndex].poItem.PoItemsId;
                    
                    poItemsStateList[e.RowIndex].poItem = itemView.GetPoItem();
                    poItemsStateList[e.RowIndex].poItem.poId=poId;
                    poItemsStateList[e.RowIndex].poItem.PoItemsId = poItemId;

                    if(poItemsStateList[e.RowIndex].state!=OrderItemsState.New)
                    {
                    poItemsStateList[e.RowIndex].state = OrderItemsState.Modified;
                    }
                    FillTheDataGridPoItems();
                }
            }
        }

       private void btAdd_Click(object sender, EventArgs e)
       {
           PoItemsView itemView = new PoItemsView(true);
           if (itemView.ShowDialog() == DialogResult.Yes)
           {
               poitems item = itemView.GetPoItem();
               var poItemContentAndState = new PoItemContentAndState();
               poItemContentAndState.poItem = item;
               poItemContentAndState.poItem.poId = this.poId;
               poItemContentAndState.state = OrderItemsState.New;
               poItemsStateList.Add(poItemContentAndState);

               FillTheDataGridPoItems();

           }
       }

       private void btDelete_Click(object sender, EventArgs e)
       {
           if (dataGridView1.SelectedRows.Count == 0)
           {
              return;
           }
          if( DialogResult.Yes==MessageBox.Show("Delete the selected PO item ?","Warning",MessageBoxButtons.YesNo))
          {
              int rowIndex=dataGridView1.SelectedRows[0].Index;

              deletedList.Add(poItemsStateList[rowIndex]);
              poItemsStateList.RemoveAt(rowIndex);
              
              FillTheDataGridPoItems();
            
          }


       }

       private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
       {

       }

       private void btSplit_Click(object sender, EventArgs e)
       {
           if (dataGridView1.SelectedRows.Count == 0)
           {
               return;
           }
           int rowIndex = dataGridView1.SelectedRows[0].Index;
           int qty = poItemsStateList[rowIndex].poItem.qty.Value;

           ItemSplit itemSplit = new ItemSplit(qty);
           if (DialogResult.OK == itemSplit.ShowDialog())
           {
               //get the first value;
               int firstValue = itemSplit.GetFirstQty();
               poItemsStateList[rowIndex].poItem.qty = firstValue;
               poItemsStateList[rowIndex].state = OrderItemsState.Modified;
               //set the second one

               var poItemContentAndState = new PoItemContentAndState();
               //can not be cloned,just assign the value;
               poItemContentAndState.poItem = new poitems();
               poItemContentAndState.poItem.currency = poItemsStateList[rowIndex].poItem.currency;
               poItemContentAndState.poItem.dc = poItemsStateList[rowIndex].poItem.dc;
               poItemContentAndState.poItem.dueDate = poItemsStateList[rowIndex].poItem.dueDate;
               poItemContentAndState.poItem.mfg = poItemsStateList[rowIndex].poItem.mfg;
               poItemContentAndState.poItem.noteToVendor = poItemsStateList[rowIndex].poItem.noteToVendor;
               poItemContentAndState.poItem.org = poItemsStateList[rowIndex].poItem.org;
               poItemContentAndState.poItem.partNo = poItemsStateList[rowIndex].poItem.partNo;
               poItemContentAndState.poItem.qcPending = poItemsStateList[rowIndex].poItem.qcPending;
               poItemContentAndState.poItem.qtyAccept=poItemsStateList[rowIndex].poItem.qtyAccept;
               poItemContentAndState.poItem.qtyCorrected = poItemsStateList[rowIndex].poItem.qtyCorrected;
               poItemContentAndState.poItem.qtyRecd = poItemsStateList[rowIndex].poItem.qtyRecd;
               poItemContentAndState.poItem.qtyRejected = poItemsStateList[rowIndex].poItem.qtyRejected;
               poItemContentAndState.poItem.qtyRTV = poItemsStateList[rowIndex].poItem.qtyRTV;
               poItemContentAndState.poItem.receiveDate = poItemsStateList[rowIndex].poItem.receiveDate;
               poItemContentAndState.poItem.salesAgent = poItemsStateList[rowIndex].poItem.salesAgent;
               poItemContentAndState.poItem.stepCode = poItemsStateList[rowIndex].poItem.stepCode;
               poItemContentAndState.poItem.unitPrice = poItemsStateList[rowIndex].poItem.unitPrice;
               poItemContentAndState.poItem.vendorIntPartNo = poItemsStateList[rowIndex].poItem.vendorIntPartNo;
                             
               poItemContentAndState.poItem.poId = this.poId;
               poItemContentAndState.poItem.qty = qty - firstValue;
               poItemContentAndState.state = OrderItemsState.New;
               poItemsStateList.Insert(rowIndex + 1, poItemContentAndState);
               FillTheDataGridPoItems();
           }




       }
    }

    public class PoItemContentAndState
    {
        public poitems poItem;
        public OrderItemsState state;

    }

}
 