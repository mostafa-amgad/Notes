using Notes.Classes;
using System;
using System.Windows.Forms;

namespace Notes.Forms
{
    public partial class AddNote : Form
    {
        public AddNote()
        {
            InitializeComponent();
        }
        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            GoToHomePage();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DatabaseConnection.GetInstance().Insert(Authentication.Username, richTextBoxNote.Text, textBoxTitle.Text);

            GoToHomePage();
        }

        void GoToHomePage()
        {
            Hide();
            MyNotes notes = new MyNotes();
            notes.ShowDialog();
            Close();
        }
    }
}
