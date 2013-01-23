using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.SoMgr;

namespace AmbleClient.SO
{

    //This SO view can be seen by the Sales.
    public partial class SoView : Form
    {
        private int rfqId;

        private List<So> soList;


        public SoView(int rfqId)
        {
            InitializeComponent();
            this.rfqId = rfqId;
            List<So> soList = GlobalRemotingClient.GetSoMgr().GetSoAccordingToRfqId(rfqId);

        }

        public SoView(So so)
        {
            InitializeComponent();
            soList = new List<So>();
            soList.Add(so);
        
        }



        private void SoView_Load(object sender, EventArgs e)
        {
          
            List<SoViewControl> soViewControlList = new List<SoViewControl>();
            for (int i = 0; i < soList.Count; i++)
            {
                SoViewControl soViewControlItem = new SoViewControl();
                soViewControlItem.Dock = System.Windows.Forms.DockStyle.Fill;
                soViewControlItem.Location = new System.Drawing.Point(3, 3);
                soViewControlItem.Name = "buyerOfferIems" + i;
                soViewControlItem.Size = new System.Drawing.Size(906, 456);
                soViewControlItem.TabIndex = 0;
                soViewControlItem.FillTheTable(soList[i]);
                soViewControlList.Add(soViewControlItem);
            }
            //   List<TabPage> tabPageList=new List<TabPage>();

            for (int i = 0; i < soViewControlList.Count; i++)
            {
                System.Windows.Forms.TabPage tabPage = new TabPage();

                tabPage.Controls.Add(soViewControlList[i]);
                tabPage.Location = new System.Drawing.Point(4, 22);
                tabPage.Name = "tabPage" + i;
                tabPage.Padding = new System.Windows.Forms.Padding(3);
                tabPage.Size = new System.Drawing.Size(941, 46297);
                tabPage.TabIndex = i;
                tabPage.Text = "SO " + i;
                tabPage.UseVisualStyleBackColor = true;
                this.tabControl1.Controls.Add(tabPage);
            }





        }
    }
}
