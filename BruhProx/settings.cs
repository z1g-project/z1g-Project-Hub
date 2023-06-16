using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO.Compression;
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

        private void button5_Click(object sender, EventArgs e)
        {
            int formWidth = int.Parse(textBox1.Text);
            int formHeight = int.Parse(textBox2.Text);

            Properties.Settings.Default.FormWidth = formWidth;
            Properties.Settings.Default.FormHeight = formHeight;
            Properties.Settings.Default.Save();
        }

        private void settings_Load(object sender, EventArgs e)
        {
            textBox1.Text = Properties.Settings.Default.FormWidth.ToString();
            textBox2.Text = Properties.Settings.Default.FormHeight.ToString();
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Directory.Delete("C:\\z1g Apps\\Terbium\\Data\\");
            MessageBox.Show("Your cache located in: C:\\z1g Apps\\Terbium\\Data\\ has been cleared. Terbium will now restart to apply the changes.");
            Process.Start(":\\z1g Apps\\Terbium\\Terbium.exe");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to choose the destination for the zip file
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ZIP files (*.zip)|*.zip";
            saveFileDialog.FileName = "TerbiumData.zip";
            saveFileDialog.InitialDirectory = "C:\\";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string sourceFolder = @"C:\z1g Apps\Terbium\Data";
                string destinationZipFile = saveFileDialog.FileName;

                // Create a new zip file
                ZipFile.CreateFromDirectory(sourceFolder, destinationZipFile);
                MessageBox.Show("Successfully Exported Cache to: " + destinationZipFile);
            }
        }


    }
}
