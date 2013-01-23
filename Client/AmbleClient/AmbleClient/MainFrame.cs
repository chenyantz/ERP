using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.AccountMgr;
using AmbleAppServer.customerVendorMgr;


namespace AmbleClient
{
    public partial class MainFrame : Form
    {

        public MainFrame()
        {
            InitializeComponent();
        }

        private void MainFrame_Load(object sender, EventArgs e)
        {

        }

        private void viewEditAccountToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmbleClient.Admin.AccountMainFrame accountOpFrame = new Admin.AccountMainFrame();
            accountOpFrame.MdiParent = this;
            accountOpFrame.Show();

        }

        private void MainFrame_Leave(object sender, EventArgs e)
        {

        }

        private void MainFrame_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void customerManagermentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custVendor.customerVendorMainFrame mainFrame = new custVendor.customerVendorMainFrame(0);
            mainFrame.MdiParent = this;
            mainFrame.Show();

        }

        private void vendorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custVendor.customerVendorMainFrame mainFrame = new custVendor.customerVendorMainFrame(1);
            mainFrame.MdiParent = this;
            mainFrame.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings.PasswordChange passwdcgFrame = new Settings.PasswordChange();
            passwdcgFrame.MdiParent = this;
            passwdcgFrame.Show();
           

        }

        private void assignCustomerVendorNumberToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Finances.FinancesView financeView = new Finances.FinancesView();
            financeView.MdiParent = this;
            financeView.Show();
        }

        private void rFQViewNewSOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RfqGui.SalesRfqListView rfqView = new RfqGui.SalesRfqListView();
            rfqView.MdiParent = this;
            rfqView.Show();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (UserInfo.Job == JobDescription.buyer)
            {
                RfqGui.BuyerRfqListView rfqView = new RfqGui.BuyerRfqListView();
                rfqView.MdiParent = this;
                rfqView.Show();
            }
            else
            {
                RfqGui.BuyerManagerRfqListView rfqView = new RfqGui.BuyerManagerRfqListView();
                rfqView.MdiParent = this;
                rfqView.Show();
            }


        }

        private void testsToolStripMenuItem_Click(object sender, EventArgs e)
        {
           // SO.Test test = new SO.Test();
          //  test.ShowDialog();
        }

        private void sOViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SO.SalesSoListView salesSoListView = new SO.SalesSoListView();
            salesSoListView.MdiParent = this;
            salesSoListView.Show();


        }

        private void pOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SO.BuyerSoListView buyerSoListView = new SO.BuyerSoListView();
            buyerSoListView.MdiParent = this;
            buyerSoListView.Show();
        }
    }
}
