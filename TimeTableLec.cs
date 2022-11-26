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
    public partial class TimeTableLec : Form
    {
        public TimeTableLec()
        {
            InitializeComponent();
        }
        Students students = new Students();
        Lector lector = new Lector();

        private void tabControl1_Click(object sender, EventArgs e)
        {

           
            if (tabControl1.SelectedIndex == 0)
            {

                LecturComboBox.DataSource = students.LecterName();
                LecturComboBox.DisplayMember = "nom_prenom";
                LecturComboBox.ValueMember = "ID";
            }
           if (tabControl1.SelectedIndex == 1)
            {
                AuditComboBox.DataSource = students.NumAudit();
                AuditComboBox.DisplayMember = "number";
                AuditComboBox.ValueMember = "ID";
            }

        }

        private void Lectur_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            int count = int.Parse(LecturComboBox.SelectedValue.ToString());

            dataGridView3.DataSource = lector.DataTableLect(count);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            int count = int.Parse(AuditComboBox.SelectedValue.ToString());

            dataGridView1.DataSource = students.DataTableAudit(count);
        }

        private void TimeTableLec_Load(object sender, EventArgs e)
        {
            
             
                if (tabControl1.SelectedIndex == 0)
                {

                    LecturComboBox.DataSource = students.LecterName();
                    LecturComboBox.DisplayMember = "nom_prenom";
                    LecturComboBox.ValueMember = "ID";
                }
                if (tabControl1.SelectedIndex == 1)
                {
                    AuditComboBox.DataSource = lector.NumAudit();
                    AuditComboBox.DisplayMember = "number";
                    AuditComboBox.ValueMember = "ID";
                }

            
        }

        private void tabControl1_Click_1(object sender, EventArgs e)
        {

        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }

