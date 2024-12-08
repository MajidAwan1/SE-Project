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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            BackColor = Color.MediumSeaGreen;
            label1.BackColor=Color.Transparent;
            label2.BackColor=Color.Transparent;
            label3.BackColor=Color.Transparent;
            label4.BackColor=Color.Transparent;

            
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textemail.Text;
            string password = textpassword.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
            {
                labelMessage.Text = "Email and Password are required.";
                labelMessage.Visible = true;
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                labelMessage.Text = "Invalid email format.";
                labelMessage.Visible = true;
                return;
            }

            string connectionString = "Server=DESKTOP-V4EF7RM\\SQLEXPRESS;Database=seproject;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // Query to check if the email exists and password matches
                    string query = "SELECT Password FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        // Execute the query and retrieve the stored hashed password
                        var storedPassword = cmd.ExecuteScalar() as string;

                        // If no user found with the given email
                        if (storedPassword == null)
                        {
                            labelMessage.Text = "Invalid email or password.";
                            labelMessage.Visible = true;
                            return;
                        }

                        // Hash the entered password and compare it with the stored one
                  

                        if (storedPassword == password)
                        {
                            MessageBox.Show("Login successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            MainMenu MainMenu = new MainMenu(email);
                            MainMenu.Show();
                            this.Hide();
                             // Close the login form
                            // You can open the main form or dashboard here after successful login
                        }
                        else
                        {
                            labelMessage.Text = "Invalid email or password.";
                            labelMessage.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    labelMessage.Text = "Database error: " + ex.Message;
                    labelMessage.Visible = true;
                }
            }
        }

        

        private void labelMessage_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textemail.Clear();
            textpassword.Clear();
            labelMessage.Visible = false; // Hide the message label
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Signup SignUp = new Signup();
            SignUp.Show();
            this.Hide();
        }

        private void textpassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void textemail_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
