using Notes.Classes;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
namespace Notes.Forms
{
    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {
            TextFile.WriteInFile("Files\\CurrentUser.txt", textBoxUsername.Text);
            Authentication.SignIn(textBoxUsername.Text, textBoxPassword.Text, true).Wait();

            if(Authentication.GetLoginStatus())
            {
                Hide();
                MyNotes notes = new MyNotes();
                notes.ShowDialog();
                Close();
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            Hide();
            SignUp signup = new SignUp();
            signup.ShowDialog();
            Close();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBoxShowPassword.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
