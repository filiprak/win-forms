﻿using System;
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
        private readonly List<SongModel> data = new List<SongModel>();

        public RootForm()
        {
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e)
        {
            data.Add(new SongModel("Paradise", "Coldplay", "rock", 2011));
            data.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));
            data.Add(new SongModel("Thunder", "Imagine Dragons", "pop", 2017));
            data.Add(new SongModel("Smooth Criminal", "Michael Jackson", "pop", 1987));
            data.Add(new SongModel("Blue Bossa", "Kenny Dorham", "jazz", 1963));
            data.Add(new SongModel("Watermelon Man", "Herbie Hancock", "jazz", 1962));
            data.Add(new SongModel("Paradise", "Coldplay", "rock", 2011));
            data.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));
            data.Add(new SongModel("Thunder", "Imagine Dragons", "pop", 2017));
            data.Add(new SongModel("Smooth Criminal", "Michael Jackson", "pop", 1987));
            data.Add(new SongModel("Blue Bossa", "Kenny Dorham", "jazz", 1963));
            data.Add(new SongModel("Watermelon Man", "Herbie Hancock", "jazz", 1962));

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

        public void MergeToolstrips(ToolStrip menu, ToolStrip status)
        {
            this.statusStrip1.Visible = true;
            ToolStripManager.Merge(menu, this.menuStrip1.Name);
            ToolStripManager.Merge(status, this.statusStrip1.Name);
        }

        public void RevertMergeToolstrips()
        {
            ToolStripManager.RevertMerge(this.menuStrip1.Name);
            ToolStripManager.RevertMerge(this.statusStrip1.Name);
            this.statusStrip1.Visible = false;
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
