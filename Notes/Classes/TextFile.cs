using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Notes.Classes
{
    public class TextFile
    {
        public static void WriteInFile(string fileName, string addToFile)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    File.Delete(fileName);
                }

                using (FileStream fileStream = File.Create(fileName))
                {
                    Byte[] txt = new UTF8Encoding(true).GetBytes(addToFile);
                    fileStream.Write(txt, 0, txt.Length);
                }
            }
            catch
            {
                MessageBox.Show("Erorr!");
            }
        }

        public static string ReadFromFile(string fileName)
        {
            try
            {
                string txt = "";
                using (StreamReader reader = File.OpenText(fileName))
                {
                    txt = reader.ReadLine();
                }
                return txt;
            }
            catch
            {
                MessageBox.Show("Erorr!");
            }
            return null;
        }
    }
}
