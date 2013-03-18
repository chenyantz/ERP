using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.Order
{
    abstract public partial class OrderListView : Form
    {

        protected string filterColumn=string.Empty;
        protected string filterString=string.Empty;

        protected Dictionary<int, string> idNameDict;
        protected List<int> intStateList = new List<int>();

        
        
        public OrderListView()
        {
            InitializeComponent();
        }

        private void OrderListView_Load(object sender, EventArgs e)
        {

            ViewStart();

            tscbList.SelectedIndexChanged -= tscbList_SelectedIndexChanged;
            tscbList.SelectedIndex = 0;
            tscbList.SelectedIndexChanged += tscbList_SelectedIndexChanged;

            FillTheIdNameDict();

            FillTheStateCombox();
            GetTheStateList();

            FillTheDataGrid();

            
        }

        private void FillTheIdNameDict()
        {
            idNameDict = new AmbleClient.Admin.AccountMgr.AccountMgr().GetIdsAndNames(new AmbleClient.Admin.AccountMgr.AccountMgr().GetAllSubsId(UserInfo.UserId));
   
        }

        protected virtual void FillTheStateCombox()
        { 
        
        }

        protected virtual void GetTheStateList()
        { 
        }

        protected virtual void ViewStart()
        { 
         //add items in comboBox and Datagridview
        
        }

        protected virtual void FillTheDataGrid()
        { 
        
        }


        protected void OrderStatesCheckedChanged(object sender, EventArgs e)
        {

            FillTheDataGrid();


        }

        private void tscbList_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillTheDataGrid();

        }

        private void tsbApply_Click(object sender, EventArgs e)
        {
            if (this.tscbFilterColumn.SelectedIndex != -1)
            {
                this.filterColumn = tscbFilterColumn.SelectedItem.ToString();
            }
            else
            {
                this.filterColumn = string.Empty;
            }
            this.filterString = tstbFilterString.Text.Trim();
            FillTheDataGrid();
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            this.filterColumn = string.Empty;
            this.filterString = string.Empty;
            FillTheDataGrid();
        }

        protected virtual void OpenOrderDetails(int rowIndex)
        { 
        
        }



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                OpenOrderDetails(e.RowIndex);
            }

            


        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            FillTheDataGrid();
        }

        private void OrderListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                FillTheDataGrid();
            }


        }

        private void tscbListState_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.StateChanged(sender, e);
        }

        protected virtual void StateChanged(object sender, EventArgs e)
        { 
        
        
        }




    }
}
