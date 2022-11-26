using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ghjdthrf
{
    class Administraition
    {
        DataBase dataBase = new DataBase();
        // добавление расписания


        public DataTable DataTable()
        {

            MySqlCommand command = new MySqlCommand("time_table_adm", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();

            DataTable table = new DataTable();
            command.CommandType = CommandType.StoredProcedure;

            adapter.SelectCommand = command;

            adapter.Fill(table);

            return table;

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
        public DataTable DayWeek()
        {

            MySqlCommand command = new MySqlCommand("SELECT ID,Name_day AS 'День недели' FROM day_week", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            
            return table;
        }

        public DataTable NumLes()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM num_les", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable NameGroup()
        {

            MySqlCommand command = new MySqlCommand("Grooup_table2", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();
            command.CommandType = CommandType.StoredProcedure;
            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable NameDisciplines()
        { 

            MySqlCommand command = new MySqlCommand("SELECT * FROM disciplines", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable NumAudit()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM class_room", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        public DataTable NumAudit2()
        {

            MySqlCommand command = new MySqlCommand("SELECT  ID AS 'Номер' ,number as 'Номер аудитории', count_tab AS 'Количество мест', Campus AS 'Корпус', Floor AS 'Этаж' FROM class_room", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable NameLect()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM lecturer", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public DataTable NameLect2()
        {

            MySqlCommand command = new MySqlCommand("SELECT ID, concat(Surname,' ',Name,' ',Patronymic) AS nom_prenom FROM lecturer", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        //select concat(NOM_PERSONNE,' ',PRENOM_PERSONNE) as 'nom_prenom' from PERSONNE 
        public int GetDay(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_day FROM datatable WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }

        public int GetLess(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT Numlesson FROM datatable WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }
        public int GetGroup(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_group  FROM datatable WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }
        public int Getdis(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_disciplines FROM datatable WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }
        public int Getdis2(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_disciplines FROM lecturer WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }
        public int GetNC(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_numclassroom FROM datatable WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }

        public int GetLec(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_lecturer FROM datatable WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }
        public int GetSpe(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_specialty FROM grooup WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }
        public int GetDep(int num)
        {

            MySqlCommand command = new MySqlCommand("SELECT ID_departament FROM lecturer WHERE ID=@num", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            command.Parameters.Add("@num", MySqlDbType.Int32).Value = num;
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return int.Parse(table.Rows[0][0].ToString());
        }


        public bool addTimeTable(int day, int numles, int namegrp, int namedis, int numaudit,int namelec)
        {
            try
            {
                MySqlCommand command = new MySqlCommand();
                String innsertQuery = "INSERT INTO datatable(ID_day, Numlesson, ID_group, ID_disciplines,ID_numclassroom,ID_lecturer ) VALUES (@day,@numles,@namegrp,@namedis,@numaudit,@namelec)";
                command.CommandText = innsertQuery;
                command.Connection = dataBase.getConnection();
               // command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@day", MySqlDbType.Int32).Value = day;
                command.Parameters.Add("@numles", MySqlDbType.Int32).Value = numles;
                command.Parameters.Add("@namegrp", MySqlDbType.Int32).Value = namegrp;
                command.Parameters.Add("@namedis", MySqlDbType.Int32).Value = namedis;
                command.Parameters.Add("@numaudit", MySqlDbType.Int32).Value = numaudit;
                command.Parameters.Add("@namelec", MySqlDbType.Int32).Value = namelec;
               


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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool editTimeTable(int number, int day, int numles, int namegrp, int namedis, int numaudit, int namelec)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE datatable SET ID_day=@day, Numlesson=@numles,ID_group=@namegrp,ID_disciplines=@namedis,ID_numclassroom=@numaudit,ID_lecturer=@namelec WHERE ID=@number";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            // command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@number", MySqlDbType.Int32).Value = number;
            command.Parameters.Add("@day", MySqlDbType.Int32).Value = day;
            command.Parameters.Add("@numles", MySqlDbType.Int32).Value = numles;
            command.Parameters.Add("@namegrp", MySqlDbType.Int32).Value = namegrp;
            command.Parameters.Add("@namedis", MySqlDbType.VarChar).Value = namedis;
            command.Parameters.Add("@numaudit", MySqlDbType.VarChar).Value = numaudit;
            command.Parameters.Add("@namelec", MySqlDbType.VarChar).Value = namelec;

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

        }
        public bool DelDataTable(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM datatable  WHERE ID=@id;";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            // command.CommandType = CommandType.StoredProcedure;
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

        }




        //end insert

        //disciplin
        public DataTable Discipline()
        {

            MySqlCommand command = new MySqlCommand("SELECT ID AS 'Номер',Name_disciplines 'Название предмета' FROM disciplines", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }


        public DataTable Depart()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM departament", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool InsertDiscipline(string name)
        {
            try
            {
                MySqlCommand command = new MySqlCommand();
                String innsertQuery = "INSERT INTO disciplines (Name_disciplines) VALUES (@name) ";
                command.CommandText = innsertQuery;
                command.Connection = dataBase.getConnection();
              //3  command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        
        public bool editDiscipline(int id,string name)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE disciplines SET Name_disciplines = @name WHERE ID=@id";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
           // command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
        

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

        }
        public bool editGroup(int id, string name, int countSt,int specid)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE grooup SET Name_group = @name,Сount_studets=@countSt,Faculty=@fac, ID_specialty=@specid WHERE ID=@id";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            // command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@countSt", MySqlDbType.Int32).Value = countSt;
            command.Parameters.Add("@fac", MySqlDbType.VarChar).Value = "ИиВТ";
            command.Parameters.Add("@specid", MySqlDbType.Int32).Value = specid;


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

        }

        //insert group

        public DataTable Spec()
        {

            MySqlCommand command = new MySqlCommand("SELECT * FROM specialty", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }
        public bool InsertGroup(string name, int countSt, int spec)
        {
            try
            {
                MySqlCommand command = new MySqlCommand();
                String innsertQuery = "inst_group";
                command.CommandText = innsertQuery;
                command.Connection = dataBase.getConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@countSt", MySqlDbType.Int32).Value = countSt;
                command.Parameters.Add("@spec", MySqlDbType.Int32).Value = spec;
                



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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public bool DelGroup(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM grooup  WHERE ID=@id;";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            // command.CommandType = CommandType.StoredProcedure;
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

        }


        //lecturer

        public DataTable Lecturer()
        {

            MySqlCommand command = new MySqlCommand("SELECT lecturer.ID AS 'Номер',lecturer.Name AS 'Имя',lecturer.Surname AS 'Фамилия', lecturer.Patronymic AS 'Отчество', disciplines.Name_disciplines AS 'Дисциплина', departament.Name_departament AS 'Кафедра', lecturer.Phone AS 'Телефон'FROM lecturer INNER JOIN disciplines ON disciplines.ID=lecturer.ID_disciplines  INNER JOIN departament ON departament.ID=lecturer.ID_departament", dataBase.getConnection());
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            DataTable table = new DataTable();

            adapter.SelectCommand = command;
            adapter.Fill(table);

            return table;
        }

        public bool InsertLecturer(string name, string surname, string patronymic, int dis, int depr, string phone)
        {
            try
            {
                MySqlCommand command = new MySqlCommand();
                String innsertQuery = "inst_lecturer";
                command.CommandText = innsertQuery;
                command.Connection = dataBase.getConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
                command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname;
                command.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = patronymic;
                command.Parameters.Add("@dis", MySqlDbType.Int32).Value = dis;
                command.Parameters.Add("@depr", MySqlDbType.Int32).Value = depr;
                command.Parameters.Add("@phone", MySqlDbType.VarChar).Value = phone;

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }
        public bool ediLector(int id, string name, string surname, string patronymic, int dis, int depr, string phone)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE lecturer SET Name = @name,Surname=@surname,Patronymic=@patronymic, 	ID_disciplines=@dis,ID_departament=@depr,	Phone=@phone WHERE ID=@id";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            // command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = name;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = surname; 
            command.Parameters.Add("@patronymic", MySqlDbType.VarChar).Value = patronymic;
            command.Parameters.Add("@dis", MySqlDbType.Int32).Value = dis;
          
            command.Parameters.Add("@depr", MySqlDbType.Int32).Value = depr;
            command.Parameters.Add("@phone", MySqlDbType.Int32).Value = phone;



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

        }

        public bool DelLec(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE  FROM lecturer  WHERE ID=@id;";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
           // command.CommandType = CommandType.StoredProcedure;
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

        }

        // audit

        public bool InsertAudit( int numaudit ,int countTab , int cam ,int floor )
        {
            try
            {
                MySqlCommand command = new MySqlCommand();
                String innsertQuery = "inst_auditor";
                command.CommandText = innsertQuery;
                command.Connection = dataBase.getConnection();
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.Add("@numaudit", MySqlDbType.Int32).Value = numaudit;
                command.Parameters.Add("@countTab", MySqlDbType.Int32).Value = countTab;
                command.Parameters.Add("@cam", MySqlDbType.Int32).Value = cam;
                command.Parameters.Add("@floor", MySqlDbType.Int32).Value = floor;




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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }

        }

        public bool editAudit(int id, int countSt, int camp,int floor)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "UPDATE grooup SET count_tab = @countSt,Campus=@camp, 	Floor=@floor WHERE ID=@id";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;
            
            command.Parameters.Add("@countSt", MySqlDbType.Int32).Value = countSt;
            command.Parameters.Add("@camp", MySqlDbType.Int32).Value = camp;
            command.Parameters.Add("@floor", MySqlDbType.Int32).Value = floor;


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

        }
        public bool DelAudit(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM class_room  WHERE ID=@id;";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
           // command.CommandType = CommandType.StoredProcedure;
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

        }

        public bool DelDis(int id)
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM disciplines   WHERE ID=@id;";
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

        public bool DelStory()
        {
            MySqlCommand command = new MySqlCommand();
            string editQuery = "DELETE FROM story_help ORDER BY ID DESC LIMIT 1 ";
            command.CommandText = editQuery;
            command.Connection = dataBase.getConnection();
            // command.CommandType = CommandType.StoredProcedure;
           // command.Parameters.Add("@id", MySqlDbType.Int32).Value = id;



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

        }

    }
}
