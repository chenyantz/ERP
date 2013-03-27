using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.BomOffer
{
    public partial class BomOfferNewCustVen : Form
    {

        bool isOffer;
        public BomOfferNewCustVen(bool isOffer)
        {
            InitializeComponent();
            this.isOffer=isOffer;
            if (isOffer)
            {
                this.Text = "Add a Vendor's Info";
                label1.Text="Customer Name*:";
            }
            else
                this.Text = "Add a Customer's Info";
            label1.Text = "Vendor Name*:";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (tbCustVenName.Text.Length == 0)
            {
                MessageBox.Show("Please input the Customer/Vendor Name");
            }
            var publicCustVen = new publiccustven
            {
                custVenName=tbCustVenName.Text.Trim(),
                custVendorType=(sbyte)(isOffer?1:0),
                contact=tbContact.Text.Trim(),
                tel=tbTel.Text.Trim(),
                email=tbEmail.Text.Trim(),
                userID=(short)UserInfo.UserId,
                enterDay=DateTime.Now
            };
            using (BomOfferEntities entity = new BomOfferEntities())
            {
                entity.publiccustven.AddObject(publicCustVen);
                entity.SaveChanges();
            }

            this.DialogResult = DialogResult.OK;

            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BomOfferNewCustVen_Load(object sender, EventArgs e)
        {

        }




        
    }
}
