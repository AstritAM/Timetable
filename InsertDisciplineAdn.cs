using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;

namespace ghjdthrf
{
    public partial class InsertDisciplineAdn : Form
    {

        public InsertDisciplineAdn()
        {
            InitializeComponent();
        }

        Administraition administraition = new Administraition();
        DataBase dataBase = new DataBase();
        private void label4_Click(object sender, EventArgs e)
        {




        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                if (administraition.DelDis(id))
                {
                    dataGridView1.DataSource = administraition.Discipline();
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

        private void button8_Click(object sender, EventArgs e)
        {

            string name = textBox2.Text;
            if (name.Trim().Equals(""))
            {
                MessageBox.Show("Введите данные!");
            }
            else
            {
                if (administraition.InsertDiscipline(name))
                {
                    dataGridView1.DataSource = administraition.Discipline();
                    MessageBox.Show("Данные удачно добавлены");
                }
                else
                {
                    MessageBox.Show("Данные  не добавлены");
                }
            }



        }

        private void InsertDisciplineAdn_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = administraition.Discipline();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
                     
            {    
                int id = int.Parse(textBox1.Text);
                            string name = textBox2.Text;


                MySqlCommand command = new MySqlCommand("SELECT * FROM disciplines  WHERE  Name_disciplines = @name", dataBase.getConnection());

                MySqlDataAdapter adapter = new MySqlDataAdapter();
                command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                DataTable table = new DataTable();


                adapter.SelectCommand = command;

                adapter.Fill(table);




                if (table.Rows.Count == 0)
                {


                    if (administraition.editDiscipline(id, name))
                    {
                        dataGridView1.DataSource = administraition.Discipline();
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

                        textBox1.Text = " ";
                        textBox2.Text = "";
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTableManage timeTableManage = new TimeTableManage();
            timeTableManage.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                   administraition.DelStory())
                {
                    dataGridView1.DataSource = administraition.Discipline();
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