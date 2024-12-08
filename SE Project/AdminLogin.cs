using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace SE_Project
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
            label1.BackColor=Color.Transparent;
            label2.BackColor=Color.Transparent;
            label3.BackColor=Color.Transparent;
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textusername.Text;
            string password = textpassword.Text;

            string adminusername = "musabandmajid";
            string adminpassword = "03410344";

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                labelMessage.Text = "Both fields are required.";
                labelMessage.Visible = true;
                return;
            }

            if (username == adminusername && password == adminpassword)
            {
                MessageBox.Show("Admin login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Close the login form
                // Open the admin dashboard or the main admin form
            }

            else
            {
                labelMessage.Text = "Invalid email or password.";
                labelMessage.Visible = true;
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            textusername.Clear();
            textpassword.Clear();
            labelMessage.Visible = false;
        }
    }
}
