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

        PropertyClass property;

        public MainFrame()
        {
            InitializeComponent();
        }

        public void SetProperty(PropertyClass popclass)
        {
            this.property = popclass;
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
            custVendor.customerVendorMainFrame mainFrame = new custVendor.customerVendorMainFrame(0, property.UserId);
            mainFrame.MdiParent = this;
            mainFrame.Show();

        }

        private void vendorManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            custVendor.customerVendorMainFrame mainFrame = new custVendor.customerVendorMainFrame(1, property.UserId);
            mainFrame.MdiParent = this;
            mainFrame.Show();
        }
    }
}
