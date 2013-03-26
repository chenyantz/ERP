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
    public partial class PoItemsView : Form
    {
        bool isNewAdd;

        public PoItemsView(bool isNewAdd)
        {
            InitializeComponent();
            this.isNewAdd = isNewAdd;
            if (isNewAdd)
            {
                tscbOp.Text = @"Add&Close";
                this.Text = "Add a PO Item";

            }
            else
            {
                tscbOp.Text = @"Update&Close";
                this.Text = "PO Item View";
            }

        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tscbOp_Click(object sender, EventArgs e)
        {
           
            
            
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        public poitems GetPoItem()
        {
            return this.poItemsControl1.GetPoItem();
        }

        public void FillTheTable(poitems poItem)
        {
            poItemsControl1.FillTheItems(poItem);
        
        }



    }
}
