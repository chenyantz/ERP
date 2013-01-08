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
            Sales.RFQListView rfqView = new Sales.RFQListView();
            rfqView.MdiParent = this;
            rfqView.Show();
        }
    }
}
