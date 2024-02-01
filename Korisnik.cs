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
    }
}
