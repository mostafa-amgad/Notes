using Notes.Classes;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace Notes.Forms
{
    public partial class MyNotes : Form
    {
        Timer listenier = new Timer();
        List<Note> notes;

        public MyNotes()
        {
            InitializeComponent();

            labelMyNotes.Text = "Welcome Back, " + Authentication.Username;

            listenier.Tick += Listenier_Tick;
            listenier.Interval = 10000;
        }

        private void Listenier_Tick(object sender, EventArgs e)
        {
            UpdateTable();
            Debug.WriteLine(notes.Count);
        }

        private void MyNotes_Load(object sender, EventArgs e)
        {
            UpdateTable();
            listenier.Start();
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
            if (e.ColumnIndex == dataGridViewNotes.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                string title = dataGridViewNotes.Rows[e.RowIndex].Cells[0].Value.ToString();
                DatabaseConnection.GetInstance().Delete(title);
                dataGridViewNotes.Rows.Remove(dataGridViewNotes.Rows[e.RowIndex]);
            }
            else if (e.ColumnIndex == dataGridViewNotes.Columns["ShowEdit"].Index && e.RowIndex >= 0)
            {
                Hide();
                AddNote note = new AddNote();
                string title = dataGridViewNotes.Rows[e.RowIndex].Cells[0].Value.ToString();
                string noteContent = dataGridViewNotes.Rows[e.RowIndex].Cells[1].Value.ToString();
                int noteId = int.Parse(dataGridViewNotes.Rows[e.RowIndex].Cells[5].Value.ToString());
                note.SetValues(title, noteContent, noteId);
                note.ShowDialog();
                Close();
            }
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            TextFile.WriteInFile("Files\\CurrentUser.txt", "");
            
            Hide();
            SignIn signIn = new SignIn();
            signIn.ShowDialog();
            Close();
        }

        void UpdateTable()
        {
            notes = DatabaseConnection.GetInstance().GetAll(Authentication.Username);

            dataGridViewNotes.Rows.Clear();
            for (int i = 0; i < notes.Count; i++)
            {
                dataGridViewNotes.Rows.Add(notes[i].noteTitle, notes[i].note, notes[i].image, "Show / Edit", "Delete", notes[i].noteId);
            }
        }
    }
}
