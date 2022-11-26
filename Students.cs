using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghjdthrf
{
    class Students
    {
        DataBase DataBase = new DataBase();
        public DataTable GroupName()
        {

            MySqlCommand command = new MySqlCommand("group_name", DataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable DataTableStud(int idGroup,int day)
        {

            MySqlCommand command = new MySqlCommand("time_table", DataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
  
            DataTable table = new DataTable();
            command.CommandType= CommandType.StoredProcedure;
           command.Parameters.Add("@id", MySqlDbType.Int32).Value = idGroup;
            command.Parameters.Add("@day", MySqlDbType.Int32).Value = day;
            adapter.SelectCommand = command;
          
            adapter.Fill(table);
  
            return table;

        }

            public DataTable LecterName()
        {

            MySqlCommand command = new MySqlCommand("SELECT ID, concat(Surname,' ',Name,' ',Patronymic) AS nom_prenom FROM lecturer", DataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable DataTableLect(int idLec)
        {

            MySqlCommand command = new MySqlCommand("time_table_lec", DataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@idLec", MySqlDbType.Int32).Value = idLec;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }

        public DataTable NumAudit()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM class_room", DataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable DataTableAudit(int idClass)
        {

            MySqlCommand command = new MySqlCommand("time_table_class", DataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@groupid", MySqlDbType.Int32).Value = idClass;
            adapter.SelectCommand = command;
            adapter.Fill(table);
            return table;
        }
    }

    class DataBase
    {
        MySqlConnection connection = new MySqlConnection("host=localhost;port=3306;user=root;password=root;database=datatable2");
        public MySqlConnection getConnection()
        {
            return connection;
        }

        public void openConnection()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();

            }
        }
        public void closeConnection()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();

            }
        }

    } 
}