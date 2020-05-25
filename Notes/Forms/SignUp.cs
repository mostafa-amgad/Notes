using Notes.Classes;
using System;
using System.Windows.Forms;

namespace Notes.Forms
{
    public partial class SignUp : Form
    {
        public SignUp()
        {
            InitializeComponent();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            Authentication.SignUp(textBoxEmail.Text, textBoxUsername.Text, textBoxPassword.Text).Wait();
            TextFile.WriteInFile("Files\\CurrentUser.txt", textBoxUsername.Text);
            if(Authentication.GetLoginStatus())
            {
                Hide();
                MyNotes notes = new MyNotes();
                notes.ShowDialog();
                Close();
            }
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            Hide();
            SignIn signin = new SignIn();
            signin.ShowDialog();
            Close();
        }
    }
}
