using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using AmbleClient.RfqGui.RfqManager;

namespace AmbleClient.RfqGui
{
    public class BuyerRfqListView:RFQListView
    {
        public BuyerRfqListView()
        {
            base.tsbNewRfq.Enabled = false;
            base.tscbAllOrMine.Enabled = false;

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
            base.rfqStatesSelectedChanged(this, null);//to fill the datagrid

            //in the list ,do not show the customer
            Customer.Visible = false;


        }

        public override int GetPageCount(int itemsPerPage, string filterColumn, string filterString, List<RfqStatesEnum> selections, bool includeSubs)
        {
            return rfqMgr.BuyerGetThePageCountOfDataTable(UserInfo.UserId, itemsPerPage, filterColumn, filterString, selections);

        }
        public override DataTable GetDataTableAccordingToPageNumber(int itemsPerPage, int currentPage, string filterColumn, string filterString, List<RfqStatesEnum> selections, bool includeSubs)
        {
            return rfqMgr.BuyerGetRfqDataTableAccordingToPageNumber(UserInfo.UserId,currentPage, itemsPerPage, filterColumn, filterString, selections);
        }
        public override void CellDoubleClickShow(int rfqId)
        {
            BuyerRfqView rfqView = new BuyerRfqView(rfqId);
            rfqView.ShowDialog();
        }


    }
}
