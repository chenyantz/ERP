using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


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
            this.Text += ("---" + UserInfo.UserName);
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
            if (UserInfo.Job == JobDescription.Purchaser)
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
            AmbleClient.Help.About about = new Help.About();
            about.ShowDialog();
        }

        private void sOViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order.SalesSoListView salesSoListView = new Order.SalesSoListView();
            salesSoListView.MdiParent = this;
            salesSoListView.Show();


        }

        private void pOToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order.BuyerSoListView buyerSoListView = new Order.BuyerSoListView();
            buyerSoListView.MdiParent = this;
            buyerSoListView.Show();
        }

        private void bOMCustomerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmbleClient.BomOffer.BomOfferCustVendor bomCustomer = new BomOffer.BomOfferCustVendor(false);
            bomCustomer.MdiParent = this;
            bomCustomer.Show();


        }

        private void bOMListViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BomOffer.BomOfferList bomOfferList=new BomOffer.BomOfferList(false);
            bomOfferList.MdiParent=this;
            bomOfferList.Show();

        }

        private void offerVendorListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmbleClient.BomOffer.BomOfferCustVendor bomCustomer = new BomOffer.BomOfferCustVendor(true);
            bomCustomer.MdiParent = this;
            bomCustomer.Show();
        }

        private void offerListViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BomOffer.BomOfferList bomOfferList = new BomOffer.BomOfferList(true);
            bomOfferList.MdiParent = this;
            bomOfferList.Show();
        }

        private void pOListViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order.PoListView poListView = new Order.PoListView();
            poListView.MdiParent = this;
            poListView.Show();
        }

        private void offerListViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AmbleClient.OfferGui.OfferListView offerListView = new OfferGui.OfferListView();
            offerListView.MdiParent = this;
            offerListView.Show();



        }

        private void sOListViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AmbleClient.Order.FLSoListView flSoListView = new Order.FLSoListView();
            flSoListView.MdiParent = this;
            flSoListView.Show();
        }

        private void pOListViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AmbleClient.Order.FLPoListView flPoListView = new Order.FLPoListView();
            flPoListView.MdiParent = this;
            flPoListView.Show();
        }

        private void sOListViewToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AmbleClient.Order.FLSoListView flSoListView = new Order.FLSoListView();
            flSoListView.MdiParent = this;
            flSoListView.Show();
        }

        private void pOListViewToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            AmbleClient.Order.FLPoListView flPoListView = new Order.FLPoListView();
            flPoListView.MdiParent = this;
            flPoListView.Show();


        }
    }
}
