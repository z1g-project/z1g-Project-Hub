using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terbium
{
    public partial class settings : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public settings()
        {
            InitializeComponent();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:/z1g apps/Terbium/Data/verconf.DAT"))
            {
                File.Delete("C:/z1g apps/Terbium/Data/verconf.DAT");
                using (StreamWriter g = new StreamWriter("C:/z1g apps/Terbium/Data/verconf.DAT"))
                {
                    g.WriteLine("Version = CloudFlare");
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist. Skipping...");
            }

        }

        private void Label3_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:/z1g apps/Terbium/Data/verconf.DAT"))
            {
                File.Delete("C:/z1g apps/Terbium/Data/verconf.DAT");
                using (StreamWriter g = new StreamWriter("C:/z1g apps/Terbium/Data/verconf.DAT"))
                {
                    g.WriteLine("Version = CloudFlare");
                }
            }
            else
            {
                Console.WriteLine("File doesn't exist. Skipping...");
            }

        }

        private void Label5_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:/z1g apps/Terbium/Data/verconf.DAT"))
            {
                File.Delete("C:/z1g apps/Terbium/Data/verconf.DAT");
            }
            else
            {
                Console.WriteLine("File doesn't exist. Skipping...");
            }

        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            if (File.Exists("C:/z1g apps/Terbium/Data/verconf.DAT"))
            {
                File.Delete("C:/z1g apps/Terbium/Data/verconf.DAT");
            }
            else
            {
                Console.WriteLine("File doesn't exist. Skipping...");
            }

        }
    }
}
