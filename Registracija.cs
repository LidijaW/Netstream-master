﻿using Netstream.Properties.DB;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Netstream
{
    public partial class Registracija : Form
    {
        private DatabaseConnector databaseConnector;
        private string connectionString;
        public Registracija()
        {
            InitializeComponent();
            connectionString = $"Server={DatabaseConstants.Server};Database={DatabaseConstants.Database};Uid={DatabaseConstants.Uid};Pwd={DatabaseConstants.Pwd};";
            databaseConnector = new DatabaseConnector(DatabaseConstants.Server, DatabaseConstants.Database, DatabaseConstants.Uid, DatabaseConstants.Pwd);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxIme.Text) ||
                string.IsNullOrEmpty(textBoxPrezime.Text) ||
                string.IsNullOrEmpty(textBoxEmail.Text) ||
                string.IsNullOrEmpty(textBoxLozinka.Text) ||
                string.IsNullOrEmpty(textBoxUsername.Text))
            {
                MessageBox.Show("Please fill in all fields.");
                return;
            }

            string ime = textBoxIme.Text;
            string prezime = textBoxPrezime.Text;
            string email = textBoxEmail.Text;
            string lozinka = textBoxLozinka.Text;
            string korisnickoIme = textBoxUsername.Text;

            bool success = SaveUserDataToDatabase(ime, prezime, email, lozinka, korisnickoIme);


            if (success)
            {
                MessageBox.Show("Podaci o korisniku spremljeni.");
            }
            else
            {
                MessageBox.Show("Greška u spremanju podataka.");
            }
        }

        private bool SaveUserDataToDatabase(string ime, string prezime, string email, string lozinka, string korisnickoIme)
        {
            try
            {
                using (var connection = new MySqlConnection(connectionString))
                {
                    string maxIdQuery = "SELECT MAX(id) FROM korisnik";
                    MySqlCommand maxIdCommand = new MySqlCommand(maxIdQuery, connection);
                    connection.Open();
                    object maxIdResult = maxIdCommand.ExecuteScalar();
                    int newId = (maxIdResult == DBNull.Value) ? 1 : Convert.ToInt32(maxIdResult) + 1;

                    string query = "INSERT INTO korisnik (id, ime, prezime, email, lozinka, Korisnicko_ime, Aktivan, Razina_ID) " +
                                   "VALUES (@Id, @Ime, @Prezime, @Email, @Lozinka, @KorisnickoIme, @Aktivan, @RazinaID)";
                    MySqlCommand command = new MySqlCommand(query, connection);
                    command.Parameters.AddWithValue("@Id", newId);
                    command.Parameters.AddWithValue("@Ime", ime);
                    command.Parameters.AddWithValue("@Prezime", prezime);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Lozinka", lozinka);
                    command.Parameters.AddWithValue("@KorisnickoIme", korisnickoIme);
                    command.Parameters.AddWithValue("@Aktivan", 1); // Postavljamo Aktivan = 1
                    command.Parameters.AddWithValue("@RazinaID", 2); // Postavljamo Razina_ID = 2

                    int rowsAffected = command.ExecuteNonQuery();

                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška prilikom spremanja u bazu podataka: {ex.Message}");
                return false;
            }
        }




        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
