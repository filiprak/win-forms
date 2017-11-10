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
    public partial class ListViewForm : Form, ViewInterface
    {
        public ListViewForm(Form mdiParent)
        {
            InitializeComponent();
            this.MdiParent = mdiParent;
        }

        public void Open(List<SongModel> initData)
        {
            foreach (SongModel data in initData)
            {
                ListViewItem record = new ListViewItem();
                SmartItemUpdate(record, data, new change(true));
                this.songListView.Items.Add(record);
            }
            this.Show();
        }

        public bool AddData(SongModel song)
        {
            foreach (ListViewItem record in this.songListView.Items)
            {
                if (record.Tag == song)
                    return false;
            }
            ListViewItem newrecord = new ListViewItem();
            SmartItemUpdate(newrecord, song, new change(true));
            this.songListView.Items.Add(newrecord);
            return true;
        }
        public bool RemoveData(SongModel song)
        {
            foreach (ListViewItem record in this.songListView.Items)
            {
                if (record.Tag == song)
                {
                    this.songListView.Items.Remove(record);
                    return true;
                }
            }
            return false;
        }
        public bool ModifyData(SongModel dest, SongModel src, change mask)
        {
            foreach (ListViewItem record in this.songListView.Items)
            {
                if (record.Tag == dest)
                {
                    SmartItemUpdate(record, src, mask);
                    return true;
                }
            }
            return false;
        }

        private void SmartItemUpdate(ListViewItem record, SongModel song, change mask) {
            if (record.Tag == null)
                record.Tag = song;
            while (record.SubItems.Count < 4)
                record.SubItems.Add(new ListViewItem.ListViewSubItem());
            if (mask.title)
                record.SubItems[0].Text = song.Title;
            if (mask.author)
                record.SubItems[1].Text = song.Author;
            if (mask.genre)
                record.SubItems[2].Text = song.Genre;
            if (mask.year)
                record.SubItems[3].Text = song.Year.ToString();
        }

        public void Exit()
        {
            if (this.MdiParent.MdiChildren.Length < 2)
                MessageBox.Show("");
        }

        private void newSongToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RootForm rf = this.MdiParent as RootForm;
            SongForm addForm = new SongForm(null);

            if (addForm.ShowDialog() == DialogResult.OK)
            {
                rf.AddNewSong(new SongModel(addForm.Title, addForm.Author, addForm.Genre, addForm.Year));
            }
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songListView.SelectedItems.Count > 0)
            {
                SongModel song = (SongModel)songListView.SelectedItems[0].Tag;
                RootForm rf = this.MdiParent as RootForm;
                rf.RemoveSong(song);
            }
        }

        private void modifyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songListView.SelectedItems.Count > 0)
            {
                SongModel song = (SongModel)songListView.SelectedItems[0].Tag;
                SongForm editform = new SongForm(song);
                if (editform.ShowDialog() == DialogResult.OK)
                {
                    SongModel editedSong = editform.Song;
                    change mask = SongModel.Diff(song, editedSong);
                    RootForm rf = this.MdiParent as RootForm;
                    rf.ModifySong(song, editedSong, mask);
                }
            }
        }
    }
}
