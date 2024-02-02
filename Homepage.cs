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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Stvaranje instance nove forme
            Search searchForm = new Search();

            // Prikazivanje nove forme
            searchForm.Show();

            // Zatvaranje trenutne forme (opcionalno, ovisno o vašim potrebama)
            this.Hide();
        }

    }
}
