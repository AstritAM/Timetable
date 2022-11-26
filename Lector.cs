using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ghjdthrf
{
    class Lector
    {
        DataBase DataBase = new DataBase();
        public DataTable DataTableLect(int idLec)
        {

            MySqlCommand command = new MySqlCommand("time_table_for_lec", DataBase.getConnection());
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

    }
}
