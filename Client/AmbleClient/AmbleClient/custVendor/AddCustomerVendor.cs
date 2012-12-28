using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.custVendor
{
    public class AddCustomerVendor:customerVendorOperation
    {
           public AddCustomerVendor(int customerOrVendor)
        { 
            base.customerOrVendor=customerOrVendor;
            if (this.customerOrVendor == 0)
            {
                base.Text = "Add a customer's info";
            }
            else
            {
                base.Text = "Add a vendor's info";
            }
    
        }

        protected override void FillTheTextboxs()
        {
            
        }



        protected override void Save()
        {
            //check if name exist

            if(GlobalRemotingClient.GetCustomerVendorMgr().IsCvtypeandCvNameExist(customerOrVendor,tbName.Text.Trim()))
            {
               
                MessageBox.Show("The company name already exists.");
                tbName.Focus();
                return;
            
            }
              
            
            GlobalRemotingClient.GetCustomerVendorMgr().AddCustomerOrVendor(customerOrVendor, tbName.Text.Trim(), tbCountry.Text.Trim(),
                String.IsNullOrWhiteSpace(tbRating.Text.Trim())?(int?)null:int.Parse(tbRating.Text.Trim()), tbTerm.Text.Trim(), tbContact1.Text.Trim(), tbContact2.Text.Trim(), tbPhone1.Text.Trim(),
                tbPhone2.Text.Trim(), tbCell.Text.Trim(), tbFax.Text.Trim(), tbEmail1.Text.Trim(), tbEmail2.Text.Trim(), UserInfo.UserId, UserInfo.UserId,DateTime.Now,
                comboBox2.SelectedText.Trim()=="Yes"?1:0,
                String.IsNullOrWhiteSpace(tbAmount.Text.Trim()) ? (int?)null : int.Parse(tbAmount.Text.Trim()), 
                tbNotes.Text.Trim());
                        
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // AddCustomerVendor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(952, 515);
            this.Name = "AddCustomerVendor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }
}
