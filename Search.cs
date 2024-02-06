using Netstream.Properties.DB;
using Netstream.Properties.Model;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Netstream
{
    public partial class Search : Form
    {

        private readonly DatabaseConnector databaseConnector;
        private string connectionString;

        public Search()
        {
            InitializeComponent();
            connectionString = $"Server={DatabaseConstants.Server};Database={DatabaseConstants.Database};Uid={DatabaseConstants.Uid};Pwd={DatabaseConstants.Pwd};";
            databaseConnector = new DatabaseConnector(DatabaseConstants.Server, DatabaseConstants.Database, DatabaseConstants.Uid, DatabaseConstants.Pwd);
            PopulateDataGridView();
        }

        private void PopulateDataGridView()
        {
            string query = "SELECT Naziv, Redatelj, Godina, Trajanje, Cijena, Tip FROM video";
            DataTable dataTable = databaseConnector.ExecuteQuery(query);
            dataGridView1.DataSource = dataTable;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
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

        private void button2_Click(object sender, EventArgs e)
        {
            KorisnikForm korisnikForma = new KorisnikForm();
            korisnikForma.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Odjavili ste se", "Poruka", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Application.Exit();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void search(object sender, EventArgs e)
        {
            string searchText = textBox1.Text.Trim();

            if (!string.IsNullOrEmpty(searchText))
            {
                string query = $"SELECT Naziv, Redatelj, Godina, Trajanje, Cijena, Tip FROM video WHERE Naziv LIKE '%{searchText}%' OR Redatelj LIKE '%{searchText}%' OR Godina LIKE '%{searchText}%' OR Trajanje LIKE '%{searchText}%' OR Cijena LIKE '%{searchText}%' OR Tip LIKE '%{searchText}%'";
                DataTable dataTable = databaseConnector.ExecuteQuery(query);
                dataGridView1.DataSource = dataTable;
            }
            else
            {
                PopulateDataGridView();
            }
        }
    }
}
