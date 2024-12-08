using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SE_Project
{
    public partial class Visit : Form
    {
        private string LoggedInemail;
        public Visit(string email)
        {
            InitializeComponent();
            LoggedInemail = email;  
            comboBox1.Text = "Select a city";
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Muzaffarabad");
            comboBox1.Items.Add("Hattian Bala");
            comboBox1.Items.Add("Bagh");
            comboBox1.Items.Add("Mirpur");
            comboBox1.Items.Add("Kotli");
            comboBox1.Items.Add("Neelum Valley");
            comboBox1.Items.Add("Bhimber");
            comboBox1.Items.Add("Poonch");
            comboBox1.Items.Add("Haveli");
            comboBox1.Items.Add("Sudhanoti");


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string selectedCity = comboBox1.SelectedItem as string;

            if (string.IsNullOrEmpty(selectedCity))
            {
                labelMessage.Text = "Please select a city!";
                labelMessage.ForeColor = Color.Red;
                labelMessage.Visible = true;
                return;
            }
            string connectionString = "Server=DESKTOP-V4EF7RM\\SQLEXPRESS;Database=seproject;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "UPDATE Users SET City = @City WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@City", selectedCity);
                    cmd.Parameters.AddWithValue("@Email", LoggedInemail); // Use the email passed to this form

                    int rows = cmd.ExecuteNonQuery();
                    if (rows > 0)
                    {
                        labelMessage.Text = $"City '{selectedCity}' has been saved successfully.";
                        labelMessage.ForeColor = Color.Green;
                        labelMessage.Visible = true;
                    }
                    else
                    {
                        labelMessage.Text = "City update failed. Try again.";
                        labelMessage.ForeColor = Color.Red;
                        labelMessage.Visible = true;
                    }
                }
            }
        }
        

        private void Visit_Load(object sender, EventArgs e)
        {

        }
    }
}
