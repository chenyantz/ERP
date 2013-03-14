using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AmbleClient.basicGui
{
    public partial class TimePicker : Form
    {

        private string fromTo;

        public String FromTo
        {
            get 
            {
                return fromTo;
            }
        }


        public TimePicker()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btOK_Click(object sender, EventArgs e)
        {
            fromTo=dateTimePicker1.Value.ToShortDateString()+" To "+dateTimePicker2.Value.ToShortDateString();
            this.Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            fromTo = string.Empty;
            this.Close();
        }
    }
}
