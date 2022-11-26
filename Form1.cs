using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ghjdthrf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            DateTable dataTable = new DateTable();
            dataTable.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTableManage timeTable = new TimeTableManage();
            timeTable.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTableLec timeTable = new TimeTableLec();
            timeTable.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
