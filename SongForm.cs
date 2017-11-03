using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win_forms
{
    public partial class SongForm : Form
    {
        private SongModel _song;
        public SongForm(SongModel song)
        {
            this._song = song;
            InitializeComponent();
        }

        public string Title
        {
            get { return titleTextBox.Text; }
        }

        public string Author
        {
            get { return authorTextBox.Text; }
        }

        public string Genre
        {
            get { return genreTextBox.Text; }
        }

        public int Year
        {
            get { return int.Parse(dateTextBox.Text); }
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
                DialogResult = DialogResult.OK;
        }

        private void authorTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void authorTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (authorTextBox.Text.Length > 0)
                return;
            e.Cancel = true;
            errorProvider1.SetError(authorTextBox, "Empty field");
        }

        private void titleTextBox_Validating(object sender, CancelEventArgs e)
        {
            if (titleTextBox.Text.Length > 0)
                return;
            e.Cancel = true;
            errorProvider1.SetError(titleTextBox, "Empty field");
        }

        private void authorTextBox_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(titleTextBox, "");
        }

        private void SongForm_Load(object sender, EventArgs e)
        {
            if (_song != null)
            {
                titleTextBox.Text = _song.Title;
                authorTextBox.Text = _song.Author;
                genreTextBox.Text = _song.Genre;
                dateTextBox.Text = _song.Year.ToString();
            }
        }
    }
}
