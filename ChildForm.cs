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
    public partial class ChildForm : Form
    {
        private BindingSource formDataSource;

        public ChildForm(BindingSource dataSource)
        {
            formDataSource = dataSource;
            InitializeComponent();
            this.dataGridView1.DataSource = formDataSource;
            this.dataGridView1.AutoGenerateColumns = true;
        }

        private void ChildForm_Load(object sender, EventArgs e)
        {
            // close form callback
            this.FormClosing += this.ChildForm_FormClosing;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void ChildForm_FormClosing(Object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                RootForm frm = this.MdiParent as RootForm;
                if (frm.GetNumChildren() < 2)
                {
                    MessageBox.Show("At least one view have to be opened always.");
                    e.Cancel = true;
                }
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongForm addForm = new SongForm(null);
            if( addForm.ShowDialog() == DialogResult.OK) {
                formDataSource.Add(new SongModel(addForm.Title, addForm.Author, addForm.Genre, addForm.Year));
            }
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            formDataSource.RemoveCurrent();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SongModel sm = formDataSource.Current as SongModel;
            SongForm editForm = new SongForm(sm);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                sm.Title = editForm.Title;
                sm.Author = editForm.Author;
                sm.Genre = editForm.Genre;
                sm.Year = editForm.Year;
            }
            formDataSource.ResetBindings(false);
        }
    }
}
