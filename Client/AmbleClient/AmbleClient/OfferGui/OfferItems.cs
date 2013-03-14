using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.OfferGui.OfferMgr;

namespace AmbleClient.OfferGui
{
    public partial class OfferItems : UserControl
    {

        protected OfferMgr.OfferMgr offerMgr;
        public OfferItems()
        {
            InitializeComponent();
            offerMgr = new OfferMgr.OfferMgr();
        }

        private void tbMfg_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbPrice_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
