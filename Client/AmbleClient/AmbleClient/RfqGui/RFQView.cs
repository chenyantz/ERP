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
    public partial class RFQView : Form
    {
        int rfqId;
        public RFQView(int rfqId)
        {
            InitializeComponent();
            this.rfqId = rfqId;
        
        }

        private void RFQView_Load(object sender, EventArgs e)
        {
            Rfq rfq = GlobalRemotingClient.GetRfqMgr().GetRfqAccordingToRfqId(rfqId);
            rfqItems1.FillTheTable(rfq);
            GuiOpAccordingToRfqState((RfqStatesEnum)rfq.rfqStates);
        }

        private void GuiOpAccordingToRfqState(RfqStatesEnum rfqState)
        {
            switch (rfqState)
            { 
                case RfqStatesEnum.New:
                      tsbQuote.Enabled = false;
                      tsbSo.Enabled = false;
                      tsbViewSo.Enabled = false;    
                       break;
                case RfqStatesEnum.Routed:
                       tsbRoute.Enabled = false;
                       tsbQuote.Enabled=false;
                       tsbSo.Enabled = false;
                       tsbViewSo.Enabled = false;
                       break;
                case RfqStatesEnum.Offered:
                       tsbRoute.Enabled = false;
                       tsbSo.Enabled = false;
                       tsbViewSo.Enabled = false;
                       break;
                case RfqStatesEnum.Quoted:
                       tsbRoute.Enabled = false;
                       tsbQuote.Enabled = false;
                       tsbViewSo.Enabled = false;
                       break;
                case RfqStatesEnum.HasSO:
                       tsbRoute.Enabled = false;
                       tsbQuote.Enabled = false;
                       break;
                case RfqStatesEnum.SoApproved:
                       tsbRoute.Enabled = false;
                       tsbQuote.Enabled = false;
                       tsbSo.Enabled = false;
                       break;
                case RfqStatesEnum.Closed:
                       tsbRoute.Enabled = false;
                       tsbQuote.Enabled = false;
                       tsbSo.Enabled = false;
                       tsbCloseRfq.Enabled = false;
                       break;
            }

        }

        private void tsbQuote_Click(object sender, EventArgs e)
        {
            rfqItems1.UpdateInfo();
            GlobalRemotingClient.GetRfqMgr().ChangeRfqState(RfqStatesEnum.Quoted, rfqId);
        }

        private void tsbRoute_Click(object sender, EventArgs e)
        {
            rfqItems1.UpdateInfo();
            GlobalRemotingClient.GetRfqMgr().ChangeRfqState(RfqStatesEnum.Routed, rfqId);
        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            rfqItems1.UpdateInfo();
        }

        private void tsbCopy_Click(object sender, EventArgs e)
        {
            GlobalRemotingClient.GetRfqMgr().CopyRfq(rfqId, UserInfo.UserId);
        }

        private void tsbSo_Click(object sender, EventArgs e)
        {

            SO.NewSo newSo = new SO.NewSo(rfqId);
            newSo.ShowDialog();



        }

        private void tsbViewSo_Click(object sender, EventArgs e)
        {
            SO.SoView soView = new SO.SoView(rfqId);
            soView.ShowDialog();
        }

        private void tsbCloseRfq_Click(object sender, EventArgs e)
        {
            if (rfqItems1.cbCloseReason.SelectedIndex == -1)
            {
                MessageBox.Show("Please Select a Reason for Closing the RFQ");
                rfqItems1.cbCloseReason.Focus();
            }
            else
            {
                rfqItems1.UpdateInfo();
                GlobalRemotingClient.GetRfqMgr().ChangeRfqState(RfqStatesEnum.Closed, rfqId);
            }
            


        }






    }
}
