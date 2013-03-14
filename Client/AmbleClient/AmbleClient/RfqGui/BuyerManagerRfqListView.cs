using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmbleClient.RfqGui.RfqManager;

namespace AmbleClient.RfqGui
{
    public class BuyerManagerRfqListView:RFQListView
    {
        public BuyerManagerRfqListView()
        {
            //Freeze only list my RFQ
            base.tsbNewRfq.Enabled = false;
            base.tscbAllOrMine.Enabled = false;
            
            
            cbNew.CheckedChanged -= rfqStatesSelectedChanged;
            cbRouted.CheckedChanged -= rfqStatesSelectedChanged;
            cbOffered.CheckedChanged -= rfqStatesSelectedChanged;
            cbQuoted.CheckedChanged -= rfqStatesSelectedChanged;
            cbHasSo.CheckedChanged -= rfqStatesSelectedChanged;
            cbClosed.CheckedChanged -= rfqStatesSelectedChanged;

            base.cbNew.Checked = false;
            base.cbRouted.Checked = true;
            base.cbOffered.Checked = true;
            base.cbQuoted.Checked = false;
            base.cbHasSo.Checked = false;
            base.cbClosed.Checked = false;

            cbNew.CheckedChanged += rfqStatesSelectedChanged;
            cbRouted.CheckedChanged += rfqStatesSelectedChanged;
            cbOffered.CheckedChanged += rfqStatesSelectedChanged;
            cbQuoted.CheckedChanged += rfqStatesSelectedChanged;
            cbHasSo.CheckedChanged += rfqStatesSelectedChanged;
            cbClosed.CheckedChanged += rfqStatesSelectedChanged;
        }

      public override int GetPageCount(int itemsPerPage, string filterColumn, string filterString,List<RfqStatesEnum> selections,bool includeSubs)
      {
          return rfqMgr.BMGetThePageCountOfDataTable(itemsPerPage, filterColumn, filterString, selections);
  
      }
      public override DataTable GetDataTableAccordingToPageNumber(int itemsPerPage, int currentPage, string filterColumn, string filterString, List<RfqStatesEnum> selections, bool includeSubs)
      {
          return rfqMgr.BMGetRfqDataTableAccordingToPageNumber(currentPage, itemsPerPage, filterColumn, filterString, selections);
      }
      public override void CellDoubleClickShow(int rfqId)
      {
          BuyerManagerRfqView rfqView = new BuyerManagerRfqView(rfqId);
          rfqView.ShowDialog();
      }



        
    }
}
