using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleClient.Order.PoMgr;
using AmbleClient.Order;

namespace AmbleClient.Order.PoView
{

    public partial class PoView : Form
    {
        private int soId;


        private PoStateList poStateList = new PoStateList();

        private List<po> poList;
        List<PoViewControl> poViewControlList = new List<PoViewControl>();


        public PoView(int soId,int nosense)
        {
            InitializeComponent();
            this.soId = soId;
            poList = PoMgr.PoMgr.GetPoAccordingToSoId(soId);
        }

        public PoView(po poMain)
        {
            InitializeComponent();
            poList = new List<po>();
            poList.Add(poMain);
        }

        public PoView(int poId)
        {
            InitializeComponent();
            poList = new List<po>();
            poList.Add(PoMgr.PoMgr.GetPoAccordingToPoId(poId));
        
        }


        private void GenerateGui()
        {
            po poMain = poList[tabControl1.SelectedIndex];

            PoState poState = poStateList.GetPoStateAccordingToValue((int)poMain.poStates);

            if (poState.WhoCanUpdate().Contains(UserInfo.Job))
            {
                tsbUpdate.Enabled = true;
            }
            else
            {
                tsbUpdate.Enabled = false;
            }
            //for list
            tscbStateList.Items.Clear();
            List<Operation> opList = poState.GetOperationList();
            foreach (Operation op in opList)
            {
                if (op.jobs.Contains(UserInfo.Job))
                {
                    tscbStateList.Items.Add(op.operationName);
                }
            }


        }

        private void SoView_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < poList.Count; i++)
            {
                PoViewControl poViewControlItem = new PoViewControl();
                poViewControlItem.Dock = System.Windows.Forms.DockStyle.Fill;
                poViewControlItem.Location = new System.Drawing.Point(3, 3);
                poViewControlItem.Name = "poItem" + i;
                poViewControlItem.Size = new System.Drawing.Size(906, 456);
                poViewControlItem.TabIndex = 0;
                poViewControlItem.FillTheTable(poList[i]);
                poViewControlList.Add(poViewControlItem);
            }

            for (int i = 0; i < poViewControlList.Count; i++)
            {
                System.Windows.Forms.TabPage tabPage = new TabPage();

                tabPage.Controls.Add(poViewControlList[i]);
                tabPage.Location = new System.Drawing.Point(4, 22);
                tabPage.Name = "tabPage" + i;
                tabPage.Padding = new System.Windows.Forms.Padding(3);
                tabPage.Size = new System.Drawing.Size(941, 46297);
                tabPage.TabIndex = i;
                tabPage.Text = "PO " + i;
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

            if (MessageBox.Show("Change the state to " + (string)tscbStateList.SelectedItem + "?", "warning", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            string selectedItemString = (string)tscbStateList.SelectedItem;
            po poMain = poList[tabControl1.SelectedIndex];

            PoState poState = poStateList.GetPoStateAccordingToValue((int)poMain.poStates);
            foreach (Operation op in poState.GetOperationList())
            {
                if (selectedItemString == op.operationName)
                {
                    op.operationMethod(poMain.poId);

                }

            }

        }

        private void tsbUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
