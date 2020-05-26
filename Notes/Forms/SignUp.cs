using Notes.Classes;
using System;
using System.Windows.Forms;

namespace Notes.Forms
{
    public partial class SignUp : Form
    {
        Timer listenier = new Timer();
        bool isVerified1;
        bool isVerified3;
        bool isVerified2;

        public SignUp()
        {
            InitializeComponent();
            listenier.Tick += SignUpListenier;
            listenier.Interval = 5000;
        }

        private void SignUpListenier(object sender, EventArgs e)
        {
            Authentication.SignIn(textBoxUsername.Text, textBoxPassword.Text, false).Wait();

            if (Authentication.GetLoginStatus())
            {
                TextFile.WriteInFile("Files\\CurrentUser.txt", textBoxUsername.Text);
                
                listenier.Stop();
                Cursor = Cursors.Default;
                Hide();
                MyNotes notes = new MyNotes();
                notes.ShowDialog();
                Close();
            }
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            isVerified1 = SignIn.Validate(ref textBoxEmail, " Email is missing", ref errorProviderEmail);
            isVerified2 = SignIn.Validate(ref textBoxUsername, " Username is missing", ref errorProviderUsername);
            isVerified3 = SignIn.Validate(ref textBoxPassword, " Password is missing", ref errorProviderPassword);


            if (isVerified1 && isVerified2 && isVerified3)
            {
                Authentication.SignUp(textBoxEmail.Text, textBoxUsername.Text, textBoxPassword.Text).Wait();

                Cursor = Cursors.WaitCursor;
                listenier.Start();
            }
        }

        private void buttonGoBack_Click(object sender, EventArgs e)
        {
            Hide();
            SignIn signin = new SignIn();
            signin.ShowDialog();
            Close();
        }

        private void checkBoxShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxShowPassword.Checked)
            {
                textBoxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                textBoxPassword.UseSystemPasswordChar = true;
            }
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if((!textBoxEmail.Text.Contains("@") && !textBoxEmail.Text.Contains(".com")) 
                || (!textBoxEmail.Text.Contains("@") && !textBoxEmail.Text.Contains(".edu")))
            {
                errorProviderEmail.SetError(textBoxEmail, " Please Enter a valid email");
            }
            else if (!string.IsNullOrEmpty(textBoxEmail.Text))
            {
                errorProviderEmail.Clear();
            }
        }
    }
}
