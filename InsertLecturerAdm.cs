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
    public partial class InsertLecturerAdm : Form
    {
        public InsertLecturerAdm()
        {
            InitializeComponent();
        }
        Administraition administraition = new Administraition();

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void InsertLecturerAdm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = administraition.Lecturer();

            comboBox2.DataSource = administraition.NameDisciplines();
            comboBox2.DisplayMember = "Name_disciplines";
            comboBox2.ValueMember = "ID";

            comboBox1.DataSource = administraition.Depart();
            comboBox1.DisplayMember = "Name_departament";
            comboBox1.ValueMember = "ID";
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try {
                string name = NamwBox2.Text;
                string surname = SurnameBox1.Text;
                string patronymic = PatronimicBox4.Text;
                int dis = int.Parse(comboBox2.SelectedValue.ToString());
                int depr = int.Parse(comboBox1.SelectedValue.ToString());
                string phone = textBox5.Text;

                if (administraition.InsertLecturer(name, surname, patronymic, dis, depr, phone))
                {
                    dataGridView1.DataSource = administraition.Lecturer();
                    MessageBox.Show("Данные удачно добавлены");
                }
                else
                {
                    MessageBox.Show("Данные  не добавлены");
                }

            } catch (Exception ex)
            {
                MessageBox.Show("введены не все параметры");
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int num = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            NamwBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            SurnameBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            PatronimicBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.SelectedValue = administraition.Getdis2(num);
            comboBox1.SelectedValue = administraition.GetDep(num);
            textBox5.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try {
                int id = int.Parse(textBox3.Text);
                string name = NamwBox2.Text;
                string surname = SurnameBox1.Text;
                string patronymic = PatronimicBox4.Text;
                int dis = int.Parse(comboBox2.SelectedValue.ToString());
                int depr = int.Parse(comboBox1.SelectedValue.ToString());
                string phone = textBox5.Text;
                if (administraition.ediLector(id, name, surname, patronymic, dis, depr, phone))
                {
                    dataGridView1.DataSource = administraition.Lecturer();
                    MessageBox.Show("Данные удачно изменены");
                }


                else
                {
                    MessageBox.Show("Данные  не удалось изменить");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            try {
                int id = int.Parse(textBox3.Text);
                if (administraition.DelLec(id))
                {
                    dataGridView1.DataSource = administraition.Lecturer();
                    MessageBox.Show("Данные удачно изменены");
                }



                else
                {
                    MessageBox.Show("Данные  не удалось изменить");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTableManage timeTableManage = new TimeTableManage();
            timeTableManage.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                   administraition.DelStory())
                {
                    dataGridView1.DataSource = administraition.Lecturer();
                    MessageBox.Show("Данные удачно удалить");
                }
                else
                {
                    MessageBox.Show("Данные  не удалось удалить");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
