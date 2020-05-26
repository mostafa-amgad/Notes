using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notes.Classes
{
    public class Note
    {
        public string noteTitle { get; set; }
        public string note { get; set; }

        public Image image { get; set; }

        public Note(string note, string noteTitle, Bitmap image)
        {
            this.note = note;
            this.noteTitle = noteTitle;
            this.image = image;
        }

        public Note()
        {
            note = null;
            noteTitle = null;
            image = null;
        }
    }
}
