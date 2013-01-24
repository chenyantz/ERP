using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.RfqMgr;

namespace AmbleClient.RfqGui
{
    public partial class RFQListView : Form
    {
        int itemsPerPage=30;
        DataTable tableCurrentPage;
        string filterColumn = string.Empty;
        string filterString = string.Empty;
        Dictionary<int,string> idToName=new Dictionary<int,string>();
        int currentPage=0;
        int totalPage=0;

        List<RfqStatesEnum> rfqStatesSelected = new List<RfqStatesEnum>();
        
        
        
        public RFQListView()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void RFQView_Load(object sender, EventArgs e)
        {
            tscbAllOrMine.SelectedIndexChanged -= tscbAllOrMine_SelectedIndexChanged;
            tscbAllOrMine.SelectedIndex = 0;
            tscbAllOrMine.SelectedIndexChanged += tscbAllOrMine_SelectedIndexChanged;
            FillTheIdNameDict();
            GetRfqStatesSelected();
            CountPageAndShowDataGridView();
        }


        private void FillTheIdNameDict()
        {
         DataTable dt=GlobalRemotingClient.GetAccountMgr().ReturnWholeAccountTable();
            foreach(DataRow dr in dt.Rows)
            {
               idToName.Add(Convert.ToInt32(dr["id"]),dr["accountName"].ToString());
            
            }
        }

        public virtual int GetPageCount(int itemsPerPage, string filterColumn, string filterString,List<RfqStatesEnum> selections,bool includeSubs)
        {


            return 0;
        }

        public virtual DataTable GetDataTableAccordingToPageNumber(int itemsPerPage, int currentPage, string filterColumn, string filterString,List<RfqStatesEnum> selections, bool includeSubs)
        {

            return null;
        }
            

        private void CountPageAndShowDataGridView()
        {
            if (tscbAllOrMine.SelectedIndex == 0)
            {
                //totalPage = GlobalRemotingClient.GetRfqMgr().GetThePageCountOfDataTable(this.itemsPerPage, UserInfo.UserId, this.filterColumn, this.filterString);
                totalPage = GetPageCount(this.itemsPerPage, this.filterColumn, this.filterString,rfqStatesSelected,true);

            
            }
            else if (tscbAllOrMine.SelectedIndex == 1)
            {
               // totalPage = GlobalRemotingClient.GetRfqMgr().GetThePageCountOfDataTablePerSale(this.itemsPerPage, UserInfo.UserId, this.filterColumn, this.filterString);
                totalPage = GetPageCount(this.itemsPerPage, this.filterColumn, this.filterString,rfqStatesSelected,false);
            
            }
            tslCount.Text = "/ {"+totalPage+"}";
            tstbCurrentPage.Text = "0";

            if (totalPage == 0)
            {
                dataGridView1.Rows.Clear();
            }
            else
            {
                BindTheDataToDataGridView();
            }
        }

        private void BindTheDataToDataGridView()
        {
            dataGridView1.Rows.Clear();
           
            if (tscbAllOrMine.SelectedIndex == 0)
            {
                //tableCurrentPage = GlobalRemotingClient.GetRfqMgr().GetICanSeeRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, this.itemsPerPage, filterColumn, filterString);
                tableCurrentPage = GetDataTableAccordingToPageNumber(itemsPerPage, currentPage, filterColumn, filterString,rfqStatesSelected,true);
            }
            else if (tscbAllOrMine.SelectedIndex == 1)
            {
               // tableCurrentPage = GlobalRemotingClient.GetRfqMgr().GetMyRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, this.itemsPerPage, filterColumn, filterString);
                tableCurrentPage = GetDataTableAccordingToPageNumber(itemsPerPage, currentPage, filterColumn, filterString,rfqStatesSelected,false);
            }
            else
            { 
              //for further use
                return;
            }
            if (tableCurrentPage == null)
                return;

            foreach(DataRow dr in tableCurrentPage.Rows)
            {
                  dataGridView1.Rows.Add
                    (
                    dr["partNo"].ToString(),
                     dr["mfg"].ToString(),
                     dr["dc"].ToString(),
                     dr["qty"].ToString(),
                     dr["resale"].ToString(),
                     dr["cost"].ToString(),
                     dr["customerName"].ToString(),
                    // DateTime.Parse(dr["rfqDate"].ToString()).ToShortDateString(),
                     Convert.ToDateTime(dr["rfqDate"]).ToShortDateString(),
                    dr["salesId"]==DBNull.Value? null:idToName[Convert.ToInt32(dr["salesId"])],
                     //dr["rfqStates"].ToString(),
                      Enum.GetName(typeof(RfqStatesEnum),Convert.ToInt32(dr["rfqStates"])),
                     (dr["rohs"]==DBNull.Value|| Convert.ToInt32(dr["rohs"])==0)? 0:1,
                     dr["alt"].ToString(),
                    dr["firstPA"] == DBNull.Value ? null : idToName[Convert.ToInt32(dr["firstPA"])],
                    dr["secondPA"] == DBNull.Value ? null : idToName[Convert.ToInt32(dr["secondPA"])]
                    );

             }
           
        }


