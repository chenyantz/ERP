using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.custVendor.customerVendorMgr;

namespace AmbleClient.custVendor
{
    public partial class customerVendorOperation : Form
    {
         protected int customerOrVendor;
         protected CustomerVendorMgr customerVendorMgr;
         public customerVendorOperation()
        {
            InitializeComponent();
            customerVendorMgr = new CustomerVendorMgr();
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

        private bool ValidateValues()
        {

            //check if rating and amout are numbers.
            if (string.IsNullOrWhiteSpace(tbName.Text.Trim()))
            {
                MessageBox.Show("The compnay name can not be empty");
                tbName.Focus();
                return false;
            }


            int temp;
            if (!(string.IsNullOrWhiteSpace(tbRating.Text.Trim())))
            {
                if (!int.TryParse(tbRating.Text.Trim(), out temp))
                {
                    // tbRating.Focus();
                    MessageBox.Show("Please input a number for the rating,not more than 100");
                    tbRating.Focus();
                    return false;
                }
                else
                {
                    if (temp > 100)//Rate的取值不可过大
                    {
                        MessageBox.Show("Invalid value for the rating,should be less than 100");
                        tbRating.Focus();
                        return false;
                    }

                }

            }

            if (!(string.IsNullOrWhiteSpace(tbAmount.Text.Trim())))
            {
                if (!int.TryParse(tbAmount.Text.Trim(), out temp))
                {
                    // tbRating.Focus();
                    MessageBox.Show("Please input a number for the Amount");
                    tbAmount.Focus();
                    return false;
                }
            }
            return true;
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ValidateValues())
                return;
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
