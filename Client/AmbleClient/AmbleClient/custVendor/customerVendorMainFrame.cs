using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AmbleAppServer.customerVendorMgr;

namespace AmbleClient.custVendor
{
    public partial class customerVendorMainFrame : Form
    {
        int customerOrVendor;
        CustomerVendorMgr cvMgr;
        int userId;

        
        
        public customerVendorMainFrame(int customerOrVendor,int userId)
        {
            InitializeComponent();
            this.customerOrVendor = customerOrVendor;//0:customer, 1:vendor
            this.userId = userId;
            if (customerOrVendor == 0)
            {
                this.Text = "View Customers";
                this.radioButton1.Text = "Include Subordinates' Customers";
                this.radioButton2.Text = "Only List My Customers";

            }
            else
            {
                this.Text = "View Vendors";
                this.radioButton1.Text = "Include Subordinates' Vendors";
                this.radioButton2.Text = "Only List My Vendors";
            }
           cvMgr=(CustomerVendorMgr)Activator.GetObject(typeof(CustomerVendorMgr),
            "tcp://192.168.1.104:1111/CustomerVendorMgr");

        }

        private void customerVendorMainFrame_Load(object sender, EventArgs e)
        {






        }
    }
}
