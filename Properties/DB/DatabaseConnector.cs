using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Netstream.Properties.DB
{
    public class DatabaseConnector
    {
        public string GetConnectionString()
        {
            string connString = "Server=localhost;Database=netstream;Uid=luka;Pwd=luka;";
            return connString;
        }

        public void TestConnection()
        {
            string connectionString = GetConnectionString();

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
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                    {
                        connection.Close();
                        Console.WriteLine("Connection closed.");
                    }
                }
            }
        }

    }

}
