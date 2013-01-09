using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.Sales
{
    public partial class NewRfq : Form
    {
        public NewRfq()
        {
            InitializeComponent();
        }

        private void NewRfq_Load(object sender, EventArgs e)
        {
            rfqItems1.NewRfqFill();
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (rfqItems1.SaveInfo())
            {
                MessageBox.Show("The RFQ has been saved successfully");
            
            }
            rfqItems1.NewRfqFill();


        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
