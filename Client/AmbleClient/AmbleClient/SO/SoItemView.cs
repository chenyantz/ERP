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
    public partial class SoItemView : Form
    {
        
        
        public SoItemView()
        {
            InitializeComponent();
        }

        public SoItemView(bool newItems)
        {
            InitializeComponent();
            if (newItems)
            {
                this.Text = "Add an SO Item";
                this.tsbUpdate.Enabled = false;
                this.soItemsControl1.NewCreateItems();
            }
            else
            {
                this.Text = "So Item View";
           
            }

        
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

        public void FillTheTable(SoItems item)
        {
            this.soItemsControl1.FillItems(item);
        
        }

        public void FreeTheSoItems()
        {
            this.soItemsControl1.FreezeAllControls();
        }

        private void SoItemView_Load(object sender, EventArgs e)
        {

        }



    }
}
