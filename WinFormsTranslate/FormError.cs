﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsTranslate
{
    public partial class FormError : Form
    {
        public FormError(string message)
        {
            InitializeComponent();

            label1.Text = message;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
