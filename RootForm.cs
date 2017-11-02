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
    public partial class RootForm : Form
    {
        public RootForm()
        {
            InitializeComponent();
        }

        private void RootForm_Load(object sender, EventArgs e)
        {
            bindingSource1.DataSource = typeof(SongModel);
            bindingSource1.Add(new SongModel("Paradise", "Coldplay", "soft-rock", 2011));
            bindingSource1.Add(new SongModel("Nothing Else Matters", "Metallica", "rock-metal", 1991));
            bindingSource1.Add(new SongModel("Sweet Child O'Mine", "Guns N'Roses", "rock", 1987));
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void windowToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChildForm newMDIChild = new ChildForm(bindingSource1);
            // Set the Parent Form of the Child window.  
            newMDIChild.MdiParent = this;
            // Display the new form.  
            newMDIChild.Show();  
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void bindingSource1_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteContext == BindingCompleteContext.DataSourceUpdate
                && e.Exception == null)
                e.Binding.BindingManagerBase.EndCurrentEdit();
        }

    }
}
