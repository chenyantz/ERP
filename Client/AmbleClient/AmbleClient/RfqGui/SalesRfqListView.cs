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
            cbNew.CheckedChanged -= rfqStatesSelectedChanged;
            cbRouted.CheckedChanged -= rfqStatesSelectedChanged;
            cbOffered.CheckedChanged -= rfqStatesSelectedChanged;
            cbQuoted.CheckedChanged -= rfqStatesSelectedChanged;
            cbHasSo.CheckedChanged -= rfqStatesSelectedChanged;
            cbClosed.CheckedChanged -= rfqStatesSelectedChanged;
          
            base.cbNew.Checked = true;
            base.cbRouted.Checked = true;
            base.cbOffered.Checked = true;
            base.cbQuoted.Checked = true;
            base.cbHasSo.Checked = true;
            base.cbClosed.Checked = false;

            cbNew.CheckedChanged += rfqStatesSelectedChanged;
            cbRouted.CheckedChanged += rfqStatesSelectedChanged;
            cbOffered.CheckedChanged += rfqStatesSelectedChanged;
            cbQuoted.CheckedChanged += rfqStatesSelectedChanged;
            cbHasSo.CheckedChanged += rfqStatesSelectedChanged;
            cbClosed.CheckedChanged += rfqStatesSelectedChanged;

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
