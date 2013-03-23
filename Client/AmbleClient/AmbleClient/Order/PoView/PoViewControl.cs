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

        public PoViewControl()
        {
            InitializeComponent();
          

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void PoViewControl_Load(object sender, EventArgs e)
        {
            FillThePACombo();
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
            CheckValues();
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
            CheckValues();
            po poMain = GetValues();
            PoMgr.PoMgr.UpdatePo(poMain);

            PoMgr.PoMgr.UpDatePoItems(poItemsStateList);

            MessageBox.Show("Update Purchase Order Successfully");
        }

        private void CheckValues()
        { 
        
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
               
              PoMgr.PoMgr.DeletePoItembyPoItemId(poItemsStateList[rowIndex].poItem.PoItemsId);
              poItemsStateList.RemoveAt(rowIndex);
              
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
 