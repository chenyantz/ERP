using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.SoMgr;

namespace AmbleClient.SO
{
    public partial class SoItemView : Form
    {
        
        
        public SoItemView()
        {
            InitializeComponent();
        }

        public SoItemView(bool newItems)
        {
            InitializeComponent();
            this.Text = "Add an SO Item";
            this.tsbUpdate.Enabled = false;
            this.soItemsControl1.NewCreateItems();
        }

        public SoItems GetSoItems()
        {
            return soItemsControl1.GetSoItem();
        }

        private void tsbAdd_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        

    }
}
