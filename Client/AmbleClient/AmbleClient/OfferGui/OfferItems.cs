using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.OfferGui.OfferMgr;

namespace AmbleClient.OfferGui
{
    public partial class OfferItems : UserControl
    {

        protected OfferMgr.OfferMgr offerMgr;

        protected int offerId;
        public OfferItems()
        {
            InitializeComponent();
            offerMgr = new OfferMgr.OfferMgr();
        }
      

        public virtual void FillTheTable(Offer offer)
        {
            this.tbMpn.Text = offer.mpn;
            this.tbMfg.Text = offer.mfg;

            this.tbQuantity.Text = offer.amount.ToString();
            this.tbPrice.Text = offer.price.ToString();
            this.tbDeliverTime.Text = offer.deliverTime.ToString();
            this.cbTimeUnit.SelectedIndex = offer.timeUnit;
            this.tbOfferDate.Text = offer.offerDate.ToShortDateString();
            this.tbOfferState.Text = (offer.offerStates == 0 ? "New" : "Routed");
            this.tbNotes.Text = offer.notes;
        
        
        }

        public bool CheckItems()
        {
            if (ItemsCheck.CheckTextBoxEmpty(tbMfg) == false)
            {
                MessageBox.Show("Please input the MFG.");
                return false;
            }

            if (ItemsCheck.CheckTextBoxEmpty(tbVendorName) == false)
            {
                MessageBox.Show("Please input the Vendor Name.");
                return false;
            
            }
            if (ItemsCheck.CheckTextBoxEmpty(tbContact) == false)
            {
                MessageBox.Show("Please input the Contact name.");
                return false;
            }
            if (ItemsCheck.CheckTextBoxEmpty(tbPhone) == false)
            {
                MessageBox.Show("Please input the Phone number.");
                return false;
            }
            if (ItemsCheck.CheckTextBoxEmpty(tbQuantity) == false)
            {
                MessageBox.Show("Please input the Quantity.");
                return false;
            }
            else
            {
                if (false == ItemsCheck.CheckIntNumber(tbQuantity))
                {
                    MessageBox.Show("The Quantity should be an integer value");
                    return false;
                }
            }

            if (ItemsCheck.CheckTextBoxEmpty(tbPrice) == false)
            {
                MessageBox.Show("Please input the Price.");
                return false;
            }
            else
            {
                if (false == ItemsCheck.CheckFloatNumber(tbPrice))
                {
                    MessageBox.Show("The Price should be a float value");
                    return false;
                }
            }
            return true;
        
        
        }

    }
}
