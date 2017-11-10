using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//@todo
/*
 * - Na zdarzenie Activate przeniesc przycisk lub pasek statusu z okna view do glownego
 * - Mergowanie pasków narzedzi: Merge i RevertMerge
 * - Ustawic flage Visible na false w oknie widoku
 * - Tag jest typu object, podstawic referencje
 * - Inteligentne odswiezanie - uaktualniac tylko to co sie zmienilo
 * - Filtry w widokach
 * - Cykliczna kontrolka
 */

namespace win_forms
{
    public partial class RootForm : Form
    {
        // document data
        private List<SongModel> data = new List<SongModel>();

        public RootForm()
        {
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e)
        {
            data.Add(new SongModel("Paradise", "Coldplay", "soft-rock", 2011));
            data.Add(new SongModel("Nothing Else Matters", "Metallica", "rock-metal", 1991));
            data.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));
            data.Add(new SongModel("Paradise", "Coldplay", "soft-rock", 2011));
            data.Add(new SongModel("Nothing Else Matters", "Metallica", "rock-metal", 1991));
            data.Add(new SongModel("Paradise", "Coldplay", "soft-rock", 2011));
            data.Add(new SongModel("Nothing Else Matters", "Metallica", "rock-metal", 1991));
            data.Add(new SongModel("Paradise", "Coldplay", "soft-rock", 2011));
            data.Add(new SongModel("Nothing Else Matters", "Metallica", "rock-metal", 1991));
            data.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));
            data.Add(new SongModel("Paradise", "Coldplay", "soft-rock", 2011));
            data.Add(new SongModel("Nothing Else Matters", "Metallica", "rock-metal", 1991));
            data.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));
            data.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));
            data.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));

            OpenNewView();
        }

        private void OpenNewView() {
            ViewInterface newMDIChild = new ListViewForm(this);
            // Display the new form.
            (newMDIChild as Form).FormClosing += child_FormClosing;
            newMDIChild.Open(this.data);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (ViewInterface view in this.MdiChildren)
                view.Exit();
            Application.Exit();
        }

        public bool AddNewSong(SongModel song) {
            if (this.data.Contains(song))
                return false;
            this.data.Add(song);
            foreach (ViewInterface view in this.MdiChildren)
                view.AddData(song);
            return true;
        }

        public bool ModifySong(SongModel dest, SongModel src, change mask)
        {
            if (!this.data.Contains(dest))
                return false;
            SongModel.SmartUpdate(dest, src, mask);
            foreach (ViewInterface view in this.MdiChildren)
                view.ModifyData(dest, src, mask);
            return true;
        }

        public bool RemoveSong(SongModel song)
        {
            if (this.data.Remove(song))
            {
                foreach (ViewInterface view in this.MdiChildren)
                    view.RemoveData(song);
            }
            return false;
        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenNewView();
        }

        private void closeViewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            activeChild.Close();
        }

        void child_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.MdiChildren.Length < 2 && e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                MessageBox.Show("At least one view window must be displayed!");
            }
        }
    }
}
