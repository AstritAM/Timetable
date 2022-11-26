using MySql.Data.MySqlClient;
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
    public partial class InsertGroupAdm : Form
    {
        public InsertGroupAdm()
        {
            InitializeComponent();
        }
        Administraition administraition = new Administraition();
        DataBase dataBase = new DataBase();
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string name = textBox2.Text;
                int count = int.Parse(textBox1.Text);
                int spec = int.Parse(comboBox2.SelectedValue.ToString());
                
                
                if (administraition.InsertGroup(name,count,spec))
            {
                dataGridView1.DataSource = administraition.NameGroup(); ; ;
                MessageBox.Show("Данные удачно добавлены");
            }
            else
            {
                MessageBox.Show("Данные  не добавлены");
            }

            }catch (Exception ex)
            {
                MessageBox.Show("введены не все параметры");
            }
           

        }

        private void InsertGroupAdm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = administraition.NameGroup();
            comboBox2.DataSource = administraition.Spec();
            comboBox2.DisplayMember = "Name_specialty";
            comboBox2.ValueMember = "ID";

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox3.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int num= int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            comboBox2.SelectedValue = administraition.GetSpe(num);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            comboBox2.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox3.Text);
                string name = textBox2.Text;

                int countSt = int.Parse(textBox3.Text);
                int specid = int.Parse(comboBox2.SelectedValue.ToString());
                MySqlCommand command = new MySqlCommand("SELECT * FROM grooup  WHERE  Name_group = @name", dataBase.getConnection());

                MySqlDataAdapter adapter = new MySqlDataAdapter();

                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                DataTable table = new DataTable();


                adapter.SelectCommand = command;



                adapter.Fill(table);
                if (table.Rows.Count == 0)
                {


                    if (administraition.editGroup(id,name,countSt,specid))
                    {
                        dataGridView1.DataSource = administraition.NameGroup();
                        MessageBox.Show("Данные удачно изменены");
                    }

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
            try
            {
                int id = int.Parse(textBox3.Text);
                if (administraition.DelGroup(id))
                {
                    dataGridView1.DataSource = administraition.NameGroup();
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
                    dataGridView1.DataSource = administraition.NameGroup();
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
