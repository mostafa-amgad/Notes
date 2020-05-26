using Notes.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;

namespace Notes.Forms
{
    public partial class MyNotes : Form
    {
        public MyNotes()
        {
            InitializeComponent();

            labelMyNotes.Text = "Welcome Back, " + Authentication.Username;
        }

        private void MyNotes_Load(object sender, EventArgs e)
        {
            List<Note> notes = DatabaseConnection.GetInstance().GetAll(Authentication.Username);
            for (int i = 0; i < notes.Count; i++)
            {
                dataGridViewNotes.Rows.Add(notes[i].noteTitle, notes[i].note, notes[i].image, "Delete");
            }
        }

        private void buttonAddNote_Click(object sender, EventArgs e)
        {
            Hide();
            AddNote note = new AddNote();
            note.ShowDialog();
            Close();
        }

        private void dataGridViewNotes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DatabaseConnection.GetInstance().Delete(dataGridViewNotes.Rows[e.RowIndex].Cells[0].Value.ToString());
            dataGridViewNotes.Rows.Remove(dataGridViewNotes.Rows[e.RowIndex]);
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            TextFile.WriteInFile("Files\\CurrentUser.txt", "");
            
            Hide();
            SignIn signIn = new SignIn();
            signIn.ShowDialog();
            Close();
        }
    }
}
