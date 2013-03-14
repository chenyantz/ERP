using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace AmbleClient.Admin
{
    public class ModifyAccount:AccountOperation
    {

        int rowIndex;

        public ModifyAccount(int rowIndex)
        {
            this.rowIndex = rowIndex;
            base.Text = "Modify the selected account";
        }


        public override void FillTheTextBox()
        {
            //base.FillTheTextBox();

            textBox1.Text = dt.Rows[rowIndex]["accountName"].ToString();
            maskedTextBox1.Text = dt.Rows[rowIndex]["accountPassword"].ToString();
            maskedTextBox2.Text = maskedTextBox1.Text;
            textBox2.Text = dt.Rows[rowIndex]["email"].ToString();
            comboBox1.SelectedItem = ((JobDescription)(int.Parse(dt.Rows[rowIndex]["job"].ToString()))).ToString();

            //first get the superviser, and get the superviser's name

            int superviser = int.Parse(dt.Rows[rowIndex]["superviser"].ToString());

            foreach (DataRow dr in dt.Rows)
            {
                if (int.Parse(dr["id"].ToString()) == superviser)
                {
                    comboBox2.SelectedItem = dr["accountName"].ToString();

                }

            }

        }

        public override void Save()
        {
            //base.Save();

            //get the current id

            int id =int.Parse( dt.Rows[rowIndex]["id"].ToString());

            accountMgr.ModifyAnAccount(id,textBox1.Text.Trim(), maskedTextBox1.Text.Trim(), textBox2.Text.Trim(),
                            GetJobIdFromJobName(comboBox1.Text), GetIdFromName(comboBox2.Text));
           
        }


    }
}
