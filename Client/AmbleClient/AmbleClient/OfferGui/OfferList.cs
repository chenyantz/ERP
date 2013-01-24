using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.OfferMgr;

namespace AmbleClient.OfferGui
{
    public partial class OfferList : Form
    {
        int rfqId;
        
        public OfferList(int rfqId)
        {
            InitializeComponent();
            this.rfqId = rfqId;

        }

        private void OfferList_Load(object sender, EventArgs e)
        {
            List<Offer> offerList = GlobalRemotingClient.GetOfferMgr().GetOffersByRfqId(rfqId);

            
            
            List<BuyerOfferItems> buyerOfferItemsList=new List<BuyerOfferItems>();
            for(int i=0;i<offerList.Count;i++)
            {
             BuyerOfferItems buyerOfferItems=new BuyerOfferItems();
            buyerOfferItems.Dock = System.Windows.Forms.DockStyle.Fill;
            buyerOfferItems.Location = new System.Drawing.Point(3, 3);
            buyerOfferItems.Name = "buyerOfferItems"+i;
            buyerOfferItems.Size = new System.Drawing.Size(906, 456);
            buyerOfferItems.TabIndex = 0;
            buyerOfferItems.FillTheTable(offerList[i]);
            buyerOfferItemsList.Add(buyerOfferItems);
            }
         //   List<TabPage> tabPageList=new List<TabPage>();
            
            for(int i=0;i<buyerOfferItemsList.Count;i++)
            {
                System.Windows.Forms.TabPage tabPage = new TabPage();

               tabPage.Controls.Add(buyerOfferItemsList[i]);
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
    }
}
