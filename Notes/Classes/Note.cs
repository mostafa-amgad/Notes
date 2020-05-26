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
        public int noteId { get; set; }
        public string noteTitle { get; set; }
        public string note { get; set; }

        public Image image { get; set; }

        public Note(int noteId, string note, string noteTitle, Bitmap image)
        {
            this.noteId = noteId;
            this.note = note;
            this.noteTitle = noteTitle;
            this.image = image;
        }

        public Note()
        {
            noteId = -1;
            note = null;
            noteTitle = null;
            image = null;
        }
    }
}
