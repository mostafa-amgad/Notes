using System;
using System.Collections.Generic;
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
            finally
            {
                connection.Close();
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
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@note", note);
                command.Parameters.AddWithValue("@notetitle", noteTitle);

                command.ExecuteNonQuery();
                MessageBox.Show("Your note has been added");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }
        
        public void Delete(string noteTitle)
        {
            string query = "DELETE FROM information WHERE notetitle = @notetitle";

            try
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@notetitle", noteTitle);
                command.ExecuteNonQuery();
                MessageBox.Show("Your data has been deleted");
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }
            finally
            {
                connection.Close();
            }
        }

        public List<Note> GetAll(string username)
        {
            string query = "SELECT * FROM information WHERE username = @username";
            try
            {
                connection.Open();
                List<Note> notes = new List<Note>();
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@username", username);

                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Note note = new Note();
                        note.noteTitle = reader["notetitle"].ToString();
                        note.note = reader["note"].ToString();
                        //note.image = reader["image"].GetType();
                        notes.Add(note);
                    }
                }
                connection.Close();
                return notes;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
                return null;
            }
        }
    }
}
