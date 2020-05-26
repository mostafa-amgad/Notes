using Notes.Classes;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Notes.Forms
{
    public partial class AddNote : Form
    {
        Bitmap image = null;
        string oldTitle;
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

            bool isVerified = SignIn.Validate(ref textBoxTitle, " Title is missing ", ref errorProviderTitle);

            if(!isFirstTime && richTextBoxNote.Text != "" && isVerified && buttonAdd.Text == "Add Note")
            {
                DatabaseConnection.GetInstance().Insert(Authentication.Username, richTextBoxNote.Text, textBoxTitle.Text, image);

                GoToHomePage();
            }
            else if(!isFirstTime && richTextBoxNote.Text != "" && isVerified && buttonAdd.Text == "Save Note")
            {
                DatabaseConnection.GetInstance().Update(oldTitle,textBoxTitle.Text, richTextBoxNote.Text);

                GoToHomePage();
            }
        }
        
        void GoToHomePage()
        {
            Hide();
            MyNotes notes = new MyNotes();
            notes.ShowDialog();
            Close();
        }

        bool isFirstTime = true;

        private void richTextBoxNote_Enter(object sender, EventArgs e)
        {
            if (isFirstTime)
            {
                isFirstTime = false;
                richTextBoxNote.Text = "";
                richTextBoxNote.ForeColor = Color.Black;
            }
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(textBoxTitle.Text))
            {
                errorProviderTitle.Clear();
            }
        }

        private void buttonAddImage_Click(object sender, EventArgs e)
        {  
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp";
            if (open.ShowDialog() == DialogResult.OK)
            {
                image = new Bitmap(open.FileName);
            }
        }

        public void SetValues(string title, string note)
        {
            richTextBoxNote.ForeColor = Color.Black;
            textBoxTitle.Text = title;
            oldTitle = textBoxTitle.Text;
            richTextBoxNote.Text = note;

            labeladdnote.Text = "Edit Your Note";
            buttonAdd.Text = "Save Note";
            isFirstTime = false;
        }
    }
}
