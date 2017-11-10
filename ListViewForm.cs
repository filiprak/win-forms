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
    public enum FilterType
    {
        All, Greater2000, SmOrEq2000
    }

    public partial class ListViewForm : Form, ViewInterface
    {
        // reference to data in root document list of all songs
        private List<SongModel> data_ref;
        public String window_title = "List View";

        public ListViewForm(Form mdiParent)
        {
            InitializeComponent();
            this.MdiParent = mdiParent;
            this.ClearFilterChecks();
            this.allFilter.Checked = true;
            this.Text = this.window_title + " - " + this.allFilter.Text;
        }

        public void Open(List<SongModel> initData)
        {
            this.data_ref = initData;
            foreach (SongModel data in initData)
            {
                ListViewItem record = new ListViewItem();
                SmartItemUpdate(record, data, new change(true));
                this.songListView.Items.Add(record);
            }
            songListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
            songListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
            this.UpdateStatusStrip();
            this.Show();
        }

        public bool AddData(SongModel song)
        {
            if (!CheckFilterCondition(song, GetCurrentFilterType()))
                return false;
            if (CheckSongPresence(song) != null)
                return false;
            ListViewItem newrecord = new ListViewItem();
            SmartItemUpdate(newrecord, song, new change(true));
            this.songListView.Items.Add(newrecord);
            this.UpdateStatusStrip();
            return true;
        }
        public bool RemoveData(SongModel song)
        {
            foreach (ListViewItem record in this.songListView.Items)
            {
                if (record.Tag == song)
                {
                    this.songListView.Items.Remove(record);
                    this.UpdateStatusStrip();
                    return true;
                }
            }
            return false;
        }
        public bool ModifyData(SongModel dest, SongModel src, change mask)
        {
            ListViewItem record = CheckSongPresence(dest);
            bool song_on_list = (record != null);
            if (song_on_list && !CheckFilterCondition(src, GetCurrentFilterType()))
            {
                this.RemoveData(dest);
                return false;
            }
            else if (!song_on_list && CheckFilterCondition(src, GetCurrentFilterType()))
            {
                this.AddData(dest);
                return true;
            }
            if (song_on_list)
                SmartItemUpdate(record, src, mask);
            return true;
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
            
        }

        public FilterType GetCurrentFilterType()
        {
            if (this.allFilter.Checked)
                return FilterType.All;
            if (this.greater2000Year.Checked)
                return FilterType.Greater2000;
            if (this.smaller2000Year.Checked)
                return FilterType.SmOrEq2000;
            return FilterType.All;
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

        public void FilterSongs(FilterType ftype)
        {
            foreach (SongModel song in this.data_ref)
            {
                bool song_on_list = (CheckSongPresence(song) != null);
                if (!song_on_list && CheckFilterCondition(song, ftype))
                    this.AddData(song);
                else if (song_on_list && !CheckFilterCondition(song, ftype))
                    this.RemoveData(song);
            }
            this.UpdateStatusStrip();
        }

        private ListViewItem CheckSongPresence(SongModel song)
        {
            foreach (ListViewItem item in this.songListView.Items)
            {
                if (item.Tag == song)
                    return item;
            }
            return null;
        }

        private bool CheckFilterCondition(SongModel song, FilterType ftype)
        {
            if (ftype == FilterType.All)
                return true;
            if (ftype == FilterType.Greater2000)
                return song.Year > 2000;
            if (ftype == FilterType.SmOrEq2000)
                return song.Year <= 2000;
            return true;
        }

        public void UpdateStatusStrip()
        {
            this.numElemsStripStatusLabel1.Text = String.Format("{0}: {1}", "Number of songs", this.songListView.Items.Count);
        }

        private void ClearFilterChecks()
        {
            this.greater2000Year.Checked = this.smaller2000Year.Checked = this.allFilter.Checked = false;

        }

        private void toolStripComboBox1_Click(object sender, EventArgs e)
        {

        }

        private void greater2000Year_Click(object sender, EventArgs e)
        {
            this.ClearFilterChecks();
            this.greater2000Year.Checked = true;
            this.Text = this.window_title + " - " + this.greater2000Year.Text;
            this.FilterSongs(FilterType.Greater2000);
        }

        private void allFilter_Click(object sender, EventArgs e)
        {
            this.ClearFilterChecks();
            this.allFilter.Checked = true;
            this.Text = this.window_title + " - " + this.allFilter.Text;
            this.FilterSongs(FilterType.All);
        }

        private void smaller2000Year_Click(object sender, EventArgs e)
        {
            this.ClearFilterChecks();
            this.smaller2000Year.Checked = true;
            this.Text = this.window_title + " - " + this.smaller2000Year.Text;
            this.FilterSongs(FilterType.SmOrEq2000);
        }

        private void ListViewForm_Activated(object sender, EventArgs e)
        {
            (this.MdiParent as RootForm).MergeToolstrips(this.menuStrip1, this.statusStrip1);
        }

        private void ListViewForm_Deactivate(object sender, EventArgs e)
        {
            (this.MdiParent as RootForm).RevertMergeToolstrips();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.newSongToolStripMenuItem_Click(sender, e);
        }

        private void modifyToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.modifyToolStripMenuItem_Click(sender, e);
        }

        private void removeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.removeToolStripMenuItem_Click(sender, e);
        }

        private void duplicateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (songListView.SelectedItems.Count > 0)
            {
                SongModel song = (SongModel)songListView.SelectedItems[0].Tag;
                RootForm rf = this.MdiParent as RootForm;
                rf.AddNewSong(new SongModel(song.Title, song.Author, song.Genre, song.Year));
            }
        }
    }
}
