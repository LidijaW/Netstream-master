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
    public partial class TrailerForm : Form
    {
        private string youtubeLink;

        public TrailerForm(string youtubeLink)
        {
            InitializeComponent();
            this.youtubeLink = youtubeLink;
        }

        private void TrailerForm_Load(object sender, EventArgs e)
        {
            string html = "<html><head>";
            html += "<meta content='IE=Edge' http-equiv='X-UA-Compatible'/>";
            html += "</head><body>";
            html += "<iframe id='video' src='" + youtubeLink + "' width='600' height='300' frameborder='0' allowfullscreen></iframe>";
            html += "</body></html>";
            webBrowser1.DocumentText = html;
        }
    }
}
