namespace Notes.Forms
{
    partial class MyNotes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.informationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notesDataSet = new Notes.notesDataSet();
            this.informationTableAdapter = new Notes.notesDataSetTableAdapters.informationTableAdapter();
            this.buttonAddNote = new System.Windows.Forms.Button();
            this.labelMyNotes = new System.Windows.Forms.Label();
            this.dataGridViewNotes = new System.Windows.Forms.DataGridView();
            this.buttonSignOut = new System.Windows.Forms.Button();
            this.noteTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.note = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.image = new System.Windows.Forms.DataGridViewImageColumn();
            this.ShowEdit = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Delete = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.informationBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notesDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotes)).BeginInit();
            this.SuspendLayout();
            // 
            // informationBindingSource
            // 
            this.informationBindingSource.DataMember = "information";
            this.informationBindingSource.DataSource = this.notesDataSet;
            // 
            // notesDataSet
            // 
            this.notesDataSet.DataSetName = "notesDataSet";
            this.notesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // informationTableAdapter
            // 
            this.informationTableAdapter.ClearBeforeFill = true;
            // 
            // buttonAddNote
            // 
            this.buttonAddNote.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAddNote.Location = new System.Drawing.Point(872, 12);
            this.buttonAddNote.Name = "buttonAddNote";
            this.buttonAddNote.Size = new System.Drawing.Size(38, 35);
            this.buttonAddNote.TabIndex = 1;
            this.buttonAddNote.Text = "+";
            this.buttonAddNote.UseVisualStyleBackColor = true;
            this.buttonAddNote.Click += new System.EventHandler(this.buttonAddNote_Click);
            // 
            // labelMyNotes
            // 
            this.labelMyNotes.AutoSize = true;
            this.labelMyNotes.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMyNotes.Location = new System.Drawing.Point(12, 9);
            this.labelMyNotes.Name = "labelMyNotes";
            this.labelMyNotes.Size = new System.Drawing.Size(109, 29);
            this.labelMyNotes.TabIndex = 2;
            this.labelMyNotes.Text = "My Notes";
            // 
            // dataGridViewNotes
            // 
            this.dataGridViewNotes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewNotes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.noteTitle,
            this.note,
            this.image,
            this.ShowEdit,
            this.Delete});
            this.dataGridViewNotes.Location = new System.Drawing.Point(13, 62);
            this.dataGridViewNotes.Name = "dataGridViewNotes";
            this.dataGridViewNotes.Size = new System.Drawing.Size(897, 387);
            this.dataGridViewNotes.TabIndex = 3;
            this.dataGridViewNotes.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewNotes_CellContentClick);
            // 
            // buttonSignOut
            // 
            this.buttonSignOut.Location = new System.Drawing.Point(12, 455);
            this.buttonSignOut.Name = "buttonSignOut";
            this.buttonSignOut.Size = new System.Drawing.Size(104, 23);
            this.buttonSignOut.TabIndex = 4;
            this.buttonSignOut.Text = "Sign Out";
            this.buttonSignOut.UseVisualStyleBackColor = true;
            this.buttonSignOut.Click += new System.EventHandler(this.buttonSignOut_Click);
            // 
            // noteTitle
            // 
            this.noteTitle.FillWeight = 200F;
            this.noteTitle.HeaderText = "Note Title";
            this.noteTitle.Name = "noteTitle";
            this.noteTitle.ReadOnly = true;
            this.noteTitle.Width = 200;
            // 
            // note
            // 
            this.note.FillWeight = 300F;
            this.note.HeaderText = "Note";
            this.note.Name = "note";
            this.note.ReadOnly = true;
            this.note.Width = 300;
            // 
            // image
            // 
            this.image.FillWeight = 150F;
            this.image.HeaderText = "Image";
            this.image.Name = "image";
            this.image.ReadOnly = true;
            this.image.Width = 150;
            // 
            // ShowEdit
            // 
            this.ShowEdit.HeaderText = "Show / Edit";
            this.ShowEdit.Name = "ShowEdit";
            // 
            // Delete
            // 
            this.Delete.HeaderText = "Delete";
            this.Delete.Name = "Delete";
            // 
            // MyNotes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(922, 490);
            this.Controls.Add(this.buttonSignOut);
            this.Controls.Add(this.dataGridViewNotes);
            this.Controls.Add(this.labelMyNotes);
            this.Controls.Add(this.buttonAddNote);
            this.Name = "MyNotes";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "My Notes";
            this.Load += new System.EventHandler(this.MyNotes_Load);
            ((System.ComponentModel.ISupportInitialize)(this.informationBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notesDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewNotes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private notesDataSet notesDataSet;
        private System.Windows.Forms.BindingSource informationBindingSource;
        private notesDataSetTableAdapters.informationTableAdapter informationTableAdapter;
        private System.Windows.Forms.Button buttonAddNote;
        private System.Windows.Forms.Label labelMyNotes;
        private System.Windows.Forms.DataGridView dataGridViewNotes;
        private System.Windows.Forms.Button buttonSignOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn note;
        private System.Windows.Forms.DataGridViewImageColumn image;
        private System.Windows.Forms.DataGridViewButtonColumn ShowEdit;
        private System.Windows.Forms.DataGridViewButtonColumn Delete;
    }
}