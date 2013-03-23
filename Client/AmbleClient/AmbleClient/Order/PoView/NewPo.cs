using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.PoMgr;


namespace AmbleClient.Order.PoView
{
    public partial class NewPo : Form
    {
        public NewPo()
        {
            InitializeComponent();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            PoMgr.PoMgr.SavePoMain(poViewControl1.GetValues());
            int poId = PoMgr.PoMgr.GetTheInsertId(UserInfo.UserId);
            PoMgr.PoMgr.UpDatePoItems(poViewControl1.GetPoItemContentAndSate());

        }

    }
}
