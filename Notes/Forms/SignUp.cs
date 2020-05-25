using Notes.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Debug.WriteLine(textBoxEmail.Text.ToString());
            Authentication.SignUp(textBoxEmail.Text, textBoxUsername.Text, textBoxPassword.Text).Wait();

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