        private void tslCount_Click(object sender, EventArgs e)
        {

        }

        private void tsbMoveNext_Click(object sender, EventArgs e)
        {
            if (currentPage < totalPage - 1)
            {
                currentPage++;
                tstbCurrentPage.Text = currentPage.ToString();
                BindTheDataToDataGridView();
            }
        }

        private void tsbMovePre_Click(object sender, EventArgs e)
        {
            if (currentPage > 0)
            {
                currentPage--;
                tstbCurrentPage.Text = currentPage.ToString();
                BindTheDataToDataGridView();
            }
        }

        private void tsbMoveFirst_Click(object sender, EventArgs e)
        {
            if (currentPage == 0)
                return;
            currentPage = 0;
            tstbCurrentPage.Text = "0";
            BindTheDataToDataGridView();
        }

        private void tsbMoveLast_Click(object sender, EventArgs e)
        {
            if (currentPage == totalPage - 1)
                return;
            currentPage = totalPage - 1;
            tstbCurrentPage.Text = (totalPage - 1).ToString();
            BindTheDataToDataGridView(); 
        }

        private void tsbClear_Click(object sender, EventArgs e)
        {
            filterColumn = string.Empty;
            filterString = string.Empty;
            toolStripTextBox1.Text = "";
            toolStripComboBox1.SelectedIndex = -1;

            CountPageAndShowDataGridView();
        }

        private void tsbApply_Click(object sender, EventArgs e)
        {
            if (toolStripComboBox1.SelectedIndex == 0)
                filterColumn = "partNo";
            if (toolStripComboBox1.SelectedIndex == 1)
                filterColumn = "customerName";
            if (string.IsNullOrWhiteSpace(toolStripComboBox1.Text.Trim()))
            { return; }
            filterString = toolStripTextBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(filterString))
            { return; }

            CountPageAndShowDataGridView();


        }

        private void tscbAllOrMine_SelectedIndexChanged(object sender, EventArgs e)
        {
            CountPageAndShowDataGridView();


        }

        private void tsbSet_Click(object sender, EventArgs e)
        {
            if (int.TryParse(toolStripTextBox2.Text.Trim(), out itemsPerPage) == false)
            {
                itemsPerPage = 30;
                return;
            }
            else
            {
                currentPage = 0;
                CountPageAndShowDataGridView();
            }



        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            NewRfq newrfq = new NewRfq();
            newrfq.ShowDialog();

        }



        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;
            //get the rfqId, the primary key
            DataRow dr = tableCurrentPage.Rows[rowIndex];
            int rfqId = Convert.ToInt32(dr["rfqNo"]);

            CellDoubleClickShow(rfqId);
           // RFQView rfqView = new RFQView(rfqId);
           // rfqView.ShowDialog();
        }

        public virtual void CellDoubleClickShow(int rfqId)
        { 
        
        
        }




        private void tscbAllOrMine_Click(object sender, EventArgs e)
        {

        }

        protected void rfqStatesSelectedChanged(object sender, EventArgs e)
        {
            GetRfqStatesSelected();
            CountPageAndShowDataGridView();

        }
        private void GetRfqStatesSelected()
        {
            rfqStatesSelected.Clear();
            if (cbNew.Checked)
                rfqStatesSelected.Add(RfqStatesEnum.New);
            if (cbRouted.Checked)
                rfqStatesSelected.Add(RfqStatesEnum.Routed);
            if (cbOffered.Checked)
                rfqStatesSelected.Add(RfqStatesEnum.Offered);
            if (cbQuoted.Checked)
                rfqStatesSelected.Add(RfqStatesEnum.Quoted);
            if (cbHasSo.Checked)
                rfqStatesSelected.Add(RfqStatesEnum.HasSO);
            if (cbSoApproved.Checked)
                rfqStatesSelected.Add(RfqStatesEnum.SoApproved);
            if (cbClosed.Checked)
                rfqStatesSelected.Add(RfqStatesEnum.Closed);
        
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            CountPageAndShowDataGridView();
        }


        private void RFQListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5)
            {
                CountPageAndShowDataGridView();
            }
        }
  }
}
