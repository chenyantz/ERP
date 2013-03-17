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
    public partial class BomOfferCustVendor : Form
    {
        bool isOffer; //false为BOM，true为offer
        
        public BomOfferCustVendor()
        {
            InitializeComponent();
        }

        public BomOfferCustVendor(bool isOffer):this()
        {
            this.isOffer = isOffer;

            if (isOffer)
            {
                this.Text = "Vendors For Offers";
                this.toolStripButton1.Text = "New Vendor";
                this.tscbDisplayBomOffer.Text = "List Offer for Selected Vendor";
                this.tsbNewBomOff.Text = "New Offer for Selected Vendor";
                this.tsbDelete.Text = "Delete the Selected Vendor";

            }
            else
            {
                this.Text = "Customer For BOMs";
                this.toolStripButton1.Text = "New Customer";
                this.tscbDisplayBomOffer.Text = "List BOM for Selected Customer";
                this.tsbNewBomOff.Text = "New BOM for Selected Customer";
                this.tsbDelete.Text="Delete the Selected Customer";
            }


        }
        
        private void BomOfferCustVendor_Load(object sender, EventArgs e)
        {

            using(BomOfferEntities entity=new BomOfferEntities())
            {
              
                if(isOffer)
                {
             var bomOfferList=from bomOffer in entity.publiccustven join myaccount in entity.account on bomOffer.userID equals myaccount.id
                                      where bomOffer.custVendorType==1
                                      select new
                                       {
                                          Id=bomOffer.custVenId,
                                          VendorName=bomOffer.custVenName,
                                          Contact=bomOffer.contact,
                                          Tel=bomOffer.tel,
                                          Email=bomOffer.email,
                                          Sale=myaccount.accountName,
                                          EnterDay=bomOffer.enterDay
                                       };
                  this.dataGridView1.DataSource=bomOfferList;
                }
                else
                {
                 var bomOfferList=from bomOffer in entity.publiccustven join myaccount in entity.account on bomOffer.userID equals myaccount.id
                                      where bomOffer.custVendorType==0
                                      select new
                                       {
                                          Id=bomOffer.custVenId,
                                          CustomerName=bomOffer.custVenName,
                                          Contact=bomOffer.contact,
                                          Tel=bomOffer.tel,
                                          Email=bomOffer.email,
                                          Buyer=myaccount.accountName,
                                          EnterDay=bomOffer.enterDay
                                       };
                 this.dataGridView1.DataSource = bomOfferList;
                
                }
               
            }
            }

        private void toolStripButton1_Click(object sender, EventArgs e)
          {
              BomOfferNewCustVen bomOfferNewCustVen = new BomOfferNewCustVen(isOffer);
              if (bomOfferNewCustVen.ShowDialog() == DialogResult.Yes)
              {
                  BomOfferCustVendor_Load(this, null);
              
              }
              


          }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            int rowIndex = e.RowIndex;
            if (rowIndex < 0)
                return;

            DataGridViewRow dgvr = dataGridView1.Rows[rowIndex];
            int custVenId = Convert.ToInt32(dgvr.Cells["Id"].Value);
            BomOffer.BomOfferList bomOfferList = new BomOfferList(isOffer, custVenId);
            bomOfferList.ShowDialog();

         }

        private void tsbNewBomOff_Click(object sender, EventArgs e)
        {
           if(dataGridView1.SelectedRows.Count==0) return;


           DataGridViewRow dgvr = dataGridView1.SelectedRows[0];
           int custVenId = Convert.ToInt32(dgvr.Cells["Id"].Value);
           NewBomOffer(custVenId);

        }

        private void NewBomOffer(int custVenId)
        {
            BomOfferNew bomOfferNew = new BomOfferNew(isOffer, custVenId);
            bomOfferNew.ShowDialog();
        
        }

        private void tscbDisplayBomOffer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;


            DataGridViewRow dgvr = dataGridView1.SelectedRows[0];
            int custVenId = Convert.ToInt32(dgvr.Cells["Id"].Value);
            BomOffer.BomOfferList bomOfferList = new BomOfferList(isOffer, custVenId);
            bomOfferList.ShowDialog();

        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count == 0) return;

            if (MessageBox.Show("Delete the selected customer/vendor will also delete its related BOM/Offer", "Warning", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
                return;

            DataGridViewRow dgvr = dataGridView1.SelectedRows[0];
            int custVenIdSelected = Convert.ToInt32(dgvr.Cells["Id"].Value);

            using (BomOfferEntities entity = new BomOfferEntities())
            {
                var bomOfferList = entity.publicbomoffer.Where(bomOffer => bomOffer.BomCustVendId == custVenIdSelected);
                foreach (var bomOffer in bomOfferList)
                {
                    entity.DeleteObject(bomOffer);
                }

                entity.DeleteObject(entity.publiccustven.Where(cv => cv.custVenId == custVenIdSelected).First());

                entity.SaveChanges();
            
            }

            BomOfferCustVendor_Load(this, null);



        }
    
    
    
    }








    }

