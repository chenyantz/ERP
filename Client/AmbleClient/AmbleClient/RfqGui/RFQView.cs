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
            GuiOpAccordingToRfqState(rfq.rfqStates);
        }

        private void GuiOpAccordingToRfqState(int rfqState)
        {
           
            if (rfqState == 0)//new rfq
            {
               tsbQuote.Enabled = false;
               tsbSo.Enabled = false;
               tsbViewSo.Enabled = false;
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






    }
}
