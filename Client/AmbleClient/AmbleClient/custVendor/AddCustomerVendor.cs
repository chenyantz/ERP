using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AmbleClient.custVendor
{
    public class AddCustomerVendor:customerVendorOperation
    {
        int customerOrVendor; int userId;


        public AddCustomerVendor(int customerOrVendor,int userId)
        { 
            this.customerOrVendor=customerOrVendor;
            this.userId=userId;
            if (this.customerOrVendor == 0)
            {
                base.Text = "Add a customer's info";
            }
            else
            {
                base.Text = "Add a vendor's info";
            }
    
        }

        protected override void Save()
        {
            //
              
            GlobalRemotingClient.GetCustomerVendorMgr().AddCustomerOrVendor(customerOrVendor, tbName.Text.Trim(), tbCountry.Text.Trim(),
                String.IsNullOrWhiteSpace(tbRating.Text.Trim())?(int?)null:int.Parse(tbRating.Text.Trim()), tbTerm.Text.Trim(), tbContact1.Text.Trim(), tbContact2.Text.Trim(), tbPhone1.Text.Trim(),
                tbPhone2.Text.Trim(), tbCell.Text.Trim(), tbFax.Text.Trim(), tbEmail1.Text.Trim(), tbEmail2.Text.Trim(), userId, userId,DateTime.Now,
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
