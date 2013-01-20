using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.SO
{
    public partial class NewSo : Form
    {
        public int rfqId;

        public NewSo()
        {
            InitializeComponent();
        }


        public NewSo(int rfqId)
        {
            InitializeComponent();
            this.rfqId = rfqId;
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.soViewControl1.rfqId = this.rfqId;
            this.soViewControl1.SoSave();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void NewSo_Load(object sender, EventArgs e)
        {
            this.soViewControl1.NewSOFill();
        }







    }
}
