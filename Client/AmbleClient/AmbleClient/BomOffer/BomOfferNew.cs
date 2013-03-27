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
    public partial class BomOfferNew : Form
    {
        bool isOffer;
        int custVenId;

        public BomOfferNew(bool isOffer, int custVenId)
        {
            InitializeComponent();
            this.isOffer = isOffer;
            this.custVenId = custVenId;
            if (isOffer)
            {
                this.Text = "Add a New Offer";

            }
            else
            {
                this.Text = "Add a New BOM";
            }


        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!ItemsCheck.CheckTextBoxEmpty(tbMfg))
            {
                MessageBox.Show("Please input the MFG");
                return;
            
            }

            if (!ItemsCheck.CheckTextBoxEmpty(tbMpn))
            {
                MessageBox.Show("Please input the MPN");
                return;
            }

            if (!ItemsCheck.CheckIntNumber(tbQty))
            {
                MessageBox.Show("The QTY should be an integer value");
                tbQty.Focus();
                return;
            }

            if (!ItemsCheck.CheckTextBoxEmpty(tbPrice))
            {
                MessageBox.Show("Please input the Price");
                return;

            }
            else
            {
                if (!ItemsCheck.CheckFloatNumber(tbPrice))
                {
                    MessageBox.Show("The Price should be a float number");
                    tbPrice.Focus();
                    return;
                
                }
            }

            
            
            var publicBomOff = new publicbomoffer
            {
                mfg = tbMfg.Text.Trim(),
                mpn = tbMpn.Text.Trim(),
                qty = int.Parse(tbQty.Text.Trim()),
                price = float.Parse(tbPrice.Text.Trim()),
                cpn = tbCpn.Text.Trim(),
                userID = (short)UserInfo.UserId,
                BomCustVendId=this.custVenId,
                enerDay = DateTime.Now
            };
            using (BomOfferEntities entity = new BomOfferEntities())
            {
                entity.publicbomoffer.AddObject(publicBomOff);
                entity.SaveChanges();
            }
            this.DialogResult = DialogResult.OK;
            this.Close();


        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }
}
