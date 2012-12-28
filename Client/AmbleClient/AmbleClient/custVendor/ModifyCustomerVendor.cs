using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;

namespace AmbleClient.custVendor
{
    public class ModifyCustomerVendor:customerVendorOperation
    {

        DataRow selectedDr;
       


        public ModifyCustomerVendor(DataRow dr,int customerOrVendor)
        {
            this.selectedDr = dr;
            base.customerOrVendor=customerOrVendor;
        
        }

        protected override void FillTheTextboxs()
        {

            if(customerOrVendor==0)
                this.Text="Modify a customer's info";
            else
                this.Text="Modify a vendor's info";

            //Bind the info of Datarow to control
            tbName.Text = selectedDr["Company Name"].ToString();
            tbCountry.Text = selectedDr["Country"].ToString();
            tbNumber.Text = selectedDr["Company Number"].ToString();
            tbRating.Text = selectedDr["Rate"].ToString();
            tbTerm.Text = selectedDr["Term"].ToString();
            tbContact1.Text = selectedDr["Contact 1"].ToString();
            tbContact2.Text = selectedDr["Contact 2"].ToString();
            tbPhone1.Text = selectedDr["Phone 1"].ToString();
            tbPhone2.Text = selectedDr["Phone 2"].ToString();
            tbCell.Text = selectedDr["Cell Phone"].ToString();
            tbFax.Text = selectedDr["Fax"].ToString();
            tbEmail1.Text = selectedDr["Email 1"].ToString();
            tbEmail2.Text = selectedDr["Email 2"].ToString();
            tbLastUpdateName.Text = selectedDr["Last Modify Name"].ToString();
            tbLastUpdateDate.Text = selectedDr["last Update Date"].ToString();
            tbAmount.Text = selectedDr["Amount"].ToString();
            tbNotes.Text = selectedDr["Notes"].ToString();

            comboBox2.SelectedValue = selectedDr["BlackListed"].ToString();
        }


        protected override void Save()
        {
            //First check if the Name exist?
          if(tbName.Text.Trim()!=selectedDr["Company Name"].ToString())
          {
            if (GlobalRemotingClient.GetCustomerVendorMgr().IsCvtypeandCvNameExist(customerOrVendor,tbName.Text.Trim(),UserInfo.UserId))
            {
                MessageBox.Show("The company name already exists.");
                tbName.Focus();
                return;
             
            }

          }

        GlobalRemotingClient.GetCustomerVendorMgr().ModifyCustomerOrVendor(customerOrVendor,selectedDr["Company Name"].ToString(),tbName.Text.Trim(),
            tbCountry.Text.Trim(),tbNumber.Text.Trim(),String.IsNullOrWhiteSpace(tbRating.Text.Trim())?(int?)null:int.Parse(tbRating.Text.Trim()), tbTerm.Text.Trim(), tbContact1.Text.Trim(), tbContact2.Text.Trim(), tbPhone1.Text.Trim(),
                tbPhone2.Text.Trim(), tbCell.Text.Trim(), tbFax.Text.Trim(), tbEmail1.Text.Trim(), tbEmail2.Text.Trim(), UserInfo.UserId,DateTime.Now,
                comboBox2.SelectedText.Trim()=="Yes"?1:0,
                String.IsNullOrWhiteSpace(tbAmount.Text.Trim()) ? (int?)null : int.Parse(tbAmount.Text.Trim()), 
                tbNotes.Text.Trim(),UserInfo.UserId);
          



        }



    }
}
