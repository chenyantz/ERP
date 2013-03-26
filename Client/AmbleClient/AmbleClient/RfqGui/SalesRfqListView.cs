using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleClient.RfqGui.RfqManager;


namespace AmbleClient.RfqGui
{
    public class SalesRfqListView:RFQListView
    {

        public SalesRfqListView()
        {
            base.tscbAllOrMine.Items.Add("List All RFQ I Can See");
            base.tscbAllOrMine.Items.Add("Only List My RFQ");
            tscbAllOrMine.SelectedIndexChanged -= tscbAllOrMine_SelectedIndexChanged;
            tscbAllOrMine.SelectedIndex = 0;
            tscbAllOrMine.SelectedIndexChanged += tscbAllOrMine_SelectedIndexChanged;


            base.cbNew.Checked = true;
            base.cbRouted.Checked = true;
            base.cbOffered.Checked = true;
            base.cbQuoted.Checked = true;
            base.cbHasSo.Checked = true;
            base.cbClosed.Checked = false;

            base.cbNew.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbRouted.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbOffered.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbQuoted.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbHasSo.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbClosed.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);

            base.rfqStatesSelectedChanged(this, null);

        }

        public override int GetPageCount(int itemsPerPage,string filterColumn, string filterString,List<RfqStatesEnum> selections, bool includeSubs)
        {
           
            if (includeSubs)
            {
                return rfqMgr.GetThePageCountOfDataTable(itemsPerPage, UserInfo.UserId,filterColumn,filterString,selections);
            }
            else
            { 
              return rfqMgr.GetThePageCountOfDataTablePerSale(itemsPerPage, UserInfo.UserId,filterColumn,filterString,selections);
            }
        }

        public override System.Data.DataTable GetDataTableAccordingToPageNumber(int itemsPerPage,int currentPage, string filterColumn, string filterString,List<RfqStatesEnum> selections, bool includeSubs)
        {   
            if (includeSubs)
            {
                return  rfqMgr.GetICanSeeRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, itemsPerPage, filterColumn, filterString,selections);
            }
            else 
            {
                return rfqMgr.GetMyRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, itemsPerPage, filterColumn, filterString,selections);
            }

        }


        public override void CellDoubleClickShow(int rfqId)
        {
            RFQView rfqView = new RFQView(rfqId);
            rfqView.ShowDialog();

        }


    }
}
