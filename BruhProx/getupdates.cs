using Markdig;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Terbium
{
    public partial class getupdates : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        public getupdates()
        {
            InitializeComponent();
        }

        public static string HtmlToRtf(string html)
        {
            RichTextBox rtBox = new RichTextBox();
            rtBox.Text = html;
            return rtBox.Rtf;
        }

        private void Button3_Click(object sender, EventArgs e)
        {

        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void getupdates_Load(object sender, EventArgs e)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://cdn.z1g-project.repl.co/z1g-hub/client/bruhprox-changelog.md");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string markdownText = reader.ReadToEnd();

            // Convert markdown to HTML
            string htmlText = Markdown.ToHtml(markdownText);

            // Set the HTML text to the textbox
            textBox1.Text = htmlText;
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void Button3_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button2_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            Process process = Process.Start("C:\\z1g-apps\\Terbium\\Terbium-bootstrap.exe");
        }

        private void Button4_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
