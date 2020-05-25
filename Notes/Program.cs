using Notes.Classes;
using Notes.Forms;
using System;
using System.Windows.Forms;

namespace Notes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Authentication.Username = TextFile.ReadFromFile("Files\\CurrentUser.txt");
            if (Authentication.Username == null || Authentication.Username == "")
            {
                Application.Run(new SignIn());
            }
            else
            {
                Application.Run(new MyNotes());
            }

        }
    }
}
