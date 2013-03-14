using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.SO.SoMgr;

namespace AmbleClient.SO
{
    public partial class BuyerSoView : Form
    {
        private So so;
        
        public BuyerSoView(So so)
        {
            InitializeComponent();
            this.so = so;

        }

        private void BuyerSoView_Load(object sender, EventArgs e)
        {
            this.soViewControl1.FillTheTable(so);
             soViewControl1.tbContact.Text=string.Empty;
             soViewControl1.tbContact.ReadOnly = true;
            
             if (UserInfo.Job == JobDescription.sales)
             {
                 soViewControl1.tbCustomer.Text = string.Empty;
                 soViewControl1.tbCustomer.ReadOnly = true;
             }

             soViewControl1.FreezeAllControls();

        }

        private void tsbEnterPo_Click(object sender, EventArgs e)
        {
            PO.NewPo newPo = new PO.NewPo();
            newPo.ShowDialog();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
