using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Netstream.Properties.DB;
using MySql.Data.MySqlClient;

namespace Netstream
{
    public partial class Login : Form
    {
        private DatabaseConnector databaseConnector;
        public Login()
        {
            InitializeComponent();
            databaseConnector = new DatabaseConnector();
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {

        }

        private void login(object sender, EventArgs e)
        {
            if (!IsDatabaseConnected())
            {
                MessageBox.Show("Failed to connect to the database. Please check your database settings.");
                return;
            }

            if (string.IsNullOrEmpty(textBoxEmail.Text) || string.IsNullOrEmpty(textBoxPassword.Text))
            {
                MessageBox.Show("Please fill in both email and password.");
                return;
            }

            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            bool isAuthenticated = AuthenticateUser(email, password);

            if (isAuthenticated)
            {
                MessageBox.Show("Login successful!");
            }
            else
            {
                MessageBox.Show("Incorrect email or password.");
            }
        }

        private bool IsDatabaseConnected()
        {
            try
            {
                databaseConnector.TestConnection();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private bool AuthenticateUser(string email, string password)
        {
            bool isAuthenticated = false;
            string connectionString = databaseConnector.GetConnectionString();

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM korisnik WHERE Email = @Email AND Password = @Password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int count = (int)command.ExecuteScalar();

                    isAuthenticated = count > 0;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while querying the database: {ex.Message}");
                }
            }

            return isAuthenticated;
        }


        private void registracija(object sender, EventArgs e)
        {
            Registracija registracijaForm = new Registracija();
            registracijaForm.ShowDialog();
        }
    }
}
