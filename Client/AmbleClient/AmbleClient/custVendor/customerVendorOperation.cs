using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.custVendor
{
    public partial class customerVendorOperation : Form
    {
       protected int customerOrVendor;
         public customerVendorOperation()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void customerVendorOperation_Load(object sender, EventArgs e)
        {

            FillTheTextboxs();

        }

        protected virtual void FillTheTextboxs()
        { 
        
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Save();
            this.Close();

            
        }
        protected virtual void Save()
        { 
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}
