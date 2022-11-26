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
    public partial class Get_Back : Form
    {
        public Get_Back()
        {
            InitializeComponent();
        }
        DataBase dataBase = new DataBase();
        public DataTable StoryHelp()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM story_help", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
      
        public bool StoryDel(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM story_help WHERE ID = @id";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            //  command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;



            dataBase.openConnection();

            if (command.ExecuteNonQuery() == 1)
            {
                dataBase.closeConnection();
                return true;
            }
            else
            {
                dataBase.closeConnection();
                return false;
            }
            //
        }

        private void Get_Back_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = StoryHelp();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int id= Convert.ToInt32(textBox1.Text);
            try
            {
                if (StoryDel(id))
                {
                    dataGridView1.DataSource =StoryHelp();
                    MessageBox.Show("Данные удачно удалитны");
                }
                else
                {
                    MessageBox.Show("Данные  не удалось удалины");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTableManage timeTableManage = new TimeTableManage();
            timeTableManage.Show();
        }
    }
}
