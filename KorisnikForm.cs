using Netstream.Properties.DB;
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

namespace Netstream
{
    public partial class KorisnikForm : Form
    {
        private readonly DatabaseConnector databaseConnector;
        private string connectionString;
        private string name;
        private string surname;

        public KorisnikForm()
        {
            InitializeComponent();
            connectionString = $"Server={DatabaseConstants.Server};Database={DatabaseConstants.Database};Uid={DatabaseConstants.Uid};Pwd={DatabaseConstants.Pwd};";
            databaseConnector = new DatabaseConnector(DatabaseConstants.Server, DatabaseConstants.Database, DatabaseConstants.Uid, DatabaseConstants.Pwd);
        }

        public void SetData(string name, string surname)
        {
            this.name = name;
            this.surname = surname;
            LoadData();
        }

        private void LoadData()
        {
            textBox1.Text = name;
            textBox2.Text = surname;
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button1home_Click(object sender, EventArgs e)
        {
            Homepage homepageForm = new Homepage();

            homepageForm.Show();

            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Search searchForm = new Search();

            searchForm.Show();

           
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odjavili ste se", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            KorisnikForm korisnikForma = new KorisnikForm();

            korisnikForma.Show();

           
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
        }
    }
}
