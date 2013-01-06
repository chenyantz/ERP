using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.RfqMgr;

namespace AmbleClient.Sales
{
    public partial class RFQView : Form
    {
        private int itemsPerPage=3;
        private DataTable tableCurrentPage;
        private string filterColumn = string.Empty;
        private string filterString = string.Empty;
        private Dictionary<int,string> idToName=new Dictionary<int,string>();
        
        
        
        public RFQView()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void RFQView_Load(object sender, EventArgs e)
        {
            FillTheIdNameDict();
            FillTheDataGridView();
        }


        private void FillTheIdNameDict()
        {
         DataTable dt=GlobalRemotingClient.GetAccountMgr().ReturnWholeAccountTable();
            foreach(DataRow dr in dt.Rows)
            {
               idToName.Add(Convert.ToInt32(dr["id"]),dr["accountName"].ToString());
            
            }
        }




        private void FillTheDataGridView()
        {
            int pages = GlobalRemotingClient.GetRfqMgr().GetThePageCountOfDataTable(this.itemsPerPage, UserInfo.UserId, this.filterColumn, this.filterString);
            tableCurrentPage = GlobalRemotingClient.GetRfqMgr().GetICanSeeRfqDataTableAccordingToPageNumber(UserInfo.UserId, Convert.ToInt32(bindingNavigatorPositionItem.Text.Trim()),this.itemsPerPage);
            BindTheDataToDataGridView();
        }

        private void BindTheDataToDataGridView()
        {
            if (this.tableCurrentPage == null)
               return;
            dataGridView1.Rows.Clear();





            foreach(DataRow dr in tableCurrentPage.Rows)
            {
                dataGridView1.Rows.Add
                    (dr["partNo"].ToString(),
                     dr["mfg"].ToString(),
                     dr["dc"].ToString(),
                     dr["qty"].ToString(),
                     dr["resale"].ToString(),
                     dr["cost"].ToString(),
                     dr["customerName"].ToString(),
                     dr["rfqDate"].ToString(),
                     dr["salesId"]==DBNull.Value? null:idToName[Convert.ToInt32(dr["salesId"])],
                     dr["rfqState"].ToString(),
                     (dr["rohs"]==DBNull.Value|| Convert.ToInt32(dr["rohs"])==0)? 0:1,
                     dr["alt"].ToString()
                    );

             }
           
        }

        private void bindingNavigatorMovePreviousItem_Click(object sender, EventArgs e)
        {

        }

        private void bindingNavigatorMoveFirstItem_Click(object sender, EventArgs e)
        {

        }
        private void bindingNavigatorMoveNextItem_Click(object sender, EventArgs e)
        {

        }
        private void bindingNavigatorMoveLastItem_Click(object sender, EventArgs e)
        {

        }






  }
}
