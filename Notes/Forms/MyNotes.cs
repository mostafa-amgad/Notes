using Notes.Classes;
using System;
using System.Windows.Forms;

namespace Notes.Forms
{
    public partial class MyNotes : Form
    {
        public MyNotes()
        {
            InitializeComponent();
        }

        private void buttonSignOut_Click(object sender, EventArgs e)
        {
            Hide();
            SignIn signin = new SignIn();
            signin.ShowDialog();
            Close();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            DatabaseConnection.GetInstance().Insert("mosta12", richTextBoxNote.Text, textBoxTitle.Text);
        }
    }
}
