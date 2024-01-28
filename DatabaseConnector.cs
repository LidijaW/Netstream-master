using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Netstream
{
    public class DatabaseConnector
    {
        private string GetConnectionString()
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
                    Console.WriteLine("Uspješno ste se spojili na bazu podataka!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Došlo je do greške prilikom pokušaja spajanja na bazu podataka: {ex.Message}");
                }
            }
        }
    }

}
