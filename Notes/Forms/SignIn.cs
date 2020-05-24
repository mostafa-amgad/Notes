﻿using Notes.Classes;
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
            Authentication.SignIn(textBoxUsername.Text, textBoxPassword.Text).Wait();

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
    }
}