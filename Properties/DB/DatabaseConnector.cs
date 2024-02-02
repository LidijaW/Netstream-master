using System;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using Netstream.Properties.Model;

namespace Netstream.Properties.DB
{
    public class DatabaseConnector
    {
        private readonly string connectionString;

        public DatabaseConnector(string server, string database, string uid, string pwd)
        {
            connectionString = $"Server={server};Database={database};Uid={uid};Pwd={pwd};";
        }

        public void TestConnection()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    Console.WriteLine("Successfully connected to the database!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while connecting to the database: {ex.Message}");
                    throw; // Rethrow the exception to be handled in the Login form
                }
            }
        }

        public bool AuthenticateUser(string email, string password)
        {
            bool isAuthenticated = false;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT COUNT(*) FROM korisnik WHERE Email = @Email AND Lozinka = @Password";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                command.Parameters.AddWithValue("@Password", password);

                try
                {
                    connection.Open();
                    int count = Convert.ToInt32(command.ExecuteScalar());
                    isAuthenticated = count > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while authenticating user: {ex.Message}");
                }
            }

            return isAuthenticated;
        }

        public Korisnik GetUserByEmail(string email)
        {
            Korisnik user = null;

            using (var connection = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM korisnik WHERE Email = @Email";
                MySqlCommand command = new MySqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);

                try
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            user = new Korisnik
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Email = reader["Email"].ToString(),
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while retrieving user information: {ex.Message}");
                }
            }

            return user;
        }
    }
}
