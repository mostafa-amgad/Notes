using System;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Notes.Classes
{
    public class DatabaseConnection
    {
        SqlConnection connection;
        static DatabaseConnection database = null;
        
        private DatabaseConnection()
        {
            connection = new SqlConnection("Data Source=notes.cvcn6tphuxi8.us-east-1.rds.amazonaws.com;Initial Catalog=notes;User ID=admin;Password=12345678");
            try
            {
                connection.Open(); 
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public static DatabaseConnection GetInstance()
        {
            if(database == null)
            {
                database = new DatabaseConnection();
            }

            return database;
        }

        public void Insert(string username, string note, string noteTitle)
        {
            string query = "INSERT INTO information (username, note, notetitle)";
            query += " VALUES (@username, @note, @notetitle)";

            try
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@note", note);
                command.Parameters.AddWithValue("@notetitle", noteTitle);

                command.ExecuteNonQuery();
                MessageBox.Show("Your Note Has been added");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }
        
        public void Delete()
        {

        }

        public void GetAll()
        {

        }
    }
}
