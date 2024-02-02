using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Netstream
{
    public partial class Korisnik : Form
    {
        public Korisnik()
        {
            InitializeComponent();
        }

        public string Email { get; internal set; }
        public string Lozinka { get; internal set; }
        public int Id { get; internal set; }

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
            
            Korisnik korisnikForma = new Korisnik();

            korisnikForma.Show();

           
            this.Hide();
        }

    }
}
