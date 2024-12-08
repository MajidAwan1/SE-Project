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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace SE_Project
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
            BackColor = Color.MediumSeaGreen;
            label5.Location = new Point(211, 358);
            label1.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;
            label3.BackColor = Color.Transparent;
            label4.BackColor = Color.Transparent;
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = textemail.Text;
            string password = textpassword.Text;
            string confirmpassword = textconfirmpassword.Text;  
            
            // validations


            if(string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(confirmpassword))
            {
                label5.Text = "All fields are required.";
                label5.Visible = true;
                return;
            }

            if (password != confirmpassword)
            {
                label5.Text = "Passwords do not match.";
                label5.Visible = true;
                return;
            }

            if (!email.Contains("@") || !email.Contains("."))
            {
                label5.Text = "Invalid email address.";
                label5.Visible = true;
                return;
            }
            string connectionString = "Server=DESKTOP-V4EF7RM\\SQLEXPRESS;Database=seproject;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    string checkEmailQuery = "SELECT COUNT(*) FROM Users WHERE Email = @Email";
                    using (SqlCommand cmd = new SqlCommand(checkEmailQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);

                        // Execute the query and get the count of matching emails
                        int emailCount = (int)cmd.ExecuteScalar();

                        // If the email already exists, show a message
                        if (emailCount > 0)
                        {
                            label5.Text = "An account already exists with this email address.";
                            label5.Visible = true;
                            return;
                        }
                    }
                    string query = "INSERT INTO Users (Password, Email) VALUES (@Password, @Email)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Email", email);
                        cmd.Parameters.AddWithValue("@Password", password); // Hash passwords in real apps

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            MessageBox.Show("Signup successful!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Login Login=new Login();
                            Login.Show();
                            this.Hide(); // Close the form
                        }
                        else
                        {
                            label5.Text = "Signup failed. Try again.";
                            label5.Visible = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    label5.Text = "Database error: " + ex.Message;
                    label5.Visible = true;
                }
            }
        }
    }
}
    

