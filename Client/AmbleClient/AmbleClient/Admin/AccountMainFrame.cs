using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using AmbleAppServer.AccountMgr;

namespace AmbleClient.Admin
{
    public partial class AccountMainFrame : Form
    {
        DataTable originalTable;

        public AccountMainFrame()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        private void FillTheDatagrid()
        {
            //fill the datagrid view

            originalTable = GlobalRemotingClient.GetAccountMgr().ReturnWholeAccountTable();

            DataTable showTable = new DataTable();
            showTable.Columns.Add("Name");
            showTable.Columns.Add("Job");
            showTable.Columns.Add("Email");
            showTable.Columns.Add("Superviser");

            foreach (DataRow dr in originalTable.Rows)
            {
                DataRow rowForShow = showTable.NewRow();
                rowForShow["Name"] = dr["accountName"];


                JobDescription jobD = (JobDescription)int.Parse(dr["job"].ToString());
                rowForShow["Job"] = jobD.ToString();

                rowForShow["Email"] = dr["email"];

                int superviser = int.Parse(dr["superviser"].ToString());
                foreach (DataRow dr2 in originalTable.Rows)
                {
                    if (int.Parse(dr2["id"].ToString()) == superviser)
                    {
                        rowForShow["Superviser"] = dr2["accountName"];

                    }

                }
                showTable.Rows.Add(rowForShow);

                dataGridView1.DataSource = showTable;
            }
        
        }

        private void AccountOperation_Load(object sender, EventArgs e)
        {
            FillTheDatagrid();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return; //this happens when doubleclick the column head;

            AccountOperation addMAccount = new ModifyAccount(e.RowIndex);
            addMAccount.SetDataTable(originalTable);
            addMAccount.ShowDialog();
            FillTheDatagrid();

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Add an account
            AccountOperation addMAccount = new AddAccount();
            addMAccount.SetDataTable(originalTable);
            addMAccount.ShowDialog();

            FillTheDatagrid();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Modify the current account;
            int rowIndex = dataGridView1.CurrentRow.Index;
            AccountOperation addMAccount = new ModifyAccount(rowIndex);
            addMAccount.SetDataTable(originalTable);
            addMAccount.ShowDialog();
            FillTheDatagrid();
        }
    }
}
