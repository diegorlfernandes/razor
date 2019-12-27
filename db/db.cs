
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.Sqlite;

namespace  RazorPagesPagination.Pages
{
    public class db
    {
        private static SqliteConnection connection;
        public db(string dbname)
        {
            connection = new SqliteConnection("" + new SqliteConnectionStringBuilder { DataSource = dbname });
            connection.Open();
        }

        public bool inserir(string message)
        {

            SqliteTransaction transaction = connection.BeginTransaction();
            SqliteCommand command = connection.CreateCommand();
            command.Transaction = transaction;
            command.CommandText = "insert into message ( text ) values ( $text )";
            command.Parameters.AddWithValue("$id", 1);
            command.Parameters.AddWithValue("$text", message);
            int ret = command.ExecuteNonQuery();
            transaction.Commit();


            if (ret == 0)
                return true;
            else
                return false;

        }


        public List<Message> SelecionarTodos()
        {
            List<Message> list = new List<Message>();

            

            var dt=new DataTable();
        

            SqliteCommand command = connection.CreateCommand();
            command.CommandText = "SELECT id, text FROM message";
            var reader = command.ExecuteReader();

            while (reader.Read())
            {
                list.Add(new Message(){id=reader.GetInt16(0),message=reader.GetString(1)});
            }

            return list;

        }

    }
}
