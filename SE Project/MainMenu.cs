﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Project
{
    public partial class MainMenu : Form
    {
        private string LoggedInEmail;
        public MainMenu(string email)
        {
            LoggedInEmail = email;
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            Visit Visit = new Visit(LoggedInEmail);
            Visit.Show();
            this.Hide();   
        }
    }
}
