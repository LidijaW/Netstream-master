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
using Netstream.Properties.Model;
using MySql.Data.MySqlClient;
using System.Data.Common;

namespace Netstream
{
    public partial class Login : Form
    {
        private readonly DatabaseConnector databaseConnector;

        public Login()
        {
            InitializeComponent();
            string connectionString = "Server=localhost;Database=netstream;Uid=luka;Pwd=luka;";
            databaseConnector = new DatabaseConnector(connectionString);
        }

        private void textBoxPassword_Click(object sender, EventArgs e)
        {

        }

        private void textBoxEmail_Click(object sender, EventArgs e)
        {

        }

        private void login(object sender, EventArgs e)
        {
            if (!TestDatabaseConnection())
            {
                MessageBox.Show("Database connection failed. Unable to login.");
                return;
            }

            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            bool isAuthenticated = databaseConnector.AuthenticateUser(email, password);

            if (isAuthenticated)
            {
                Korisnik user = databaseConnector.GetUserByEmail(email);
                if (user != null)
                {
                    // Proceed with user login
                    MessageBox.Show($"Login successful! Welcome, {user.Email}!");
                }
                else
                {
                    MessageBox.Show("An error occurred while retrieving user information.");
                }
            }
            else
            {
                MessageBox.Show("Incorrect email or password.");
            }
        }

        private void registracija(object sender, EventArgs e)
        {
            Registracija registracijaForm = new Registracija();
            registracijaForm.ShowDialog();
        }

        private bool TestDatabaseConnection()
        {
            try
            {
                databaseConnector.TestConnection();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error testing database connection: {ex.Message}");
                return false;
            }
        }
    }
}
