using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.OfferGui.OfferMgr;

namespace AmbleClient.OfferGui
{
    public partial class OfferView : Form
    {
        OfferMgr.OfferMgr offerMgr = new OfferMgr.OfferMgr();
        List<Offer> offerList;
        List<OfferItems> offerItemsList = new List<OfferItems>();

        
        public OfferView(int rfqId)
        {
            InitializeComponent();
            offerList = offerMgr.GetOffersByRfqId(rfqId);


        }

        public OfferView(int offerId,int nosense)
        {
            InitializeComponent();
            offerList=new List<Offer>();
            offerList.Add(offerMgr.GetOfferByOfferId(offerId));
        }


        private void OfferList_Load(object sender, EventArgs e)
        {
            for(int i=0;i<offerList.Count;i++)
            {
                OfferItems offerItems;
                if (UserInfo.Job == JobDescription.Sales || UserInfo.Job == JobDescription.SalesManager)
                {
                    offerItems = new SalesOfferItems();
                
                }
                else
                {
                   offerItems = new BuyerOfferItems();
                }
            offerItems.Dock = System.Windows.Forms.DockStyle.Fill;
            offerItems.Location = new System.Drawing.Point(3, 3);
            offerItems.Name = "OfferItems"+i;
            offerItems.Size = new System.Drawing.Size(906, 456);
            offerItems.TabIndex = 0;
            offerItems.FillTheTable(offerList[i]);
            offerItemsList.Add(offerItems);
            }
         //   List<TabPage> tabPageList=new List<TabPage>();
            
            for(int i=0;i<offerItemsList.Count;i++)
            {
                System.Windows.Forms.TabPage tabPage = new TabPage();

               tabPage.Controls.Add(offerItemsList[i]);
               tabPage.Location = new System.Drawing.Point(4, 22);
               tabPage.Name = "tabPage"+i;
               tabPage.Padding = new System.Windows.Forms.Padding(3);
               tabPage.Size = new System.Drawing.Size(912, 462);
               tabPage.TabIndex = 0;
               tabPage.Text = "Offer"+i;
               tabPage.UseVisualStyleBackColor = true;
               this.tabControl1.Controls.Add(tabPage);
            }
            tabControl1_SelectedIndexChanged(this, null);
    }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (UserInfo.Job == JobDescription.Sales || UserInfo.Job == JobDescription.SalesManager)
            {
                this.tsbRoute.Enabled = false;
                this.tsbUpdate.Enabled = false;
            }
            else
            {
                if (offerList[tabControl1.SelectedIndex].offerStates == (int)OfferState.New)
                {
                    this.tsbRoute.Enabled = true;

                }
                else
                {
                    this.tsbRoute.Enabled = false;
                }
            
            }

        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            OfferItems item = offerItemsList[tabControl1.SelectedIndex];
            BuyerOfferItems bItem = item as BuyerOfferItems;
            bItem.UpdateItems();

        }

        private void tsbRoute_Click(object sender, EventArgs e)
        {
            OfferItems item = offerItemsList[tabControl1.SelectedIndex];
            BuyerOfferItems bItem = item as BuyerOfferItems;
            bItem.UpdateOfferState((int)OfferState.Routed);

        }

        private void tsbCloseOffer_Click(object sender, EventArgs e)
        {
            OfferItems item = offerItemsList[tabControl1.SelectedIndex];
            BuyerOfferItems bItem = item as BuyerOfferItems;
            bItem.UpdateOfferState((int)OfferState.Closed);
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
