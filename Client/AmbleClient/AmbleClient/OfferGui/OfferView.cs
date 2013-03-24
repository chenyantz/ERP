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
            if (UserInfo.Job == JobDescription.sales || UserInfo.Job == JobDescription.saleManager)
            {
                this.tsbRoute.Enabled = false;
                this.tsbUpdate.Enabled = false;
            }

            for(int i=0;i<offerList.Count;i++)
            {
                OfferItems offerItems;
                if (UserInfo.Job == JobDescription.sales || UserInfo.Job == JobDescription.saleManager)
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

            }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
    }
}
