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
           


            base.tsbNewRfq.Enabled = false;
            base.tscbAllOrMine.Enabled = true;
            base.tscbAllOrMine.Items.Add("List All RFQ");
            base.tscbAllOrMine.Items.Add("List RFQ which PA is me");


            tscbAllOrMine.SelectedIndexChanged -= tscbAllOrMine_SelectedIndexChanged;
            tscbAllOrMine.SelectedIndex = 0;
            tscbAllOrMine.SelectedIndexChanged += tscbAllOrMine_SelectedIndexChanged;
            
            base.cbNew.Checked = false;
            base.cbRouted.Checked = true;
            base.cbOffered.Checked = true;
            base.cbQuoted.Checked = false;
            base.cbHasSo.Checked = false;
            base.cbClosed.Checked = false;

            base.cbNew.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbRouted.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbOffered.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbQuoted.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbHasSo.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.cbClosed.CheckedChanged += new System.EventHandler(base.rfqStatesSelectedChanged);
            base.rfqStatesSelectedChanged(this, null);
        }

      public override int GetPageCount(int itemsPerPage, string filterColumn, string filterString,List<RfqStatesEnum> selections,bool includeSubs)
      {
          if (includeSubs)
          {
              return rfqMgr.BMGetThePageCountOfDataTable(itemsPerPage, filterColumn, filterString, selections);
          }
          else
          {
              return rfqMgr.BuyerGetThePageCountOfDataTable(UserInfo.UserId, itemsPerPage, filterColumn, filterString, selections);
          }
      }
      public override DataTable GetDataTableAccordingToPageNumber(int itemsPerPage, int currentPage, string filterColumn, string filterString, List<RfqStatesEnum> selections, bool includeSubs)
      {
          if (includeSubs)
          {
              return rfqMgr.BMGetRfqDataTableAccordingToPageNumber(currentPage, itemsPerPage, filterColumn, filterString, selections);
          }
          else
          {
              return rfqMgr.BuyerGetRfqDataTableAccordingToPageNumber(UserInfo.UserId, currentPage, itemsPerPage, filterColumn, filterString, selections);
          }

      }
      public override void CellDoubleClickShow(int rfqId)
      {
          BuyerManagerRfqView rfqView = new BuyerManagerRfqView(rfqId);
          rfqView.ShowDialog();
      }



        
    }
}
