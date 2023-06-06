using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terbium
{
    public partial class firstrun : Form
    {
        public firstrun()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //File.Create("C:/z1g apps/Terbium/Data/verconf.DAT"); (Deprecated)
            File.Create("C:/z1g apps/Terbium/Data/setupdone.DAT");
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            
        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            File.Create("C:/z1g apps/Terbium/Data/verconf.DAT");
            
        }

        private void Label3_Click(object sender, EventArgs e)
        {
            File.Create("C:/z1g apps/Terbium/Data/verconf.DAT");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must complete the setup to use Terbium!", "Error");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You must complete the setup to use Terbium!", "Error");
        }
    }
}
