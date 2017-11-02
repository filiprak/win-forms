﻿using System;
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

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
