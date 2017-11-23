using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace win_forms
{
    public partial class GenreControl : UserControl
    {
        private string[] genreValues = {"rock", "pop", "jazz"};
        private int idx = 0;

        [EditorAttribute(typeof(GenreEditor),
            typeof(System.Drawing.Design.UITypeEditor))]
        [Category("Genre Control")]
        [BrowsableAttribute(true)]
        public string Genre
        {
            get { return genreValues[idx]; }
            set
            {
                if (value == null)
                    return;
                if (value.Equals("rock"))
                {
                    this.pictureBox1.Image = Properties.Resources.rock;
                    this.idx = 0;
                }
                else if (value.Equals("pop"))
                {
                    this.pictureBox1.Image = Properties.Resources.pop;
                    this.idx = 1;
                }
                else if (value.Equals("jazz"))
                {
                    this.pictureBox1.Image = Properties.Resources.jazz;
                    this.idx = 2;
                }
                pictureBox1.Refresh();
                pictureBox1.Visible = true;
            }
        }
        public GenreControl()
        {
            InitializeComponent();
        }

        private void GenreControl_Load(object sender, EventArgs e)
        {

        }

        private void GenreControl_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void GenreControl_Resize(object sender, EventArgs e)
        {
            Control control = (Control)sender;

            // Ensure the Form remains square (Height = Width).
            if (control.Size.Height != control.Size.Width)
            {
                control.Size = new Size(control.Size.Height, control.Size.Height);
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.idx = (this.idx + 1) % 3;
            this.Genre = this.genreValues[this.idx];
        }

    }
}
