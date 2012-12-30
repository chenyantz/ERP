using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.Finances
{

    public partial class FinancesView : Form
    {
        private DataTable customerVendorTable;
        private DataTable userTable;
        List<CustomerVenderPrimaryKey> changeList = new List<CustomerVenderPrimaryKey>();
        
        enum FilterType { 
        All,
        ByCompanyName,
        ByOwnerName
        }
        public FinancesView()
        {
            InitializeComponent();
        }

        private void FinancesView_Load(object sender, EventArgs e)
        {
           

            FillTheDataGrid();

        }

        private void FillTheDataGrid()
        {
            customerVendorTable = GlobalRemotingClient.GetCustomerVendorMgr().GetTheCompanyNecessaryInfoForFinance();
            userTable = GlobalRemotingClient.GetAccountMgr().ReturnWholeAccountTable();
            
            dataGridView1.Rows.Clear();
            dataGridView1.CellValueChanged -= dataGridView1_CellValueChanged;

            FilterType filterType=FilterType.All;
            string filterText=""; 
            //Fill the DataGrid according to the Filter
            if(string.IsNullOrWhiteSpace(tscbSearchType.Text.Trim())||string.IsNullOrWhiteSpace(tstbSearchWord.Text.Trim()))
            {
             filterType=FilterType.All;
            }
            else if(tscbSearchType.SelectedIndex==0)//company search
            {
                  filterType=FilterType.ByCompanyName;
                  filterText=tstbSearchWord.Text.Trim();
             }
            else if(tscbSearchType.SelectedIndex==1)//onwerName
            {
                filterType = FilterType.ByOwnerName;
                filterText = tstbSearchWord.Text.Trim();
            }
            else
            {
                filterType=FilterType.All;
            }


            if (filterType == FilterType.All)
            {
                var rowsForShowTable = from cvRow in customerVendorTable.AsEnumerable()
                                       join userRow in userTable.AsEnumerable()
                                       on cvRow["ownerName"] equals userRow["id"]
                                       select
                                        new
                                        {
                                            CompanyTypeValue = (int.Parse(cvRow["cvtype"].ToString()) == 0 ? "C" : "V"),
                                            CompanyNameValue = cvRow["cvname"].ToString(),
                                            CountryValue = cvRow["country"].ToString(),
                                            OwnerNameValue = userRow["accountName"].ToString(),
                                            CustomerVendorNumberValue = cvRow["cvNumber"].ToString()
                                        };


                foreach (var row in rowsForShowTable)
                {
                    dataGridView1.Rows.Add(row.CompanyTypeValue, row.CompanyNameValue, row.CountryValue, row.OwnerNameValue, row.CustomerVendorNumberValue);

                }

            }
            else if(filterType==FilterType.ByCompanyName)
            {
                var rowsForShowTable = from cvRow in customerVendorTable.AsEnumerable()
                                       join userRow in userTable.AsEnumerable()
                                       on cvRow["ownerName"] equals userRow["id"]
                                       where cvRow["cvname"].ToString().Contains(filterText) 
                                       select
                                        new
                                        {
                                            CompanyTypeValue = (int.Parse(cvRow["cvtype"].ToString()) == 0 ? "C" : "V"),
                                            CompanyNameValue = cvRow["cvname"].ToString(),
                                            CountryValue = cvRow["country"].ToString(),
                                            OwnerNameValue = userRow["accountName"].ToString(),
                                            CustomerVendorNumberValue = cvRow["cvNumber"].ToString()
                                        };


                foreach (var row in rowsForShowTable)
                {
                    dataGridView1.Rows.Add(row.CompanyTypeValue, row.CompanyNameValue, row.CountryValue, row.OwnerNameValue, row.CustomerVendorNumberValue);

                }


            }
            else if (filterType == FilterType.ByOwnerName)
            {
                var rowsForShowTable = from cvRow in customerVendorTable.AsEnumerable()
                                       join userRow in userTable.AsEnumerable()
                                       on cvRow["ownerName"] equals userRow["id"]
                                       where userRow["accountName"].ToString().ToLower().Contains(filterText.ToLower())
                                       select
                                        new
                                        {
                                            CompanyTypeValue = (int.Parse(cvRow["cvtype"].ToString()) == 0 ? "C" : "V"),
                                            CompanyNameValue = cvRow["cvname"].ToString(),
                                            CountryValue = cvRow["country"].ToString(),
                                            OwnerNameValue = userRow["accountName"].ToString(),
                                            CustomerVendorNumberValue = cvRow["cvNumber"].ToString()
                                        };


                foreach (var row in rowsForShowTable)
                {
                    dataGridView1.Rows.Add(row.CompanyTypeValue, row.CompanyNameValue, row.CountryValue, row.OwnerNameValue, row.CustomerVendorNumberValue);

                }

            }
            else
            {
                MessageBox.Show("error");
            }

            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
            changeList.Clear();

        }


        private void tsbSave_Click(object sender, EventArgs e)
        {
           //get data from the changeList
            int failrecord = 0;
            if (changeList.Count == 0) return;
            foreach (CustomerVenderPrimaryKey changeItem in changeList)
            {
                if (!GlobalRemotingClient.GetCustomerVendorMgr().AssignCompanyNumberByFinance(changeItem.Cvtype, changeItem.CvName, changeItem.OwnerName, changeItem.CvNumber))
                {
                    failrecord++;
                }
            
            }
            if (failrecord == 0)
            {
                MessageBox.Show("All the Customer Number or Vendor Number has been assigned or updated");
            }

            //clear the changeList
            changeList.Clear();

        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.Red;
            //get the value from datagridRow
            DataGridViewRow dgvr = dataGridView1.Rows[e.RowIndex];
            int cvtypeValue = (dgvr.Cells[CompanyType.Index].Value.ToString() == "C" ? 0 : 1);
            string cvNameValue=dgvr.Cells[CompanyName.Index].Value.ToString();
            string cvNumberValue = dgvr.Cells[CustomerVendorNumber.Index].Value.ToString();
            string ownerNameStr=dgvr.Cells[OwnerName.Index].Value.ToString();
            var ids = from row in userTable.AsEnumerable()
                      where row["accountName"].ToString() == ownerNameStr
                      select row["id"];
            int ownerNameValue = Convert.ToInt32(ids.First<object>());
      
            changeList.Add(new CustomerVenderPrimaryKey(cvtypeValue,cvNameValue,ownerNameValue,cvNumberValue));
             
            
        }
       
        private void tsbSearch_Click(object sender, EventArgs e)
        {
            FillTheDataGrid();

        }

        private void tsbClearSearch_Click(object sender, EventArgs e)
        {
            tscbSearchType.SelectedIndex = -1;
            tstbSearchWord.Text = string.Empty;
            FillTheDataGrid();
        }


    }
}