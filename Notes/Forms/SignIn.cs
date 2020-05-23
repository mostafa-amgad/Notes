using Notes.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            Authentication.SignIn(textBoxUsername.Text, textBoxPassword.Text).Wait();
        }

        private void buttonSignUp_Click(object sender, EventArgs e)
        {
            Hide();
            SignUp signup = new SignUp();
            signup.ShowDialog();
            Close();
        }
    }
}
