using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using MySql.Data.MySqlClient;


namespace ghjdthrf
{
    public partial class TimeTableManage : Form
    {
        public TimeTableManage()
        {
            InitializeComponent();
        }

        Administraition admin = new Administraition();
        DataBase dataBase = new DataBase();
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void TimeTableManage_Load(object sender, EventArgs e)

        {
            dataGridView1.DataSource = admin.DataTable();
            comboBox1.DataSource = admin.DayWeek();
            comboBox1.DisplayMember = "День недели";
            comboBox1.ValueMember = "ID";

            comboBox2.DataSource = admin.NumLes();
            comboBox2.DisplayMember = "ID";
            comboBox2.ValueMember = "ID";

            comboBox3.DataSource = admin.NameGroup();
            comboBox3.DisplayMember = "Название группы";
            comboBox3.ValueMember = "ID";

            comboBox4.DataSource = admin.NameDisciplines();
            comboBox4.DisplayMember = "Name_disciplines";
            comboBox4.ValueMember = "ID";

            comboBox5.DataSource = admin.NumAudit();
            comboBox5.DisplayMember = "number";
            comboBox5.ValueMember = "ID";

            comboBox6.DataSource = admin.NameLect2();
            comboBox6.DisplayMember = "nom_prenom";
            comboBox6.ValueMember = "ID";

        }
        public DataTable DataTableaDM()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM datatable", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();
            command.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            return table;

        }

        private void AddTimeT_Click(object sender, EventArgs e)
        {
            int day = int.Parse(comboBox1.SelectedValue.ToString());
            int numles = int.Parse(comboBox2.SelectedValue.ToString());
            int namegr = int.Parse(comboBox3.SelectedValue.ToString());
            int namedis = int.Parse(comboBox4.SelectedValue.ToString());
            int numaudit = int.Parse(comboBox5.SelectedValue.ToString());
            int namelec = int.Parse(comboBox6.SelectedValue.ToString());

            MySqlCommand command = new MySqlCommand("SELECT * FROM datatable WHERE ID_day= @day AND Numlesson = @numles", dataBase.getConnection());
           
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@day", MySqlDbType.Int32).Value = day;
            command.Parameters.Add("@numles", MySqlDbType.Int32).Value = numles;
            DataSet table = new DataSet();


            adapter.SelectCommand = command;

            adapter.Fill(table);

            int r = 0;
          
            

            foreach (DataTable ds in table.Tables) {
                if (ds.Rows.Count != 0)
                {
                    foreach (DataRow datarow in ds.Rows)

                    {


                        if (Convert.ToInt32(datarow[2]) == numles)
                        {

                            if (Convert.ToInt32(datarow[3]) == namegr || Convert.ToInt32(datarow[6]) == namelec || Convert.ToInt32(datarow[5]) == numaudit)
                            {
                                MessageBox.Show("Неверно");
                                break;
                            }
                            else if (Convert.ToInt32(ds.Rows.IndexOf(datarow)) >= ds.Rows.Count - 1)
                            {
                                if (admin.addTimeTable(day, numles, namegr, namedis, numaudit, namelec))
                                {
                                    dataGridView1.DataSource = admin.DataTable();
                                    MessageBox.Show("Данные удачно добавлены");
                                    break;
                                }
                                else
                                {

                                    MessageBox.Show("Данные неудачно добавлен");
                                    break;
                                }

                            }
                        }



                    }
                }
                
                
                 else   if (admin.addTimeTable(day, numles, namegr, namedis, numaudit, namelec))
                    {

                        MessageBox.Show("Данные удачно добавлен");
                        break;
                    }
                    else
                    {

                        MessageBox.Show("Данные неудачно добавлен");
                        break;
                    }

                

                }

            dataGridView1.DataSource = admin.DataTable();


        }
        //group
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertGroupAdm insertGroup = new InsertGroupAdm();
            insertGroup.Show();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                int num = int.Parse(textBox1.Text);
                int day = int.Parse(comboBox1.SelectedValue.ToString());
                int numles = int.Parse(comboBox2.SelectedValue.ToString());
                int namegr = int.Parse(comboBox3.SelectedValue.ToString());
                int namedis = int.Parse(comboBox4.SelectedValue.ToString());
                int numaudit = int.Parse(comboBox5.SelectedValue.ToString());
                int namelec = int.Parse(comboBox6.SelectedValue.ToString());



                if (admin.editTimeTable(num, day, numles, namegr, namedis, numaudit, namelec))
                {
                    dataGridView1.DataSource = admin.DataTable();
                    MessageBox.Show("Данные удачно изменены");
                }
                else
                {
                    MessageBox.Show("Данные  не изменить");
                }
       
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            textBox1.Text = " ";
        }


        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int num = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            comboBox1.SelectedValue = admin.GetDay(num);
            comboBox2.SelectedValue = admin.GetLess(num);

            comboBox3.SelectedValue = admin.GetGroup(num);
            comboBox4.SelectedValue = admin.Getdis(num);
            comboBox5.SelectedValue = admin.GetNC(num);
            comboBox6.SelectedValue = admin.GetLec(num);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertDisciplineAdn disciplineAdn = new InsertDisciplineAdn();
            disciplineAdn.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                if (admin.DelDataTable(id))
                {
                    dataGridView1.DataSource = admin.DataTable();
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertLecturerAdm insertLecturer = new InsertLecturerAdm();
            insertLecturer.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertAuditorAdmin insertAuditor = new InsertAuditorAdmin();
            insertAuditor.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 form1 = new Form1();
            form1.Show();
        }

        Get_Back get_Back = new Get_Back();
        private void button8_Click(object sender, EventArgs e)
        {
            this.Hide();
            get_Back.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                if (
                   admin.DelStory())
                {
                    dataGridView1.DataSource = admin.DataTable();
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


        private void button11_Click(object sender, EventArgs e)
        {
            DateTime date = new DateTime();
            string d = DateTime.Now.Year.ToString() + DateTime.Now.Month.ToString() + DateTime.Now.Day.ToString() + DateTime.Now.Hour.ToString()
            + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString();

            //cmd с указанием пути до pg_dump с параметром
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = @"C:\MAMP\bin\mysql\bin\";
            //C:\Program Files\PostgreSQL\12\bin\pg_dump.exe —file "C:\\Users\\sulin\\Desktop\\1.sql" —host "localhost" —port "7777" —username "postgres" —no-password —verbose —format=c —blobs —encoding "UTF8" "Autodiller 1.0"
            p.StartInfo.Arguments = @"/k mysqldump.exe -u root -p datatable > C:\MAMP\bin\mysql\bin\"+d +".sql";
            p.Start();
            MessageBox.Show("Успешно!");
            p.Close();
        }

        private void button10_Click_1(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "SQL file (*.sql)|*.sql|All files(*.*)|*.*";
            string pathdb = "";
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл 
            pathdb = openFileDialog1.FileName;

            //cmd с указанием пути до pg_dump с параметром 
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.WorkingDirectory = @"C:\MAMP\bin\mysql\bin\";
            p.StartInfo.Arguments = @"/k mysql.exe -u root -p test < "+pathdb ;
            p.Start();
            MessageBox.Show("Успешно!");
            p.Close();
        }
    }
}
