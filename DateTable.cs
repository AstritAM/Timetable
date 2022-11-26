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
    public partial class DateTable : Form
    {
        public DateTable()
        {
            InitializeComponent();
        }
        Administraition administraition = new Administraition();
        Students students = new Students();
        //private void Group_Click(object sender, EventArgs e)
        //{
        //    GroupComboBox.DataSource = students.GroupName();
        //    GroupComboBox.DisplayMember = "Name_group";
        //    GroupComboBox.ValueMember = "ID";
        //}

        private void button2_Click(object sender, EventArgs e)
        {
            int count = int.Parse(GroupComboBox.SelectedValue.ToString());
            int day= int.Parse(comboBox1.SelectedValue.ToString());

            dataGridView2.DataSource = students.DataTableStud(count,day);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        //private void Lectur_Click(object sender, EventArgs e)
        //{
        //    LecturComboBox.DataSource = students.LecterName();
        //    LecturComboBox.DisplayMember = "Surname";
        //    LecturComboBox.ValueMember = "id";

        //}

        private void button3_Click(object sender, EventArgs e)
        {
            int count = int.Parse(LecturComboBox.SelectedValue.ToString());

            dataGridView3.DataSource = students.DataTableLect(count);
        }

        //private void Auditor_Click(object sender, EventArgs e)
        //{
        //    AuditComboBox.DataSource = students.LecterName();
        //    AuditComboBox.DisplayMember = "id";
        //    AuditComboBox.ValueMember = "id";
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            int count = int.Parse(AuditComboBox.SelectedValue.ToString());

            dataGridView1.DataSource = students.DataTableAudit(count);
        }

        private void DateTable_Load(object sender, EventArgs e)
        {
         
        }

        private void DateTable_Load_1(object sender, EventArgs e)
        {
            if (tabControl1.SelectedIndex == 0)
            {
                GroupComboBox.DataSource = students.GroupName();
                GroupComboBox.DisplayMember = "Name_group";
                GroupComboBox.ValueMember = "ID";
                comboBox1.DataSource = administraition.DayWeek();
                comboBox1.DisplayMember = "День недели";
                comboBox1.ValueMember = "ID";

            }
            if(tabControl1.SelectedIndex == 1)
            {

                LecturComboBox.DataSource = students.LecterName();
                LecturComboBox.DisplayMember = "nom_prenom";
                LecturComboBox.ValueMember = "ID";
            }
            if (tabControl1.SelectedIndex == 2)
            {
                AuditComboBox.DataSource = students.NumAudit();
                AuditComboBox.DisplayMember = "number";
                AuditComboBox.ValueMember = "ID";
            }

        }

        private void Lectur_Click(object sender, EventArgs e)
        {
           //  tabControl1.SelectedIndex = 1;
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {

            if (tabControl1.SelectedIndex == 0)
            {
                GroupComboBox.DataSource = students.GroupName();
                GroupComboBox.DisplayMember = "Name_group";
                GroupComboBox.ValueMember = "ID";
                comboBox1.DataSource = administraition.DayWeek();
                comboBox1.DisplayMember = "День недели";
                comboBox1.ValueMember = "ID";


            }
            if (tabControl1.SelectedIndex == 1)
            {

                LecturComboBox.DataSource = students.LecterName();
                LecturComboBox.DisplayMember = "nom_prenom";
                LecturComboBox.ValueMember = "ID";
            }
            if (tabControl1.SelectedIndex == 2)
            {
                AuditComboBox.DataSource = students.NumAudit();
                AuditComboBox.DisplayMember = "number";
                AuditComboBox.ValueMember = "ID";
            }

        }

        private void AuditComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LecturComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Auditor_Click(object sender, EventArgs e)
        {

        }

        private void Group_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    }
    

