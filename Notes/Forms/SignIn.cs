using Notes.Classes;
using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Diagnostics;

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
            bool isVerified1 = Validate(ref textBoxUsername, " Username is missing.", ref errorProviderUsername);
            bool isVerified2 = Validate(ref textBoxPassword, " Password is missing.", ref errorProviderPassword);

            if(isVerified1 && isVerified2)
            {
                Authentication.SignIn(textBoxUsername.Text, textBoxPassword.Text, true).Wait();

                if (Authentication.GetLoginStatus())
                {
                    TextFile.WriteInFile("Files\\CurrentUser.txt", textBoxUsername.Text);
                    Hide();
                    MyNotes notes = new MyNotes();
                    notes.ShowDialog();
                    Close();
                }
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

        public static bool Validate(ref TextBox textBox, string message, ref ErrorProvider error)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                error.SetError(textBox, message);
                return false;
            }
            else
            {
                error.Clear();
                return true;
            }
        }

        private void textBoxUsername_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxUsername.Text))
            {
                errorProviderUsername.Clear();
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxPassword.Text))
            {
                errorProviderPassword.Clear();
            }
        }
    }
}
