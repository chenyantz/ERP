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

        public SoItemView(string title)
        {
            InitializeComponent();
            this.Text = title;
        }

        public SoItems GetSoItems()
        {
            return soItemsControl1.GetSoItem();
        }
        

    }
}
