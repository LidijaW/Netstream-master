using System;
using System.Data.Entity;
using MySql.Data.MySqlClient;

namespace Netstream.Properties.DB
{
    public class NetstreamContext : DbContext
    {
        public DbSet<Korisnik> Korisnici { get; set; }

        public NetstreamContext() : base("name=NetstreamContext")
        {
            try
            {
                Database.Initialize(false);
            }
            catch (InvalidOperationException ex)
            {
                
                Console.WriteLine("An error occurred while initializing the database context: " + ex.Message);
                throw; 
            }
        }
    }
}
