using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.BomOffer
{
    public partial class BomOfferList : Form
    {
         bool isOffer;
         bool listbyCustVen = false;
         int custVenId;


        public BomOfferList(bool isOffer)
        {
            InitializeComponent();
            this.isOffer = isOffer;
        }
        public BomOfferList(bool isOffer, int custVenId)
            : this(isOffer)
        {
            this.listbyCustVen = true;
            this.custVenId = custVenId;
        }


        private void BomOfferList_Load(object sender, EventArgs e)
        {
            if (isOffer)
                this.Text = "Offers List";
            else
                this.Text = "BOMs List";

            if (listbyCustVen)
            {
                tscbFilterBy.Enabled = false;
                tstbFilterString.Enabled = false;
                tsbSearch.Enabled = false;
                tsbCancel.Enabled = false;
            }


            using (BomOfferEntities entity = new BomOfferEntities())
            {
                if (listbyCustVen)
                {
                    var bomOfferList = from bomOffer in entity.publicbomoffer
                                       join custVen in entity.publiccustven on bomOffer.BomCustVendId equals custVen.custVenId
                                       where custVen.custVendorType == (isOffer ? 1 : 0) && custVen.custVenId==this.custVenId
                                       
                                       select new
                                       {
                                           Id = bomOffer.BomCustVendId,
                                           MFG = bomOffer.mfg,
                                           MPN = bomOffer.mpn,
                                           Qty = bomOffer.qty,
                                           Price = bomOffer.price,
                                           Cpn = bomOffer.cpn
                                       };

                    this.dataGridView1.DataSource = bomOfferList;

                }

                else
                {

                    var bomOfferList = from bomOffer in entity.publicbomoffer
                                       join custVen in entity.publiccustven on bomOffer.BomCustVendId equals custVen.custVenId
                                       where custVen.custVendorType == (isOffer ? 1 : 0)
                                       select new
                                       {
                                           Id=bomOffer.BomCustVendId,
                                           Company = custVen.custVenName,
                                           MFG = bomOffer.mfg,
                                           MPN = bomOffer.mpn,
                                           Qty = bomOffer.qty,
                                           Price = bomOffer.price,
                                           Cpn = bomOffer.cpn
                                       };

                    this.dataGridView1.DataSource = bomOfferList;
                }

            }

        }

        private void tsbDeleteItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 0) return;
            if (MessageBox.Show("Delete the selected item?", "Delete", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

           DataGridViewRow dgvr = dataGridView1.SelectedRows[0];
           int bomOfferId = Convert.ToInt32(dgvr.Cells["Id"].Value);


            using (BomOfferEntities entity = new BomOfferEntities())
            {
                var bomOfferItem = entity.publicbomoffer.First(item => item.BomCustVendId == bomOfferId);
                entity.DeleteObject(bomOfferItem);
                entity.SaveChanges();
            }
            BomOfferList_Load(this,null);



        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            BomOfferList_Load(this, null);
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            if ((tscbFilterBy.Text.Trim().Length == 0)|| (tstbFilterString.Text.Trim().Length == 0))
                return;

            if ((tscbFilterBy.SelectedIndex == 0) && (tstbFilterString.Text.Trim().Length != 0))
            {
                using (BomOfferEntities entity = new BomOfferEntities())
                {
                    var bomOfferList = from bomOffer in entity.publicbomoffer
                                       join custVen in entity.publiccustven on bomOffer.BomCustVendId equals custVen.custVenId
                                       where custVen.custVendorType == (isOffer ? 1 : 0) &&(custVen.custVenName.Contains(tstbFilterString.Text.Trim()))
                                       select new
                                       {
                                           Id = bomOffer.BomCustVendId,
                                           Company = custVen.custVenName,
                                           MFG = bomOffer.mfg,
                                           MPN = bomOffer.mpn,
                                           Qty = bomOffer.qty,
                                           Price = bomOffer.price,
                                           Cpn = bomOffer.cpn
                                       };

                    this.dataGridView1.DataSource = bomOfferList;

                }
            
            
            }




        }

        private void tsbToExcel_Click(object sender, EventArgs e)
        {

            DataTable dt;
            //generate datatable according to DataGridView
            try
            {
              dt=GridView2DataTable(dataGridView1);
            }
            catch (Exception ex)
            {
                Logger.Error(ex.Message);
                Logger.Error(ex.StackTrace);
                MessageBox.Show("Met some errors while generating the Excel format file ");
                return;
            }
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
              saveFileDialog1.Filter = "Excel 文件(*.xls)|*.xls|Excel 文件(*.xlsx)|*.xlsx|所有文件(*.*)|*.*";
            //以文件“*.xls”导出

              List<string> columnName = new List<string>();
              foreach (DataColumn column in dt.Columns)
              {
                  columnName.Add(column.ColumnName);
              
              }



              if (saveFileDialog1.ShowDialog() == DialogResult.OK)
              {
                  AmbleClient.ExcelHelper.ExcelHelper.Export(dt, this.isOffer?"Offer":"BOM", saveFileDialog1.FileName, "WorkSheet1",columnName.ToArray(),columnName.ToArray());
              }


        }
    
         private  DataTable GridView2DataTable(DataGridView gv)
        {
            DataTable table = new DataTable();
            if (gv.Rows.Count==0 && gv.Columns.Count == 0)
            {
                return table;
            }
            int columnCount = gv.Columns.Count;
            for (int i = 0; i < columnCount; i++)
            {
                string text = gv.Columns[i].HeaderText;
                table.Columns.Add(text);
            }
            foreach (DataGridViewRow r in gv.Rows)
            {
                    DataRow row = table.NewRow();
                    int j = 0;
                    for (int i = 0; i < columnCount; i++)
                    {
                        string text = r.Cells[i].Value.ToString();

                            row[j] = text;
                            j++;
                  
                    }
                    table.Rows.Add(row);
            }
            return table;
     }


     


    
    
    
    }
}
