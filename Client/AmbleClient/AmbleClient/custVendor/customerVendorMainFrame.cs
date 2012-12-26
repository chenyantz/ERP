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
        int userId;
        DataTable userTable;
        DataTable orginateCustomerVendorTable;
        DataTable showTable;
      
        
        
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

        }

        private void customerVendorMainFrame_Load(object sender, EventArgs e)
        {
            userTable = GlobalRemotingClient.GetAccountMgr().ReturnWholeAccountTable();
                    
            //Add columns to DataGridview
            showTable = new DataTable();
            showTable.Columns.AddRange(
                new DataColumn[]{
                    new DataColumn("Company Name",typeof(string)),
                    new DataColumn("Country",typeof(string)),
                    new DataColumn("Rate",typeof(int)),
                    new DataColumn("Term",typeof(string)),
                    new DataColumn("Contact 1",typeof(string)),
                    new DataColumn("Contact 2",typeof(string)),
                    new DataColumn("Phone 1",typeof(string)),
                    new DataColumn("Phone 2",typeof(string)),
                    new DataColumn("Cell Phone",typeof(string)),
                    new DataColumn("Fax",typeof(string)), 
                    new DataColumn("Email 1",typeof(string)),
                    new DataColumn("Email 2",typeof(string)),
                    new DataColumn("Owner Name",typeof(string)),
                    new DataColumn("Last Modify Name",typeof(string)),
                    new DataColumn("Last Update Date",typeof(DateTime)),
                    new DataColumn("BlackListed",typeof(string)),
                    new DataColumn("Amount",typeof(int)),
                    new DataColumn("Notes",typeof(string))
                });

            radioButton1.Checked = true;// Note, this will call FillDataGrid();

        }
        private void FillTheDataGrid()
        {

            this.showTable.Clear();

            if (radioButton1.Checked)
            {
                orginateCustomerVendorTable = GlobalRemotingClient.GetCustomerVendorMgr().GetTheCustomersOrVendorsICanSee(customerOrVendor, userId);
            }
            else if (radioButton2.Checked)
            {
                orginateCustomerVendorTable = GlobalRemotingClient.GetCustomerVendorMgr().GetMyCustomerOrVendor(customerOrVendor, userId);
            
            }

            var showRows = from cvrow in orginateCustomerVendorTable.AsEnumerable()
                           join userrow in userTable.AsEnumerable() on cvrow["ownerName"] equals userrow["id"] 
                           join userrow2 in userTable.AsEnumerable() on cvrow["lastUpdateName"] equals userrow2["id"]
                       select new
                       {
                           
                           name = cvrow["cvname"],
                           country = cvrow["country"],
                           rate=cvrow["rate"],
                           term=cvrow["term"],
                           contact1=cvrow["contact1"],
                           contact2=cvrow["contact2"],
                           phone1=cvrow["phone1"],
                           phone2=cvrow["phone2"],
                           cellphone=cvrow["cellphone"],
                           fax=cvrow["fax"],
                           email1=cvrow["email1"],
                           email2=cvrow["email2"],
                           ownerName=userrow["accountName"],
                           lastUpdateName=userrow2.Field<string>("accountName"),
                           lastUpdateDate=cvrow.Field<DateTime>("lastUpdateDate"),
                           blacklisted =((DBNull.Value.Equals(cvrow["blacklisted"])||Convert.ToInt32(cvrow["blacklisted"])==0)? "No" : "Yes"),
                           amount=cvrow["amount"],
                           notes=cvrow["notes"]
                       };
            
           foreach(var row in showRows)
           {
               showTable.Rows.Add(row.name, row.country, row.rate,row.term, row.contact1, row.contact2, row.phone1, row.phone2, row.cellphone,
                  row.fax, row.email1, row.email2, row.ownerName, row.lastUpdateName,row.lastUpdateDate, row.blacklisted, row.amount, row.notes);

           }
           
           dataGridView1.DataSource = showTable;
            //列宽自适应
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }


        }

        private void button1_Click(object sender, EventArgs e)
        {
            customerVendorOperation addOpframe = new AddCustomerVendor(customerOrVendor,userId);
            addOpframe.ShowDialog();
            FillTheDataGrid();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                radioButton2.Checked = false;
            }
            else
            {
                radioButton2.Checked = true;
            }
            FillTheDataGrid();


        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked == true)
            {
                radioButton1.Checked = false;
            }
            else
            {
                radioButton1.Checked = true;
            }
            FillTheDataGrid();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;
            
            customerVendorOperation modifyOpFrame = new ModifyCustomerVendor(GetDataRowInShowTableFromIndex(rowIndex),customerOrVendor,userId);
            modifyOpFrame.ShowDialog();
            FillTheDataGrid();

        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
          customerVendorOperation ModifyOpFrame = new ModifyCustomerVendor(GetDataRowInShowTableFromIndex(e.RowIndex),customerOrVendor,userId);
          ModifyOpFrame.ShowDialog();
          FillTheDataGrid();
        }

        private DataRow GetDataRowInShowTableFromIndex(int rowIndex)
        { 
         //get the primary key in datagridview
            string companyName = dataGridView1["Company Name", rowIndex].Value.ToString();

            var dataRows = showTable.AsEnumerable().Where<DataRow>(row => row["Company Name"].ToString() == companyName);
            return dataRows.First<DataRow>();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DataRow dr = GetDataRowInShowTableFromIndex(this.dataGridView1.CurrentRow.Index);
            GlobalRemotingClient.GetCustomerVendorMgr().DeleteCustomerOrVendor(customerOrVendor, dr["Compnay Name"].ToString());
            FillTheDataGrid();
            
        }


    }
}
