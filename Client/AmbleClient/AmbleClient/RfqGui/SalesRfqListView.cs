using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AmbleAppServer.RfqMgr;


namespace AmbleClient.RfqGui
{
    public class SalesRfqListView:RFQListView
    {

        public SalesRfqListView()
        {
            cbNew.CheckedChanged -= rfqStatesSelectedChanged;
            cbRouted.CheckedChanged -= rfqStatesSelectedChanged;
            cbQuoted.CheckedChanged -= rfqStatesSelectedChanged;
            cbHasSo.CheckedChanged -= rfqStatesSelectedChanged;
            cbSoApproved.CheckedChanged -= rfqStatesSelectedChanged;
            cbClosed.CheckedChanged -= rfqStatesSelectedChanged;
          
            base.cbNew.Checked = true;
            base.cbRouted.Checked = true;
            base.cbQuoted.Checked = true;
            base.cbHasSo.Checked = true;
            base.cbSoApproved.Checked = true;
            base.cbClosed.Checked = false;

            cbNew.CheckedChanged += rfqStatesSelectedChanged;
            cbRouted.CheckedChanged += rfqStatesSelectedChanged;
            cbQuoted.CheckedChanged += rfqStatesSelectedChanged;
            cbHasSo.CheckedChanged += rfqStatesSelectedChanged;
            cbSoApproved.CheckedChanged += rfqStatesSelectedChanged;
            cbClosed.CheckedChanged += rfqStatesSelectedChanged;

        }

        public override int GetPageCount(int itemsPerPage,string filterColumn, string filterString,List<RfqStatesEnum> selections, bool includeSubs)
        {
           
            if (includeSubs)
            {
                return GlobalRemotingClient.GetRfqMgr().GetThePageCountOfDataTable(itemsPerPage, UserInfo.UserId,filterColumn,filterString);
            }
            else
            { 
              return GlobalRemotingClient.GetRfqMgr().GetThePageCountOfDataTablePerSale(itemsPerPage, UserInfo.UserId,filterColumn,filterString);
            }
        }

        public override System.Data.DataTable GetDataTableAccordingToPageNumber(int itemsPerPage,int currentPage, string filterColumn, string filterString,List<RfqStatesEnum> selections, bool includeSubs)
        {   
            if (includeSubs)
            {
                return  GlobalRemotingClient.GetRfqMgr().GetICanSeeRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, itemsPerPage, filterColumn, filterString);
            }
            else 
            {
                return GlobalRemotingClient.GetRfqMgr().GetMyRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, itemsPerPage, filterColumn, filterString);
            }

        }



    }
}
