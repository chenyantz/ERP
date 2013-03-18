using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.SoMgr;
using AmbleClient.Order;

namespace AmbleClient.SO
{

    public partial class SoView : Form
    {
        private int rfqId;


        private SoOrderStateList soStateList = new SoOrderStateList();

        private List<So> soList;
        List<SoViewControl> soViewControlList = new List<SoViewControl>();
        

        public SoView(int rfqId)
        {
            InitializeComponent();
            this.rfqId = rfqId;
            soList = SoMgr.GetSoAccordingToRfqId(rfqId);
        }

        public SoView(So so)
        {
            InitializeComponent();
            soList = new List<So>();
            soList.Add(so);
        }

        private void GenerateGui()
        {
            So so = soList[tabControl1.SelectedIndex];

           SoState soState=soStateList.GetSoStateAccordingToValue(so.soStates);

           if(soState.WhoCanUpdate().Contains(UserInfo.Job))
            {
             tsbUpdate.Enabled=true;
            }
            else
            {
            tsbUpdate.Enabled=false;
            }
          //for list
           tscbStateList.Items.Clear();
           List<Operation> opList = soState.GetOperationList();
           foreach (Operation op in opList)
           {
               if (op.jobs.Contains(UserInfo.Job))
               {
                   tscbStateList.Items.Add(op.operationName);
               }
           }
        //for enter PO
           if ((UserInfo.Job == JobDescription.admin || UserInfo.Job == JobDescription.boss || UserInfo.Job == JobDescription.buyerManager || UserInfo.Job == JobDescription.buyer)
               && (so.soStates == new SoApprove().GetStateValue()))
           {
               tsbPoEnter.Enabled = true;

           }
           else
           {
               tsbPoEnter.Enabled = false;
           }
         



       }

        private void SoView_Load(object sender, EventArgs e)
        {
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
            tabControl1_SelectedIndexChanged(this, null);

        }


        private void tsbClose_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GenerateGui();
        }

        private void tscbStateList_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (MessageBox.Show("Change the state to "+(string)tscbStateList.SelectedItem + "?", "warning", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string selectedItemString = (string)tscbStateList.SelectedItem;
            So so = soList[tabControl1.SelectedIndex];

            SoState soState = soStateList.GetSoStateAccordingToValue(so.soStates);
            foreach (Operation op in soState.GetOperationList())
            {
                if (selectedItemString == op.operationName)
                {
                    op.operationMethod(so.soId);
                
                }
            
            }

        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
