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
    public partial class InsertAuditorAdmin : Form
    {
        public InsertAuditorAdmin()
        {
            InitializeComponent();
        }

        Administraition administraition = new Administraition();

        private void button8_Click(object sender, EventArgs e)
        {
            try { 
            int numaudit = int.Parse( textBox1.Text);
            int countTab = int.Parse(textBox2.Text);
            int cam = int.Parse(textBox3.Text);
            int floor = int.Parse(textBox4.Text);

            if (administraition.InsertAudit(numaudit, countTab, cam, floor))
            {
                dataGridView1.DataSource = administraition.NumAudit2();
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

private void InsertAuditorAdmin_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = administraition.NumAudit2();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text= dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text= dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text= dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text= dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(textBox1.Text);
                int countSt = int.Parse(textBox2.Text);
                int camp = int.Parse(textBox3.Text);
                int floor = int.Parse(textBox4.Text);



                if (administraition.editAudit(id, countSt, camp, floor))
                {
                    dataGridView1.DataSource = administraition.NumAudit();
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

        private void button6_Click(object sender, EventArgs e)
        {
                try { 
                int id = int.Parse(textBox1.Text);
                    if (administraition.DelAudit(id))
                    {
                        dataGridView1.DataSource = administraition.NumAudit2();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            TimeTableManage timeTableManage = new TimeTableManage();
            timeTableManage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if(
                   administraition.DelStory())
                {
                    dataGridView1.DataSource = administraition.NumAudit2();
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
