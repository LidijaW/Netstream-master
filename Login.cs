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
        private string connectionString;
        public Korisnik user;

        public Login()
        {
            InitializeComponent();
            connectionString = $"Server={DatabaseConstants.Server};Database={DatabaseConstants.Database};Uid={DatabaseConstants.Uid};Pwd={DatabaseConstants.Pwd};";
            databaseConnector = new DatabaseConnector(DatabaseConstants.Server, DatabaseConstants.Database, DatabaseConstants.Uid, DatabaseConstants.Pwd);
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
                MessageBox.Show("Neuspjelo spajanje na databazu.");
                return;
            }

            string email = textBoxEmail.Text;
            string password = textBoxPassword.Text;

            bool isAuthenticated = databaseConnector.AuthenticateUser(email, password);

            if (isAuthenticated)
            {
                user = databaseConnector.GetUserByEmail(email);
                if (user != null)
                {
                    MessageBox.Show($"Uspješno ste se prijavili! Dobrošli, {user.Email}.");
                    Homepage homepageForm = new Homepage();
                    KorisnikForm korisnikForma = new KorisnikForm();
                    korisnikForma.SetData(user.Ime, user.Prezime);
                    //korisnikForma.Show();
                    homepageForm.Show();
                    this.Hide();
                    return;
                }
                else
                {
                    MessageBox.Show("Došlo je do pogreške prilikom dohvaćanja korisničkih informacija.");
                }
            }
            else
            {
                MessageBox.Show("Netočan email ili lozinka.");
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
                Console.WriteLine($"Greška u testiranju povezivanja na bazu podataka: {ex.Message}");
                return false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }



    }
}
