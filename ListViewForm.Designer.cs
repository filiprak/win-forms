namespace win_forms
{
    partial class ListViewForm
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
            this.songListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newSongToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modifyToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.allFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.greater2000Year = new System.Windows.Forms.ToolStripMenuItem();
            this.smaller2000Year = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // songListView
            // 
            this.songListView.AutoArrange = false;
            this.songListView.BackColor = System.Drawing.SystemColors.Window;
            this.songListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.songListView.ContextMenuStrip = this.contextMenuStrip1;
            this.songListView.Cursor = System.Windows.Forms.Cursors.Hand;
            this.songListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.songListView.FullRowSelect = true;
            this.songListView.GridLines = true;
            this.songListView.Location = new System.Drawing.Point(0, 24);
            this.songListView.Name = "songListView";
            this.songListView.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.songListView.Size = new System.Drawing.Size(549, 282);
            this.songListView.TabIndex = 0;
            this.songListView.UseCompatibleStateImageBehavior = false;
            this.songListView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Title";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Genre";
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Year";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(549, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSongToolStripMenuItem,
            this.modifyToolStripMenuItem,
            this.removeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // newSongToolStripMenuItem
            // 
            this.newSongToolStripMenuItem.Name = "newSongToolStripMenuItem";
            this.newSongToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newSongToolStripMenuItem.Text = "New Song";
            this.newSongToolStripMenuItem.Click += new System.EventHandler(this.newSongToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.removeToolStripMenuItem.Text = "Remove";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // modifyToolStripMenuItem
            // 
            this.modifyToolStripMenuItem.Name = "modifyToolStripMenuItem";
            this.modifyToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.modifyToolStripMenuItem.Text = "Modify";
            this.modifyToolStripMenuItem.Click += new System.EventHandler(this.modifyToolStripMenuItem_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.modifyToolStripMenuItem1,
            this.removeToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(118, 70);
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.newToolStripMenuItem.Text = "New";
            // 
            // modifyToolStripMenuItem1
            // 
            this.modifyToolStripMenuItem1.Name = "modifyToolStripMenuItem1";
            this.modifyToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.modifyToolStripMenuItem1.Text = "Modify";
            // 
            // removeToolStripMenuItem1
            // 
            this.removeToolStripMenuItem1.Name = "removeToolStripMenuItem1";
            this.removeToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.removeToolStripMenuItem1.Text = "Remove";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allFilter,
            this.greater2000Year,
            this.smaller2000Year});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(45, 20);
            this.toolStripMenuItem1.Text = "Filter";
            // 
            // allFilter
            // 
            this.allFilter.Checked = true;
            this.allFilter.CheckOnClick = true;
            this.allFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.allFilter.Name = "allFilter";
            this.allFilter.Size = new System.Drawing.Size(152, 22);
            this.allFilter.Text = "All";
            this.allFilter.Click += new System.EventHandler(this.allFilter_Click);
            // 
            // greater2000Year
            // 
            this.greater2000Year.CheckOnClick = true;
            this.greater2000Year.Name = "greater2000Year";
            this.greater2000Year.Size = new System.Drawing.Size(152, 22);
            this.greater2000Year.Text = "Year > 2000";
            this.greater2000Year.Click += new System.EventHandler(this.greater2000Year_Click);
            // 
            // smaller2000Year
            // 
            this.smaller2000Year.CheckOnClick = true;
            this.smaller2000Year.Name = "smaller2000Year";
            this.smaller2000Year.Size = new System.Drawing.Size(152, 22);
            this.smaller2000Year.Text = "Year <= 2000";
            this.smaller2000Year.Click += new System.EventHandler(this.smaller2000Year_Click);
            // 
            // ListViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(549, 306);
            this.Controls.Add(this.songListView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "ListViewForm";
            this.Text = "ListViewForm";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView songListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newSongToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modifyToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem allFilter;
        private System.Windows.Forms.ToolStripMenuItem greater2000Year;
        private System.Windows.Forms.ToolStripMenuItem smaller2000Year;

    }
}