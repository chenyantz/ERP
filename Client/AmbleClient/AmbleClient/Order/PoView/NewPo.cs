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

        int soId;
        
        public NewPo()
        {
            InitializeComponent();
        }

        public NewPo(int soId)
        {
            this.soId = soId;
            InitializeComponent();
        
        }


        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            po poMain = poViewControl1.GetValues();
            poMain.soId = this.soId;
            poMain.poStates =(sbyte) new PoNew().GetStateValue();
            poMain.poDate = DateTime.Now;
            PoMgr.PoMgr.SavePoMain(poMain);
            int poId = PoMgr.PoMgr.GetTheInsertId(UserInfo.UserId);
            List<PoItemContentAndState> items = poViewControl1.GetPoItemContentAndSate();
            foreach (PoItemContentAndState pics in items)
            {
                pics.poItem.poId = poId;
            
            }
            PoMgr.PoMgr.UpDatePoItems(items);
            this.Close();

        }

    }
}
